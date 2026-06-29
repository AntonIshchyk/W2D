import { useMutation, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import type { InfiniteData } from '@tanstack/react-query'

type VoteTarget = {
  id: number
  currentUserVote?: number | null
  score: number
}

type VoteMutationArgs = {
  entityId: number
  value: number
}

type UseEntityVoteMutationOptions = {
  queryKey: unknown[]
  mutationFn: (entityId: number, value: number) => Promise<void>
  invalidateKeys: unknown[][]
}

type EntityPage<T extends VoteTarget> = {
  items: T[]
}

type VoteCache<T extends VoteTarget> = T | T[] | InfiniteData<EntityPage<T>>

function updateVoteState<T extends VoteTarget>(item: T, value: number): T {
  const newVote = item.currentUserVote === value ? 0 : value
  const delta = newVote - (item.currentUserVote ?? 0)
  return { ...item, currentUserVote: newVote, score: item.score + delta }
}

function isInfiniteVoteData<T extends VoteTarget>(data: VoteCache<T>): data is InfiniteData<EntityPage<T>> {
  return typeof data === 'object' && data !== null && 'pages' in data
}

function updateCachedData<T extends VoteTarget>(data: VoteCache<T> | undefined, entityId: number, value: number): VoteCache<T> | undefined {
  if (!data) return data

  if (isInfiniteVoteData(data)) {
    return {
      ...data,
      pages: data.pages.map((page) => ({
        ...page,
        items: page.items.map((item) => (item.id === entityId ? updateVoteState(item, value) : item)),
      })),
    }
  }

  if (Array.isArray(data)) {
    return data.map((item) => (item.id === entityId ? updateVoteState(item, value) : item))
  }

  if (data.id === entityId) {
    return updateVoteState(data, value)
  }

  return data
}

export function useEntityVoteMutation({ queryKey, mutationFn, invalidateKeys }: UseEntityVoteMutationOptions) {
  const queryClient = useQueryClient()

  const voteMutation = useMutation({
    mutationFn: ({ entityId, value }: VoteMutationArgs) => mutationFn(entityId, value),
    onMutate: async ({ entityId, value }) => {
      await queryClient.cancelQueries({ queryKey })
      const previous = queryClient.getQueryData<VoteCache<VoteTarget>>(queryKey)

      queryClient.setQueryData<VoteCache<VoteTarget>>(queryKey, (data) => updateCachedData(data, entityId, value))
      return { previous }
    },
    onError: (_err, _variables, context) => {
      if (context?.previous) {
        queryClient.setQueryData(queryKey, context.previous)
      }
      toast.error('Failed to vote')
    },
    onSettled: async () => {
      queryClient.invalidateQueries({ queryKey })
      await Promise.all(invalidateKeys.map((key) => queryClient.invalidateQueries({ queryKey: key })))
    },
  })

  const handleVote = (entityId: number, currentVote: number | undefined | null, newValue: number) => {
    const value = currentVote === newValue ? 0 : newValue
    voteMutation.mutate({ entityId, value })
  }

  return { voteMutation, handleVote }
}

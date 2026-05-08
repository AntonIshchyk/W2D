import { useMutation, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'

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

function updateVoteState<T extends VoteTarget>(item: T, value: number): T {
  const newVote = item.currentUserVote === value ? 0 : value
  const delta = newVote - (item.currentUserVote ?? 0)
  return { ...item, currentUserVote: newVote, score: item.score + delta }
}

function updateCachedData(data: any, entityId: number, value: number): any {
  if (!data) return data

  if (data.pages) {
    return {
      ...data,
      pages: data.pages.map((page: any) => ({
        ...page,
        items: page.items.map((item: any) => (item.id === entityId ? updateVoteState(item, value) : item)),
      })),
    }
  }

  if (Array.isArray(data)) {
    return data.map((item: any) => (item.id === entityId ? updateVoteState(item, value) : item))
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
      const previous = queryClient.getQueryData(queryKey)

      queryClient.setQueryData(queryKey, (data: any) => updateCachedData(data, entityId, value))
      return { previous }
    },
    onError: (_err, _variables, context: any) => {
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
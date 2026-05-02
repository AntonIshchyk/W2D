import { useMutation, useQueryClient } from '@tanstack/react-query'
import { votePost } from '../api/posts'
import { toast } from 'sonner'

export function usePostVoteMutation(queryKey: unknown[]) {
  const queryClient = useQueryClient()

  const voteMutation = useMutation({
    mutationFn: ({ postId, value }: { postId: number; value: number }) => votePost(postId, value),
    onMutate: async ({ postId, value }) => {
      await queryClient.cancelQueries({ queryKey })
      const previous = queryClient.getQueryData(queryKey)
      queryClient.setQueryData(queryKey, (data: any) => {
        if (!data) return data
        
        if (data.pages) {
          return {
            ...data,
            pages: data.pages.map((page: any) => ({
              ...page,
              items: page.items.map((p: any) => {
                if (p.id !== postId) return p
                const newVote = p.currentUserVote === value ? 0 : value
                const delta = newVote - (p.currentUserVote ?? 0)
                return { ...p, currentUserVote: newVote, score: p.score + delta }
              })
            }))
          }
        }
        
        if (data.id === postId) {
          const newVote = data.currentUserVote === value ? 0 : value
          const delta = newVote - (data.currentUserVote ?? 0)
          return { ...data, currentUserVote: newVote, score: data.score + delta }
        }
        
        return data
      })
      return { previous }
    },
    onError: (_err, _variables, context: any) => {
      if (context?.previous) {
        queryClient.setQueryData(queryKey, context.previous)
      }
      toast.error('Failed to vote')
    },
      onSettled: (_data, _error) => {
        queryClient.invalidateQueries({ queryKey })

        queryClient.invalidateQueries({
          predicate: (query) => {
            const key = Array.isArray(query.queryKey) ? query.queryKey[0] : query.queryKey
            return key === 'posts' || key === 'user-posts' || key === 'post'
          }
        })
    }
  })

  const handlePostVote = (postId: number, currentVote: number | undefined, newValue: number) => {
    const value = currentVote === newValue ? 0 : newValue
    voteMutation.mutate({ postId, value })
  }

  return { voteMutation, handlePostVote }
}

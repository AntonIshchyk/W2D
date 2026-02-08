import { useState } from 'react'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import type { Comment } from '../types/posts'

async function fetchComments(postId: number): Promise<Comment[]> {
  const response = await fetch(API_ENDPOINTS.posts.comments(postId), {
    headers: getAuthHeaders()
  })
  if (!response.ok) throw new Error('Failed to fetch comments')
  return response.json()
}

async function createComment(postId: number, content: string): Promise<Comment> {
  const response = await fetch(API_ENDPOINTS.posts.comments(postId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify({ content })
  })
  if (!response.ok) throw new Error('Failed to create comment')
  return response.json()
}

async function deleteComment(postId: number, commentId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.commentById(postId, commentId), {
    method: 'DELETE',
    headers: getAuthHeaders()
  })
  if (!response.ok) throw new Error('Failed to delete comment')
}

async function voteComment(postId: number, commentId: number, value: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.commentVote(postId, commentId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify({ value })
  })
  if (!response.ok) throw new Error('Failed to vote on comment')
}

function timeAgo(dateString: string): string {
  const seconds = Math.floor((Date.now() - new Date(dateString).getTime()) / 1000)
  if (seconds < 60) return 'just now'
  const minutes = Math.floor(seconds / 60)
  if (minutes < 60) return `${minutes}m ago`
  const hours = Math.floor(minutes / 60)
  if (hours < 24) return `${hours}h ago`
  const days = Math.floor(hours / 24)
  if (days < 30) return `${days}d ago`
  return new Date(dateString).toLocaleDateString()
}

interface CommentsProps {
  postId: number
  currentUserId?: number
}

export function Comments({ postId, currentUserId }: CommentsProps) {
  const [newComment, setNewComment] = useState('')
  const queryClient = useQueryClient()

  const { data: comments = [], isLoading } = useQuery({
    queryKey: ['comments', postId],
    queryFn: () => fetchComments(postId)
  })

  const createMutation = useMutation({
    mutationFn: (content: string) => createComment(postId, content),
    onSuccess: () => {
      setNewComment('')
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
      queryClient.invalidateQueries({ queryKey: ['post', String(postId)] })
      queryClient.invalidateQueries({ queryKey: ['posts'] })
    }
  })

  const deleteMutation = useMutation({
    mutationFn: (commentId: number) => deleteComment(postId, commentId),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
      queryClient.invalidateQueries({ queryKey: ['post', String(postId)] })
      queryClient.invalidateQueries({ queryKey: ['posts'] })
    }
  })

  const voteMutation = useMutation({
    mutationFn: ({ commentId, value }: { commentId: number; value: number }) =>
      voteComment(postId, commentId, value),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
    }
  })

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    const trimmed = newComment.trim()
    if (!trimmed) return
    createMutation.mutate(trimmed)
  }

  const handleVote = (comment: Comment, newValue: number) => {
    if (!currentUserId) return
    const value = comment.currentUserVote === newValue ? 0 : newValue
    voteMutation.mutate({ commentId: comment.id, value })
  }

  return (
    <div className="mt-8 pt-8 border-t">
      <h3 className="text-lg font-semibold text-gray-900 mb-6">
        Comments {comments.length > 0 && <span className="text-gray-400 font-normal">({comments.length})</span>}
      </h3>

      {/* Comment form */}
      {currentUserId ? (
        <form onSubmit={handleSubmit} className="mb-8">
          <textarea
            value={newComment}
            onChange={(e) => setNewComment(e.target.value)}
            placeholder="Write a comment..."
            rows={3}
            maxLength={1000}
            className="w-full px-3 py-2 border border-gray-200 rounded-lg text-sm resize-none focus:outline-none focus:ring-2 focus:ring-gray-200 focus:border-transparent"
          />
          <div className="flex items-center justify-between mt-2">
            <span className="text-xs text-gray-400">{newComment.length}/1000</span>
            <button
              type="submit"
              disabled={!newComment.trim() || createMutation.isPending}
              className="px-4 py-1.5 bg-gray-900 text-white text-sm rounded-lg hover:bg-gray-800 disabled:opacity-40 disabled:cursor-not-allowed transition-colors"
            >
              {createMutation.isPending ? 'Posting...' : 'Comment'}
            </button>
          </div>
          {createMutation.isError && (
            <p className="text-xs text-red-500 mt-1">Failed to post comment. Try again.</p>
          )}
        </form>
      ) : (
        <p className="text-sm text-gray-400 mb-8">Log in to leave a comment.</p>
      )}

      {/* Comments list */}
      {isLoading ? (
        <p className="text-sm text-gray-400">Loading comments...</p>
      ) : comments.length === 0 ? (
        <p className="text-sm text-gray-400">No comments yet. Be the first to share your thoughts.</p>
      ) : (
        <div className="space-y-4">
          {comments.map((comment) => (
            <div key={comment.id} className="flex gap-3 group">
              {/* Vote column */}
              <div className="flex flex-col items-center gap-0.5 pt-1">
                <button
                  onClick={() => handleVote(comment, 1)}
                  disabled={!currentUserId}
                  className={`p-0.5 rounded hover:bg-gray-100 transition-colors ${
                    comment.currentUserVote === 1 ? 'text-orange-500' : 'text-gray-300'
                  } ${!currentUserId ? 'cursor-not-allowed' : ''}`}
                >
                  <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M5.293 9.707a1 1 0 010-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 01-1.414 1.414L11 7.414V15a1 1 0 11-2 0V7.414L6.707 9.707a1 1 0 01-1.414 0z" />
                  </svg>
                </button>
                <span className={`text-xs font-medium ${
                  comment.score > 0 ? 'text-orange-500' : comment.score < 0 ? 'text-blue-500' : 'text-gray-400'
                }`}>
                  {comment.score}
                </span>
                <button
                  onClick={() => handleVote(comment, -1)}
                  disabled={!currentUserId}
                  className={`p-0.5 rounded hover:bg-gray-100 transition-colors ${
                    comment.currentUserVote === -1 ? 'text-blue-500' : 'text-gray-300'
                  } ${!currentUserId ? 'cursor-not-allowed' : ''}`}
                >
                  <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M14.707 10.293a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 111.414-1.414L9 12.586V5a1 1 0 012 0v7.586l2.293-2.293a1 1 0 011.414 0z" />
                  </svg>
                </button>
              </div>

              {/* Comment content */}
              <div className="flex-1 min-w-0">
                <div className="flex items-center gap-2 mb-1">
                  <span className="text-sm font-medium text-gray-900">{comment.userName || 'Anonymous'}</span>
                  <span className="text-xs text-gray-400">{timeAgo(comment.createdAt)}</span>
                </div>
                <p className="text-sm text-gray-700 whitespace-pre-wrap break-words">{comment.content}</p>
                {currentUserId === comment.userId && (
                  <button
                    onClick={() => deleteMutation.mutate(comment.id)}
                    disabled={deleteMutation.isPending}
                    className="text-xs text-gray-300 hover:text-red-400 mt-1 opacity-0 group-hover:opacity-100 transition-opacity"
                  >
                    delete
                  </button>
                )}
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  )
}

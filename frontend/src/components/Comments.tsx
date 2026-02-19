import React, { useState } from 'react'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PAGINATION } from '../config/constants'
import type { Comment } from '../types/posts'

async function fetchComments(postId: number, page = 1, pageSize = PAGINATION.DEFAULT_PAGE_SIZE): Promise<Comment[]> {
  const url = `${API_ENDPOINTS.posts.comments(postId)}?page=${page}&pageSize=${pageSize}`
  const response = await fetch(url, { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch comments')
  return response.json()
}

async function createComment(postId: number, content: string, parentCommentId?: number): Promise<Comment> {
  const body: any = { content }
  if (parentCommentId !== undefined) body.parentCommentId = parentCommentId
  const response = await fetch(API_ENDPOINTS.posts.comments(postId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(body)
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

interface CommentNodeProps {
  comment: Comment
  depth?: number
  currentUserId?: number
  onVote: (c: Comment, v: number) => void
  onDelete: (id: number) => void
  onReplyToggle: (id: number | null) => void
  activeReplyId: number | null
  replyDrafts: Record<number, string>
  setReplyDraft: (id: number, value: string) => void
  submitReply: (id: number) => void
  createPending: boolean
  createError: boolean
  deletePending: boolean
}

const CommentNode: React.FC<CommentNodeProps> = React.memo(({
  comment, depth = 0, currentUserId, onVote, onDelete,
  onReplyToggle, activeReplyId, replyDrafts, setReplyDraft,
  submitReply, createPending, createError, deletePending
}) => {
  const [showReplies, setShowReplies] = useState(true)
  const toggleReplies = () => setShowReplies(prev => !prev)

  return (
    <div className={`flex gap-3 group ${depth > 0 ? 'pl-6 border-l border-gray-100' : ''}`}>
      <div className="flex flex-col items-center gap-0.5 pt-1">
        {/* Upvote */}
        <button
          onClick={() => onVote(comment, 1)}
          disabled={!currentUserId || comment.isDeleted}
          className={`p-1 rounded hover:bg-gray-100 transition-colors ${comment.currentUserVote === 1 ? 'text-orange-500' : 'text-gray-300'} ${!currentUserId ? 'cursor-not-allowed' : ''}`}
        >
          <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
            <path d="M10 4l-6 6h12l-6-6z" />
          </svg>
        </button>

        {/* Score */}
        <span className={`text-xs font-medium ${comment.score > 0 ? 'text-orange-500' : comment.score < 0 ? 'text-blue-500' : 'text-gray-400'}`}>
          {comment.score}
        </span>

        {/* Downvote */}
        <button
          onClick={() => onVote(comment, -1)}
          disabled={!currentUserId || comment.isDeleted}
          className={`p-1 rounded hover:bg-gray-100 transition-colors ${comment.currentUserVote === -1 ? 'text-blue-500' : 'text-gray-300'} ${!currentUserId ? 'cursor-not-allowed' : ''}`}
        >
          <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
            <path d="M10 16l6-6H4l6 6z" />
          </svg>
        </button>
      </div>

      <div className="flex-1 min-w-0">
        <div className="flex items-center gap-2 mb-1">
          <span className="text-sm font-medium text-gray-900">{comment.userName || 'Anonymous'}</span>
          <span className="text-xs text-gray-400">{timeAgo(comment.createdAt)}</span>
        </div>

        <p className={`text-sm wrap-break-word ${comment.isDeleted ? 'text-gray-400 italic' : 'text-gray-700'}`}>
          {comment.content}
        </p>

        <div className="mt-1 flex items-center gap-3 text-xs">
          {currentUserId && !comment.isDeleted && (
            <button onClick={() => onReplyToggle(comment.id)} className="text-gray-400 hover:text-gray-600">reply</button>
          )}
          {currentUserId === comment.userId && !comment.isDeleted && (
            <button onClick={() => onDelete(comment.id)} disabled={deletePending} className="text-gray-400 hover:text-red-500">delete</button>
          )}
          {comment.replies && comment.replies.length > 0 && (
            <button onClick={toggleReplies} className="text-gray-400 hover:text-gray-600">
              {showReplies ? 'Hide replies' : `Show ${comment.replies.length} replies`}
            </button>
          )}
        </div>

        {activeReplyId === comment.id && currentUserId && (
          <div className="mt-2">
            <textarea
              value={replyDrafts[comment.id] || ''}
              onChange={e => setReplyDraft(comment.id, e.target.value)}
              placeholder="Write a reply..."
              rows={2}
              maxLength={1000}
              className="w-full px-3 py-2 border rounded-lg text-sm resize-none focus:outline-none focus:ring-2 focus:ring-gray-200"
            />
            <div className="flex justify-end items-center gap-2 mt-2">
              <button onClick={() => onReplyToggle(null)} className="px-3 py-1 text-xs text-gray-500 hover:text-gray-700">cancel</button>
              <button
                onClick={() => submitReply(comment.id)}
                disabled={!replyDrafts[comment.id] || createPending}
                className="px-3 py-1 bg-gray-900 text-white text-xs rounded-lg hover:bg-gray-800 disabled:opacity-40 disabled:cursor-not-allowed"
              >
                {createPending ? 'Posting...' : 'Reply'}
              </button>
            </div>
            {createError && <p className="text-xs text-red-500 mt-1">Failed to post reply. Try again.</p>}
          </div>
        )}

        {showReplies && comment.replies && comment.replies.length > 0 && (
          <div className="mt-4 space-y-4">
            {comment.replies.map(r => (
              <CommentNode
                key={r.id}
                comment={r}
                depth={depth + 1}
                currentUserId={currentUserId}
                onVote={onVote}
                onDelete={onDelete}
                onReplyToggle={onReplyToggle}
                activeReplyId={activeReplyId}
                replyDrafts={replyDrafts}
                setReplyDraft={setReplyDraft}
                submitReply={submitReply}
                createPending={createPending}
                createError={createError}
                deletePending={deletePending}
              />
            ))}
          </div>
        )}
      </div>
    </div>
  )
})

interface CommentsProps {
  postId: number
  currentUserId?: number
}

export function Comments({ postId, currentUserId }: CommentsProps) {
  const queryClient = useQueryClient()
  const [newComment, setNewComment] = useState('')
  const [activeReplyId, setActiveReplyId] = useState<number | null>(null)
  const [replyDrafts, setReplyDrafts] = useState<Record<number, string>>({})

  const { data: comments = [], isLoading } = useQuery({
    queryKey: ['comments', postId],
    queryFn: () => fetchComments(postId)
  })

  const createMutation = useMutation({
    mutationFn: async ({ content, parentCommentId }: { content: string; parentCommentId?: number }) => {
      const comment = await createComment(postId, content, parentCommentId)
      // Ensure currentUserVote is 0 for new comments
      return { ...comment, currentUserVote: 0 }
    },
    onSuccess: () => {
      setNewComment('')
      setReplyDrafts({})
      setActiveReplyId(null)
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
      toast.success('Comment posted!')
    },
    onError: (err: any) => toast.error(err.message)
  })

  const deleteMutation = useMutation({
    mutationFn: (commentId: number) => deleteComment(postId, commentId),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
      toast.success('Comment deleted')
    },
    onError: (err: any) => toast.error(err.message)
  })

  const voteMutation = useMutation({
    mutationFn: ({ commentId, value }: { commentId: number; value: number }) => voteComment(postId, commentId, value),
    onError: (err: any) => toast.error(err.message)
  })

  const handleVote = (comment: Comment, value: number) => {
    if (!currentUserId) return
    const voteValue = comment.currentUserVote === value ? 0 : value
    voteMutation.mutate({ commentId: comment.id, value: voteValue })
  }

  const toggleReply = (commentId: number | null) => setActiveReplyId(prev => (prev === commentId ? null : commentId))
  const handleReplyChange = (commentId: number, value: string) => setReplyDrafts(prev => ({ ...prev, [commentId]: value }))
  const submitReply = (commentId: number) => {
    const text = (replyDrafts[commentId] || '').trim()
    if (!text) return
    createMutation.mutate({ content: text, parentCommentId: commentId })
  }

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    const trimmed = newComment.trim()
    if (!trimmed) return
    createMutation.mutate({ content: trimmed })
  }

  const countAll = (list: Comment[]): number => list.reduce((sum, c) => sum + 1 + countAll(c.replies || []), 0)

  return (
    <div className="mt-8 pt-8 border-t">
      <h3 className="text-lg font-semibold text-gray-900 mb-6">
        Comments {comments.length > 0 && <span className="text-gray-400 font-normal">({countAll(comments)})</span>}
      </h3>

      {currentUserId ? (
        <form onSubmit={handleSubmit} className="mb-8">
          <textarea
            value={newComment}
            onChange={e => setNewComment(e.target.value)}
            placeholder="Write a comment..."
            rows={3}
            maxLength={1000}
            className="w-full px-3 py-2 border rounded-lg text-sm resize-none focus:outline-none focus:ring-2 focus:ring-gray-200"
          />
          <div className="flex justify-between items-center mt-2">
            <span className="text-xs text-gray-400">{newComment.length}/1000</span>
            <button
              type="submit"
              disabled={!newComment.trim() || createMutation.isPending}
              className="px-4 py-1.5 bg-gray-900 text-white text-sm rounded-lg hover:bg-gray-800 disabled:opacity-40 disabled:cursor-not-allowed"
            >
              {createMutation.isPending ? 'Posting...' : 'Comment'}
            </button>
          </div>
          {createMutation.isError && <p className="text-xs text-red-500 mt-1">Failed to post comment. Try again.</p>}
        </form>
      ) : <p className="text-sm text-gray-400 mb-8">Log in to leave a comment.</p>}

      {isLoading ? (
        <p className="text-sm text-gray-400">Loading comments...</p>
      ) : comments.length === 0 ? (
        <p className="text-sm text-gray-400">No comments yet. Be the first to share your thoughts.</p>
      ) : (
        <div className="space-y-4">
          {comments.map(comment => (
            <CommentNode
              key={comment.id}
              comment={comment}
              currentUserId={currentUserId}
              depth={0}
              onVote={handleVote}
              onDelete={(id) => deleteMutation.mutate(id)}
              onReplyToggle={toggleReply}
              activeReplyId={activeReplyId}
              replyDrafts={replyDrafts}
              setReplyDraft={handleReplyChange}
              submitReply={submitReply}
              createPending={createMutation.isPending}
              createError={createMutation.isError}
              deletePending={deleteMutation.isPending}
            />
          ))}
        </div>
      )}
    </div>
  )
}

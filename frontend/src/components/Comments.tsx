import React, { useState } from 'react'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PAGINATION } from '../config/constants'
import type { Comment } from '../types/posts'

// ─── All headers include Content-Type so the backend can parse JSON bodies ───

function jsonHeaders() {
  return {
    ...getAuthHeaders(),
    'Content-Type': 'application/json',
  }
}

async function fetchComments(postId: number, page = 1, pageSize = PAGINATION.DEFAULT_PAGE_SIZE): Promise<Comment[]> {
  const url = `${API_ENDPOINTS.posts.comments(postId)}?page=${page}&pageSize=${pageSize}`
  const response = await fetch(url, { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch comments')
  return response.json()
}

async function createComment(postId: number, content: string, parentCommentId?: number): Promise<Comment> {
  const body: Record<string, unknown> = { content }
  if (parentCommentId !== undefined) body.parentCommentId = parentCommentId
  const response = await fetch(API_ENDPOINTS.posts.comments(postId), {
    method: 'POST',
    headers: jsonHeaders(),
    body: JSON.stringify(body),
  })
  if (!response.ok) throw new Error('Failed to create comment')
  return response.json()
}

async function deleteComment(postId: number, commentId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.commentById(postId, commentId), {
    method: 'DELETE',
    headers: getAuthHeaders(),
  })
  if (!response.ok) throw new Error('Failed to delete comment')
}

async function voteComment(postId: number, commentId: number, value: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.commentVote(postId, commentId), {
    method: 'POST',
    headers: jsonHeaders(),          // ← was missing Content-Type; backend got value=0
    body: JSON.stringify({ value }),
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

// ─── CommentNode ─────────────────────────────────────────────────────────────

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
  submitReply, createPending, createError, deletePending,
}) => {
  const [showReplies, setShowReplies] = useState(true)
  const isOwner = currentUserId === comment.userId

  return (
    <div className={`flex gap-3 ${depth > 0 ? 'pl-5 border-l border-gray-100' : ''}`}>

      {/* Vote column */}
      <div className="flex flex-col items-center gap-0.5 pt-0.5 shrink-0">
        <button
          type="button"
          onClick={() => onVote(comment, 1)}
          disabled={!currentUserId || !!comment.isDeleted}
          aria-label="Upvote comment"
          className={`p-1 rounded transition-colors ${
            comment.currentUserVote === 1
              ? 'text-orange-500'
              : 'text-gray-300 hover:text-orange-400 hover:bg-orange-50'
          } disabled:cursor-not-allowed disabled:opacity-40`}
        >
          <svg className="w-3.5 h-3.5" fill="currentColor" viewBox="0 0 20 20">
            <path d="M5.293 9.707a1 1 0 010-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 01-1.414 1.414L11 7.414V15a1 1 0 11-2 0V7.414L6.707 9.707a1 1 0 01-1.414 0z" />
          </svg>
        </button>

        <span className={`text-xs font-medium tabular-nums ${
          comment.score > 0 ? 'text-orange-500' :
          comment.score < 0 ? 'text-blue-500' :
          'text-gray-400'
        }`}>
          {comment.score}
        </span>

        <button
          type="button"
          onClick={() => onVote(comment, -1)}
          disabled={!currentUserId || !!comment.isDeleted}
          aria-label="Downvote comment"
          className={`p-1 rounded transition-colors ${
            comment.currentUserVote === -1
              ? 'text-blue-500'
              : 'text-gray-300 hover:text-blue-400 hover:bg-blue-50'
          } disabled:cursor-not-allowed disabled:opacity-40`}
        >
          <svg className="w-3.5 h-3.5" fill="currentColor" viewBox="0 0 20 20">
            <path d="M14.707 10.293a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 111.414-1.414L9 12.586V5a1 1 0 012 0v7.586l2.293-2.293a1 1 0 011.414 0z" />
          </svg>
        </button>
      </div>

      {/* Content */}
      <div className="flex-1 min-w-0 pb-4">
        <div className="flex items-center gap-2 mb-1">
          <span className="text-xs font-semibold text-gray-800">{comment.userName || 'Anonymous'}</span>
          <span className="text-xs text-gray-400">{timeAgo(comment.createdAt)}</span>
          {isOwner && !comment.isDeleted && (
            <span className="text-xs text-gray-300 bg-gray-100 rounded px-1.5 py-0.5 leading-none">you</span>
          )}
        </div>

        <p className={`text-sm leading-relaxed wrap-break-word ${
          comment.isDeleted ? 'text-gray-400 italic' : 'text-gray-700'
        }`}>
          {comment.content}
        </p>

        {/* Action row */}
        <div className="mt-1.5 flex items-center gap-3 text-xs">
          {currentUserId && !comment.isDeleted && (
            <button
              type="button"
              onClick={() => onReplyToggle(comment.id)}
              className="text-gray-400 hover:text-gray-600 transition-colors"
            >
              {activeReplyId === comment.id ? 'cancel' : 'reply'}
            </button>
          )}
          {isOwner && !comment.isDeleted && (
            <button
              type="button"
              onClick={() => onDelete(comment.id)}
              disabled={deletePending}
              className="text-gray-400 hover:text-red-500 transition-colors disabled:opacity-40"
            >
              delete
            </button>
          )}
          {comment.replies && comment.replies.length > 0 && (
            <button
              type="button"
              onClick={() => setShowReplies(p => !p)}
              className="text-gray-400 hover:text-gray-600 transition-colors"
            >
              {showReplies ? 'hide replies' : `show ${comment.replies.length} ${comment.replies.length === 1 ? 'reply' : 'replies'}`}
            </button>
          )}
        </div>

        {/* Reply box */}
        {activeReplyId === comment.id && currentUserId && (
          <div className="mt-3">
            <textarea
              value={replyDrafts[comment.id] || ''}
              onChange={e => setReplyDraft(comment.id, e.target.value)}
              placeholder="Write a reply…"
              rows={2}
              maxLength={1000}
              className="w-full px-3 py-2 border border-gray-200 rounded-lg text-sm resize-none focus:outline-none focus:ring-2 focus:ring-gray-200 focus:border-transparent"
            />
            <div className="flex justify-end items-center gap-2 mt-1.5">
              <button
                type="button"
                onClick={() => onReplyToggle(null)}
                className="px-3 py-1 text-xs text-gray-500 hover:text-gray-700 transition-colors"
              >
                Cancel
              </button>
              <button
                type="button"
                onClick={() => submitReply(comment.id)}
                disabled={!replyDrafts[comment.id]?.trim() || createPending}
                className="px-3 py-1.5 bg-gray-900 text-white text-xs rounded-lg hover:bg-gray-700 disabled:opacity-40 disabled:cursor-not-allowed transition-colors"
              >
                {createPending ? 'Posting…' : 'Reply'}
              </button>
            </div>
            {createError && (
              <p className="text-xs text-red-500 mt-1">Failed to post. Try again.</p>
            )}
          </div>
        )}

        {/* Nested replies */}
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

CommentNode.displayName = 'CommentNode'

// ─── Comments root ────────────────────────────────────────────────────────────

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
    queryFn: () => fetchComments(postId),
  })

  const createMutation = useMutation({
    mutationFn: ({ content, parentCommentId }: { content: string; parentCommentId?: number }) =>
      createComment(postId, content, parentCommentId),
    onSuccess: () => {
      setNewComment('')
      setReplyDrafts({})
      setActiveReplyId(null)
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
      toast.success('Comment posted!')
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const deleteMutation = useMutation({
    mutationFn: (commentId: number) => deleteComment(postId, commentId),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
      toast.success('Comment deleted')
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const voteMutation = useMutation({
    mutationFn: ({ commentId, value }: { commentId: number; value: number }) =>
      voteComment(postId, commentId, value),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const handleVote = (comment: Comment, value: number) => {
    if (!currentUserId) return
    const voteValue = comment.currentUserVote === value ? 0 : value
    voteMutation.mutate({ commentId: comment.id, value: voteValue })
  }

  const toggleReply = (commentId: number | null) =>
    setActiveReplyId(prev => (prev === commentId ? null : commentId))

  const handleReplyChange = (commentId: number, value: string) =>
    setReplyDrafts(prev => ({ ...prev, [commentId]: value }))

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

  const countAll = (list: Comment[]): number =>
    list.reduce((sum, c) => sum + 1 + countAll(c.replies || []), 0)

  const total = countAll(comments)

  return (
    <div className="mt-8 pt-6 border-t border-gray-100">
      <h3 className="text-sm font-semibold text-gray-900 mb-5 flex items-center gap-2">
        Comments
        {total > 0 && (
          <span className="text-xs font-normal text-gray-400 bg-gray-100 rounded-full px-2 py-0.5">
            {total}
          </span>
        )}
      </h3>

      {/* New comment form */}
      {currentUserId ? (
        <form onSubmit={handleSubmit} className="mb-7">
          <textarea
            value={newComment}
            onChange={e => setNewComment(e.target.value)}
            placeholder="Write a comment…"
            rows={3}
            maxLength={1000}
            className="w-full px-3 py-2.5 border border-gray-200 rounded-lg text-sm resize-none focus:outline-none focus:ring-2 focus:ring-gray-200 focus:border-transparent transition-shadow"
          />
          <div className="flex justify-between items-center mt-2">
            <span className="text-xs text-gray-400 tabular-nums">{newComment.length}/1000</span>
            <button
              type="submit"
              disabled={!newComment.trim() || createMutation.isPending}
              className="px-4 py-1.5 bg-gray-900 text-white text-xs rounded-lg hover:bg-gray-700 disabled:opacity-40 disabled:cursor-not-allowed transition-colors"
            >
              {createMutation.isPending ? 'Posting…' : 'Post comment'}
            </button>
          </div>
          {createMutation.isError && (
            <p className="text-xs text-red-500 mt-1">Failed to post. Try again.</p>
          )}
        </form>
      ) : (
        <p className="text-xs text-gray-400 mb-7">Sign in to leave a comment.</p>
      )}

      {/* Comment list */}
      {isLoading ? (
        <p className="text-xs text-gray-400">Loading comments…</p>
      ) : comments.length === 0 ? (
        <p className="text-xs text-gray-400">No comments yet. Be the first.</p>
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

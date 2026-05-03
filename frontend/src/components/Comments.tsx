import React, { useState } from 'react'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import { Reply, Trash2, X, Clock, TrendingUp } from 'lucide-react'
import { cn } from '../lib/utils'
import { UserAvatar } from './UserAvatar'
import { Dialog, DialogTrigger, DialogContent, DialogTitle } from './ui/dialog'
import { formatRelativeTime } from '../lib/utils/date'
import { isValidPhotoUrl } from '../lib/utils/validation'
import type { Comment } from '../types/posts'
import { PhotoUpload } from './PhotoUpload'
import { VoteButtons } from './VoteButtons'
import { fetchComments, createComment, deleteComment, voteComment } from '../api/comments'


interface CommentNodeProps {
  comment: Comment
  depth?: number
  currentUserId?: number
  onVote: (c: Comment, v: number) => void
  onDelete: (id: number) => void
  onReplyToggle: (id: number | null) => void
  activeReplyId: number | null
  replyDrafts: Record<number, string>
  replyPhotos: Record<number, string | null>
  setReplyDraft: (id: number, value: string) => void
  setReplyPhoto: (id: number, url: string | null) => void
  submitReply: (id: number) => void
  createPending: boolean
  createError: boolean
  deletePending: boolean
  isLast?: boolean
}

const CommentNode: React.FC<CommentNodeProps> = React.memo(({
  comment, depth = 0, currentUserId, onVote, onDelete,
  onReplyToggle, activeReplyId, replyDrafts, replyPhotos,
  setReplyDraft, setReplyPhoto, submitReply,
  createPending, createError, deletePending, isLast,
}) => {
  const [showReplies, setShowReplies] = useState(true)
  const isOwner = currentUserId === comment.userId
  const isReplyOpen = activeReplyId === comment.id
  const replyText = replyDrafts[comment.id] || ''
  const replyPhoto = replyPhotos[comment.id] ?? null
  const canSubmitReply = (replyText.trim().length > 0 || !!replyPhoto) && !createPending
  const hasReplies = !!comment.replies?.length

  return (
    <div className={`flex gap-2.5 ${depth > 0 ? '' : ''}`}>
      <VoteButtons
        score={comment.score}
        currentUserVote={comment.currentUserVote}
        onVote={(val) => onVote(comment, val)}
        disabled={!currentUserId || comment.isDeleted}
        className="flex-col px-1 py-1 min-w-10 bg-transparent border-transparent gap-0.5"
      />

      <div className={`flex-1 min-w-0 pb-3 ${!isLast && depth === 0 ? 'border-b border-border/60' : ''}`}>
        <div className="flex items-center gap-2 mb-1.5">
          {!comment.isDeleted && (
            <UserAvatar url={comment.userPhotoUrl} username={comment.userName} className="w-6 h-6" />
          )}
          <span className="text-sm font-medium text-foreground">
            {comment.isDeleted ? 'deleted' : (comment.userName || 'Anonymous')}
          </span>
          <span className="text-sm text-muted-foreground">
            {formatRelativeTime(comment.createdAt)}
          </span>
        </div>

        {comment.isDeleted ? (
          <p className="text-sm text-muted-foreground italic">{comment.content}</p>
        ) : (
          <div className="space-y-2">
            {comment.content && (
              <p className="text-sm leading-relaxed wrap-break-word text-foreground">
                {comment.content}
              </p>
            )}
            {comment.photoUrl && isValidPhotoUrl(comment.photoUrl) && (
              <Dialog>
                <DialogTrigger asChild>
                  <div className="rounded-lg overflow-hidden max-w-55 cursor-pointer ring-1 ring-black/5 hover:ring-black/10 transition-all">
                    <img src={comment.photoUrl} alt="" className="w-full object-cover max-h-52" />
                  </div>
                </DialogTrigger>
                <DialogContent className="max-w-[95vw] sm:max-w-[90vw] md:max-w-[80vw] h-[85vh] p-0 border-0 bg-transparent flex items-center justify-center shadow-none">
                  <DialogTitle className="sr-only">Image Preview</DialogTitle>
                  <img src={comment.photoUrl} alt="Preview" className="max-w-full max-h-full object-contain" />
                </DialogContent>
              </Dialog>
            )}
          </div>
        )}

        {!comment.isDeleted && (
          <div className="mt-2 flex items-center gap-1">
            {currentUserId && (
              <button
                type="button"
                onClick={() => onReplyToggle(comment.id)}
                className={`flex items-center gap-1.5 px-2.5 py-1 rounded-full text-sm transition-colors ${
                  isReplyOpen
                    ? 'bg-primary/10 text-primary'
                    : 'text-muted-foreground hover:bg-primary/10 hover:text-primary'
                }`}
              >
                {isReplyOpen ? <X size={12} /> : <Reply size={12} />}
                {isReplyOpen ? 'Cancel' : 'Reply'}
              </button>
            )}
            {isOwner && (
              <button
                type="button"
                onClick={() => onDelete(comment.id)}
                disabled={deletePending}
                className="flex items-center gap-1.5 px-2.5 py-1 rounded-full text-sm text-muted-foreground hover:bg-destructive/10 hover:text-destructive transition-colors disabled:opacity-40"
              >
                <Trash2 size={12} />
                Delete
              </button>
            )}
            {hasReplies && (
              <button
                type="button"
                onClick={() => setShowReplies(p => !p)}
                className="px-2.5 py-1 rounded-full text-sm text-muted-foreground hover:text-primary transition-colors"
              >
                {showReplies
                  ? 'hide replies'
                  : `${comment.replies!.length} ${comment.replies!.length === 1 ? 'reply' : 'replies'}`}
              </button>
            )}
          </div>
        )}

        {isReplyOpen && currentUserId && (
          <div className="mt-2.5 bg-card rounded-xl border border-border/70 overflow-hidden">
            <textarea
              value={replyText}
              onChange={e => setReplyDraft(comment.id, e.target.value)}
              placeholder={`Reply to ${comment.userName || 'this comment'}…`}
              rows={2}
              maxLength={1000}
              autoFocus
              className="w-full px-3 pt-2.5 pb-1.5 text-sm bg-transparent resize-none focus:outline-none text-foreground placeholder:text-muted-foreground"
            />
            <div className="flex items-center justify-between px-2 pb-2">
              <PhotoUpload
                value={replyPhoto ? [replyPhoto] : []}
                onChange={urls => setReplyPhoto(comment.id, urls[0] ?? null)}
                maxPhotos={1}
                disabled={createPending}
              />
              <div className="flex items-center gap-2">
                <span className="text-sm text-muted-foreground tabular-nums">{replyText.length}/1000</span>
                <button
                  type="button"
                  onClick={() => submitReply(comment.id)}
                  disabled={!canSubmitReply}
                  className="flex items-center gap-1.5 px-3 py-1.5 bg-primary text-primary-foreground text-sm font-medium rounded-full hover:bg-primary/90 disabled:opacity-30 disabled:cursor-not-allowed transition-colors"
                >
                  {createPending ? 'Posting…' : 'Reply'}
                </button>
              </div>
            </div>
            {createError && (
              <p className="text-sm text-destructive px-3 pb-2">Failed to post. Try again.</p>
            )}
          </div>
        )}

        {showReplies && hasReplies && (
          <div className="mt-3 pl-3 border-l-2 border-border/60 space-y-3">
            {comment.replies!.map((r, i) => (
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
                replyPhotos={replyPhotos}
                setReplyDraft={setReplyDraft}
                setReplyPhoto={setReplyPhoto}
                submitReply={submitReply}
                createPending={createPending}
                createError={createError}
                deletePending={deletePending}
                isLast={i === comment.replies!.length - 1}
              />
            ))}
          </div>
        )}
      </div>
    </div>
  )
})

CommentNode.displayName = 'CommentNode'

interface CommentsProps {
  postId: number
  currentUserId?: number
}

export function Comments({ postId, currentUserId }: CommentsProps) {
  const queryClient = useQueryClient()
  const [newComment, setNewComment]       = useState('')
  const [newPhoto, setNewPhoto]           = useState<string | null>(null)
  const [activeReplyId, setActiveReplyId] = useState<number | null>(null)
  const [replyDrafts, setReplyDrafts]     = useState<Record<number, string>>({})
  const [replyPhotos, setReplyPhotos]     = useState<Record<number, string | null>>({})

  const [sort, setSort] = useState<'top' | 'new'>('top')

  const { data: allComments = [], isLoading } = useQuery({
    queryKey: ['comments', postId],
    queryFn: () => fetchComments(postId),
  })

  const sortComments = (comments: Comment[]): Comment[] => {
    const sorted = [...comments].sort((a, b) => {
      if (sort === 'top') {
        const scoreDiff = b.score - a.score
        return scoreDiff !== 0 ? scoreDiff : new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
      } else {
        return new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
      }
    })
    return sorted.map(c => ({
      ...c,
      replies: c.replies ? sortComments(c.replies) : undefined,
    }))
  }

  const comments = sortComments(allComments)

  const createMutation = useMutation({
    mutationFn: ({ content, photoUrl, parentCommentId }: {
      content: string; photoUrl?: string; parentCommentId?: number
    }) => createComment({ postId, content, photoUrl, parentCommentId }),
    onSuccess: () => {
      setNewComment('')
      setNewPhoto(null)
      setReplyDrafts({})
      setReplyPhotos({})
      setActiveReplyId(null)
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
      queryClient.invalidateQueries({ queryKey: ['post', postId] })
      queryClient.invalidateQueries({ queryKey: ['posts'] })
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const deleteMutation = useMutation({
    mutationFn: (commentId: number) => deleteComment(postId, commentId),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['comments', postId] })
      queryClient.invalidateQueries({ queryKey: ['post', postId] })
      queryClient.invalidateQueries({ queryKey: ['posts'] })
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const voteMutation = useMutation({
    mutationFn: ({ commentId, value }: { commentId: number; value: number }) =>
      voteComment(postId, commentId, value),
    onSuccess: () => queryClient.invalidateQueries({ queryKey: ['comments', postId] }),
    onError: (err: Error) => toast.error(err.message),
  })

  const handleVote = (comment: Comment, value: number) => {
    if (!currentUserId) return
    const voteValue = comment.currentUserVote === value ? 0 : value
    voteMutation.mutate({ commentId: comment.id, value: voteValue })
  }

  const toggleReply = (commentId: number | null) =>
    setActiveReplyId(prev => prev === commentId ? null : commentId)

  const handleReplyChange = (commentId: number, value: string) =>
    setReplyDrafts(prev => ({ ...prev, [commentId]: value }))

  const handleReplyPhoto = (commentId: number, url: string | null) =>
    setReplyPhotos(prev => ({ ...prev, [commentId]: url }))

  const submitReply = (commentId: number) => {
    const text = (replyDrafts[commentId] || '').trim()
    const photo = replyPhotos[commentId] ?? undefined
    if (!text && !photo) return
    createMutation.mutate({ content: text, photoUrl: photo, parentCommentId: commentId })
  }

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    const trimmed = newComment.trim()
    if (!trimmed && !newPhoto) return
    createMutation.mutate({ content: trimmed, photoUrl: newPhoto ?? undefined })
  }

  const countAll = (list: Comment[]): number =>
    list.reduce((sum, c) => sum + (c.isDeleted ? 0 : 1) + countAll(c.replies || []), 0)

  const total = countAll(comments)
  const canSubmit = (newComment.trim().length > 0 || !!newPhoto) && !createMutation.isPending

  return (
    <div className="mt-8 pt-6 border-t border-border/60">
      <div className="flex items-center gap-2 mb-5">
        <h3 className="text-sm font-semibold text-foreground">Comments</h3>
        {total > 0 && (
          <span className="text-sm text-primary bg-primary/10 rounded-full px-2 py-0.5 tabular-nums">
            {total}
          </span>
        )}
        <div className="ml-auto flex items-center gap-3">
          <div className="flex items-center gap-1 bg-muted/40 p-1 rounded-full border border-border/50 shrink-0">
            <button
              onClick={() => setSort('top')}
              className={cn("px-4 py-2 rounded-full text-sm font-medium transition-colors flex items-center gap-2", sort === 'top' ? "bg-background shadow-sm text-foreground" : "text-foreground hover:text-primary")}
            >
              <TrendingUp className="w-4 h-4" /> Top
            </button>
            <button
              onClick={() => setSort('new')}
              className={cn("px-4 py-2 rounded-full text-sm font-medium transition-colors flex items-center gap-2", sort === 'new' ? "bg-background shadow-sm text-foreground" : "text-foreground hover:text-primary")}
            >
              <Clock className="w-4 h-4" /> New
            </button>
          </div>
        </div>
      </div>

      {currentUserId ? (
        <form onSubmit={handleSubmit} className="mb-6">
          <div className="border border-border rounded-xl overflow-hidden focus-within:border-ring transition-colors bg-card">
            <textarea
              value={newComment}
              onChange={e => setNewComment(e.target.value)}
              placeholder={newPhoto ? 'Add a caption (optional)…' : 'Write a comment…'}
              rows={3}
              maxLength={1000}
              className="w-full px-3.5 pt-3 pb-2 text-sm bg-transparent resize-none focus:outline-none text-foreground placeholder:text-muted-foreground"
            />
            <div className="flex items-center justify-between px-3 pb-2.5 border-t border-border/60 pt-2">
              <div className="flex items-center gap-3">
                <PhotoUpload
                  value={newPhoto ? [newPhoto] : []}
                  onChange={urls => setNewPhoto(urls[0] ?? null)}
                  maxPhotos={1}
                  disabled={createMutation.isPending}
                />
                <span className="text-sm text-muted-foreground tabular-nums">{newComment.length}/1000</span>
              </div>
              <button
                type="submit"
                disabled={!canSubmit}
                className="flex items-center gap-1.5 px-4 py-1.5 bg-primary text-primary-foreground text-sm font-medium rounded-full hover:bg-primary/90 disabled:opacity-30 disabled:cursor-not-allowed transition-colors"
              >
                {createMutation.isPending ? 'Posting…' : 'Comment'}
              </button>
            </div>
          </div>
          {createMutation.isError && (
            <p className="text-sm text-destructive mt-1.5 px-1">Failed to post. Try again.</p>
          )}
        </form>
      ) : (
        <p className="text-sm text-muted-foreground mb-6">Sign in to leave a comment.</p>
      )}

      {isLoading ? (
        <div className="space-y-4">
          {[1, 2, 3].map(i => (
            <div key={i} className="flex gap-2.5 animate-pulse">
              <div className="w-6 shrink-0 flex flex-col items-center gap-1 pt-0.5">
                <div className="w-4 h-3 bg-muted rounded" />
                <div className="w-4 h-3 bg-muted rounded" />
                <div className="w-4 h-3 bg-muted rounded" />
              </div>
              <div className="flex-1 pb-3 border-b border-border/60">
                <div className="flex items-center gap-2 mb-2">
                  <div className="w-6 h-6 rounded-full bg-muted" />
                  <div className="h-3 w-20 bg-muted rounded" />
                  <div className="h-3 w-12 bg-muted rounded" />
                </div>
                <div className="h-3 w-3/4 bg-muted rounded mb-1.5" />
                <div className="h-3 w-1/2 bg-muted rounded" />
              </div>
            </div>
          ))}
        </div>
      ) : comments.length === 0 ? (
        <p className="text-sm text-muted-foreground">No comments yet. Be the first!</p>
      ) : (
        <div className="space-y-3">
          {comments.map((comment, i) => (
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
              replyPhotos={replyPhotos}
              setReplyDraft={handleReplyChange}
              setReplyPhoto={handleReplyPhoto}
              submitReply={submitReply}
              createPending={createMutation.isPending}
              createError={createMutation.isError}
              deletePending={deleteMutation.isPending}
              isLast={i === comments.length - 1}
            />
          ))}
        </div>
      )}
    </div>
  )
}

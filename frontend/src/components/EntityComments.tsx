import React, { useState } from 'react'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import { Reply, Trash2, X, Clock, TrendingUp, Menu, Pencil } from 'lucide-react'
import { cn } from '../lib/utils'
import { UserAvatar } from './UserAvatar'
import { Dialog, DialogTrigger, DialogContent, DialogTitle } from './ui/dialog'
import { Button } from './ui/button'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { formatRelativeTime } from '../lib/utils/date'
import { isValidPhotoUrl } from '../lib/utils/validation'
import type { Comment } from '../types/posts'
import { PhotoUpload } from './PhotoUpload'
import { VoteButtons } from './VoteButtons'
import { createComment, deleteComment, fetchComments, updateComment, voteComment, type CommentTarget } from '../api/comments'

interface CommentNodeProps {
  comment: Comment
  depth?: number
  currentUserId?: number
  onVote: (c: Comment, v: number) => void
  onDelete: (id: number) => void
  onEditToggle: (comment: Comment) => void
  onReplyToggle: (id: number | null) => void
  activeReplyId: number | null
  activeEditId: number | null
  replyDrafts: Record<number, string>
  replyPhotos: Record<number, string | null>
  editDrafts: Record<number, string>
  editPhotos: Record<number, string | null>
  setReplyDraft: (id: number, value: string) => void
  setReplyPhoto: (id: number, url: string | null) => void
  setEditDraft: (id: number, value: string) => void
  setEditPhoto: (id: number, url: string | null) => void
  submitReply: (id: number) => void
  submitEdit: (id: number) => void
  createPending: boolean
  createError: boolean
  editPending: boolean
  editError: boolean
  deletePending: boolean
  isLast?: boolean
}

const CommentNode: React.FC<CommentNodeProps> = React.memo(({
  comment, depth = 0, currentUserId, onVote, onDelete,
  onEditToggle, onReplyToggle, activeReplyId, activeEditId, replyDrafts, replyPhotos,
  editDrafts, editPhotos, setReplyDraft, setReplyPhoto, setEditDraft, setEditPhoto,
  submitReply, submitEdit,
  createPending, createError, editPending, editError, deletePending, isLast,
}) => {
  const [showReplies, setShowReplies] = useState(true)
  const isOwner = currentUserId === comment.userId
  const isReplyOpen = activeReplyId === comment.id
  const isEditOpen = activeEditId === comment.id
  const replyText = replyDrafts[comment.id] || ''
  const replyPhoto = replyPhotos[comment.id] ?? null
  const editText = editDrafts[comment.id] || ''
  const editPhoto = editPhotos[comment.id] ?? null
  const canSubmitReply = (replyText.trim().length > 0 || !!replyPhoto) && !createPending
  const canSubmitEdit = (editText.trim().length > 0 || !!editPhoto) && !editPending
  const hasReplies = !!comment.replies?.length
  const editTextareaRef = React.useRef<HTMLTextAreaElement | null>(null)

  React.useEffect(() => {
    if (!isEditOpen || !editTextareaRef.current) return

    const textarea = editTextareaRef.current
    textarea.focus()
    const length = textarea.value.length
    textarea.setSelectionRange(length, length)
  }, [isEditOpen, editText])

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
        <div className="flex items-center justify-between gap-2 mb-1.5">
          <div className="flex items-center gap-2 min-w-0">
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
          {isOwner && !comment.isDeleted && (
            <Popover>
              <PopoverTrigger asChild>
                <div onClick={(e) => e.stopPropagation()}>
                  <Button variant="ghost" size="sm" className="h-7 w-7 p-0">
                    <Menu className="h-4 w-4" />
                  </Button>
                </div>
              </PopoverTrigger>
              <PopoverContent align="end" className="w-32 p-2" onClick={(e) => e.stopPropagation()}>
                <div className="flex flex-col gap-1">
                  <Button
                    variant="ghost"
                    className="justify-start gap-2 h-8"
                    onClick={() => onEditToggle(comment)}
                  >
                    <Pencil className="w-4 h-4" />
                    Edit
                  </Button>
                  <Button
                    variant="ghost"
                    className="justify-start gap-2 h-8 text-destructive hover:text-destructive hover:bg-destructive/10"
                    onClick={() => {
                      if (window.confirm('Delete this comment? This cannot be undone.')) {
                        onDelete(comment.id)
                      }
                    }}
                    disabled={deletePending}
                  >
                    <Trash2 className="w-4 h-4" />
                    {deletePending ? 'Deleting…' : 'Delete'}
                  </Button>
                </div>
              </PopoverContent>
            </Popover>
          )}
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

        {isEditOpen && currentUserId && (
          <div className="mt-2.5 bg-card rounded-xl border border-border/70 overflow-hidden">
            <textarea
              ref={editTextareaRef}
              value={editText}
              onChange={e => setEditDraft(comment.id, e.target.value)}
              placeholder="Edit your comment…"
              rows={2}
              maxLength={1000}
              className="w-full px-3 pt-2.5 pb-1.5 text-sm bg-transparent resize-none focus:outline-none text-foreground placeholder:text-muted-foreground"
            />
            <div className="flex items-center justify-between px-2 pb-2">
              <PhotoUpload
                value={editPhoto ? [editPhoto] : []}
                onChange={urls => setEditPhoto(comment.id, urls[0] ?? null)}
                maxPhotos={1}
                disabled={editPending}
              />
              <div className="flex items-center gap-2">
                <button
                  type="button"
                  onClick={() => onEditToggle(comment)}
                  className="flex items-center gap-1.5 px-3 py-1.5 rounded-full text-sm font-medium text-muted-foreground hover:bg-muted hover:text-foreground transition-colors"
                >
                  Cancel
                </button>
                <span className="text-sm text-muted-foreground tabular-nums">{editText.length}/1000</span>
                <button
                  type="button"
                  onClick={() => submitEdit(comment.id)}
                  disabled={!canSubmitEdit}
                  className="flex items-center gap-1.5 px-3 py-1.5 bg-primary text-primary-foreground text-sm font-medium rounded-full hover:bg-primary/90 disabled:opacity-30 disabled:cursor-not-allowed transition-colors"
                >
                  {editPending ? 'Saving…' : 'Save'}
                </button>
              </div>
            </div>
            {editError && (
              <p className="text-sm text-destructive px-3 pb-2">Failed to save. Try again.</p>
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
                onEditToggle={onEditToggle}
                onReplyToggle={onReplyToggle}
                activeReplyId={activeReplyId}
                activeEditId={activeEditId}
                replyDrafts={replyDrafts}
                replyPhotos={replyPhotos}
                editDrafts={editDrafts}
                editPhotos={editPhotos}
                setReplyDraft={setReplyDraft}
                setReplyPhoto={setReplyPhoto}
                setEditDraft={setEditDraft}
                setEditPhoto={setEditPhoto}
                submitReply={submitReply}
                submitEdit={submitEdit}
                createPending={createPending}
                createError={createError}
                editPending={editPending}
                editError={editError}
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
  target: CommentTarget
  entityId: number
  currentUserId?: number
}

export function Comments({ target, entityId, currentUserId }: CommentsProps) {
  const queryClient = useQueryClient()
  const [newComment, setNewComment] = useState('')
  const [newPhoto, setNewPhoto] = useState<string | null>(null)
  const [activeReplyId, setActiveReplyId] = useState<number | null>(null)
  const [activeEditId, setActiveEditId] = useState<number | null>(null)
  const [replyDrafts, setReplyDrafts] = useState<Record<number, string>>({})
  const [replyPhotos, setReplyPhotos] = useState<Record<number, string | null>>({})
  const [editDrafts, setEditDrafts] = useState<Record<number, string>>({})
  const [editPhotos, setEditPhotos] = useState<Record<number, string | null>>({})
  const [sort, setSort] = useState<'top' | 'new'>('top')

  const commentsQueryKey = ['comments', target, entityId]
  const detailQueryKey = target === 'posts' ? ['post', entityId] : ['place', entityId]
  const collectionQueryKey = target === 'posts' ? ['posts'] : ['places']
  const userCollectionQueryKey = target === 'posts' ? ['user-posts'] : ['user-places']

  const { data: allComments = [], isLoading } = useQuery({
    queryKey: commentsQueryKey,
    queryFn: () => fetchComments(target, entityId),
  })

  const sortComments = (comments: Comment[]): Comment[] => {
    const sorted = [...comments].sort((a, b) => {
      if (sort === 'top') {
        const scoreDiff = b.score - a.score
        return scoreDiff !== 0 ? scoreDiff : new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
      }

      return new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
    })

    return sorted.map(c => ({
      ...c,
      replies: c.replies ? sortComments(c.replies) : undefined,
    }))
  }

  const comments = sortComments(allComments)

  const createMutation = useMutation({
    mutationFn: ({ content, photoUrl, parentCommentId }: { content: string; photoUrl?: string; parentCommentId?: number }) =>
      createComment({ target, entityId, content, photoUrl, parentCommentId }),
    onSuccess: async () => {
      setNewComment('')
      setNewPhoto(null)
      setReplyDrafts({})
      setReplyPhotos({})
      setActiveReplyId(null)
      await Promise.all([
        queryClient.invalidateQueries({ queryKey: commentsQueryKey }),
        queryClient.invalidateQueries({ queryKey: detailQueryKey }),
        queryClient.invalidateQueries({ queryKey: collectionQueryKey }),
        queryClient.invalidateQueries({ queryKey: userCollectionQueryKey }),
      ])
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const editMutation = useMutation({
    mutationFn: ({ commentId, content, photoUrl }: { commentId: number; content: string; photoUrl?: string }) =>
      updateComment({ target, entityId, commentId, content, photoUrl }),
    onSuccess: () => {
      setActiveEditId(null)
      toast.success('Comment updated')
      queryClient.invalidateQueries({ queryKey: commentsQueryKey })
      queryClient.invalidateQueries({ queryKey: detailQueryKey })
      queryClient.invalidateQueries({ queryKey: collectionQueryKey })
      queryClient.invalidateQueries({ queryKey: userCollectionQueryKey })
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const deleteMutation = useMutation({
    mutationFn: (commentId: number) => deleteComment(target, entityId, commentId),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: commentsQueryKey })
      queryClient.invalidateQueries({ queryKey: detailQueryKey })
      queryClient.invalidateQueries({ queryKey: collectionQueryKey })
      queryClient.invalidateQueries({ queryKey: userCollectionQueryKey })
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const voteMutation = useMutation({
    mutationFn: ({ commentId, value }: { commentId: number; value: number }) =>
      voteComment(target, entityId, commentId, value),
    onSuccess: () => queryClient.invalidateQueries({ queryKey: commentsQueryKey }),
    onError: (err: Error) => toast.error(err.message),
  })

  const handleVote = (comment: Comment, value: number) => {
    if (!currentUserId) return
    const voteValue = comment.currentUserVote === value ? 0 : value
    voteMutation.mutate({ commentId: comment.id, value: voteValue })
  }

  const toggleEdit = (comment: Comment) => {
    setActiveEditId(prev => {
      const next = prev === comment.id ? null : comment.id

      if (next === comment.id) {
        setEditDrafts(current => ({ ...current, [comment.id]: comment.content || '' }))
        setEditPhotos(current => ({ ...current, [comment.id]: comment.photoUrl ?? null }))
      }

      return next
    })
  }

  const toggleReply = (commentId: number | null) =>
    setActiveReplyId(prev => prev === commentId ? null : commentId)

  const handleReplyChange = (commentId: number, value: string) =>
    setReplyDrafts(prev => ({ ...prev, [commentId]: value }))

  const handleReplyPhoto = (commentId: number, url: string | null) =>
    setReplyPhotos(prev => ({ ...prev, [commentId]: url }))

  const handleEditChange = (commentId: number, value: string) =>
    setEditDrafts(prev => ({ ...prev, [commentId]: value }))

  const handleEditPhoto = (commentId: number, url: string | null) =>
    setEditPhotos(prev => ({ ...prev, [commentId]: url }))

  const submitReply = (commentId: number) => {
    const text = (replyDrafts[commentId] || '').trim()
    const photo = replyPhotos[commentId] ?? undefined
    if (!text && !photo) return
    createMutation.mutate({ content: text, photoUrl: photo, parentCommentId: commentId })
  }

  const submitEdit = (commentId: number) => {
    const text = (editDrafts[commentId] || '').trim()
    const photo = editPhotos[commentId] ?? undefined
    if (!text && !photo) return
    editMutation.mutate({ commentId, content: text, photoUrl: photo })
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
              className={cn('px-4 py-2 rounded-full text-sm font-medium transition-colors flex items-center gap-2', sort === 'top' ? 'bg-background shadow-sm text-foreground' : 'text-foreground hover:text-primary')}
            >
              <TrendingUp className="w-4 h-4" /> Top
            </button>
            <button
              onClick={() => setSort('new')}
              className={cn('px-4 py-2 rounded-full text-sm font-medium transition-colors flex items-center gap-2', sort === 'new' ? 'bg-background shadow-sm text-foreground' : 'text-foreground hover:text-primary')}
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
            <p className="text-sm text-destructive mt-2">Failed to post comment. Try again.</p>
          )}
        </form>
      ) : (
        <div className="mb-6 rounded-xl border border-dashed border-border/70 bg-muted/20 px-4 py-5 text-sm text-muted-foreground">
          Sign in to comment.
        </div>
      )}

      {isLoading ? (
        <div className="flex items-center gap-2 text-sm text-muted-foreground py-6">
          <svg className="w-4 h-4 animate-spin" fill="none" viewBox="0 0 24 24">
            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4" />
            <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8v8z" />
          </svg>
          Loading comments…
        </div>
      ) : comments.length > 0 ? (
        <div className="space-y-4">
          {comments.map((comment, index) => (
            <CommentNode
              key={comment.id}
              comment={comment}
              currentUserId={currentUserId}
              onVote={handleVote}
              onDelete={(id) => deleteMutation.mutate(id)}
              onEditToggle={toggleEdit}
              onReplyToggle={toggleReply}
              activeReplyId={activeReplyId}
              activeEditId={activeEditId}
              replyDrafts={replyDrafts}
              replyPhotos={replyPhotos}
              editDrafts={editDrafts}
              editPhotos={editPhotos}
              setReplyDraft={handleReplyChange}
              setReplyPhoto={handleReplyPhoto}
              setEditDraft={handleEditChange}
              setEditPhoto={handleEditPhoto}
              submitReply={submitReply}
              submitEdit={submitEdit}
              createPending={createMutation.isPending}
              createError={createMutation.isError}
              editPending={editMutation.isPending}
              editError={editMutation.isError}
              deletePending={deleteMutation.isPending}
              isLast={index === comments.length - 1}
            />
          ))}
        </div>
      ) : (
        <div className="py-10 text-center text-sm text-muted-foreground">No comments yet.</div>
      )}
    </div>
  )
}

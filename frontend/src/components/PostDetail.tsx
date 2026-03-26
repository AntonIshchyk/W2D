import { useParams, useNavigate } from 'react-router-dom'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useState } from 'react'
import { toast } from 'sonner'
import {
  ArrowBigUp, ArrowBigDown, ChevronLeft, ChevronRight, X,
  MapPin, Clock, Trash2, Tag,
  BookOpen, Map, HelpCircle, ThumbsUp, Trophy, Target,
} from 'lucide-react'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PostType } from '../types/posts'
import type { Post } from '../types/posts'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { formatRelativeTime } from '../lib/utils/date'
import { Comments } from './Comments'
import { cn } from '../lib/utils'

// ── Type maps (mirrors Posts.tsx) ─────────────────────────────────────────────

const POST_TYPE_LABELS: Record<PostType, string> = {
  [PostType.ExperienceShare]: 'Experience',
  [PostType.Guide]: 'Guide',
  [PostType.Question]: 'Question',
  [PostType.Recommendation]: 'Recommendation',
  [PostType.Achievement]: 'Achievement',
  [PostType.Challenge]: 'Challenge',
}

const POST_TYPE_COLORS: Record<PostType, { bg: string; text: string; border: string }> = {
  [PostType.ExperienceShare]: { bg: 'bg-blue-50',    text: 'text-blue-700',    border: 'border-blue-200'    },
  [PostType.Guide]:           { bg: 'bg-emerald-50', text: 'text-emerald-700', border: 'border-emerald-200' },
  [PostType.Question]:        { bg: 'bg-amber-50',   text: 'text-amber-700',   border: 'border-amber-200'   },
  [PostType.Recommendation]:  { bg: 'bg-purple-50',  text: 'text-purple-700',  border: 'border-purple-200'  },
  [PostType.Achievement]:     { bg: 'bg-rose-50',    text: 'text-rose-700',    border: 'border-rose-200'    },
  [PostType.Challenge]:       { bg: 'bg-red-50',     text: 'text-red-700',     border: 'border-red-200'     },
}

const POST_TYPE_ICONS: Record<PostType, React.ElementType> = {
  [PostType.ExperienceShare]: BookOpen,
  [PostType.Guide]: Map,
  [PostType.Question]: HelpCircle,
  [PostType.Recommendation]: ThumbsUp,
  [PostType.Achievement]: Trophy,
  [PostType.Challenge]: Target,
}

// ── API ───────────────────────────────────────────────────────────────────────

async function fetchPost(id: number): Promise<Post> {
  const response = await fetch(API_ENDPOINTS.posts.byId(id), { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch post')
  return response.json()
}

async function votePost(postId: number, value: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.vote(postId), {
    method: 'POST',
    headers: { ...getAuthHeaders(), 'Content-Type': 'application/json' },
    body: JSON.stringify({ value }),
  })
  if (!response.ok) throw new Error('Failed to vote on post')
}

async function deletePost(postId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.byId(postId), {
    method: 'DELETE',
    headers: getAuthHeaders(),
  })
  if (!response.ok) throw new Error('Failed to delete post')
}

// ── Lightbox ──────────────────────────────────────────────────────────────────

function Lightbox({ urls, initialIndex, onClose }: {
  urls: string[]
  initialIndex: number
  onClose: () => void
}) {
  const [index, setIndex] = useState(initialIndex)
  const prev = () => setIndex(i => (i - 1 + urls.length) % urls.length)
  const next = () => setIndex(i => (i + 1) % urls.length)

  return (
    <div
      className="fixed inset-0 z-50 bg-black/90 flex items-center justify-center"
      onClick={onClose}
      onKeyDown={e => {
        if (e.key === 'ArrowLeft') prev()
        if (e.key === 'ArrowRight') next()
        if (e.key === 'Escape') onClose()
      }}
      tabIndex={0}
      // eslint-disable-next-line jsx-a11y/no-autofocus
      autoFocus
    >
      <button type="button" onClick={onClose}
        className="absolute top-4 right-4 text-white/70 hover:text-white transition-colors z-10">
        <X className="w-5 h-5" />
      </button>

      {urls.length > 1 && (
        <span className="absolute top-4 left-1/2 -translate-x-1/2 text-white/60 text-sm">
          {index + 1} / {urls.length}
        </span>
      )}

      {urls.length > 1 && (
        <button type="button" onClick={e => { e.stopPropagation(); prev() }}
          className="absolute left-4 text-white/60 hover:text-white transition-colors">
          <ChevronLeft className="w-8 h-8" />
        </button>
      )}

      <img
        src={urls[index]}
        alt=""
        className="max-w-[90vw] max-h-[85vh] object-contain rounded-xl"
        onClick={e => e.stopPropagation()}
      />

      {urls.length > 1 && (
        <button type="button" onClick={e => { e.stopPropagation(); next() }}
          className="absolute right-4 text-white/60 hover:text-white transition-colors">
          <ChevronRight className="w-8 h-8" />
        </button>
      )}

      {urls.length > 1 && (
        <div className="absolute bottom-4 left-1/2 -translate-x-1/2 flex gap-2">
          {urls.map((url, i) => (
            <button key={i} type="button" onClick={e => { e.stopPropagation(); setIndex(i) }}
              className={cn(
                'w-12 h-12 rounded-lg overflow-hidden border-2 transition-all',
                i === index ? 'border-white opacity-100' : 'border-transparent opacity-40 hover:opacity-70'
              )}>
              <img src={url} alt="" className="w-full h-full object-cover" />
            </button>
          ))}
        </div>
      )}
    </div>
  )
}

// ── Photo gallery ─────────────────────────────────────────────────────────────

function PhotoGallery({ urls, onOpen }: { urls: string[]; onOpen: (i: number) => void }) {
  if (urls.length === 0) return null

  if (urls.length === 1) return (
    <div className="mb-6 rounded-2xl overflow-hidden cursor-pointer" onClick={() => onOpen(0)}>
      <img src={urls[0]} alt="" className="w-full max-h-[28rem] object-cover" />
    </div>
  )

  if (urls.length === 2) return (
    <div className="mb-6 grid grid-cols-2 gap-1 rounded-2xl overflow-hidden">
      {urls.map((url, i) => (
        <img key={i} src={url} alt="" className="w-full h-64 object-cover cursor-pointer" onClick={() => onOpen(i)} />
      ))}
    </div>
  )

  if (urls.length === 3) return (
    <div className="mb-6 rounded-2xl overflow-hidden" style={{ display: 'grid', gridTemplateColumns: '2fr 1fr', gap: 4, height: 260 }}>
      <img src={urls[0]} alt="" className="w-full h-full object-cover cursor-pointer" onClick={() => onOpen(0)} />
      <div style={{ display: 'grid', gridTemplateRows: '1fr 1fr', gap: 4 }}>
        <img src={urls[1]} alt="" className="w-full h-full object-cover cursor-pointer" onClick={() => onOpen(1)} />
        <img src={urls[2]} alt="" className="w-full h-full object-cover cursor-pointer" onClick={() => onOpen(2)} />
      </div>
    </div>
  )

  return (
    <div className="mb-6 rounded-2xl overflow-hidden space-y-1">
      <div className="grid grid-cols-2 gap-1">
        <img src={urls[0]} alt="" className="w-full h-56 object-cover cursor-pointer" onClick={() => onOpen(0)} />
        <img src={urls[1]} alt="" className="w-full h-56 object-cover cursor-pointer" onClick={() => onOpen(1)} />
      </div>
      <div className={cn('grid gap-1', urls.length === 4 ? 'grid-cols-2' : 'grid-cols-3')}>
        {urls.slice(2, 5).map((url, i) => (
          <div key={i} className="relative cursor-pointer" onClick={() => onOpen(i + 2)}>
            <img src={url} alt="" className="w-full h-32 object-cover" />
            {i === 2 && urls.length > 5 && (
              <div className="absolute inset-0 bg-black/50 flex items-center justify-center">
                <span className="text-white text-lg font-bold">+{urls.length - 5}</span>
              </div>
            )}
          </div>
        ))}
      </div>
    </div>
  )
}

// ── Main ──────────────────────────────────────────────────────────────────────

export function PostDetail() {
  const { id } = useParams<{ id: string }>()
  const navigate = useNavigate()
  const queryClient = useQueryClient()
  const [lightboxIndex, setLightboxIndex] = useState<number | null>(null)

  const { data: currentUser, isError: userError, error: userQueryError } = useCurrentUser()

  const { data: post, isLoading, isError } = useQuery({
    queryKey: ['post', id],
    queryFn: () => fetchPost(Number(id)),
    enabled: !!id && !isNaN(Number(id)),
  })

  const voteMutation = useMutation({
    mutationFn: ({ postId, value }: { postId: number; value: number }) => votePost(postId, value),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['post', id] })
      queryClient.invalidateQueries({ queryKey: ['posts'] })
    },
    onError: (e: Error) => toast.error(e.message),
  })

  const deleteMutation = useMutation({
    mutationFn: deletePost,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      toast.success('Post deleted')
      navigate('/posts')
    },
    onError: (e: Error) => toast.error(e.message),
  })

  useAuthErrorHandler(userError, userQueryError)

  const handleVote = (currentVote: number | undefined, newValue: number) => {
    if (!currentUser || !id) return
    const value = currentVote === newValue ? 0 : newValue
    voteMutation.mutate({ postId: Number(id), value })
  }

  if (isLoading) return (
    <PageLayout>
      <div className="flex items-center justify-center py-20">
        <div className="flex items-center gap-2.5 text-muted-foreground">
          <svg className="w-4 h-4 animate-spin" fill="none" viewBox="0 0 24 24">
            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4" />
            <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8v8z" />
          </svg>
          <span className="text-sm">Loading…</span>
        </div>
      </div>
    </PageLayout>
  )

  if (isError || !post) return (
    <PageLayout>
      <div className="max-w-3xl mx-auto">
        <h2 className="text-xl font-semibold mb-2">Not found</h2>
        <p className="text-sm text-muted-foreground mb-4">This post doesn't exist or has been removed.</p>
        <button type="button" onClick={() => navigate('/posts')}
          className="text-sm text-muted-foreground hover:text-foreground underline">
          Back to posts
        </button>
      </div>
    </PageLayout>
  )

  const typeStyle   = POST_TYPE_COLORS[post.type as PostType]
  const TypeIcon    = POST_TYPE_ICONS[post.type as PostType]
  const isOwner     = currentUser?.userId === post.author?.id
  const photos      = post.photoUrls ?? []

  return (
    <>
      {lightboxIndex !== null && (
        <Lightbox urls={photos} initialIndex={lightboxIndex} onClose={() => setLightboxIndex(null)} />
      )}

      <PageLayout>
        <div className="max-w-3xl mx-auto">

          {/* Back */}
          <button type="button" onClick={() => navigate('/posts')}
            className="group flex items-center gap-1.5 text-sm text-muted-foreground hover:text-foreground mb-6 transition-colors">
            <ChevronLeft className="w-4 h-4 transition-transform group-hover:-translate-x-0.5" />
            Back to posts
          </button>

          {/* Card */}
          <article className="bg-card border border-border/50 rounded-3xl p-6 md:p-8">

            {/* ── Author row ── */}
            <div className="flex items-center justify-between mb-5">
              <div className="flex items-center gap-3">
                {post.author?.profilePhotoUrl ? (
                  <img src={post.author.profilePhotoUrl} alt="User"
                    className="h-10 w-10 rounded-full object-cover border border-primary/20 flex-shrink-0" />
                ) : (
                  <div className="h-10 w-10 rounded-full bg-gradient-to-br from-primary/20 to-primary/10 flex items-center justify-center border border-primary/20 flex-shrink-0">
                    <span className="text-primary font-bold text-sm">
                      {post.author?.username ? post.author.username.substring(0, 2).toUpperCase() : 'AN'}
                    </span>
                  </div>
                )}
                <div>
                  <p className="text-sm font-semibold text-foreground leading-tight">
                    {post.author?.username || 'Anonymous'}
                  </p>
                  {typeStyle && (
                    <div className={cn('flex items-center gap-1 mt-0.5 text-xs font-medium', typeStyle.text)}>
                      {TypeIcon && <TypeIcon className="w-3.5 h-3.5" />}
                      <span>{POST_TYPE_LABELS[post.type as PostType]}</span>
                    </div>
                  )}
                </div>
              </div>

              <div className="flex items-center gap-2">
                {post.communityName && (
                  <span className="px-3 py-1 rounded-full text-xs font-bold border bg-gray-900 text-white border-gray-900">
                    {post.communityName}
                  </span>
                )}
                {isOwner && (
                  <button type="button"
                    onClick={() => {
                      if (window.confirm('Delete this post? This cannot be undone.'))
                        deleteMutation.mutate(post.id)
                    }}
                    disabled={deleteMutation.isPending}
                    className="flex items-center gap-1.5 text-xs text-muted-foreground hover:text-destructive transition-colors px-3 py-1.5 rounded-full hover:bg-destructive/10 border border-transparent hover:border-destructive/20"
                  >
                    <Trash2 className="w-3.5 h-3.5" />
                    {deleteMutation.isPending ? 'Deleting…' : 'Delete'}
                  </button>
                )}
              </div>
            </div>

            {/* ── Title ── */}
            <h1 className="text-2xl md:text-3xl font-bold text-foreground leading-snug mb-4">
              {post.title}
            </h1>

            {/* ── Photos ── */}
            {photos.length > 0 && <PhotoGallery urls={photos} onOpen={setLightboxIndex} />}

            {/* ── Body ── */}
            {post.description && (
              <p className="text-sm md:text-base text-foreground leading-relaxed whitespace-pre-wrap mb-6">
                {post.description}
              </p>
            )}

            {/* ── Location ── */}
            {post.locationName && (
              <div className="flex items-center gap-2 text-sm text-muted-foreground bg-muted/40 border border-border/50 rounded-2xl px-4 py-3 mb-6 w-fit">
                <MapPin className="w-4 h-4 shrink-0" />
                <span>{post.locationName}</span>
              </div>
            )}

            {/* ── Footer: vote + time ── */}
            <div className="flex items-center gap-3 pt-5 border-t border-border/40 mb-8">
              {/* Vote pill */}
              <div className="flex items-center gap-1 bg-muted/40 rounded-full p-1 border border-border/50">
                <button
                  onClick={() => handleVote(post.currentUserVote, 1)}
                  disabled={!currentUser || voteMutation.isPending}
                  className={cn(
                    'p-1.5 rounded-full transition-colors flex items-center justify-center',
                    post.currentUserVote === 1
                      ? 'bg-orange-100 text-orange-600 dark:bg-orange-900/30'
                      : 'hover:bg-muted text-muted-foreground',
                    'disabled:opacity-40 disabled:cursor-not-allowed'
                  )}
                  aria-label="Upvote"
                >
                  <ArrowBigUp className="w-5 h-5" fill={post.currentUserVote === 1 ? 'currentColor' : 'none'} />
                </button>

                <span className={cn(
                  'text-sm font-bold min-w-[2ch] text-center',
                  post.score > 0 ? 'text-orange-600' : post.score < 0 ? 'text-blue-600' : 'text-foreground'
                )}>
                  {post.score}
                </span>

                <button
                  onClick={() => handleVote(post.currentUserVote, -1)}
                  disabled={!currentUser || voteMutation.isPending}
                  className={cn(
                    'p-1.5 rounded-full transition-colors flex items-center justify-center',
                    post.currentUserVote === -1
                      ? 'bg-blue-100 text-blue-600 dark:bg-blue-900/30'
                      : 'hover:bg-muted text-muted-foreground',
                    'disabled:opacity-40 disabled:cursor-not-allowed'
                  )}
                  aria-label="Downvote"
                >
                  <ArrowBigDown className="w-5 h-5" fill={post.currentUserVote === -1 ? 'currentColor' : 'none'} />
                </button>
              </div>

              {/* Time */}
              <div className="flex items-center gap-1.5 text-sm font-bold text-muted-foreground bg-muted/40 px-3 py-2 rounded-full border border-border/50">
                <Clock className="w-4 h-4 opacity-70" />
                <span>{formatRelativeTime(post.createdAt)}</span>
              </div>
            </div>

            {/* ── Comments ── */}
            <Comments postId={post.id} currentUserId={currentUser?.userId} />
          </article>
        </div>
      </PageLayout>
    </>
  )
}
import { useParams, useNavigate } from 'react-router-dom'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import {
  ArrowBigUp, ArrowBigDown, ChevronLeft,
  MapPin, Clock, Trash2
} from 'lucide-react'
import { Dialog, DialogContent, DialogTrigger, DialogTitle } from './ui/dialog'
import { Carousel, CarouselContent, CarouselItem, CarouselNext, CarouselPrevious } from "./ui/carousel"
import { PageLayout } from './Navbar'
import { PostType } from '../types/posts'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { formatRelativeTime } from '../lib/utils/date'
import { Comments } from './Comments'
import { cn } from '../lib/utils'
import { fetchPost, votePost, deletePost, POST_TYPE_LABELS, POST_TYPE_COLORS, POST_TYPE_ICONS } from '../features/posts/api'

// ── Photo Carousel ──────────────────────────────────────────────

function PostCarousel({ urls }: { urls: string[] }) {
  if (!urls || urls.length === 0) return null

  return (
    <div className="mt-4 mb-6 md:px-0" onClick={(e) => e.preventDefault()}>
      <Carousel className="w-full">
        <CarouselContent>
          {urls.map((url, i) => (
            <CarouselItem key={i}>
              <Dialog>
                <DialogTrigger asChild>
                  <div className="relative w-full h-96 flex items-center justify-center bg-black/95 rounded-2xl overflow-hidden cursor-pointer hover:opacity-95 transition-opacity">
                    <img 
                      src={url} 
                      alt={`Attachment ${i + 1}`} 
                      className="max-w-full max-h-full object-contain"
                    />
                    {urls.length > 1 && (
                      <div className="absolute top-3 right-3 bg-black/60 text-white text-xs font-medium px-2.5 py-1 rounded-full backdrop-blur-md">
                        {i + 1} / {urls.length}
                      </div>
                    )}
                  </div>
                </DialogTrigger>
                <DialogContent className="max-w-[95vw] sm:max-w-[90vw] md:max-w-[80vw] h-[90vh] p-0 border-0 bg-transparent flex flex-col justify-center shadow-none">
                  <DialogTitle className="sr-only">Image View</DialogTitle>
                  <div className="relative w-full h-full flex items-center justify-center">
                    <img src={url} className="max-w-full max-h-full object-contain" alt="Fullscreen view" />
                  </div>
                </DialogContent>
              </Dialog>
            </CarouselItem>
          ))}
        </CarouselContent>
        {urls.length > 1 && (
          <div className="absolute inset-y-0 left-2 right-2 flex items-center justify-between pointer-events-none">
            <CarouselPrevious className="relative inset-0 translate-x-0 translate-y-0 bg-black/50 text-white border-0 hover:bg-black/80 hover:text-white pointer-events-auto" />
            <CarouselNext className="relative inset-0 translate-x-0 translate-y-0 bg-black/50 text-white border-0 hover:bg-black/80 hover:text-white pointer-events-auto" />
          </div>
        )}
      </Carousel>
    </div>
  )
}

export function PostDetail() {
  const { id } = useParams<{ id: string }>()
  const navigate = useNavigate()
  const queryClient = useQueryClient()

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
                    className="h-10 w-10 rounded-full object-cover border border-primary/20 shrink-0" />
                ) : (
                  <div className="h-10 w-10 rounded-full bg-linear-to-br from-primary/20 to-primary/10 flex items-center justify-center border border-primary/20 shrink-0">
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
            {photos.length > 0 && <PostCarousel urls={photos} />}

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

              <div className="flex items-center gap-1.5 text-sm font-bold text-muted-foreground bg-muted/40 px-3 py-2 rounded-full border border-border/50">
                <Clock className="w-4 h-4 opacity-70" />
                <span>{formatRelativeTime(post.createdAt)}</span>
              </div>
            </div>

            <Comments postId={post.id} currentUserId={currentUser?.userId} />
          </article>
        </div>
      </PageLayout>
  )
}

import { useParams, useNavigate } from 'react-router-dom'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import {
  ChevronLeft,
  MapPin, Clock, Trash2
} from 'lucide-react'
import { PageLayout } from './Navbar'
import { PostType } from '../types/posts'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { usePostVoteMutation } from '../hooks/usePostVoteMutation'
import { formatRelativeTime } from '../lib/utils/date'
import { getGoogleMapsUrl } from '../lib/utils/maps'
import { Comments } from './Comments'
import { PhotoCarousel } from './PhotoCarousel'
import { fetchPost, deletePost } from '../api/posts'
import { PostAuthorInfo } from './PostAuthorInfo'
import { VoteButtons } from './VoteButtons'

export function PostDetail() {
  const { id } = useParams<{ id: string }>()
  const navigate = useNavigate()
  const queryClient = useQueryClient()
  const { data: currentUser } = useCurrentUser()
  const { data: post, isLoading, isError } = useQuery({
    queryKey: ['post', id],
    queryFn: () => fetchPost(Number(id)),
    enabled: !!id && !isNaN(Number(id)),
  })

  const { handlePostVote: handleVoteMutation, voteMutation } = usePostVoteMutation(['post', id])

  const deleteMutation = useMutation({
    mutationFn: deletePost,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      toast.success('Post deleted')
      navigate('/posts')
    },
    onError: (e: Error) => toast.error(e.message),
  })

  const handleVote = (currentVote: number | undefined, newValue: number) => {
    if (!currentUser || !id) return
    handleVoteMutation(Number(id), currentVote, newValue)
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
        <p className="text-sm mb-4">This post doesn't exist or has been removed.</p>
        <button type="button" onClick={() => navigate('/posts')}
          className="text-sm hover:text-foreground underline">
          Back to posts
        </button>
      </div>
    </PageLayout>
  )

  const isOwner = currentUser?.userId === post.author?.id
  const photos = post.photoUrls ?? []
  const googleMapsUrl = getGoogleMapsUrl(post.latitude, post.longitude, post.locationName)

  return (
    <PageLayout>
      <div className="max-w-3xl mx-auto">
          <button type="button" onClick={() => navigate('/posts')}
            className="group flex items-center gap-1.5 text-sm text-muted-foreground hover:text-foreground mb-6 transition-colors">
            <ChevronLeft className="w-4 h-4 transition-transform group-hover:-translate-x-0.5" />
            Back to posts
          </button>

          <article className="bg-card border border-border/50 rounded-3xl p-6 md:p-8">
            <div className="flex items-center justify-between mb-5">
              <PostAuthorInfo author={post.author as any} type={post.type as PostType} />

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
                    className="flex items-center gap-1.5 text-sm hover:text-destructive transition-colors px-3 py-1.5 rounded-full hover:bg-destructive/10 border border-transparent hover:border-destructive/20"
                  >
                    <Trash2 className="w-3.5 h-3.5" />
                    {deleteMutation.isPending ? 'Deleting…' : 'Delete'}
                  </button>
                )}
              </div>
            </div>

            <h1 className={`text-2xl md:text-3xl font-bold text-foreground leading-snug ${post.locationName ? 'mb-2' : 'mb-4'}`}>
              {post.title}
            </h1>

            {post.locationName && (
              googleMapsUrl ? (
                <a
                  href={googleMapsUrl}
                  target="_blank"
                  rel="noreferrer"
                  className="flex items-center gap-1.5 text-primary hover:underline mb-5 text-sm w-fit"
                >
                  <MapPin className="w-4 h-4 shrink-0" />
                  <span>{post.locationName}</span>
                </a>
              ) : (
                <div className="flex items-center gap-1.5 text-muted-foreground mb-5 text-sm w-fit">
                  <MapPin className="w-4 h-4 shrink-0" />
                  <span>{post.locationName}</span>
                </div>
              )
            )}

            {photos.length > 0 && <PhotoCarousel urls={photos} />}

            {post.description && (
              <p className="text-sm md:text-base text-foreground leading-relaxed whitespace-pre-wrap mt-4 mb-6">
                {post.description}
              </p>
            )}

            <div className="flex items-center gap-3 pt-5 border-t border-border/40 mb-8">
              <VoteButtons
                score={post.score}
                currentUserVote={post.currentUserVote}
                onVote={(val) => handleVote(post.currentUserVote, val)}
                disabled={!currentUser || voteMutation.isPending}
              />

              <div className="flex items-center gap-1.5 text-sm font-bold bg-muted/40 px-3 py-2 rounded-full border border-border/50">
                <Clock className="w-4 h-4" />
                <span>{formatRelativeTime(post.createdAt)}</span>
              </div>
            </div>

            <Comments postId={post.id} currentUserId={currentUser?.userId} />
          </article>
        </div>
      </PageLayout>
  )
}

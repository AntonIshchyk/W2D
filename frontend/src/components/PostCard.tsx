import { Link } from 'react-router-dom'
import { MessageSquare, Clock, MapPin, Menu, Pencil, Trash2 } from 'lucide-react'
import { cn } from '../lib/utils'
import type { Post } from '../types/posts'
import { PostType } from '../types/posts'
import { formatRelativeTime } from '../lib/utils/date'
import { getGoogleMapsUrl } from '../lib/utils/maps'
import { PhotoCarousel } from './PhotoCarousel'
import { PostAuthorInfo } from './PostAuthorInfo'
import { VoteButtons } from './VoteButtons'
import { Button } from './ui/button'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { useMutation, useQueryClient } from '@tanstack/react-query'
import { deletePost } from '../api/posts'
import { toast } from 'sonner'

interface PostCardProps {
  post: Post
  currentUser: any
  onVote: (postId: number, currentVote: number | undefined, newValue: number) => void
  className?: string
  isPreview?: boolean
}

export function PostCard({ post, currentUser, onVote, className, isPreview }: PostCardProps) {
  const queryClient = useQueryClient()
  
  const deleteMutation = useMutation({
    mutationFn: deletePost,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      queryClient.invalidateQueries({ queryKey: ['user-posts'] })
      toast.success('Post deleted')
    },
    onError: (e: Error) => toast.error(e.message),
  })

  const ContainerProps = isPreview
    ? { role: undefined, tabIndex: undefined }
    : { role: 'button' as const, tabIndex: 0 as const }

  const googleMapsUrl = getGoogleMapsUrl(post.latitude, post.longitude, post.locationName)

  return (
    <article
      {...ContainerProps}
      onClick={isPreview ? undefined : () => undefined}
      onKeyDown={isPreview ? undefined : (e) => e.key === 'Enter' && undefined}
      className={cn('group bg-card border border-border/50 rounded-3xl p-5 md:p-6 hover:shadow-xl hover:shadow-primary/5 hover:border-primary/20 transition-all duration-300 flex flex-col', className)}
    >
      <div className="flex items-center justify-between mb-4">
        <PostAuthorInfo author={post.author as any} type={post.type as PostType} />

        <div className="flex items-center gap-2">
          {post.communityName && (
            <span className="px-3 py-1 rounded-full text-xs font-bold border bg-primary text-primary-foreground border-primary">
              {post.communityName}
            </span>
          )}
          {currentUser != null && currentUser.userId != null && currentUser.userId === post.author?.id && !isPreview && (
            <Popover>
              <PopoverTrigger asChild>
                <div onClick={(e) => e.stopPropagation()}>
                  <Button variant="ghost" size="sm" className="h-8 w-8 p-0">
                    <Menu className="w-4 h-4" />
                  </Button>
                </div>
              </PopoverTrigger>
              <PopoverContent align="end" className="w-40 p-2" onClick={(e) => e.stopPropagation()}>
                <div className="flex flex-col gap-1">
                  <Button 
                    variant="ghost" 
                    className="justify-start gap-2 h-9"
                    onClick={() => {
                      alert('Edit post coming soon')
                    }}
                  >
                    <Pencil className="w-4 h-4" />
                    Edit Post
                  </Button>
                  <Button 
                    variant="ghost" 
                    className="justify-start gap-2 h-9 text-destructive hover:text-destructive hover:bg-destructive/10"
                    onClick={() => {
                      if (window.confirm('Delete this post? This cannot be undone.')) {
                        deleteMutation.mutate(post.id)
                      }
                    }}
                    disabled={deleteMutation.isPending}
                  >
                    <Trash2 className="w-4 h-4" />
                    {deleteMutation.isPending ? 'Deleting…' : 'Delete'}
                  </Button>
                </div>
              </PopoverContent>
            </Popover>
          )}
        </div>
      </div>

        <div className="flex-1">
        {isPreview ? (
          <h3 className={`font-bold text-xl md:text-2xl text-foreground ${post.locationName ? 'mb-2' : 'mb-2'} wrap-break-word break-all whitespace-normal line-clamp-2`}>
            {post.title}
          </h3>
        ) : (
          <Link to={`/posts/${post.id}`}>
            <h3 className={`font-bold text-xl md:text-2xl text-foreground ${post.locationName ? 'mb-2' : 'mb-2'} group-hover:text-primary transition-colors wrap-break-word break-all whitespace-normal line-clamp-2`}>
              {post.title}
            </h3>
          </Link>
        )}

        {post.locationName && (
          googleMapsUrl ? (
            <a
              href={googleMapsUrl}
              target="_blank"
              rel="noreferrer"
              className="flex items-center gap-1.5 text-primary hover:underline mb-3 text-sm w-fit"
              onClick={(e) => e.stopPropagation()}
            >
              <MapPin className="w-4 h-4 shrink-0" />
              <span>{post.locationName}</span>
            </a>
          ) : (
            <div className="flex items-center gap-1.5 text-muted-foreground mb-3 text-sm w-fit">
              <MapPin className="w-4 h-4 shrink-0" />
              <span>{post.locationName}</span>
            </div>
          )
        )}

        <PhotoCarousel urls={post.photoUrls || []} containerClassName="mb-3 md:px-0" imageContainerClassName="h-75 md:h-112.5" />

        {post.description && (
          <p className="text-foreground text-sm md:text-base whitespace-normal break-all leading-relaxed line-clamp-2">
            {post.description}
          </p>
        )}
      </div>

      <div className="flex items-center justify-between mt-5 pt-4 border-t border-border/40">
        <div className="flex items-center gap-3">
          <VoteButtons
            score={post.score}
            currentUserVote={post.currentUserVote}
            onVote={(value) => onVote(post.id, post.currentUserVote, value)}
            disabled={isPreview || !currentUser}
          />

          {isPreview ? (
            <div className="flex items-center gap-2 text-sm font-bold text-muted-foreground px-3 py-2 rounded-full bg-muted/40 border border-border/50">
              <MessageSquare className="w-4 h-4" />
              <span>{post.commentCount}</span>
            </div>
          ) : (
            <Link
              to={`/posts/${post.id}`}
              className="flex items-center gap-2 text-sm font-bold hover:bg-muted/50 px-3 py-2 rounded-full transition-colors border border-transparent hover:border-border/50 bg-muted/40"
            >
              <MessageSquare className="w-4 h-4" />
              <span>{post.commentCount}</span>
            </Link>
          )}

          <div className="flex items-center gap-1.5 text-sm font-bold bg-muted/40 px-3 py-2 rounded-full border border-border/50">
            <Clock className="w-4 h-4" />
            <span>{formatRelativeTime(post.createdAt)}</span>
          </div>
        </div>
      </div>
    </article>
  )
}

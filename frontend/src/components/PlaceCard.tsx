import { Link, useNavigate } from 'react-router-dom'
import { MapPin, Users, Menu, Pencil, Trash2, MessageSquare, Clock } from 'lucide-react'
import { cn } from '../lib/utils'
import { getGoogleMapsUrl } from '../lib/utils/maps'
import { PhotoCarousel } from './PhotoCarousel'
import { UserAvatar } from './UserAvatar'
import type { Place } from '../types/places'
import { Button } from './ui/button'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { useMutation, useQueryClient } from '@tanstack/react-query'
import { deletePlace } from '../api/places'
import { toast } from 'sonner'
import type { UserInfo } from '../lib/auth'
import { VoteButtons } from './VoteButtons'
import { formatRelativeTime } from '../lib/utils/date'

interface PlaceCardProps {
  place: Place
  currentUser?: UserInfo | null
  onDelete?: (placeId: number) => void
  onVote?: (placeId: number, currentVote: number | undefined | null, newValue: number) => void
  className?: string
  isPreview?: boolean
  compact?: boolean
}

export function PlaceCard({ place, currentUser, onDelete, onVote, className, isPreview, compact }: PlaceCardProps) {
  const queryClient = useQueryClient()
  const navigate = useNavigate()
  
  const deleteMutation = useMutation({
    mutationFn: deletePlace,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['places'] })
      queryClient.invalidateQueries({ queryKey: ['user-places'] })
      toast.success('Place deleted')
      onDelete?.(place.id)
    },
    onError: (e: Error) => toast.error(e.message),
  })

  const googleMapsUrl = getGoogleMapsUrl(place.latitude, place.longitude, place.locationName)

  return (
    <div
      className={cn(
        'group bg-card border border-border/50 rounded-3xl p-5 md:p-6 hover:shadow-xl hover:shadow-primary/5 hover:border-primary/20 transition-all duration-300 flex flex-col',
        className,
      )}
    >
      <div className="flex items-center justify-between mb-4">
        <div className="flex items-center gap-3 min-w-0">
          <UserAvatar url={place.userPhotoUrl} username={place.userName} className={compact ? 'h-8 w-8' : 'h-10 w-10'} />
          <div className="min-w-0">
            <p className="font-semibold text-foreground truncate">{place.userName}</p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          {place.communityName && (
            <span className="px-3 py-1 rounded-full text-xs font-bold border bg-primary text-primary-foreground border-primary inline-flex items-center gap-1.5 shrink-0">
              <Users className="h-3 w-3" />
              {place.communityName}
            </span>
          )}
          
          {currentUser != null && currentUser.userId != null && currentUser.userId === place.userId && !isPreview && (
            <Popover>
              <PopoverTrigger asChild>
                <div onClick={(e) => e.stopPropagation()}>
                  <Button variant="ghost" size="sm" className="h-8 w-8 p-0">
                    <Menu className="h-4 w-4" />
                  </Button>
                </div>
              </PopoverTrigger>
              <PopoverContent align="end" className="w-40 p-2" onClick={(e) => e.stopPropagation()}>
                <div className="flex flex-col gap-1">
                  <Button 
                    variant="ghost" 
                    className="justify-start gap-2 h-9"
                    onClick={() => {
                      navigate(`/places/${place.id}/edit`)
                    }}
                  >
                    <Pencil className="w-4 h-4" />
                    Edit Place
                  </Button>
                  <Button 
                    variant="ghost" 
                    className="justify-start gap-2 h-9 text-destructive hover:text-destructive hover:bg-destructive/10"
                    onClick={() => {
                      if (window.confirm('Delete this place? This cannot be undone.')) {
                        deleteMutation.mutate(place.id)
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
        {
          (() => {
            const titleClass = `font-bold ${compact ? 'text-lg md:text-xl' : 'text-xl md:text-2xl'} text-foreground ${place.locationName ? 'mb-2' : 'mb-2'} wrap-break-word break-all whitespace-normal line-clamp-2`
            return isPreview ? (
              <h3 className={titleClass}>{place.title}</h3>
            ) : (
              <Link to={`/places/${place.id}`} onClick={(e) => e.stopPropagation()}>
                <h3 className={`${titleClass} group-hover:text-primary transition-colors`}>{place.title}</h3>
              </Link>
            )
          })()
        }

        {place.locationName && (
          googleMapsUrl ? (
            <a
              href={googleMapsUrl}
              target="_blank"
              rel="noreferrer"
              className="flex items-center gap-1.5 text-primary hover:underline mb-3 text-sm w-fit"
              onClick={(e) => e.stopPropagation()}
            >
              <MapPin className="w-4 h-4 shrink-0" />
              <span>{place.locationName}</span>
            </a>
          ) : (
            <div className="flex items-center gap-1.5 text-muted-foreground mb-3 text-sm w-fit">
              <MapPin className="w-4 h-4 shrink-0" />
              <span>{place.locationName}</span>
            </div>
          )
        )}

        <PhotoCarousel
          urls={place.photoUrls}
          containerClassName={compact ? 'mb-2 md:px-0' : 'mb-3 md:px-0'}
          imageContainerClassName={compact ? 'h-40 md:h-56' : 'h-75 md:h-112.5'}
        />

        {place.description && (
          <p className="text-foreground text-sm md:text-base whitespace-normal break-all leading-relaxed line-clamp-2">
            {place.description}
          </p>
        )}
      </div>

      <div className="flex items-center justify-between mt-5 pt-4 border-t border-border/40">
        <div className="flex items-center gap-3">
          <VoteButtons
            score={place.score}
            currentUserVote={place.currentUserVote ?? undefined}
            onVote={(value) => onVote?.(place.id, place.currentUserVote ?? undefined, value)}
            disabled={isPreview || !currentUser || !onVote}
          />

          {isPreview ? (
            <div className="flex items-center gap-2 text-sm font-bold text-muted-foreground px-3 py-2 rounded-full bg-muted/40 border border-border/50">
              <MessageSquare className="w-4 h-4" />
              <span>{place.commentCount}</span>
            </div>
          ) : (
            <Link
              to={`/places/${place.id}`}
              className="flex items-center gap-2 text-sm font-bold hover:bg-muted/50 px-3 py-2 rounded-full transition-colors border border-transparent hover:border-border/50 bg-muted/40"
              onClick={(e) => e.stopPropagation()}
            >
              <MessageSquare className="w-4 h-4" />
              <span>{place.commentCount}</span>
            </Link>
          )}

          <div className="flex items-center gap-1.5 text-sm font-bold bg-muted/40 px-3 py-2 rounded-full border border-border/50">
            <Clock className="w-4 h-4" />
            <span>{formatRelativeTime(place.createdAt)}</span>
          </div>
        </div>
      </div>
    </div>
  )
}

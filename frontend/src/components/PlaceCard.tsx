import { MapPin, Users, Menu, Pencil, Trash2 } from 'lucide-react'
import { useNavigate } from 'react-router-dom'
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

interface PlaceCardProps {
  place: Place
  currentUser?: UserInfo | null
  onClick?: (place: Place) => void
  onDelete?: (placeId: number) => void
  className?: string
  isPreview?: boolean
}

export function PlaceCard({ place, currentUser, onClick, onDelete, className, isPreview }: PlaceCardProps) {
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

  type DivProps = { role?: string; tabIndex?: number }
  const ContainerProps: DivProps = isPreview ? {} : { role: 'button', tabIndex: 0 }
  const googleMapsUrl = getGoogleMapsUrl(place.latitude, place.longitude, place.locationName)

  return (
    <div
      {...ContainerProps}
      onClick={isPreview ? undefined : () => onClick?.(place)}
      onKeyDown={isPreview ? undefined : (e) => e.key === 'Enter' && onClick?.(place)}
      className={cn(
        'group bg-card border border-border/50 rounded-3xl p-5 md:p-6 hover:shadow-xl hover:shadow-primary/5 hover:border-primary/20 transition-all duration-300 flex flex-col',
        className,
      )}
    >
      <div className="flex items-center justify-between mb-4">
        <div className="flex items-center gap-3 min-w-0">
          <UserAvatar url={place.userPhotoUrl} username={place.userName} className="h-10 w-10" />
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
        <h3 className={`font-bold text-xl md:text-2xl text-foreground ${place.locationName ? 'mb-2' : 'mb-2'} wrap-break-word break-all whitespace-normal line-clamp-2`}>
          {place.title}
        </h3>

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
          containerClassName="mb-3 md:px-0"
          imageContainerClassName="h-75 md:h-112.5"
        />

        {place.description && (
          <p className="text-foreground text-sm md:text-base whitespace-normal break-all leading-relaxed line-clamp-2">
            {place.description}
          </p>
        )}
      </div>
    </div>
  )
}

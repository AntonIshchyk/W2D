import { MapPin, Users } from 'lucide-react'
import { cn } from '../lib/utils'
import { PhotoCarousel } from './PhotoCarousel'
import { UserAvatar } from './UserAvatar'
import type { Place } from '../types/places'

interface PlaceCardProps {
  place: Place
  onClick?: (place: Place) => void
  className?: string
  isPreview?: boolean
}

export function PlaceCard({ place, onClick, className, isPreview }: PlaceCardProps) {
  type DivProps = { role?: string; tabIndex?: number }
  const ContainerProps: DivProps = isPreview ? {} : { role: 'button', tabIndex: 0 }
  const googleMapsUrl = place.latitude != null && place.longitude != null
    ? `https://www.google.com/maps/search/?api=1&query=${place.latitude},${place.longitude}`
    : place.locationName
      ? `https://www.google.com/maps/search/?api=1&query=${encodeURIComponent(place.locationName)}`
      : null

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
          <UserAvatar username={place.userName} className="h-10 w-10" />
          <div className="min-w-0">
            <p className="font-semibold text-foreground truncate">{place.userName}</p>
          </div>
        </div>

        {place.communityName && (
          <span className="px-3 py-1 rounded-full text-xs font-bold border bg-primary text-primary-foreground border-primary inline-flex items-center gap-1.5 shrink-0">
            <Users className="h-3 w-3" />
            {place.communityName}
          </span>
        )}
      </div>

      <div className="flex-1">
        <h3 className="font-bold text-xl md:text-2xl text-foreground mb-2 wrap-break-word break-all whitespace-normal line-clamp-2">
          {place.title}
        </h3>

        <p className="text-foreground text-sm md:text-base whitespace-normal break-all leading-relaxed line-clamp-2">
          {place.description}
        </p>

        <PhotoCarousel
          urls={place.photoUrls}
          containerClassName="mt-4 mb-2 md:px-0"
          imageContainerClassName="h-75 md:h-112.5"
        />

        <div className="flex items-center gap-1.5 flex-wrap mt-4 pt-4 border-t border-border/40">
          {place.locationName && (
            googleMapsUrl ? (
              <a
                href={googleMapsUrl}
                target="_blank"
                rel="noreferrer"
                className="flex items-center gap-1.5 text-primary hover:underline"
                onClick={(e) => e.stopPropagation()}
              >
                <MapPin className="h-4 w-4 shrink-0" />
                <span className="text-xs wrap-break-word max-w-56 whitespace-normal">
                  {place.locationName}
                </span>
              </a>
            ) : (
              <span className="flex items-center gap-1.5">
                <MapPin className="h-4 w-4 shrink-0" />
                <span className="text-xs wrap-break-word max-w-56 whitespace-normal">
                  {place.locationName}
                </span>
              </span>
            )
          )}
        </div>
      </div>
    </div>
  )
}

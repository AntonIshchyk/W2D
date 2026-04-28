import { MapPin, Clock, Users } from 'lucide-react'
import { PhotoCarousel } from './PhotoCarousel'
import type { Place } from '../types/places'

interface PlaceCardProps {
  place: Place
  onClick?: (place: Place) => void
  className?: string
}

function formatPlaceDate(dateStr: string) {
  const date = new Date(dateStr)
  return (
    date.toLocaleDateString('en-US', {
      weekday: 'short',
      month: 'short',
      day: 'numeric',
    }) + ' at ' +

    date.toLocaleTimeString('en-US', {
      hour: '2-digit',
      minute: '2-digit',
    })
  )
}

export function PlaceCard({ place, onClick, className }: PlaceCardProps) {
  return (
    <div
      role="button"
      tabIndex={0}
      onClick={() => onClick?.(place)}
      onKeyDown={(e) => e.key === 'Enter' && onClick?.(place)}
      className={className}
    >
      <PhotoCarousel
        urls={place.photoUrls}
        containerClassName="m-0"
        imageContainerClassName="h-52"
      />

      <div className="px-4 py-3.5 space-y-2.5">
        {place.communityName && (
          <span className="inline-flex items-center gap-1.5 text-xs font-medium bg-primary/10 text-primary px-2.5 py-0.5 rounded-full">
            <Users className="h-3 w-3" />
            {place.communityName}
          </span>
        )}

        <h1 className="font-semibold text-l leading-snug text-foreground">
          {place.title}
        </h1>

        <p className="text-sm leading-relaxed line-clamp-2">
          {place.description}
        </p>

        <div className="flex items-center gap-1.5 flex-wrap">
          <Clock className="h-3 w-3  shrink-0" />
          <span className="text-xs">
            {formatPlaceDate(place.scheduledAt)}
          </span>
          {place.locationName && (
            <span className="flex items-center gap-1.5">
              <MapPin className="h-3 w-3 shrink-0" />
              <span className="text-xs truncate">
                {place.locationName}
              </span>
            </span>
          )}
        </div>
      </div>
    </div>
  )
}

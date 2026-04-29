import { MapPin, Users } from 'lucide-react'
import { PhotoCarousel } from './PhotoCarousel'
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

  return (
    <div
      {...ContainerProps}
      onClick={isPreview ? undefined : () => onClick?.(place)}
      onKeyDown={isPreview ? undefined : (e) => e.key === 'Enter' && onClick?.(place)}
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

        <h1 className="font-bold text-xl md:text-2xl leading-snug text-foreground wrap-break-word break-all whitespace-normal line-clamp-2">
          {place.title}
        </h1>

        <p className="text-sm leading-relaxed whitespace-normal break-all line-clamp-2">
          {place.description}
        </p>

        <div className="flex items-center gap-1.5 flex-wrap">
          {place.locationName && (
            <span className="flex items-center gap-1.5">
              <MapPin className="h-4 w-4 shrink-0" />
              <span className="text-xs wrap-break-word max-w-56 whitespace-normal">
                {place.locationName}
              </span>
            </span>
          )}
        </div>
      </div>
    </div>
  )
}

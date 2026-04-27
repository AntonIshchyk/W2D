import { MapPin, Clock, Users } from 'lucide-react'
import { cn } from '../lib/utils'
import { PhotoCarousel } from './PhotoCarousel'
import type { Event } from '../types/events'

interface EventCardProps {
  event: Event
  onClick?: (event: Event) => void
  className?: string
}

function formatEventDate(dateStr: string) {
  const date = new Date(dateStr)
  return (
    date.toLocaleDateString('en-US', {
      weekday: 'short',
      month: 'short',
      day: 'numeric',
    }) +
    ' · ' +
    date.toLocaleTimeString('en-US', {
      hour: '2-digit',
      minute: '2-digit',
    })
  )
}

export function EventCard({ event, onClick, className }: EventCardProps) {
  return (
    <div
      role="button"
      tabIndex={0}
      onClick={() => onClick?.(event)}
      onKeyDown={(e) => e.key === 'Enter' && onClick?.(event)}
      className={cn(
        'group rounded-2xl border bg-card overflow-hidden cursor-pointer',
        'transition-colors duration-150 hover:border-border/80',
        'focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-primary',
        className,
      )}
    >
      <PhotoCarousel
        urls={event.photoUrls}
        containerClassName="m-0"
        imageContainerClassName="h-52"
      />

      <div className="px-4 py-3.5 space-y-2.5">

        {event.communityName && (
          <span className="inline-flex items-center gap-1.5 text-xs font-medium bg-primary/10 text-primary px-2.5 py-0.5 rounded-full">
            <Users className="h-3 w-3" />
            {event.communityName}
          </span>
        )}

        <h3 className="font-semibold text-[15px] leading-snug text-foreground">
          {event.title}
        </h3>

        <p className="text-sm text-muted-foreground leading-relaxed line-clamp-2">
          {event.description}
        </p>

        <div className="flex items-center gap-1.5 flex-wrap">
          <Clock className="h-3 w-3 text-muted-foreground shrink-0" />
          <span className="text-xs text-muted-foreground">
            {formatEventDate(event.scheduledAt)}
          </span>
          {event.locationName && (
            <>
              <span className="w-1 h-1 rounded-full bg-muted-foreground/35 shrink-0" />
              <MapPin className="h-3 w-3 text-muted-foreground shrink-0" />
              <span className="text-xs text-muted-foreground truncate">
                {event.locationName}
              </span>
            </>
          )}
        </div>
      </div>
    </div>
  )
}
import { useNavigate } from 'react-router-dom'
import { Calendar } from 'lucide-react'
import { format } from 'date-fns'
import { Card, CardContent, CardHeader, CardTitle, CardDescription } from './ui/card'
import type { Event } from '../types/events'

interface EventCardProps {
  event: Event
}

export function EventCard({ event }: EventCardProps) {
  const navigate = useNavigate()
  return (
    <Card
      className="flex flex-col h-full hover:shadow-sm transition-shadow cursor-pointer"
      onClick={() => navigate(`/events/${event.id}`)}
    >
      <CardHeader className="pb-2">
        <CardTitle className="text-base leading-snug line-clamp-2">{event.title}</CardTitle>
        <CardDescription className="line-clamp-2 text-xs mt-1">{event.description}</CardDescription>
      </CardHeader>
      <CardContent className="flex-1 space-y-3 pb-3">
        <div className="flex items-center gap-1.5 text-xs text-muted-foreground">
          <Calendar className="h-3.5 w-3.5 shrink-0" />
          <span>{format(new Date(event.scheduledAt), 'EEE, MMM d · h:mm a')}</span>
        </div>
        {event.communityName && (
          <span className="text-xs text-muted-foreground">{event.communityName}</span>
        )}
      </CardContent>
    </Card>
  )
}

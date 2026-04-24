import { useQuery } from '@tanstack/react-query'
import { useParams, useNavigate, Link } from 'react-router-dom'
import {
  Calendar, ArrowLeft,
} from 'lucide-react'
import { format } from 'date-fns'
import { Card, CardContent } from './ui/card'
import { Button } from './ui/button'
import { Skeleton } from './ui/skeleton'
import { PageLayout } from './Navbar'
import {
  fetchEvent,
} from '../api/events'
import { cn } from '../lib/utils'

export function EventDetail() {
  const { id } = useParams<{ id: string }>()
  const eventId = parseInt(id ?? '', 10)
  const navigate = useNavigate()

  const { data: event, isLoading, isError } = useQuery({
    queryKey: ['event', eventId],
    queryFn: () => fetchEvent(eventId),
    enabled: !isNaN(eventId),
    retry: false,
  })

  if (isLoading) {
    return (
      <PageLayout>
        <div className="max-w-2xl mx-auto space-y-4">
          <Skeleton className="h-8 w-2/3" />
          <Skeleton className="h-4 w-full" />
          <Skeleton className="h-4 w-3/4" />
          <Skeleton className="h-32 w-full" />
        </div>
      </PageLayout>
    )
  }

  if (isError || !event) {
    return (
      <PageLayout>
        <div className="max-w-2xl mx-auto text-center py-16">
          <p className="text-muted-foreground">Event not found.</p>
          <Button variant="outline" className="mt-4" onClick={() => navigate('/events')}>
            Back to events
          </Button>
        </div>
      </PageLayout>
    )
  }

  const isPast      = new Date(event.scheduledAt) < new Date()

  return (
    <PageLayout>
      <div className="max-w-2xl mx-auto">
        {/* Back */}
        <Button
          variant="ghost"
          size="sm"
          className="mb-4 -ml-2 gap-1.5 text-muted-foreground"
          onClick={() => navigate(-1)}
        >
          <ArrowLeft className="h-4 w-4" />
          Back
        </Button>

        {/* Header */}
        <div className="flex items-start justify-between gap-4 mb-2">
          <div>
            <h1 className="text-2xl font-bold leading-tight">{event.title}</h1>
            <p className="text-sm text-muted-foreground mt-1">
              Organised by{' '}
              <span className="font-medium text-foreground">{event.organizerName}</span>
            </p>
          </div>
        </div>

        {/* Community link */}
        {event.communityName && (
          <div className="mb-4">
            <Link to="/communities" className="text-sm text-primary hover:underline">
              {event.communityName}
            </Link>
          </div>
        )}

        {/* Description */}
        <p className="text-sm text-muted-foreground whitespace-pre-wrap mb-6">{event.description}</p>

        {/* Meta card */}
        <Card className="mb-6">
          <CardContent className="pt-4 space-y-3">
            {/* Date */}
            <div className="flex items-center gap-2 text-sm">
              <Calendar className="h-4 w-4 text-muted-foreground shrink-0" />
              <span className={cn(isPast && 'line-through text-muted-foreground')}>
                {format(new Date(event.scheduledAt), 'EEEE, MMMM d, yyyy · h:mm a')}
              </span>
              {isPast && <span className="text-xs text-muted-foreground">(past)</span>}
            </div>
          </CardContent>
        </Card>
      </div>
    </PageLayout>
  )
}

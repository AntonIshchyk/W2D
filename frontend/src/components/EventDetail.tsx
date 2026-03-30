import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useState } from 'react'
import { useParams, useNavigate, Link } from 'react-router-dom'
import {
  Calendar, Users, ArrowLeft,
  Edit2, Trash2, Clock
} from 'lucide-react'
import { toast } from 'sonner'
import { format } from 'date-fns'
import { Card, CardContent } from './ui/card'
import { Badge } from './ui/badge'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Textarea } from './ui/textarea'
import { Label } from './ui/label'
import { Skeleton } from './ui/skeleton'
import {
  Dialog, DialogContent, DialogHeader, DialogTitle,
  DialogDescription, DialogFooter
} from './ui/dialog'
import { PageLayout } from './Navbar'
import {
  cancelRsvp,
  deleteEvent,
  fetchAttendees,
  fetchEvent,
  rsvpEvent,
  updateEvent,
} from '../features/events/api'
import { cn } from '../lib/utils'
import { useCurrentUser } from '../hooks/useCurrentUser'
import type { Event, UpdateEventRequest } from '../types/events'

// ── EditEventDialog ───────────────────────────────────────────────────────────

function EditEventDialog({ event, onClose }: { event: Event; onClose: () => void }) {
  const queryClient = useQueryClient()
  const [title, setTitle]           = useState(event.title)
  const [description, setDescription] = useState(event.description)
  const [scheduledAt, setScheduledAt] = useState(
    // Convert ISO to datetime-local format
    event.scheduledAt ? format(new Date(event.scheduledAt), "yyyy-MM-dd'T'HH:mm") : ''
  )
  const [maxAttendees, setMaxAttendees] = useState<string>(
    event.maxAttendees != null ? String(event.maxAttendees) : ''
  )

  const mutation = useMutation({
    mutationFn: (data: UpdateEventRequest) => updateEvent(event.id, data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['event', event.id] })
      queryClient.invalidateQueries({ queryKey: ['events'] })
      toast.success('Event updated')
      onClose()
    },
    onError: (err: Error) => toast.error(err.message),
  })

  function handleSubmit(e: React.FormEvent) {
    e.preventDefault()
    if (!title.trim() || !description.trim() || !scheduledAt) {
      toast.error('Title, description, and date are required')
      return
    }
    const parsedMaxAttendees = maxAttendees ? parseInt(maxAttendees, 10) : null
    const safeMaxAttendees = parsedMaxAttendees && parsedMaxAttendees > 0 ? parsedMaxAttendees : null

    mutation.mutate({
      title: title.trim(),
      description: description.trim(),
      scheduledAt: new Date(scheduledAt).toISOString(),
      maxAttendees: safeMaxAttendees,
    })
  }

  return (
    <Dialog open onOpenChange={onClose}>
      <DialogContent className="max-w-lg max-h-[90vh] overflow-y-auto">
        <DialogHeader>
          <DialogTitle>Edit event</DialogTitle>
        </DialogHeader>
        <form onSubmit={handleSubmit} className="space-y-4 mt-2">
          <div className="space-y-1.5">
            <Label htmlFor="edit-title">Title *</Label>
            <Input id="edit-title" value={title} onChange={e => setTitle(e.target.value)} maxLength={120} />
          </div>
          <div className="space-y-1.5">
            <Label htmlFor="edit-desc">Description *</Label>
            <Textarea id="edit-desc" value={description} onChange={e => setDescription(e.target.value)} rows={3} maxLength={2000} />
          </div>
          <div className="space-y-1.5">
            <Label htmlFor="edit-date">Date & time *</Label>
            <Input id="edit-date" type="datetime-local" value={scheduledAt} onChange={e => setScheduledAt(e.target.value)} />
          </div>
          <div className="space-y-1.5">
            <Label htmlFor="edit-max">Max attendees</Label>
            <Input id="edit-max" type="number" min={1} placeholder="Unlimited" value={maxAttendees} onChange={e => setMaxAttendees(e.target.value)} />
          </div>
          <div className="flex justify-end gap-2 pt-2">
            <Button type="button" variant="outline" onClick={onClose}>Cancel</Button>
            <Button type="submit" disabled={mutation.isPending}>
              {mutation.isPending ? 'Saving…' : 'Save changes'}
            </Button>
          </div>
        </form>
      </DialogContent>
    </Dialog>
  )
}

// ── DeleteConfirmDialog ───────────────────────────────────────────────────────

function DeleteConfirmDialog({ eventId, onClose }: { eventId: number; onClose: () => void }) {
  const navigate    = useNavigate()
  const queryClient = useQueryClient()

  const mutation = useMutation({
    mutationFn: () => deleteEvent(eventId),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['events'] })
      toast.success('Event deleted')
      navigate('/events')
    },
    onError: (err: Error) => toast.error(err.message),
  })

  return (
    <Dialog open onOpenChange={onClose}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Delete event</DialogTitle>
          <DialogDescription>
            This will permanently delete the event and all RSVPs. This cannot be undone.
          </DialogDescription>
        </DialogHeader>
        <DialogFooter>
          <Button variant="outline" onClick={onClose}>Cancel</Button>
          <Button variant="destructive" disabled={mutation.isPending} onClick={() => mutation.mutate()}>
            {mutation.isPending ? 'Deleting…' : 'Delete'}
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  )
}

// ── Main component ────────────────────────────────────────────────────────────

export function EventDetail() {
  const { id } = useParams<{ id: string }>()
  const eventId = parseInt(id ?? '', 10)
  const navigate = useNavigate()
  const queryClient = useQueryClient()
  const [showEdit, setShowEdit]     = useState(false)
  const [showDelete, setShowDelete] = useState(false)

  const { data: currentUser } = useCurrentUser()

  const { data: event, isLoading, isError } = useQuery({
    queryKey: ['event', eventId],
    queryFn: () => fetchEvent(eventId),
    enabled: !isNaN(eventId),
    retry: false,
  })

  const { data: attendees } = useQuery({
    queryKey: ['event-attendees', eventId],
    queryFn: () => fetchAttendees(eventId),
    enabled: !isNaN(eventId),
  })

  const rsvpMutation = useMutation({
    mutationFn: () => rsvpEvent(eventId),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['event', eventId] })
      queryClient.invalidateQueries({ queryKey: ['event-attendees', eventId] })
      queryClient.invalidateQueries({ queryKey: ['events'] })
      toast.success('You\'re in!')
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const cancelMutation = useMutation({
    mutationFn: () => cancelRsvp(eventId),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['event', eventId] })
      queryClient.invalidateQueries({ queryKey: ['event-attendees', eventId] })
      queryClient.invalidateQueries({ queryKey: ['events'] })
      toast.success('RSVP cancelled')
    },
    onError: (err: Error) => toast.error(err.message),
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
    const isCancelled = event.status === 'Cancelled'
    const isOrganizer = currentUser?.userId === event.organizerId
    const hasRsvp     = event.currentUserRsvp === 'Confirmed' || event.currentUserRsvp === 'Waitlisted'
    const spotsLeft   = event.maxAttendees != null
      ? Math.max(0, event.maxAttendees - event.attendeeCount)
      : null
    const isFull      = spotsLeft === 0
  const confirmed  = attendees?.filter(a => a.status === 'Confirmed')  ?? []
  const waitlisted = attendees?.filter(a => a.status === 'Waitlisted') ?? []

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
          <div className="flex items-center gap-2 shrink-0">
            {isOrganizer && (
              <>
                <Button variant="outline" size="icon" className="h-8 w-8" onClick={() => setShowEdit(true)}>
                  <Edit2 className="h-3.5 w-3.5" />
                </Button>
                <Button variant="outline" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => setShowDelete(true)}>
                  <Trash2 className="h-3.5 w-3.5" />
                </Button>
              </>
            )}
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

            {/* Attendees */}
            <div className="flex items-center gap-2 text-sm">
              <Users className="h-4 w-4 text-muted-foreground shrink-0" />
              <span>
                <span className="font-medium">{event.attendeeCount}</span> going
                {spotsLeft !== null && (
                  <span className={cn('ml-1', spotsLeft === 0 ? 'text-destructive' : 'text-muted-foreground')}>
                    · {spotsLeft} spot{spotsLeft !== 1 ? 's' : ''} left
                  </span>
                )}
                {waitlisted.length > 0 && (
                  <span className="ml-1 text-muted-foreground">
                    · {waitlisted.length} waitlisted
                  </span>
                )}
              </span>
            </div>
          </CardContent>
        </Card>

        {/* Tags */}
        {event.tags.length > 0 && (
          <div className="flex flex-wrap gap-1.5 mb-6">
            {event.tags.map(tag => (
              <Badge key={tag.id} variant="outline" className="text-xs font-normal">
                {tag.name}
              </Badge>
            ))}
          </div>
        )}

        {/* RSVP section */}
        {!isCancelled && currentUser && !isOrganizer && (
          <div className="mb-8">
            {event.currentUserRsvp === 'Confirmed' && (
              <div className="flex items-center gap-3">
                <Badge variant="default" className="bg-green-600 text-sm px-3 py-1">You're going!</Badge>
                <Button
                  variant="outline"
                  size="sm"
                  disabled={cancelMutation.isPending}
                  onClick={() => cancelMutation.mutate()}
                >
                  Cancel RSVP
                </Button>
              </div>
            )}
            {event.currentUserRsvp === 'Waitlisted' && (
              <div className="flex items-center gap-3">
                <Badge variant="secondary" className="text-sm px-3 py-1">You're on the waitlist</Badge>
                <Button
                  variant="outline"
                  size="sm"
                  disabled={cancelMutation.isPending}
                  onClick={() => cancelMutation.mutate()}
                >
                  Leave waitlist
                </Button>
              </div>
            )}
            {!hasRsvp && (
              <Button
                size="sm"
                disabled={rsvpMutation.isPending || (isFull && spotsLeft === 0) || isPast}
                onClick={() => rsvpMutation.mutate()}
              >
                {isFull ? 'Join waitlist' : 'RSVP to this event'}
              </Button>
            )}
          </div>
        )}
        {isOrganizer && (
          <p className="text-sm text-muted-foreground italic mb-8">You are organising this event.</p>
        )}

        {/* Attendees list */}
        {(confirmed.length > 0 || waitlisted.length > 0) && (
          <div className="space-y-4">
            {confirmed.length > 0 && (
              <div>
                <h2 className="text-sm font-semibold mb-2 flex items-center gap-1.5">
                  <Users className="h-4 w-4" />
                  Attendees ({confirmed.length})
                </h2>
                <div className="flex flex-wrap gap-2">
                  {confirmed.map(a => (
                    <div key={a.userId} className="flex items-center gap-1.5 text-xs bg-muted rounded-full px-3 py-1">
                      {a.userName ?? 'Anonymous'}
                    </div>
                  ))}
                </div>
              </div>
            )}
            {waitlisted.length > 0 && (
              <div>
                <h2 className="text-sm font-semibold mb-2 flex items-center gap-1.5 text-muted-foreground">
                  <Clock className="h-4 w-4" />
                  Waitlist ({waitlisted.length})
                </h2>
                <div className="flex flex-wrap gap-2">
                  {waitlisted.map(a => (
                    <div key={a.userId} className="flex items-center gap-1.5 text-xs bg-muted/50 rounded-full px-3 py-1 text-muted-foreground">
                      {a.userName ?? 'Anonymous'}
                    </div>
                  ))}
                </div>
              </div>
            )}
          </div>
        )}
      </div>

      {showEdit && <EditEventDialog event={event} onClose={() => setShowEdit(false)} />}
      {showDelete && <DeleteConfirmDialog eventId={event.id} onClose={() => setShowDelete(false)} />}
    </PageLayout>
  )
}


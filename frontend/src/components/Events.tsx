import { useInfiniteQuery, useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback, useMemo } from 'react'
import { useNavigate } from 'react-router-dom'
import {
  Calendar, Users, Plus, X,
  ChevronsUpDown, Check, Clock, CalendarDays
} from 'lucide-react'
import { toast } from 'sonner'
import { format } from 'date-fns'
import { Card, CardContent, CardHeader, CardTitle, CardDescription } from './ui/card'
import { Badge } from './ui/badge'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Textarea } from './ui/textarea'
import { Label } from './ui/label'
import { Skeleton } from './ui/skeleton'
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogTrigger } from './ui/dialog'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PAGINATION } from '../config/constants'
import { EmptyState } from './ui/empty-state'
import { LoadingSpinner } from './ui/loading-spinner'
import { cn } from '../lib/utils'
import { useCurrentUser } from '../hooks/useCurrentUser'

// ── Types ─────────────────────────────────────────────────────────────────────

interface Tag {
  id: number
  name: string
}

interface Community {
  id: number
  name: string
}

interface Event {
  id: number
  title: string
  description: string
  organizerId: number
  organizerName: string
  topicId: number | null
  communityName: string | null
  tags: Tag[]
  scheduledAt: string
  maxAttendees: number | null
  attendeeCount: number
  status: string
  currentUserRsvp: string | null
  createdAt: string
  updatedAt: string
}

interface ScrollResult {
  items: Event[]
  nextCursor: number | null
  hasMore: boolean
  totalCount: number
}

interface CreateEventRequest {
  title: string
  description: string
  scheduledAt: string
  topicId?: number | null
  tagIds?: number[]
  maxAttendees?: number | null
}

// ── API helpers ───────────────────────────────────────────────────────────────

async function fetchEvents(
  cursor: number | null,
  topicId?: number,
  status?: string,
  upcomingOnly?: boolean
): Promise<ScrollResult> {
  const params = new URLSearchParams({ limit: PAGINATION.DEFAULT_PAGE_SIZE.toString() })
  if (cursor !== null) params.append('cursor', cursor.toString())
  if (topicId) params.append('topicId', topicId.toString())
  if (status) params.append('status', status)
  if (upcomingOnly) params.append('upcomingOnly', 'true')

  const response = await fetch(`${API_ENDPOINTS.events.base}?${params}`, {
    headers: getAuthHeaders(),
  })
  if (!response.ok) throw new Error('Failed to fetch events')
  return response.json()
}

async function fetchCommunities(): Promise<Community[]> {
  const response = await fetch(
    `${API_ENDPOINTS.communities.base}?limit=${PAGINATION.COMMUNITIES_FETCH_SIZE}`,
    { headers: getAuthHeaders() }
  )
  if (!response.ok) throw new Error('Failed to fetch communities')
  return response.json()
}

async function fetchTags(): Promise<Tag[]> {
  const response = await fetch(API_ENDPOINTS.tags.base, { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch tags')
  return response.json()
}

async function createEvent(data: CreateEventRequest): Promise<Event> {
  const response = await fetch(API_ENDPOINTS.events.base, {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(data),
  })
  if (!response.ok) {
    let msg = 'Failed to create event'
    try { msg = (await response.json()).message || msg } catch {}
    throw new Error(msg)
  }
  return response.json()
}

async function rsvpEvent(eventId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.events.rsvp(eventId), {
    method: 'POST',
    headers: getAuthHeaders(),
  })
  if (!response.ok) {
    let msg = 'Failed to RSVP'
    try { msg = (await response.json()).message || msg } catch {}
    throw new Error(msg)
  }
}

async function cancelRsvp(eventId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.events.rsvp(eventId), {
    method: 'DELETE',
    headers: getAuthHeaders(),
  })
  if (!response.ok) {
    let msg = 'Failed to cancel RSVP'
    try { msg = (await response.json()).message || msg } catch {}
    throw new Error(msg)
  }
}

// ── EventCard ─────────────────────────────────────────────────────────────────

function EventCard({ event, currentUserId }: { event: Event; currentUserId?: number }) {
  const queryClient = useQueryClient()
  const navigate    = useNavigate()

  const rsvpMutation = useMutation({
    mutationFn: () => rsvpEvent(event.id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['events'] })
      queryClient.invalidateQueries({ queryKey: ['event', event.id] })
      toast.success('You\'re in!')
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const cancelMutation = useMutation({
    mutationFn: () => cancelRsvp(event.id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['events'] })
      queryClient.invalidateQueries({ queryKey: ['event', event.id] })
      toast.success('RSVP cancelled')
    },
    onError: (err: Error) => toast.error(err.message),
  })

  const isPast     = new Date(event.scheduledAt) < new Date()
  const isFull     = event.status === 'Full'
  const isCancelled = event.status === 'Cancelled'
  const isOrganizer = currentUserId === event.organizerId
  const hasRsvp     = event.currentUserRsvp === 'Confirmed' || event.currentUserRsvp === 'Waitlisted'

  const spotsLeft =
    event.maxAttendees != null
      ? Math.max(0, event.maxAttendees - event.attendeeCount)
      : null

  return (
    <Card
      className={cn(
        'flex flex-col h-full hover:shadow-sm transition-shadow cursor-pointer',
        isCancelled && 'opacity-60'
      )}
      onClick={() => navigate(`/events/${event.id}`)}
    >
      <CardHeader className="pb-2">
        <div className="flex items-start justify-between gap-2">
          <CardTitle className="text-base leading-snug line-clamp-2">{event.title}</CardTitle>
          <div className="flex flex-col items-end gap-1 shrink-0">
            {event.status !== 'Open' && (
              <Badge
                variant={isCancelled ? 'destructive' : event.status === 'Full' ? 'secondary' : 'outline'}
                className="text-xs"
              >
                {event.status}
              </Badge>
            )}
            {event.currentUserRsvp === 'Confirmed' && (
              <Badge variant="default" className="text-xs bg-green-600">Going</Badge>
            )}
            {event.currentUserRsvp === 'Waitlisted' && (
              <Badge variant="secondary" className="text-xs">Waitlisted</Badge>
            )}
          </div>
        </div>
        <CardDescription className="line-clamp-2 text-xs mt-1">{event.description}</CardDescription>
      </CardHeader>

      <CardContent className="flex-1 space-y-3 pb-3">
        {/* Date & time */}
        <div className="flex items-center gap-1.5 text-xs text-muted-foreground">
          <Calendar className="h-3.5 w-3.5 shrink-0" />
          <span className={cn(isPast && 'line-through')}>
            {format(new Date(event.scheduledAt), 'EEE, MMM d · h:mm a')}
          </span>
          {isPast && <span className="text-muted-foreground/60">(past)</span>}
        </div>

        {/* Attendees & community */}
        <div className="flex flex-wrap gap-x-3 gap-y-1 text-xs text-muted-foreground">
          <span className="flex items-center gap-1">
            <Users className="h-3.5 w-3.5" />
            {event.attendeeCount} going
            {spotsLeft !== null && (
              <span className={cn(spotsLeft === 0 ? 'text-destructive' : 'text-muted-foreground')}>
                {' '}· {spotsLeft} spot{spotsLeft !== 1 ? 's' : ''} left
              </span>
            )}
          </span>
          {event.communityName && (
            <span className="text-muted-foreground">
              {event.communityName}
            </span>
          )}
        </div>

        {/* Tags */}
        {event.tags.length > 0 && (
          <div className="flex gap-1 flex-wrap pt-1 border-t">
            {event.tags.slice(0, 3).map(tag => (
              <Badge key={tag.id} variant="outline" className="text-xs font-normal">
                {tag.name}
              </Badge>
            ))}
            {event.tags.length > 3 && (
              <Badge variant="outline" className="text-xs text-muted-foreground">
                +{event.tags.length - 3}
              </Badge>
            )}
          </div>
        )}

        {/* RSVP button */}
        {!isCancelled && !isOrganizer && currentUserId && (
          <div
            className="pt-2 border-t"
            onClick={e => e.stopPropagation()}
          >
            {hasRsvp ? (
              <Button
                variant="outline"
                size="sm"
                className="w-full text-xs"
                disabled={cancelMutation.isPending}
                onClick={() => cancelMutation.mutate()}
              >
                {event.currentUserRsvp === 'Waitlisted' ? 'Leave waitlist' : 'Cancel RSVP'}
              </Button>
            ) : (
              <Button
                size="sm"
                className="w-full text-xs"
                disabled={rsvpMutation.isPending || (isFull && !isPast)}
                onClick={() => rsvpMutation.mutate()}
              >
                {isFull ? 'Join waitlist' : 'RSVP'}
              </Button>
            )}
          </div>
        )}
        {isOrganizer && (
          <div className="pt-2 border-t">
            <span className="text-xs text-muted-foreground italic">You're organising this</span>
          </div>
        )}
      </CardContent>
    </Card>
  )
}

// ── CreateEventDialog ─────────────────────────────────────────────────────────

function CreateEventDialog({
  communities,
  tags,
}: {
  communities: Community[]
  tags: Tag[]
}) {
  const queryClient = useQueryClient()
  const [open, setOpen]             = useState(false)
  const [title, setTitle]           = useState('')
  const [description, setDescription] = useState('')
  const [scheduledAt, setScheduledAt] = useState('')
  const [maxAttendees, setMaxAttendees] = useState<string>('')
  const [topicId, setCommunityId] = useState<number | null>(null)
  const [communityOpen, setCommunityOpen] = useState(false)
  const [selectedTagIds, setSelectedTagIds] = useState<number[]>([])
  const [tagsOpen, setTagsOpen] = useState(false)

  const mutation = useMutation({
    mutationFn: createEvent,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['events'] })
      toast.success('Event created!')
      setOpen(false)
      resetForm()
    },
    onError: (err: Error) => toast.error(err.message),
  })

  function resetForm() {
    setTitle('')
    setDescription('')
    setScheduledAt('')
    setMaxAttendees('')
    setCommunityId(null)
    setSelectedTagIds([])
  }

  function handleSubmit(e: React.FormEvent) {
    e.preventDefault()
    if (!title.trim() || !description.trim() || !scheduledAt) {
      toast.error('Title, description, and date are required')
      return
    }
    mutation.mutate({
      title: title.trim(),
      description: description.trim(),
      scheduledAt: new Date(scheduledAt).toISOString(),
      topicId: topicId ?? null,
      tagIds: selectedTagIds,
      maxAttendees: maxAttendees ? parseInt(maxAttendees, 10) : null,
    })
  }

  const toggleTag = (id: number) =>
    setSelectedTagIds(prev => prev.includes(id) ? prev.filter(t => t !== id) : [...prev, id])

  const selectedCommunity = communities.find(a => a.id === topicId)

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button size="sm" className="gap-1.5">
          <Plus className="h-4 w-4" />
          New event
        </Button>
      </DialogTrigger>
      <DialogContent className="max-w-lg max-h-[90vh] overflow-y-auto">
        <DialogHeader>
          <DialogTitle>Create an event</DialogTitle>
        </DialogHeader>
        <form onSubmit={handleSubmit} className="space-y-4 mt-2">
          {/* Title */}
          <div className="space-y-1.5">
            <Label htmlFor="ev-title">Title *</Label>
            <Input
              id="ev-title"
              placeholder="e.g. Sunday morning hike"
              value={title}
              onChange={e => setTitle(e.target.value)}
              maxLength={120}
            />
          </div>

          {/* Description */}
          <div className="space-y-1.5">
            <Label htmlFor="ev-desc">Description *</Label>
            <Textarea
              id="ev-desc"
              placeholder="What's the plan?"
              value={description}
              onChange={e => setDescription(e.target.value)}
              rows={3}
              maxLength={2000}
            />
          </div>

          {/* Date & time */}
          <div className="space-y-1.5">
            <Label htmlFor="ev-date">Date & time *</Label>
            <Input
              id="ev-date"
              type="datetime-local"
              value={scheduledAt}
              onChange={e => setScheduledAt(e.target.value)}
            />
          </div>

          {/* Max attendees */}
          <div className="space-y-1.5">
            <Label htmlFor="ev-max">Max attendees (optional)</Label>
            <Input
              id="ev-max"
              type="number"
              min={1}
              placeholder="Unlimited"
              value={maxAttendees}
              onChange={e => setMaxAttendees(e.target.value)}
            />
          </div>

          {/* Community (optional) */}
          <div className="space-y-1.5">
            <Label>Community (optional)</Label>
            <Popover open={communityOpen} onOpenChange={setCommunityOpen}>
              <PopoverTrigger asChild>
                <Button variant="outline" role="combobox" className="w-full justify-between font-normal">
                  {selectedCommunity ? selectedCommunity.name : 'Select community...'}
                  <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
                </Button>
              </PopoverTrigger>
              <PopoverContent className="w-full p-0">
                <Command>
                  <CommandInput placeholder="Search communities…" />
                  <CommandList>
                    <CommandEmpty>No communities found.</CommandEmpty>
                    <CommandGroup>
                      <CommandItem
                        value="__none__"
                        onSelect={() => { setCommunityId(null); setCommunityOpen(false) }}
                      >
                        <Check className={cn('mr-2 h-4 w-4', topicId === null ? 'opacity-100' : 'opacity-0')} />
                        None
                      </CommandItem>
                      {communities.map(a => (
                        <CommandItem
                          key={a.id}
                          value={a.name}
                          onSelect={() => { setCommunityId(a.id); setCommunityOpen(false) }}
                        >
                          <Check className={cn('mr-2 h-4 w-4', topicId === a.id ? 'opacity-100' : 'opacity-0')} />
                          {a.name}
                        </CommandItem>
                      ))}
                    </CommandGroup>
                  </CommandList>
                </Command>
              </PopoverContent>
            </Popover>
          </div>

          {/* Tags */}
          <div className="space-y-1.5">
            <Label>Tags (optional)</Label>
            <Popover open={tagsOpen} onOpenChange={setTagsOpen}>
              <PopoverTrigger asChild>
                <Button variant="outline" role="combobox" className="w-full justify-between font-normal">
                  {selectedTagIds.length > 0
                    ? `${selectedTagIds.length} tag${selectedTagIds.length > 1 ? 's' : ''} selected`
                    : 'Select tags…'}
                  <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
                </Button>
              </PopoverTrigger>
              <PopoverContent className="w-full p-0">
                <Command>
                  <CommandInput placeholder="Search tags…" />
                  <CommandList>
                    <CommandEmpty>No tags found.</CommandEmpty>
                    <CommandGroup>
                      {tags.map(tag => (
                        <CommandItem
                          key={tag.id}
                          value={tag.name}
                          onSelect={() => toggleTag(tag.id)}
                        >
                          <Check className={cn('mr-2 h-4 w-4', selectedTagIds.includes(tag.id) ? 'opacity-100' : 'opacity-0')} />
                          {tag.name}
                        </CommandItem>
                      ))}
                    </CommandGroup>
                  </CommandList>
                </Command>
              </PopoverContent>
            </Popover>
            {selectedTagIds.length > 0 && (
              <div className="flex flex-wrap gap-1 mt-1">
                {tags.filter(t => selectedTagIds.includes(t.id)).map(tag => (
                  <Badge key={tag.id} variant="secondary" className="gap-1 text-xs">
                    {tag.name}
                    <button type="button" onClick={() => toggleTag(tag.id)}>
                      <X className="h-3 w-3" />
                    </button>
                  </Badge>
                ))}
              </div>
            )}
          </div>

          <div className="flex justify-end gap-2 pt-2">
            <Button type="button" variant="outline" onClick={() => setOpen(false)}>
              Cancel
            </Button>
            <Button type="submit" disabled={mutation.isPending}>
              {mutation.isPending ? 'Creating…' : 'Create event'}
            </Button>
          </div>
        </form>
      </DialogContent>
    </Dialog>
  )
}

// ── Main component ────────────────────────────────────────────────────────────

export function Events() {
  const [selectedCommunity, setSelectedCommunity] = useState<number | undefined>(undefined)
  const [statusFilter, setStatusFilter]         = useState<string>('')
  const [upcomingOnly, setUpcomingOnly]         = useState(true)
  const [communityOpen, setCommunityOpen]         = useState(false)
  const observerTarget = useRef<HTMLDivElement>(null)

  const { data: currentUser } = useCurrentUser()

  const { data: communities } = useQuery({ queryKey: ['communities-list'], queryFn: fetchCommunities })
  const { data: tags }       = useQuery({ queryKey: ['tags'], queryFn: fetchTags })

  const { data, fetchNextPage, hasNextPage, isFetchingNextPage, isLoading } = useInfiniteQuery({
    queryKey: ['events', selectedCommunity, statusFilter, upcomingOnly],
    queryFn: ({ pageParam }) =>
      fetchEvents(pageParam, selectedCommunity, statusFilter || undefined, upcomingOnly),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false,
  })

  const handleObserver = useCallback((entries: IntersectionObserverEntry[]) => {
    const [target] = entries
    if (target.isIntersecting && hasNextPage && !isFetchingNextPage) fetchNextPage()
  }, [fetchNextPage, hasNextPage, isFetchingNextPage])

  useEffect(() => {
    const el = observerTarget.current
    const observer = new IntersectionObserver(handleObserver, { threshold: 0.1 })
    if (el) observer.observe(el)
    return () => { if (el) observer.unobserve(el) }
  }, [handleObserver])

  const allEvents  = useMemo(() => data?.pages.flatMap(p => p.items) ?? [], [data?.pages])
  const totalCount = data?.pages[0]?.totalCount ?? 0
  const hasFilters = !!(selectedCommunity || statusFilter || !upcomingOnly)

  const selectedCommunityName = communities?.find(a => a.id === selectedCommunity)?.name

  return (
    <PageLayout>
      {/* Header */}
      <div className="mb-6">
        <div className="flex items-baseline justify-between mb-4">
          <div>
            <h1 className="text-2xl font-bold">Events</h1>
            <p className="text-sm text-muted-foreground mt-0.5">
              {totalCount > 0 ? `${totalCount} event${totalCount !== 1 ? 's' : ''}` : 'Upcoming events near you'}
            </p>
          </div>
          {currentUser && (
            <CreateEventDialog
              communities={communities ?? []}
              tags={tags ?? []}
            />
          )}
        </div>

        {/* Filters */}
        <div className="flex flex-wrap gap-2">
          {/* Upcoming toggle */}
          <Button
            variant={upcomingOnly ? 'default' : 'outline'}
            size="sm"
            className="h-8 text-xs gap-1.5"
            onClick={() => setUpcomingOnly(v => !v)}
          >
            <Clock className="h-3.5 w-3.5" />
            {upcomingOnly ? 'Upcoming' : 'All time'}
          </Button>

          {/* Status filter */}
          <Select value={statusFilter || 'all'} onValueChange={v => setStatusFilter(v === 'all' ? '' : v)}>
            <SelectTrigger className="h-8 text-xs w-32">
              <SelectValue placeholder="Status" />
            </SelectTrigger>
            <SelectContent>
              <SelectItem value="all">All statuses</SelectItem>
              <SelectItem value="Open">Open</SelectItem>
              <SelectItem value="Full">Full</SelectItem>
              <SelectItem value="Cancelled">Cancelled</SelectItem>
              <SelectItem value="Completed">Completed</SelectItem>
            </SelectContent>
          </Select>

          {/* Community filter */}
          <Popover open={communityOpen} onOpenChange={setCommunityOpen}>
            <PopoverTrigger asChild>
              <Button variant="outline" size="sm" className="h-8 text-xs gap-1">
                {selectedCommunityName ?? 'Community'}
                <ChevronsUpDown className="h-3 w-3 shrink-0 opacity-50" />
              </Button>
            </PopoverTrigger>
            <PopoverContent className="w-56 p-0">
              <Command>
                <CommandInput placeholder="Search…" />
                <CommandList>
                  <CommandEmpty>No communities.</CommandEmpty>
                  <CommandGroup>
                    <CommandItem
                      value="__all__"
                      onSelect={() => { setSelectedCommunity(undefined); setCommunityOpen(false) }}
                    >
                      <Check className={cn('mr-2 h-4 w-4', !selectedCommunity ? 'opacity-100' : 'opacity-0')} />
                      All communities
                    </CommandItem>
                    {(communities ?? []).map(a => (
                      <CommandItem
                        key={a.id}
                        value={a.name}
                        onSelect={() => { setSelectedCommunity(a.id); setCommunityOpen(false) }}
                      >
                        <Check className={cn('mr-2 h-4 w-4', selectedCommunity === a.id ? 'opacity-100' : 'opacity-0')} />
                        {a.name}
                      </CommandItem>
                    ))}
                  </CommandGroup>
                </CommandList>
              </Command>
            </PopoverContent>
          </Popover>

          {/* Clear filters */}
          {hasFilters && (
            <Button
              variant="ghost"
              size="sm"
              className="h-8 text-xs"
              onClick={() => {
                setSelectedCommunity(undefined)
                setStatusFilter('')
                setUpcomingOnly(true)
              }}
            >
              <X className="h-3.5 w-3.5 mr-1" />
              Clear
            </Button>
          )}
        </div>
      </div>

      {/* Content */}
      {isLoading ? (
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
          {Array.from({ length: 6 }).map((_, i) => (
            <Card key={i} className="flex flex-col h-52">
              <CardHeader className="pb-2">
                <Skeleton className="h-4 w-3/4" />
                <Skeleton className="h-3 w-full mt-2" />
              </CardHeader>
              <CardContent className="flex-1 space-y-2">
                <Skeleton className="h-3 w-1/2" />
                <Skeleton className="h-3 w-1/3" />
              </CardContent>
            </Card>
          ))}
        </div>
      ) : allEvents.length === 0 ? (
        <EmptyState
          icon={CalendarDays}
          title="No events found"
          description={hasFilters ? 'Try adjusting your filters.' : 'Be the first to organise something!'}
        />
      ) : (
        <>
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
            {allEvents.map(event => (
              <EventCard key={event.id} event={event} currentUserId={currentUser?.userId} />
            ))}
          </div>

          {/* Infinite scroll sentinel */}
          <div ref={observerTarget} className="flex justify-center py-6">
            {isFetchingNextPage && <LoadingSpinner />}
          </div>
        </>
      )}
    </PageLayout>
  )
}


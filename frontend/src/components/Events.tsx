import { useInfiniteQuery, useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback, useMemo } from 'react'
import { useNavigate } from 'react-router-dom'
import {
  Calendar, Users, Plus, X,
  ChevronsUpDown, Check, CalendarDays,
  Search, Loader2, Map as MapIcon, List
} from 'lucide-react'
import { toast } from 'sonner'
import { format } from 'date-fns'
import { Card, CardContent, CardHeader, CardTitle, CardDescription } from './ui/card'
import { Badge } from './ui/badge'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Skeleton } from './ui/skeleton'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { PageLayout } from './Navbar'
import { EventsMap } from './EventsMap'
import { EmptyState } from './ui/empty-state'
import { LoadingSpinner } from './ui/loading-spinner'
import { cn } from '../lib/utils'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { cancelRsvp, fetchCommunities, fetchEvents, rsvpEvent, searchCities } from '../features/events/api'
import type { Event, EventQueryBounds } from '../types/events'

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
  const isOrganizer = currentUserId === event.organizerId
  const hasRsvp     = event.currentUserRsvp === 'Confirmed' || event.currentUserRsvp === 'Waitlisted'

  const spotsLeft =
    event.maxAttendees != null
      ? Math.max(0, event.maxAttendees - event.attendeeCount)
      : null

  return (
    <Card
      className={cn(
        'flex flex-col h-full hover:shadow-sm transition-shadow cursor-pointer'
      )}
      onClick={() => navigate(`/events/${event.id}`)}
    >
      <CardHeader className="pb-2">
        <div className="flex items-start justify-between gap-2">
          <CardTitle className="text-base leading-snug line-clamp-2">{event.title}</CardTitle>
          <div className="flex flex-col items-end gap-1 shrink-0">
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
        {!isOrganizer && currentUserId && (
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
                disabled={rsvpMutation.isPending || (spotsLeft === 0 && !isPast)}
                onClick={() => rsvpMutation.mutate()}
              >
                {spotsLeft === 0 ? 'Join waitlist' : 'RSVP'}
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

export function Events() {
  const navigate = useNavigate()
  const [selectedCommunity, setSelectedCommunity] = useState<number | undefined>(undefined)
  const [upcomingOnly, setUpcomingOnly]         = useState(true)
  const [communityOpen, setCommunityOpen]         = useState(false)
  const [viewMode, setViewMode] = useState<'map' | 'list'>('map')
  const [bounds, setBounds] = useState<EventQueryBounds | undefined>()
  const [mapCenter, setMapCenter] = useState<[number, number]>([51.505, -0.09])
  const [mapZoom, setMapZoom] = useState<number>(12)
  const [searchQuery, setSearchQuery] = useState('')
  const [isSearchingCity, setIsSearchingCity] = useState(false)
  const [selectedEvent, setSelectedEvent] = useState<Event | null>(null)
  
  const observerTarget = useRef<HTMLDivElement>(null)

  const { data: currentUser } = useCurrentUser()

  const { data: communities } = useQuery({ queryKey: ['communities-list'], queryFn: fetchCommunities })

  const { data, fetchNextPage, hasNextPage, isFetchingNextPage, isLoading } = useInfiniteQuery({
    queryKey: ['events', selectedCommunity, upcomingOnly, bounds, viewMode],
    queryFn: ({ pageParam }) =>
      fetchEvents(pageParam, selectedCommunity, upcomingOnly, viewMode === 'map' ? bounds : undefined),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false,
  })

  async function handleSearchCity(e: React.FormEvent) {
    e.preventDefault()
    if (!searchQuery.trim()) return
    setIsSearchingCity(true)
    try {
      const results = await searchCities(searchQuery)
      if (results && results.length > 0) {
        setMapCenter([parseFloat(results[0].lat), parseFloat(results[0].lon)])
        setMapZoom(12)
        toast.success(`Showing events near ${results[0].display_name.split(',')[0]}`)
      } else {
        toast.error('City not found')
      }
    } catch {
      toast.error('Search failed')
    } finally {
      setIsSearchingCity(false)
    }
  }

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
  const hasFilters = !!(selectedCommunity || !upcomingOnly)

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
          <div className="flex gap-2">
            <div className="bg-muted p-1 rounded-md flex items-center">
              <Button
                variant={viewMode === 'map' ? 'secondary' : 'ghost'}
                size="sm"
                className="h-8 px-2"
                onClick={() => setViewMode('map')}
              >
                <MapIcon className="h-4 w-4 mr-1" />
                Map
              </Button>
              <Button
                variant={viewMode === 'list' ? 'secondary' : 'ghost'}
                size="sm"
                className="h-8 px-2"
                onClick={() => setViewMode('list')}
              >
                <List className="h-4 w-4 mr-1" />
                List
              </Button>
            </div>
            {currentUser && (
              <Button onClick={() => navigate('/events/create')} size="sm">
                <Plus className="h-4 w-4 mr-2" />
                Create Event
              </Button>
            )}
          </div>
        </div>

        {/* Filters */}
        <div className="flex flex-col sm:flex-row gap-4 mb-4">
          {viewMode === 'map' && (
            <form onSubmit={handleSearchCity} className="flex gap-2">
              <div className="relative">
                <Input
                  type="text"
                  placeholder="Search city..."
                  value={searchQuery}
                  onChange={(e) => setSearchQuery(e.target.value)}
                  className="pl-8 h-9 text-sm w-48"
                  disabled={isSearchingCity}
                />
                <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground" />
              </div>
              <Button type="submit" size="sm" className="h-9" disabled={isSearchingCity || !searchQuery.trim()}>
                {isSearchingCity ? <Loader2 className="h-4 w-4 animate-spin" /> : 'Search'}
              </Button>
            </form>
          )}
          
          <div className="flex flex-wrap gap-2 items-center">
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
                setUpcomingOnly(true)
              }}
            >
              <X className="h-3.5 w-3.5 mr-1" />
              Clear
            </Button>
          )}
          </div>
        </div>
      </div>

      {/* Content */}
      {viewMode === 'map' ? (
        <div className="flex flex-col md:flex-row gap-4 h-150">
          <div className={cn(
            "rounded-xl overflow-hidden border shadow-sm transition-all duration-300 relative",
            selectedEvent ? "w-full md:w-2/3" : "w-full"
          )}>
            <EventsMap 
              events={allEvents} 
              onBoundsChange={setBounds} 
              center={mapCenter}
              zoom={mapZoom}
              onEventClick={setSelectedEvent}
              selectedEventId={selectedEvent?.id}
            />
          </div>
          {selectedEvent && (
            <div className="w-full md:w-1/3 flex flex-col relative animate-in slide-in-from-right-8 duration-300">
              <Button
                variant="ghost"
                size="icon"
                className="absolute top-2 right-2 z-10 w-8 h-8 rounded-full bg-background/80 hover:bg-background backdrop-blur-sm shadow-sm"
                onClick={() => setSelectedEvent(null)}
              >
                <X className="h-4 w-4" />
              </Button>
              <div className="h-full overflow-y-auto pb-4">
                <EventCard event={selectedEvent} currentUserId={currentUser?.userId} />
              </div>
            </div>
          )}
        </div>
      ) : isLoading ? (
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
          action={currentUser ? {
            label: 'Create Event',
            onClick: () => navigate('/events/create')
          } : undefined}
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


import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import {
  Calendar, Users, Plus, X,
  ChevronsUpDown, Check,
  Search, Loader2, MapPin
} from 'lucide-react'
import { toast } from 'sonner'
import { format } from 'date-fns'
import { Card, CardContent, CardHeader, CardTitle, CardDescription } from './ui/card'
import { Badge } from './ui/badge'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { PageLayout } from './Navbar'
import { EventsMap } from './EventsMap'
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
  const [bounds, setBounds] = useState<EventQueryBounds | undefined>()
  const defaultCenter: [number, number] = [20, 0]
  const defaultZoom = 2

  const [mapCenter, setMapCenter] = useState<[number, number]>(() => {
    try {
      const raw = localStorage.getItem('events.mapState')
      if (raw) {
        const parsed = JSON.parse(raw)
        if (Array.isArray(parsed.center) && typeof parsed.zoom === 'number') {
          return [Number(parsed.center[0]), Number(parsed.center[1])]
        }
      }
    } catch {
      // ignore parse errors
    }
    return defaultCenter
  })

  const [mapZoom, setMapZoom] = useState<number>(() => {
    try {
      const raw = localStorage.getItem('events.mapState')
      if (raw) {
        const parsed = JSON.parse(raw)
        if (typeof parsed.zoom === 'number') return parsed.zoom
      }
    } catch {
      // ignore
    }
    return defaultZoom
  })

  useEffect(() => {
    try {
      localStorage.setItem('events.mapState', JSON.stringify({ center: mapCenter, zoom: mapZoom }))
    } catch {
      // ignore storage errors
    }
  }, [mapCenter, mapZoom])

  const [isGettingLocation, setIsGettingLocation] = useState(false)
  const [searchQuery, setSearchQuery] = useState('')
  const [isSearchingCity, setIsSearchingCity] = useState(false)
  const [selectedEvent, setSelectedEvent] = useState<Event | null>(null)
  
  // Auto-fetch location on mount if permission granted
  useEffect(() => {
    if (!('geolocation' in navigator) || !navigator.permissions) return
    
    let isMounted = true
    navigator.permissions.query({ name: 'geolocation' }).then(result => {
      if (result.state === 'granted' && isMounted) {
        navigator.geolocation.getCurrentPosition(
          (pos) => {
            if (isMounted) {
              setMapCenter([pos.coords.latitude, pos.coords.longitude])
              // We won't automatically zoom in too tight on initial auto-load, just center
              if (mapZoom < 10) setMapZoom(10)
            }
          },
          () => {} // silence errors on auto-fetch
        )
      }
    }).catch(() => {}) // Some browsers throw on query
    
    return () => { isMounted = false }
  }, [])

  const { data: currentUser } = useCurrentUser()

  const { data: communities } = useQuery({ queryKey: ['communities-list'], queryFn: fetchCommunities })

  const { data: allEvents = [] } = useQuery({
    queryKey: ['events', selectedCommunity, upcomingOnly, bounds],
    queryFn: () => fetchEvents(selectedCommunity, upcomingOnly, bounds),
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

  function handleUseMyLocation() {
    if (!('geolocation' in navigator)) {
      toast.error('Geolocation is not supported by your browser')
      return
    }

    setIsGettingLocation(true)
    navigator.geolocation.getCurrentPosition(
      (pos) => {
        setMapCenter([pos.coords.latitude, pos.coords.longitude])
        setMapZoom(12)
        toast.success('Map centered to your location')
        setIsGettingLocation(false)
      },
      (err) => {
        toast.error('Unable to retrieve location')
        setIsGettingLocation(false)
      },
      { enableHighAccuracy: true, timeout: 10000 }
    )
  }

  const totalCount = allEvents?.length ?? 0
  const hasFilters = !!(selectedCommunity || !upcomingOnly)

  const selectedCommunityName = communities?.find(a => a.id === selectedCommunity)?.name

  return (
    <PageLayout fullWidth>
      <div className="relative w-full h-[100dvh] flex flex-col overflow-hidden">
        {/* Floating UI Container */}
        <div className="absolute top-0 left-0 right-0 z-10 p-4 pointer-events-none flex flex-col gap-2">
          {/* Top Bar */}
          <div className="pointer-events-auto flex flex-col xl:flex-row xl:items-center justify-between bg-card/95 backdrop-blur shadow-sm border rounded-xl p-3 gap-3">
            <div className="flex flex-wrap items-center gap-3 xl:gap-6">
              <div>
                <h1 className="text-xl font-bold leading-none">Events</h1>
                <p className="text-xs text-muted-foreground mt-1">
                  {totalCount > 0 ? `${totalCount} event${totalCount !== 1 ? 's' : ''}` : 'Loading...'}
                </p>
              </div>
              
              {/* Search */}
              <form onSubmit={handleSearchCity} className="flex gap-2">
                <div className="relative">
                  <Input
                    type="text"
                    placeholder="Search city..."
                    value={searchQuery}
                    onChange={(e) => setSearchQuery(e.target.value)}
                    className="pl-8 h-9 text-sm w-40 sm:w-48 bg-background"
                    disabled={isSearchingCity}
                  />
                  <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground" />
                </div>
                <Button type="submit" size="sm" className="h-9" disabled={isSearchingCity || !searchQuery.trim()}>
                  {isSearchingCity ? <Loader2 className="h-4 w-4 animate-spin" /> : 'Search'}
                </Button>
                <Button
                  type="button"
                  size="sm"
                  className="h-9"
                  variant="outline"
                  onClick={handleUseMyLocation}
                  disabled={isGettingLocation}
                  title="My location"
                >
                  {isGettingLocation ? <Loader2 className="h-4 w-4 animate-spin" /> : <MapPin className="h-4 w-4" />}
                </Button>
              </form>

              {/* Filters */}
              <div className="flex items-center gap-2">
                <Popover open={communityOpen} onOpenChange={setCommunityOpen}>
                  <PopoverTrigger asChild>
                    <Button variant="outline" size="sm" className="h-9 text-xs gap-1">
                      {selectedCommunityName ?? 'All Communities'}
                      <ChevronsUpDown className="h-3 w-3 shrink-0 opacity-50" />
                    </Button>
                  </PopoverTrigger>
                  <PopoverContent className="w-56 p-0" align="start">
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

                {hasFilters && (
                  <Button
                    variant="ghost"
                    size="sm"
                    className="h-9 text-xs"
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

            {/* Right Side Tools */}
            <div className="flex items-center gap-3">
              {currentUser && (
                <Button onClick={() => navigate('/events/create')} size="sm" className="h-9">
                  <Plus className="h-4 w-4 mr-1 sm:mr-2" />
                  <span className="hidden sm:inline">Create Event</span>
                  <span className="sm:hidden">Create</span>
                </Button>
              )}
            </div>
          </div>
        </div>

        {/* Map Layer */}
        <div className="flex-1 w-full h-full relative z-0">
          <EventsMap 
            events={allEvents} 
            onBoundsChange={setBounds} 
            center={mapCenter}
            zoom={mapZoom}
            onEventClick={setSelectedEvent}
            selectedEventId={selectedEvent?.id}
          />
        </div>

        {/* Floating Selected Event Drawer */}
        {selectedEvent && (
          <div className="absolute top-28 sm:top-24 right-4 sm:bottom-4 w-[calc(100vw-2rem)] sm:w-80 max-h-[60vh] sm:max-h-none z-20 pointer-events-auto bg-card border shadow-2xl rounded-xl overflow-hidden flex flex-col animate-in slide-in-from-right-8 duration-300">
            <Button
              variant="ghost"
              size="icon"
              className="absolute top-2 right-2 z-30 w-8 h-8 rounded-full bg-background/80 hover:bg-background shadow-sm"
              onClick={() => setSelectedEvent(null)}
            >
              <X className="h-4 w-4" />
            </Button>
            <div className="flex-1 overflow-y-auto p-3 sm:p-4">
              <EventCard event={selectedEvent} currentUserId={currentUser?.userId} />
            </div>
          </div>
        )}
      </div>
    </PageLayout>
  )
}


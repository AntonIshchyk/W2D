import { useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef } from 'react'
import { useNavigate } from 'react-router-dom'
import {
  Calendar, Plus, X,
  ChevronsUpDown, Check,
  Search, Loader2, MapPin,
  Map, List,
} from 'lucide-react'
import { toast } from 'sonner'
import { format } from 'date-fns'
import { Card, CardContent, CardHeader, CardTitle, CardDescription } from './ui/card'
import { Button } from './ui/button'
import { Badge } from './ui/badge'
import { Input } from './ui/input'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { PageLayout } from './Navbar'
import { EventsMap } from './EventsMap'
import { cn } from '../lib/utils'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { fetchCommunities, fetchEvents, searchCities } from '../features/events/api'
import { loadMapState, DEFAULT_CENTER, DEFAULT_ZOOM } from '../utils/events'
import type { Event, EventQueryBounds, SearchLocation, ViewMode } from '../types/events'

function EventCard({ event }: { event: Event }) {
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

export function Events() {
  const navigate = useNavigate()
  const [selectedCommunity, setSelectedCommunity] = useState<number | undefined>(undefined)
  const [communityOpen, setCommunityOpen]         = useState(false)
  const [viewMode, setViewMode]                   = useState<ViewMode>('map')
  const [mapCenter, setMapCenter] = useState<[number, number]>(() => loadMapState().center)
  const [mapZoom, setMapZoom]     = useState<number>(() => loadMapState().zoom)
  const [bounds, setBounds]               = useState<EventQueryBounds | undefined>()
  const [debouncedBounds, setDebouncedBounds] = useState<EventQueryBounds | undefined>()
  const boundsTimeoutRef = useRef<ReturnType<typeof setTimeout> | null>(null)
  const [searchLocation, setSearchLocation] = useState<SearchLocation | null>(null)
  const [isGettingLocation, setIsGettingLocation] = useState(false)
  const [searchQuery, setSearchQuery]             = useState('')
  const [isSearchingCity, setIsSearchingCity]     = useState(false)
  const [autocompleteResults, setAutocompleteResults] = useState<any[]>([])
  const [showAutocomplete, setShowAutocomplete] = useState(false)
  const searchTimeoutRef = useRef<ReturnType<typeof setTimeout> | null>(null)
  const [selectedEvent, setSelectedEvent]         = useState<Event | null>(null)

  const { data: currentUser } = useCurrentUser()
  const { data: communities } = useQuery({
    queryKey: ['communities-list'],
    queryFn: fetchCommunities,
  })

  const effectiveBounds: EventQueryBounds | undefined = searchLocation
    ? searchLocation.bounds
    : debouncedBounds

  const { data: allEvents = [], isLoading: eventsLoading } = useQuery({
    queryKey: ['events', selectedCommunity, effectiveBounds],
    queryFn:  () => fetchEvents(selectedCommunity, effectiveBounds),
  })

  useEffect(() => {
    try {
      localStorage.setItem('events.mapState', JSON.stringify({ center: mapCenter, zoom: mapZoom }))
    } catch {}
  }, [mapCenter, mapZoom])

  useEffect(() => {
    boundsTimeoutRef.current = setTimeout(() => setDebouncedBounds(bounds), 500)
    return () => { if (boundsTimeoutRef.current) clearTimeout(boundsTimeoutRef.current) }
  }, [bounds])

  // Debounced autocomplete search
  useEffect(() => {
    if (!searchQuery.trim()) {
      setAutocompleteResults([])
      setShowAutocomplete(false)
      return
    }

    if (searchTimeoutRef.current) clearTimeout(searchTimeoutRef.current)
    setIsSearchingCity(true)

    searchTimeoutRef.current = setTimeout(async () => {
      try {
        const results = await searchCities(searchQuery)
        setAutocompleteResults(results)
        setShowAutocomplete(true)
      } catch {
        toast.error('Search failed')
        setAutocompleteResults([])
      } finally {
        setIsSearchingCity(false)
      }
    }, 400)

    return () => {
      if (searchTimeoutRef.current) clearTimeout(searchTimeoutRef.current)
    }
  }, [searchQuery])

  function selectAutocompleteResult(result: any) {
    const bounds: EventQueryBounds = result.boundingbox
      ? {
          minLat: parseFloat(result.boundingbox[0]),
          maxLat: parseFloat(result.boundingbox[1]),
          minLng: parseFloat(result.boundingbox[2]),
          maxLng: parseFloat(result.boundingbox[3]),
        }
      : {
          minLat: parseFloat(result.lat) - 1,
          maxLat: parseFloat(result.lat) + 1,
          minLng: parseFloat(result.lon) - 1,
          maxLng: parseFloat(result.lon) + 1,
        }

    setSearchLocation({
      name: result.display_name.split(',')[0],
      lat: parseFloat(result.lat),
      lon: parseFloat(result.lon),
      bounds,
    })
    setMapCenter([parseFloat(result.lat), parseFloat(result.lon)])
    setMapZoom(12)
    setSearchQuery('')
    setShowAutocomplete(false)
    setAutocompleteResults([])
  }

  async function handleSearchCity(e: React.FormEvent) {
    e.preventDefault()
    if (!searchQuery.trim()) return
    setIsSearchingCity(true)
    try {
      const results = await searchCities(searchQuery)
      if (results?.length) {
        selectAutocompleteResult(results[0])
      } else {
        toast.error('Place not found')
      }
    } catch {
      toast.error('Search failed')
    } finally {
      setIsSearchingCity(false)
    }
  }

  function handleUseMyLocation() {
    if (!('geolocation' in navigator)) {
      toast.error('Please enable geolocation in your browser')
      return
    }
    setIsGettingLocation(true)
    navigator.geolocation.getCurrentPosition(
      (pos) => {
        setMapCenter([pos.coords.latitude, pos.coords.longitude])
        setMapZoom(12)
        setSearchLocation(null)
        setIsGettingLocation(false)
      },
      () => {
        toast.error('Could not get your location')
        setIsGettingLocation(false)
      },
      { enableHighAccuracy: true, timeout: 10000 },
    )
  }

  function clearSearchLocation() {
    setSearchLocation(null)
    setMapCenter(DEFAULT_CENTER)
    setMapZoom(DEFAULT_ZOOM)
  }

  // ── Derived ────────────────────────────────────────────────────────────────

  const totalCount = allEvents.length
  const selectedCommunityName = communities?.find(c => c.id === selectedCommunity)?.name

  return (
    <PageLayout fullWidth>
      <div className="relative w-full h-dvh flex flex-col overflow-hidden">
        <div className="absolute top-0 left-0 right-0 z-10 p-4 pointer-events-none flex flex-col gap-2">
          <div className="pointer-events-auto flex flex-col xl:flex-row xl:items-center justify-between bg-card/95 backdrop-blur shadow-sm border rounded-xl p-3 gap-3">
            <div className="flex flex-wrap items-center gap-3 xl:gap-6">
              {/* Title + count */}
              <h1 className="text-xl font-bold leading-none">
                Events ({totalCount})
              </h1>

              {/* City search */}
              <div className="relative flex gap-2 flex-wrap sm:flex-nowrap items-start sm:items-center">
                <div className="relative w-40 sm:w-48">
                  <Input
                    type="text"
                    placeholder="Search city…"
                    value={searchQuery}
                    onChange={(e) => setSearchQuery(e.target.value)}
                    onBlur={() => setTimeout(() => setShowAutocomplete(false), 100)}
                    onFocus={() => searchQuery.trim() && setShowAutocomplete(true)}
                    className="pl-8 h-9 text-sm w-full bg-background"
                    disabled={isGettingLocation}
                    autoComplete="off"
                  />
                  <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground" />
                  
                  {/* Autocomplete dropdown */}
                  {showAutocomplete && autocompleteResults.length > 0 && (
                    <div className="absolute top-full left-0 right-0 mt-1 bg-background border rounded-md shadow-lg z-50">
                      {autocompleteResults.slice(0, 8).map((result, idx) => (
                        <button
                          key={idx}
                          type="button"
                          className="w-full px-3 py-2 text-left text-sm hover:bg-accent transition-colors border-b last:border-b-0 flex items-start gap-2"
                          onMouseDown={(e) => {
                            e.preventDefault()
                            selectAutocompleteResult(result)
                          }}
                        >
                          <MapPin className="h-4 w-4 shrink-0 mt-0.5 text-muted-foreground" />
                          <span className="line-clamp-1">{result.display_name}</span>
                        </button>
                      ))}
                    </div>
                  )}
                </div>
                <Button
                  type="button"
                  size="sm"
                  variant="outline"
                  className="h-9"
                  onClick={handleUseMyLocation}
                  disabled={isGettingLocation}
                  title="Use my location"
                >
                  {isGettingLocation ? <Loader2 className="h-4 w-4 animate-spin" /> : <MapPin className="h-4 w-4" />}
                </Button>
              </div>

              {searchLocation && (
                <Badge variant="secondary" className="gap-1.5 pl-2 pr-1 h-7 text-xs font-normal">
                  <MapPin className="h-3 w-3 shrink-0" />
                  {searchLocation.name}
                  <button
                    type="button"
                    onClick={clearSearchLocation}
                    className="ml-0.5 rounded-full p-0.5 hover:bg-foreground/10 transition-colors"
                    aria-label={`Clear location filter: ${searchLocation.name}`}
                  >
                    <X className="h-3 w-3" />
                  </button>
                </Badge>
              )}

              {/* Community filter */}
              <div className="flex items-center gap-2 flex-wrap">
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
                          {(communities ?? []).map(c => (
                            <CommandItem
                              key={c.id}
                              value={c.name}
                              onSelect={() => { setSelectedCommunity(c.id); setCommunityOpen(false) }}
                            >
                              <Check className={cn('mr-2 h-4 w-4', selectedCommunity === c.id ? 'opacity-100' : 'opacity-0')} />
                              {c.name}
                            </CommandItem>
                          ))}
                        </CommandGroup>
                      </CommandList>
                    </Command>
                  </PopoverContent>
                </Popover>
                {selectedCommunity && (
                  <Button
                    variant="ghost"
                    size="sm"
                    className="h-9 w-9 p-0"
                    onClick={() => setSelectedCommunity(undefined)}
                    title="Clear community filter"
                  >
                    <X className="h-4 w-4" />
                  </Button>
                )}
              </div>
            </div>

            {/* Right side */}
            <div className="flex items-center gap-3">
              <div className="flex rounded-lg border overflow-hidden h-9">
                <Button
                  variant={viewMode === 'map' ? 'default' : 'ghost'}
                  size="sm"
                  className="h-9 rounded-none border-0 px-3"
                  onClick={() => setViewMode('map')}
                  title="Map view"
                >
                  <Map className="h-4 w-4" />
                </Button>
                <div className="w-px bg-border" />
                <Button
                  variant={viewMode === 'list' ? 'default' : 'ghost'}
                  size="sm"
                  className="h-9 rounded-none border-0 px-3"
                  onClick={() => setViewMode('list')}
                  title="List view"
                >
                  <List className="h-4 w-4" />
                </Button>
              </div>

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
        <div className={cn('flex-1 w-full h-full relative z-0', viewMode !== 'map' && 'hidden')}>
          <EventsMap
            events={allEvents}
            onBoundsChange={setBounds}
            center={mapCenter}
            zoom={mapZoom}
            onEventClick={setSelectedEvent}
            selectedEventId={selectedEvent?.id}
          />
        </div>
        {viewMode === 'list' && (
          <div className="flex-1 overflow-y-auto pt-28 sm:pt-24 px-4 pb-6">
            {eventsLoading ? (
              <div className="flex items-center justify-center gap-2 py-16 text-sm text-muted-foreground">
                <Loader2 className="h-4 w-4 animate-spin" />
                Loading events…
              </div>
            ) : allEvents.length === 0 ? (
              <div className="flex items-center justify-center py-16 text-sm text-muted-foreground">
                No events found
              </div>
            ) : (
              <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-4">
                {allEvents.map(event => (
                  <EventCard key={event.id} event={event} />
                ))}
              </div>
            )}
          </div>
        )}
        <div
          className={cn(
            'absolute top-28 sm:top-24 right-4 w-[calc(100vw-2rem)] sm:w-80 max-h-[60vh] z-20',
            'bg-card border shadow-2xl rounded-xl overflow-hidden flex flex-col',
            'transition-all duration-300 ease-in-out',
            selectedEvent && viewMode === 'map'
              ? 'opacity-100 translate-x-0 pointer-events-auto'
              : 'opacity-0 translate-x-6 pointer-events-none',
          )}
          aria-hidden={!selectedEvent || viewMode !== 'map'}
        >
          <Button
            variant="ghost"
            size="icon"
            className="absolute top-2 right-2 z-30 w-9 h-9 rounded-full bg-background/80 hover:bg-background shadow-sm"
            onClick={(e) => { e.stopPropagation(); setSelectedEvent(null) }}
            tabIndex={selectedEvent ? 0 : -1}
          >
            <X className="h-4 w-4" />
            <span className="sr-only">Close event preview</span>
          </Button>
          <div className="flex-1 overflow-y-auto p-3 sm:p-4">
            {selectedEvent && <EventCard event={selectedEvent} />}
          </div>
        </div>
      </div>
    </PageLayout>
  )
}

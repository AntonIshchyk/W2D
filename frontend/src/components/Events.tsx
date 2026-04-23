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
import { EventsMap, type FlyToTarget } from './EventsMap'
import { cn } from '../lib/utils'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { fetchCommunities, fetchEvents, searchCities } from '../api/events'
import { loadMapState, DEFAULT_CENTER, DEFAULT_ZOOM } from '../utils/events'
import type { Event, EventQueryBounds, ViewMode } from '../types/events'

// ─── EventCard ─────────────────────────────────────────────────────────────────

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

// ─── Events ────────────────────────────────────────────────────────────────────

export function Events() {
  const navigate = useNavigate()

  // ── UI state ────────────────────────────────────────────────────────────────
  const [viewMode, setViewMode]           = useState<ViewMode>('map')
  const [selectedCommunities, setSelectedCommunities] = useState<number[]>([])
  const [communityOpen, setCommunityOpen] = useState(false)
  const [selectedEvent, setSelectedEvent] = useState<Event | null>(null)
  const flyToIdRef = useRef(0)
  const [flyToTarget, setFlyToTarget] = useState<FlyToTarget | null>(null)
  const [initialMapState] = useState(() => loadMapState())
  const [rawBounds, setRawBounds]           = useState<EventQueryBounds | undefined>()
  const [debouncedBounds, setDebouncedBounds] = useState<EventQueryBounds | undefined>()
  const [searchBounds, setSearchBounds]     = useState<EventQueryBounds | null>(null)
  const [searchLocationName, setSearchLocationName] = useState<string | null>(null)
  const boundsDebounceRef = useRef<ReturnType<typeof setTimeout> | null>(null)

  // ── City search UI ──────────────────────────────────────────────────────────
  const [searchQuery, setSearchQuery]               = useState('')
  const [autocompleteResults, setAutocompleteResults] = useState<any[]>([])
  const [showAutocomplete, setShowAutocomplete]     = useState(false)
  const [isSearchingCity, setIsSearchingCity]       = useState(false)
  const [isGettingLocation, setIsGettingLocation]   = useState(false)
  const searchDebounceRef = useRef<ReturnType<typeof setTimeout> | null>(null)

  // ── Data ────────────────────────────────────────────────────────────────────
  const { data: currentUser } = useCurrentUser()
  const { data: communities } = useQuery({
    queryKey: ['communities-list'],
    queryFn: fetchCommunities,
  })

  const effectiveBounds = searchBounds ?? debouncedBounds
  const { data: allEvents = [], isLoading: eventsLoading } = useQuery({
    queryKey: ['events', selectedCommunities, effectiveBounds],
    queryFn: () => fetchEvents(selectedCommunities, effectiveBounds),
  })

  // ── Effects ─────────────────────────────────────────────────────────────────
  useEffect(() => {
    if (boundsDebounceRef.current) clearTimeout(boundsDebounceRef.current)
    boundsDebounceRef.current = setTimeout(() => setDebouncedBounds(rawBounds), 500)
    return () => { if (boundsDebounceRef.current) clearTimeout(boundsDebounceRef.current) }
  }, [rawBounds])

  useEffect(() => {
    if (searchDebounceRef.current) clearTimeout(searchDebounceRef.current)

    if (!searchQuery.trim()) {
      setAutocompleteResults([])
      setShowAutocomplete(false)
      setIsSearchingCity(false)
      return
    }

    setIsSearchingCity(true)
    searchDebounceRef.current = setTimeout(async () => {
      try {
        const results = await searchCities(searchQuery)
        setAutocompleteResults(results ?? [])
        setShowAutocomplete(true)
      } catch {
        toast.error('Search failed')
        setAutocompleteResults([])
      } finally {
        setIsSearchingCity(false)
      }
    }, 400)

    return () => { if (searchDebounceRef.current) clearTimeout(searchDebounceRef.current) }
  }, [searchQuery])

  // ── Handlers ─────────────────────────────────────────────────────────────────

  function flyTo(center: [number, number], zoom: number) {
    flyToIdRef.current += 1
    setFlyToTarget({ center, zoom, id: flyToIdRef.current })
  }

  function boundsFromResult(result: any): EventQueryBounds {
    const lat = parseFloat(result.lat)
    const lon = parseFloat(result.lon)
    const radiusKm = 30
    const degreesPerKmLat = 1 / 111.32
    const latOffset = radiusKm * degreesPerKmLat
    const lonOffset = radiusKm * degreesPerKmLat / Math.max(Math.cos((lat * Math.PI) / 180), 0.1)

    return {
      minLat: lat - latOffset,
      maxLat: lat + latOffset,
      minLng: lon - lonOffset,
      maxLng: lon + lonOffset,
    }
  }

  function applySearchResult(result: any) {
    const center: [number, number] = [parseFloat(result.lat), parseFloat(result.lon)]
    setSearchBounds(boundsFromResult(result))
    setSearchLocationName(result.display_name.split(',')[0])
    flyTo(center, 12)
    setSearchQuery('')
    setShowAutocomplete(false)
    setAutocompleteResults([])
  }

  function clearSearchLocation() {
    setSearchBounds(null)
    setSearchLocationName(null)
    flyTo(DEFAULT_CENTER, DEFAULT_ZOOM)
  }

  async function handleSearchSubmit(e: React.FormEvent) {
    e.preventDefault()
    if (!searchQuery.trim()) return
    
    if (autocompleteResults.length > 0) {
      applySearchResult(autocompleteResults[0])
    } else {
      toast.error('Place not found')
    }
  }

  function handleUseMyLocation() {
    if (!('geolocation' in navigator)) {
      toast.error('Please enable geolocation in your browser')
      return
    }
    setIsGettingLocation(true)
    navigator.geolocation.getCurrentPosition(
      async (pos) => {
        const lat = pos.coords.latitude
        const lng = pos.coords.longitude
        
        const bounds = boundsFromResult({ lat: lat.toString(), lon: lng.toString() })
        setSearchBounds(bounds)
        
        try {
          const res = await fetch(`https://photon.komoot.io/reverse?lon=${lng}&lat=${lat}`)
          const data = await res.json()
          if (data.features && data.features.length > 0) {
            const props = data.features[0].properties
            const displayName = props.city || props.name || props.state || 'Your Location'
            setSearchLocationName(displayName)
          } else {
            setSearchLocationName('Your Location')
          }
        } catch {
          setSearchLocationName('Your Location')
        }
        
        flyTo([lat, lng], 12)
        setIsGettingLocation(false)
      },
      () => {
        toast.error('Could not get your location')
        setIsGettingLocation(false)
      },
      { enableHighAccuracy: true, timeout: 10_000 },
    )
  }

  function handleViewChange(center: [number, number], zoom: number) {
    try {
      localStorage.setItem('events.mapState', JSON.stringify({ center, zoom }))
    } catch {}
  }

  // ── Derived ──────────────────────────────────────────────────────────────────
  const selectedCommunityNames = (communities ?? [])
    .filter((c) => selectedCommunities.includes(c.id))
    .map((c) => c.name)

  const communityFilterLabel =
    selectedCommunities.length === 0
      ? 'All Communities'
      : selectedCommunities.length === 1
        ? selectedCommunityNames[0] ?? '1 Community'
        : `${selectedCommunities.length} Communities`

  return (
    <PageLayout fullWidth>
      <div className="relative w-full h-dvh flex flex-col overflow-hidden">

        {/* ── Toolbar ── */}
        <div className="absolute top-0 left-0 right-0 z-10 p-4 pointer-events-none flex flex-col gap-2">
          <div className="pointer-events-auto flex flex-col xl:flex-row xl:items-center justify-between bg-card/95 backdrop-blur shadow-sm border rounded-xl p-3 gap-3">
            <div className="flex flex-wrap items-center gap-3 xl:gap-6">

              {/* Title + count */}
              <h1 className="text-xl font-bold leading-none">
                Events ({allEvents.length})
              </h1>

              {/* City search */}
              <div className="relative flex gap-2 flex-wrap sm:flex-nowrap items-start sm:items-center">
                <form onSubmit={handleSearchSubmit} className="relative w-40 sm:w-48">
                  <Input
                    type="text"
                    placeholder="Search city…"
                    value={searchQuery}
                    onChange={(e) => setSearchQuery(e.target.value)}
                    onBlur={() => setTimeout(() => setShowAutocomplete(false), 150)}
                    onFocus={() => autocompleteResults.length > 0 && setShowAutocomplete(true)}
                    className="pl-8 h-9 text-sm w-full bg-background"
                    disabled={isGettingLocation}
                    autoComplete="off"
                  />
                  {isSearchingCity
                    ? <Loader2 className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground animate-spin" />
                    : <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground" />
                  }

                  {showAutocomplete && autocompleteResults.length > 0 && (
                    <div className="absolute top-full left-0 right-0 mt-1 bg-background border rounded-md shadow-lg z-50">
                      {autocompleteResults.slice(0, 8).map((result, idx) => (
                        <button
                          key={idx}
                          type="button"
                          className="w-full px-3 py-2 text-left text-sm hover:bg-accent transition-colors border-b last:border-b-0 flex items-start gap-2"
                          onMouseDown={(e) => {
                            e.preventDefault()
                            applySearchResult(result)
                          }}
                        >
                          <MapPin className="h-4 w-4 shrink-0 mt-0.5 text-muted-foreground" />
                          <span className="line-clamp-1">{result.display_name}</span>
                        </button>
                      ))}
                    </div>
                  )}
                </form>

                <Button
                  type="button"
                  size="sm"
                  variant="outline"
                  className="h-9"
                  onClick={handleUseMyLocation}
                  disabled={isGettingLocation}
                  title="Use my location"
                >
                  {isGettingLocation
                    ? <Loader2 className="h-4 w-4 animate-spin" />
                    : <MapPin className="h-4 w-4" />
                  }
                </Button>
              </div>

              {searchLocationName && (
                <Badge variant="secondary" className="gap-1.5 pl-2 pr-1 h-7 text-xs font-normal">
                  <MapPin className="h-3 w-3 shrink-0" />
                  {searchLocationName}
                  <button
                    type="button"
                    onClick={clearSearchLocation}
                    className="ml-0.5 rounded-full p-0.5 hover:bg-foreground/10 transition-colors"
                    aria-label={`Clear location filter: ${searchLocationName}`}
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
                      {communityFilterLabel}
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
                            onSelect={() => setSelectedCommunities([])}
                          >
                            <Check className={cn('mr-2 h-4 w-4', selectedCommunities.length === 0 ? 'opacity-100' : 'opacity-0')} />
                            All communities
                          </CommandItem>
                          {(communities ?? []).map(c => (
                            <CommandItem
                              key={c.id}
                              value={c.name}
                              onSelect={() => {
                                setSelectedCommunities((prev) =>
                                  prev.includes(c.id)
                                    ? prev.filter((id) => id !== c.id)
                                    : [...prev, c.id]
                                )
                              }}
                            >
                              <Check className={cn('mr-2 h-4 w-4', selectedCommunities.includes(c.id) ? 'opacity-100' : 'opacity-0')} />
                              {c.name}
                            </CommandItem>
                          ))}
                        </CommandGroup>
                      </CommandList>
                    </Command>
                  </PopoverContent>
                </Popover>
                {selectedCommunities.length > 0 && (
                  <Button
                    variant="ghost"
                    size="sm"
                    className="h-9 w-9 p-0"
                    onClick={() => setSelectedCommunities([])}
                    title="Clear community filter"
                  >
                    <X className="h-4 w-4" />
                  </Button>
                )}
              </div>
            </div>

            {/* Right side: view toggle + create */}
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

        {/* ── Map view ── */}
        <div className={cn('flex-1 w-full h-full relative z-0', viewMode !== 'map' && 'hidden')}>
          <EventsMap
            events={allEvents}
            onBoundsChange={setRawBounds}
            onViewChange={handleViewChange}
            flyToTarget={flyToTarget}
            initialCenter={initialMapState.center}
            initialZoom={initialMapState.zoom}
            selectedEventId={selectedEvent?.id}
            onEventClick={setSelectedEvent}
          />
        </div>

        {/* ── List view ── */}
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

        {/* ── Selected event panel (map view only) ── */}
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

import { useQuery } from '@tanstack/react-query'
import { useEffect, useRef, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import {
  Plus,
  X,
  ChevronsUpDown,
  Check,
  Search,
  Loader2,
  MapPin,
  Map, List,
  ImageIcon,
} from 'lucide-react'
import { toast } from 'sonner'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { PageLayout } from './Navbar'
import { PlacesMap, type FlyToTarget } from './PlacesMap'
import { PlaceCard } from './PlaceCard'
import { cn } from '../lib/utils'
import { useCitySearch } from '../hooks/useCitySearch'
import { fetchPlaces, reverseGeocode } from '../api/places'
import { votePlace } from '../api/places'
import { fetchCommunities } from '../api/communities'
import { loadMapState, DEFAULT_CENTER, DEFAULT_ZOOM } from '../utils/mapState'
import type { CitySearchResult, Place, PlaceQueryBounds, ViewMode } from '../types/places'
import { EmptyState } from './ui/empty-state'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { useEntityVoteMutation } from '../hooks/useEntityVoteMutation'

function applyPlaceVote(place: Place, currentVote: number | undefined | null, newValue: number): Place {
  const nextVote = currentVote === newValue ? 0 : newValue
  const delta = nextVote - (currentVote ?? 0)

  return {
    ...place,
    currentUserVote: nextVote,
    score: place.score + delta,
  }
}

export function Places() {
  const navigate = useNavigate()
  const { data: currentUser } = useCurrentUser()
  const [viewMode, setViewMode] = useState<ViewMode>('map')
  const [selectedCommunities, setSelectedCommunities] = useState<number[]>([])
  const [communityOpen, setCommunityOpen] = useState(false)
  const [selectedPlace, setSelectedPlace] = useState<Place | null>(null)
  const flyToIdRef = useRef(0)
  const [flyToTarget, setFlyToTarget] = useState<FlyToTarget | null>(null)
  const [initialMapState] = useState(() => loadMapState())
  const [rawBounds, setRawBounds] = useState<PlaceQueryBounds | undefined>()
  const [debouncedBounds, setDebouncedBounds] = useState<PlaceQueryBounds | undefined>()
  const [searchBounds, setSearchBounds] = useState<PlaceQueryBounds | null>(null)
  const [searchLocationName, setSearchLocationName] = useState<string | null>(null)
  const boundsDebounceRef = useRef<ReturnType<typeof setTimeout> | null>(null)
  const [isGettingLocation, setIsGettingLocation] = useState(false)

  const {
    query: searchQuery,
    setQuery: setSearchQuery,
    results: autocompleteResults,
    isSearching: isSearchingCity,
    showResults: showAutocomplete,
    setShowResults: setShowAutocomplete,
    clear: clearSearchInput,
  } = useCitySearch({
    debounceMs: 400,
    onSearchError: () => toast.error('Search failed'),
  })

  const { data: communities } = useQuery({
    queryKey: ['communities-list'],
    queryFn: fetchCommunities,
  })

  const effectiveBounds = searchBounds ?? debouncedBounds
  const placesQueryKey = ['places', selectedCommunities, effectiveBounds]
  const { data: allPlaces = [], isLoading: placesLoading } = useQuery({
    queryKey: placesQueryKey,
    queryFn: () => fetchPlaces(selectedCommunities, effectiveBounds),
  })
  const { handleVote: votePlaceMutation } = useEntityVoteMutation({
    queryKey: placesQueryKey,
    mutationFn: votePlace,
    invalidateKeys: [['places'], ['place']],
  })

  useEffect(() => {
    if (boundsDebounceRef.current) clearTimeout(boundsDebounceRef.current)
    boundsDebounceRef.current = setTimeout(() => setDebouncedBounds(rawBounds), 500)
    return () => {
      if (boundsDebounceRef.current) clearTimeout(boundsDebounceRef.current)
    }
  }, [rawBounds])

  function flyTo(center: [number, number], zoom: number) {
    flyToIdRef.current += 1
    setFlyToTarget({ center, zoom, id: flyToIdRef.current })
  }

  function boundsFromResult(result: Pick<CitySearchResult, 'lat' | 'lon'>): PlaceQueryBounds {
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

  function applySearchResult(result: CitySearchResult) {
    const center: [number, number] = [parseFloat(result.lat), parseFloat(result.lon)]
    setSearchBounds(boundsFromResult(result))
    setSearchLocationName(result.display_name.split(',')[0])
    flyTo(center, 12)
    clearSearchInput()
  }

  function clearSearchLocation() {
    setSearchBounds(null)
    setSearchLocationName(null)
    setSearchQuery('')
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
        
        const bounds = boundsFromResult({
          lat: lat.toString(),
          lon: lng.toString(),
        })
        setSearchBounds(bounds)

        try {
          const displayName = await reverseGeocode(lat, lng)
          setSearchLocationName(displayName?.split(',')[0] ?? 'Your Location')
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
      localStorage.setItem('places.mapState', JSON.stringify({ center, zoom }))
    } catch {}
  }

  const selectedCommunityNames = (communities ?? [])
    .filter((c) => selectedCommunities.includes(c.id))
    .map((c) => c.name)

  const communityFilterLabel =
    selectedCommunities.length === 0
      ? 'All Communities'
      : selectedCommunities.length === 1
        ? selectedCommunityNames[0] ?? '1 Community'
        : `${selectedCommunities.length} Communities`

  const placeCardClassName = 'group bg-card border border-border/50 rounded-3xl p-5 md:p-6 hover:shadow-xl hover:shadow-primary/5 hover:border-primary/20 transition-all duration-300 flex flex-col'

  const handlePlaceDelete = (deletedPlaceId: number) => {
    if (selectedPlace?.id === deletedPlaceId) {
      setSelectedPlace(null)
    }
  }

  const handlePlaceVote = (placeId: number, currentVote: number | undefined | null, newValue: number) => {
    setSelectedPlace((current) => {
      if (!current || current.id !== placeId) {
        return current
      }

      return applyPlaceVote(current, currentVote, newValue)
    })

    votePlaceMutation(placeId, currentVote, newValue)
  }

  return (
    <PageLayout fullWidth>
      <div className="relative w-full h-dvh flex flex-col overflow-hidden">
        <div className="absolute top-0 left-0 right-0 z-10 p-4 pointer-events-none flex flex-col gap-2">
          
          <div className="pointer-events-auto flex flex-col xl:flex-row xl:items-center justify-between bg-card/95 backdrop-blur shadow-sm border rounded-xl p-4 gap-3">
              <div className="flex flex-wrap items-center gap-3 xl:gap-4">
                <h1 className="text-xl font-bold leading-none">
                Places ({allPlaces.length})
              </h1>

              <div className="relative flex gap-2 flex-wrap sm:flex-nowrap items-start sm:items-center">
                <form onSubmit={handleSearchSubmit} className="relative w-40 sm:w-52">
                  <Input
                    type="text"
                    placeholder="Search city…"
                    value={searchLocationName ?? searchQuery}
                    onChange={(e) => {
                      if (searchLocationName) {
                        clearSearchLocation()
                      }
                      setSearchQuery(e.target.value)
                    }}
                    onBlur={() => setTimeout(() => setShowAutocomplete(false), 150)}
                    onFocus={() => {
                      if (searchLocationName) return
                      autocompleteResults.length > 0 && setShowAutocomplete(true)
                    }}
                    className={cn(
                      'pl-8 pr-8 h-9 text-sm w-full bg-background',
                      searchLocationName && 'text-foreground font-medium',
                    )}
                    disabled={isGettingLocation}
                    autoComplete="off"
                    readOnly={!!searchLocationName}
                  />

                  {isSearchingCity
                    ? <Loader2 className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground animate-spin" />
                    : <Search className={cn('absolute left-2.5 top-2.5 h-4 w-4', searchLocationName ? 'text-primary' : 'text-muted-foreground')} />
                  }

                  {searchLocationName && (
                    <button
                      type="button"
                      onClick={(e) => {
                        e.preventDefault()
                        clearSearchLocation()
                      }}
                      className="absolute right-2 top-2 rounded-full p-0.5 text-muted-foreground hover:text-foreground hover:bg-accent transition-colors"
                      aria-label="Clear location filter"
                    >
                      <X className="h-4 w-4" />
                    </button>
                  )}

                  {showAutocomplete && autocompleteResults.length > 0 && !searchLocationName && (
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
                  <>
                    {isGettingLocation
                      ? <Loader2 className="h-4 w-4 animate-spin" />
                      : <MapPin className="h-4 w-4" />
                    }
                    <span className="hidden sm:inline">Use my location</span>
                  </>
                </Button>
              </div>

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
                          {(communities ?? []).map((c) => (
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
                {(selectedCommunities.length > 0 || searchLocationName) && (
                  <Button
                    variant="ghost"
                    size="sm"
                    className="h-9 text-destructive border-destructive/40 hover:bg-destructive hover:text-white hover:border-destructive transition-colors"
                    onClick={() => {
                      setSelectedCommunities([])
                      clearSearchLocation()
                    }}
                    title="Reset filters"
                  >
                    <X className="h-4 w-4" /> Reset filters
                  </Button>
                )}
              </div>
            </div>

            <div className="flex items-center gap-2">
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
              <Button onClick={() => navigate('/places/create')} size="sm" className="h-9">
                <Plus className="h-4 w-4 mr-1 sm:mr-2" />
                <span className="hidden sm:inline">Create Place</span>
                <span className="sm:hidden">Create</span>
              </Button>
            </div>
          </div>
        </div>

        <div className={cn('flex-1 w-full h-full relative z-0', viewMode !== 'map' && 'hidden')}>
          <PlacesMap
            places={allPlaces}
            onBoundsChange={setRawBounds}
            onViewChange={handleViewChange}
            flyToTarget={flyToTarget}
            initialCenter={initialMapState.center}
            initialZoom={initialMapState.zoom}
            selectedPlaceId={selectedPlace?.id}
            onPlaceClick={setSelectedPlace}
          />
        </div>

        {viewMode === 'list' && (
          <div className="flex-1 overflow-y-auto pt-28 sm:pt-24 px-4 pb-6">
            {placesLoading ? (
              <div className="flex items-center justify-center gap-2 py-16 text-sm text-muted-foreground">
                <Loader2 className="h-4 w-4 animate-spin" />
                Loading places…
              </div>
            ) : allPlaces.length === 0 ? (
            <div className="py-20 text-center">
              <EmptyState
                icon={ImageIcon}
                title="There are no places yet"
                action={selectedCommunities.length === 0 ? {
                  label: 'Create Place',
                  onClick: () => navigate('/places/create')
                } : undefined}
              />
            </div>
          )  : (
              <div className="max-w-3xl mx-auto space-y-6">
                {allPlaces.map((place) => (
                  <PlaceCard key={place.id} place={place} currentUser={currentUser} className={placeCardClassName} onDelete={handlePlaceDelete} onVote={handlePlaceVote} />
                ))}
              </div>
            )}
          </div>
        )}

        <div
          className={cn(
            'absolute top-28 sm:top-24 right-4 w-[calc(100vw-2rem)] sm:w-96 max-h-[80vh] z-20',
            selectedPlace && viewMode === 'map'
              ? 'opacity-100 translate-x-0 pointer-events-auto'
              : 'opacity-0 translate-x-6 pointer-events-none',
          )}
          aria-hidden={!selectedPlace || viewMode !== 'map'}
        >
          {selectedPlace && <PlaceCard place={selectedPlace} currentUser={currentUser} className={placeCardClassName} onDelete={handlePlaceDelete} onVote={handlePlaceVote} />}
        </div>
      </div>
    </PageLayout>
  )
}

import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import {
  Check,
  ChevronsUpDown,
  Loader2,
  MapPin,
  Search,
  Users,
  ArrowLeft,
  ArrowRight,
  Info,
  Image,
  Calendar
} from 'lucide-react'
import { toast } from 'sonner'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Textarea } from './ui/textarea'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { PageLayout } from './Navbar'
import { LocationPickerMap } from './LocationPickerMap'
import { createEvent, reverseGeocode } from '../api/events'
import { fetchCommunities } from '../api/communities'
import { useCitySearch } from '../hooks/useCitySearch'
import { cn } from '../lib/utils'
import type { CitySearchResult } from '../types/events'

const STEPS = [
  { id: 1, label: 'Details', icon: Info },
  { id: 2, label: 'Photos', icon: Image },
  { id: 3, label: 'Location', icon: MapPin },
]

export function CreateEvent() {
  const queryClient = useQueryClient()
  const navigate = useNavigate()

  const { data: communities = [] } = useQuery({
    queryKey: ['communities-list'],
    queryFn: fetchCommunities,
  })

  const [step, setStep] = useState(1)

  const [title, setTitle] = useState('')
  const [description, setDescription] = useState('')
  const [scheduledAt, setScheduledAt] = useState('')
  const [communityId, setCommunityId] = useState<number | null>(null)
  const [communityOpen, setCommunityOpen] = useState(false)
  const [location, setLocation] = useState<{ lat: number; lng: number } | null>(null)
  const [isFetchingLocation, setIsFetchingLocation] = useState(false)

  const {
    query: locationInput,
    setQuery: setLocationInput,
    setQuerySilently: setLocationInputSilently,
    results: locationSearchResults,
    isSearching: isSearchingLocation,
    showResults: showLocationResults,
    setShowResults: setShowLocationResults,
  } = useCitySearch({
    debounceMs: 350,
    onSearchError: () => toast.error('Location search failed'),
  })

  const applyLocationSearchResult = (result: CitySearchResult) => {
    const lat = parseFloat(result.lat)
    const lng = parseFloat(result.lon)

    if (Number.isNaN(lat) || Number.isNaN(lng)) return

    setLocation({ lat, lng })
    setLocationInputSilently(result.display_name)
  }

  const handleLocationSelect = async (lat: number, lng: number) => {
    setLocation({ lat, lng })
    setIsFetchingLocation(true)
    try {
      const displayName = await reverseGeocode(lat, lng)
      if (displayName) setLocationInputSilently(displayName)
    } catch (err) {
      console.error(err)
    } finally {
      setIsFetchingLocation(false)
    }
  }

  const mutation = useMutation({
    mutationFn: createEvent,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['events'] })
      toast.success('Event created!')
      navigate('/events')
    },
    onError: (err: unknown) => {
      const message = err instanceof Error ? err.message : 'Failed to create event'
      toast.error(message)
    },
  })

  const selectedCommunity = communities.find(c => c.id === communityId)

  const formattedDate = scheduledAt
    ? new Date(scheduledAt).toLocaleDateString('en-US', {
        weekday: 'short',
        month: 'short',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
      })
    : null

  function handleSubmit() {
    mutation.mutate({
      title,
      description,
      scheduledAt: new Date(scheduledAt).toISOString(),
      ...(communityId !== null ? { communityId } : {}),
      latitude: location?.lat,
      longitude: location?.lng,
      locationName: locationInput.trim() || undefined,
    })
  }

  const canProceed =
    step === 1
      ? title.trim().length > 0 && description.trim().length > 0
      : step === 2
        ? scheduledAt.length > 0
        : true

  return (
    <PageLayout>
      <div className="min-h-[calc(100vh-4rem)] bg-background text-foreground">
        <div className="max-w-6xl mx-auto px-6 py-14 grid grid-cols-1 lg:grid-cols-[1fr_380px] gap-12 items-start">
          <div className="space-y-10">
            <div className="flex items-center gap-0">
              {STEPS.map((s, i) => {
                const Icon = s.icon
                const current = step === s.id
                
                return (
                  <div key={s.id} className="flex items-center">
                    <button
                      type="button"
                      onClick={() => setStep(s.id)}
                      className={cn(
                        'flex items-center gap-2 px-4 py-2 rounded-full text-sm font-medium transition-all duration-300',
                        current && 'bg-primary text-primary-foreground',
                        !current && 'text-primary hover:bg-accent hover:text-accent-foreground cursor-pointer',
                      )}
                    >
                      <Icon className="h-4 w-4" />
                      {s.label}
                    </button>
                    {i < STEPS.length - 1 && (
                      <div className={cn(
                        'h-px w-8 mx-2 transition-colors duration-500',
                        step > s.id ? 'bg-primary' : 'bg-border',
                      )} />
                    )}
                  </div>
                )
              })}
            </div>

            <div className="relative">
              {step === 1 && (
                <div className="space-y-8 animate-in fade-in slide-in-from-right-4 duration-300">
                  <div className="space-y-2">
                    <label className="text-xs font-semibold uppercase tracking-widest">Title</label>
                    <Input
                      autoFocus
                      value={title}
                      onChange={e => setTitle(e.target.value)}
                      placeholder="Title your event (e.g. Walk in the park, running group...)"
                      className="bg-card border-border text-foreground placeholder:text-muted-foreground h-12 text-base focus-visible:ring-primary focus-visible:border-primary"
                    />
                  </div>

                  <div className="relative">
                    <label className="text-xs font-semibold uppercase tracking-widest">
                      Date & Time
                      </label>
                    <Input
                      type="datetime-local"
                      value={scheduledAt}
                      onChange={e => setScheduledAt(e.target.value)}
                      className="pr-12 bg-card border-border text-foreground h-12 text-base focus-visible:ring-primary focus-visible:border-primary"
                    />
                  </div>

                  <div className="space-y-2">
                    <label className="text-xs font-semibold uppercase tracking-widest">
                      Community
                    </label>
                    <Popover open={communityOpen} onOpenChange={setCommunityOpen}>
                      <PopoverTrigger asChild>
                        <Button
                          variant="outline"
                          role="combobox"
                          className="w-full justify-between h-12 bg-card border-border text-foreground hover:bg-accent hover:text-accent-foreground font-normal text-sm"
                        >
                          {selectedCommunity ? selectedCommunity.name : 'Pick a community'}
                          <ChevronsUpDown className="h-5 w-5 shrink-0 opacity-50" />
                        </Button>
                      </PopoverTrigger>
                      <PopoverContent className="w-full p-0 bg-card border-border" align="start">
                        <Command className="bg-transparent">
                          <CommandInput
                            placeholder="Find a community..."
                            className="text-foreground placeholder:text-muted-foreground"
                          />
                          <CommandList>
                            <CommandEmpty className="text-muted-foreground py-6 text-center text-sm">No community found.</CommandEmpty>
                            <CommandGroup>
                              {communities.map(c => (
                                <CommandItem
                                  key={c.id}
                                  value={c.name}
                                  onSelect={() => {
                                    setCommunityId(c.id === communityId ? null : c.id)
                                    setCommunityOpen(false)
                                  }}
                                  className="text-foreground aria-selected:bg-accent"
                                >
                                  <Check className={cn('mr-2 h-5 w-5 text-primary', communityId === c.id ? 'opacity-100' : 'opacity-0')} />
                                  {c.name}
                                </CommandItem>
                              ))}
                            </CommandGroup>
                          </CommandList>
                        </Command>
                      </PopoverContent>
                    </Popover>
                  </div>

                  <div className="space-y-2">
                    <label className="text-xs font-semibold uppercase tracking-widest">Description</label>
                    <Textarea
                      value={description}
                      onChange={e => setDescription(e.target.value)}
                      placeholder="Share the plan, who it's for, what to bring, and what is imporant to know."
                      rows={5}
                      className="bg-card border-border text-foreground placeholder:text-muted-foreground text-sm resize-none focus-visible:ring-primary focus-visible:border-primary"
                    />
                  </div>
                </div>
              )}

              {step === 2 && (
                <div className="space-y-8 animate-in fade-in slide-in-from-right-4 duration-300">
                  
                </div>
              )}

              {step === 3 && (
                <div className="space-y-8 animate-in fade-in slide-in-from-right-4 duration-300">
                  <div className="space-y-2 relative">
                    <div className="flex items-center gap-2">
                      <label className="text-xs font-semibold uppercase tracking-widest">
                        Location
                      </label>
                      {isFetchingLocation && <Loader2 className="h-3 w-3 animate-spin text-muted-foreground" />}
                    </div>
                    <div className="relative">
                      <Input
                        value={locationInput}
                        onChange={(e) => setLocationInput(e.target.value)}
                        onFocus={() => locationSearchResults.length > 0 && setShowLocationResults(true)}
                        onBlur={() => setTimeout(() => setShowLocationResults(false), 150)}
                        placeholder="Search a place or drop a pin, then modify the name if needed"
                        className="pl-10 bg-card border-border text-foreground placeholder:text-muted-foreground h-12 text-base focus-visible:ring-primary focus-visible:border-primary"
                        autoComplete="off"
                      />
                      {isSearchingLocation ? (
                        <Loader2 className="h-4 w-4 animate-spin text-muted-foreground absolute left-3 top-1/2 -translate-y-1/2" />
                      ) : (
                        <Search className="h-4 w-4 text-muted-foreground absolute left-3 top-1/2 -translate-y-1/2" />
                      )}
                    </div>

                    {showLocationResults && locationSearchResults.length > 0 && (
                      <div className="absolute left-0 right-0 top-full mt-1 z-1200 rounded-md border bg-card shadow-lg overflow-hidden">
                        {locationSearchResults.slice(0, 8).map((result, idx) => (
                          <button
                            key={`${result.lat}-${result.lon}-${idx}`}
                            type="button"
                            className="w-full px-3 py-2 text-left text-sm hover:bg-accent transition-colors border-b last:border-b-0 flex items-start gap-2"
                            onMouseDown={(e) => {
                              e.preventDefault()
                              applyLocationSearchResult(result)
                            }}
                          >
                            <MapPin className="h-4 w-4 shrink-0 mt-0.5 text-muted-foreground" />
                            <span className="line-clamp-1">{result.display_name}</span>
                          </button>
                        ))}
                      </div>
                    )}
                  </div>

                  <div className="rounded-2xl overflow-hidden border bg-card h-150 relative">
                    <LocationPickerMap
                      onLocationSelect={handleLocationSelect}
                      location={location ? [location.lat, location.lng] : null}
                    />
                  </div>
                </div>
              )}
            </div>

            <div className="flex items-center justify-between">
              <Button
                variant="ghost"
                onClick={() => (step === 1 ? navigate('/events') : setStep((s) => s - 1))}
                className="hover:text-foreground hover:bg-accent gap-2 text-base h-12 px-6"
              >
                <ArrowLeft className="h-5 w-5" />
                {step === 1 ? 'Cancel' : 'Back'}
              </Button>

              {step < 3 ? (
                <Button
                  onClick={() => setStep((s) => s + 1)}
                  disabled={!canProceed}
                  className="bg-primary text-primary-foreground hover:bg-primary/90 font-semibold gap-2 text-base h-12 px-8 disabled:opacity-30"
                >
                  Continue
                  <ArrowRight className="h-5 w-5" />
                </Button>
              ) : (
                <Button
                  onClick={handleSubmit}
                  disabled={mutation.isPending}
                  className="bg-primary text-primary-foreground hover:bg-primary/90 font-semibold gap-2 text-base h-12 px-8 min-w-40"
                >
                  {mutation.isPending
                    ? (
                      <>
                        <Loader2 className="h-5 w-5 animate-spin" /> Creating…
                      </>
                    ) : (
                      <>
                        Create Event
                      </>
                    )
                  }
                </Button>
              )}
            </div>
          </div>

          <div className="hidden lg:block sticky top-24">
            <p className="text-xs font-semibold uppercase tracking-widest text-muted-foreground mb-4">Preview</p>
            <div className="rounded-2xl border bg-card shadow-sm overflow-hidden">
              <div className="p-6 space-y-5">
                <div>
                  <h3 className={cn(
                    'font-bold text-lg leading-snug transition-all wrap-break-word',
                    title ? 'text-foreground' : 'text-muted-foreground italic',
                  )}>
                    {title || 'Your event title…'}
                  </h3>
                  <p className={cn(
                    'mt-2 text-sm leading-relaxed line-clamp-4 transition-all wrap-break-word',
                    description ? 'text-muted-foreground/90' : 'text-muted-foreground/60 italic',
                  )}>
                    {description || 'Description will appear here…'}
                  </p>
                </div>

                <div className="space-y-3 pt-4 border-t">
                  <div className="flex items-center gap-3 text-base">
                    <Calendar className="h-5 w-5 text-primary shrink-0" />
                    <span className={formattedDate ? 'text-foreground/90' : 'text-muted-foreground/60 italic'}>
                      {formattedDate || 'No date and time selected yet'}
                    </span>
                  </div>

                  <div className="flex items-center gap-3 text-base">
                    <Users className="h-5 w-5 text-primary shrink-0" />
                    <span className={selectedCommunity ? 'text-foreground/90' : 'text-muted-foreground/60 italic'}>
                      {selectedCommunity?.name || 'Open to everyone'}
                    </span>
                  </div>

                  <div className="flex items-center gap-3 text-base">
                    <MapPin className="h-5 w-5 text-primary shrink-0" />
                    <span className={locationInput ? 'text-foreground/90' : 'text-muted-foreground/60 italic'}>
                      {locationInput || 'Choose a spot on the map'}
                    </span>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </PageLayout>
  )
}

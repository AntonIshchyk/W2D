import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useNavigate, useParams } from 'react-router-dom'
import {
  Check,
  ChevronsUpDown,
  Loader2,
  MapPin,
  Search,
  ArrowLeft,
  ArrowRight,
  Info,
  Image,
} from 'lucide-react'
import { toast } from 'sonner'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Textarea } from './ui/textarea'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { PageLayout } from './Navbar'
import { LocationPickerMap } from './LocationPickerMap'
import { PlaceImageUpload } from './PlaceImageUpload'
import { updatePlace, fetchPlace } from '../api/places'
import { fetchCommunities } from '../api/communities'
import { cn } from '../lib/utils'
import type { Place } from '../types/places'
import { PlaceCard } from './PlaceCard'
import { useEntityForm } from '../hooks/useEntityForm'

const STEPS = [
  { id: 1, label: 'Details', icon: Info },
  { id: 2, label: 'Location', icon:  MapPin },
  { id: 3, label: 'Photos', icon: Image },
]

export function EditPlace() {
  const { placeId } = useParams<{ placeId: string }>()
  const queryClient = useQueryClient()
  const navigate = useNavigate()

  const { data: existingPlace, isLoading: isLoadingPlace } = useQuery({
    queryKey: ['place', placeId],
    queryFn: () => fetchPlace(Number(placeId)),
    enabled: !!placeId && !isNaN(Number(placeId)),
  })

  const { data: communities = [] } = useQuery({
    queryKey: ['communities-list'],
    queryFn: fetchCommunities,
  })

  const {
    step, setStep,
    title, setTitle,
    description, setDescription,
    communityId, setCommunityId,
    communityOpen, setCommunityOpen,
    location,
    photoUrls, setPhotoUrls,
    isFetchingLocation,
    detailErrors, setDetailErrors,
    locationInput, setLocationInput,
    locationSearchResults,
    isSearchingLocation,
    showLocationResults, setShowLocationResults,
    applyLocationSearchResult,
    handleLocationSelect,
    validateDetails,
    canProceed
  } = useEntityForm(existingPlace)

  const mutation = useMutation({
    mutationFn: () => updatePlace(Number(placeId), {
      title,
      description,
      ...(communityId !== null ? { communityId } : {}),
      latitude: location?.lat,
      longitude: location?.lng,
      locationName: locationInput.trim() || undefined,
      photoUrls,
    }),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['places'] })
      queryClient.invalidateQueries({ queryKey: ['place', placeId] })
      toast.success('Place updated!')
      navigate('/places')
    },
    onError: (err: unknown) => {
      const message = err instanceof Error ? err.message : 'Failed to update place'
      toast.error(message)
    },
  })

  const selectedCommunity = communities.find(c => c.id === communityId)

  function handleSubmit() {
    if (!validateDetails()) {
      setStep(1)
      toast.error('Please fix the required fields before updating the place.')
      return
    }

    mutation.mutate()
  }

  

  const previewPlace: Place = {
    id: existingPlace?.id ?? 0,
    title: title || 'Your place title…',
    description: description || 'Description will appear here…',
    userId: existingPlace?.userId ?? 0,
    userName: existingPlace?.userName ?? 'You',
    communityId: selectedCommunity?.id ?? existingPlace?.communityId ?? null,
    communityName: selectedCommunity?.name ?? existingPlace?.communityName ?? 'Open to everyone',
    latitude: location?.lat ?? existingPlace?.latitude,
    longitude: location?.lng ?? existingPlace?.longitude,
    locationName: locationInput || existingPlace?.locationName || 'Choose a spot on the map',
    photoUrls: photoUrls ?? [],
    createdAt: existingPlace?.createdAt ?? new Date().toISOString(),
    updatedAt: new Date().toISOString(),
  }

  if (isLoadingPlace) {
    return (
      <PageLayout>
        <div className="flex items-center justify-center py-20">
          <div className="flex items-center gap-2.5 text-muted-foreground">
            <Loader2 className="w-4 h-4 animate-spin" />
            <span className="text-sm">Loading…</span>
          </div>
        </div>
      </PageLayout>
    )
  }

  if (!existingPlace) {
    return (
      <PageLayout>
        <div className="max-w-3xl mx-auto">
          <h2 className="text-xl font-semibold mb-2">Place not found</h2>
          <Button variant="ghost" onClick={() => navigate('/places')}>
            Back to places
          </Button>
        </div>
      </PageLayout>
    )
  }

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
                    <label className="text-xs font-semibold uppercase tracking-widest">
                      Title <span className="text-destructive">*</span>
                    </label>
                    <Input
                      autoFocus
                      value={title}
                      onChange={e => {
                        setTitle(e.target.value)
                        if (detailErrors.title) {
                          setDetailErrors((prev) => ({ ...prev, title: undefined }))
                        }
                      }}
                      placeholder="Title your place (e.g. Walk in the park, running group...)"
                      className={cn(
                        'bg-card border-border text-foreground placeholder:text-muted-foreground h-12 text-base focus-visible:ring-primary focus-visible:border-primary',
                        detailErrors.title && 'border-destructive focus-visible:ring-destructive focus-visible:border-destructive',
                      )}
                    />
                    {detailErrors.title && <p className="text-xs text-destructive">{detailErrors.title}</p>}
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
                    <label className="text-xs font-semibold uppercase tracking-widest">
                      Description <span className="text-destructive">*</span>
                    </label>
                    <Textarea
                      value={description}
                      onChange={e => {
                        setDescription(e.target.value)
                        if (detailErrors.description) {
                          setDetailErrors((prev) => ({ ...prev, description: undefined }))
                        }
                      }}
                      placeholder="Share the plan, who it's for, and what is imporant to know."
                      rows={4}
                      className={cn(
                        'bg-card border-border text-foreground placeholder:text-muted-foreground text-sm resize-none focus-visible:ring-primary focus-visible:border-primary',
                        detailErrors.description && 'border-destructive focus-visible:ring-destructive focus-visible:border-destructive',
                      )}
                    />
                    {detailErrors.description && <p className="text-xs text-destructive">{detailErrors.description}</p>}
                  </div>
                </div>
              )}

              {step === 2 && (
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
                        placeholder="Optional: search or drop a pin"
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

              <div
                className={cn(
                  'space-y-8',
                  step === 3
                    ? 'animate-in fade-in slide-in-from-right-4 duration-300'
                    : 'hidden',
                )}
              >
                <div className="space-y-2">
                  <label className="text-xs font-semibold uppercase tracking-widest">
                    Place Photos
                  </label>
                  <PlaceImageUpload
                    value={photoUrls}
                    onChange={setPhotoUrls}
                    maxFiles={4}
                    disabled={mutation.isPending}
                  />
                </div>
              </div>
            </div>

            <div className="flex items-center justify-between">
              <Button
                variant="ghost"
                onClick={() => (step === 1 ? navigate('/places') : setStep((s) => s - 1))}
                className="hover:text-foreground hover:bg-accent gap-2 text-base h-12 px-6"
              >
                <ArrowLeft className="h-5 w-5" />
                {step === 1 ? 'Cancel' : 'Back'}
              </Button>

              {step < 3 ? (
                <Button
                  onClick={() => {
                    if (step === 1 && !validateDetails()) return
                    setStep((s) => s + 1)
                  }}
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
                        <Loader2 className="h-5 w-5 animate-spin" /> Updating…
                      </>
                    ) : (
                      <>
                        Update Place
                      </>
                    )
                  }
                </Button>
              )}
            </div>
          </div>

          <div className="hidden lg:block sticky top-24">
            <p className="text-sm font-semibold uppercase tracking-widest mb-4">Preview</p>
            <PlaceCard
              place={previewPlace}
              isPreview
              className='rounded-2xl border bg-card shadow-sm overflow-hidden cursor-default'
            />
          </div>
        </div>
      </div>
    </PageLayout>
  )
}

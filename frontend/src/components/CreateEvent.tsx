import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import {
  Check,
  ChevronsUpDown,
  Loader2,
  MapPin,
  Calendar,
  Users,
  ArrowLeft,
  ArrowRight,
  Info,
  Sparkles,
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
import { cn } from '../lib/utils'

const STEPS = [
  { id: 1, label: 'Details', icon: Info },
  { id: 2, label: 'When', icon: Calendar },
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
  const [locationName, setLocationName] = useState('')
  const [isFetchingLocation, setIsFetchingLocation] = useState(false)

  const handleLocationSelect = async (lat: number, lng: number) => {
    setLocation({ lat, lng })
    setIsFetchingLocation(true)
    try {
      const displayName = await reverseGeocode(lat, lng)
      if (displayName) setLocationName(displayName)
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
      locationName: locationName || undefined,
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

          {/* ── Left: Form ─────────────────────────────────────────── */}
          <div className="space-y-10">

            {/* Step indicator */}
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

            {/* Step panels */}
            <div className="relative">

              {/* Step 1 — Details */}
              {step === 1 && (
                <div className="space-y-8 animate-in fade-in slide-in-from-right-4 duration-300">
                  <div>
                    <p className="text-4xl font-bold tracking-tight text-foreground">What's the event?</p>
                  </div>

                  <div className="space-y-2">
                    <label className="text-xs font-semibold uppercase tracking-widest text-muted-foreground">Title</label>
                    <Input
                      autoFocus
                      value={title}
                      onChange={e => setTitle(e.target.value)}
                      placeholder="Movie night, Hackathon, Rooftop BBQ…"
                      className="bg-card border-border text-foreground placeholder:text-muted-foreground h-14 text-lg focus-visible:ring-primary focus-visible:border-primary"
                    />
                  </div>

                  <div className="space-y-2">
                    <label className="text-xs font-semibold uppercase tracking-widest text-muted-foreground">Description</label>
                    <Textarea
                      value={description}
                      onChange={e => setDescription(e.target.value)}
                      placeholder="What should attendees know? What's the vibe?"
                      rows={6}
                      className="bg-card border-border text-foreground placeholder:text-muted-foreground text-lg resize-none focus-visible:ring-primary focus-visible:border-primary"
                    />
                  </div>
                </div>
              )}

              {/* Step 2 — When & Community */}
              {step === 2 && (
                <div className="space-y-8 animate-in fade-in slide-in-from-right-4 duration-300">
                  <div>
                    <p className="text-4xl font-bold tracking-tight text-foreground">When is it?</p>
                    <p className="mt-2 text-lg text-muted-foreground">Set the date and optionally link a community.</p>
                  </div>

                  <div className="space-y-2">
                    <label className="text-xs font-semibold uppercase tracking-widest text-muted-foreground">Date & Time</label>
                    <Input
                      type="datetime-local"
                      value={scheduledAt}
                      onChange={e => setScheduledAt(e.target.value)}
                      className="bg-card border-border text-foreground h-14 text-lg focus-visible:ring-primary focus-visible:border-primary scheme-dark"
                    />
                  </div>

                  <div className="space-y-2">
                    <label className="text-xs font-semibold uppercase tracking-widest text-muted-foreground">
                      Community <span className="normal-case font-normal text-muted-foreground/70">(optional)</span>
                    </label>
                    <Popover open={communityOpen} onOpenChange={setCommunityOpen}>
                      <PopoverTrigger asChild>
                        <Button
                          variant="outline"
                          role="combobox"
                          className="w-full justify-between h-14 bg-card border-border text-foreground hover:bg-accent hover:text-accent-foreground font-normal text-lg"
                        >
                          {selectedCommunity ? selectedCommunity.name : 'Select a community…'}
                          <ChevronsUpDown className="h-5 w-5 shrink-0 opacity-50" />
                        </Button>
                      </PopoverTrigger>
                      <PopoverContent className="w-full p-0 bg-card border-border" align="start">
                        <Command className="bg-transparent">
                          <CommandInput
                            placeholder="Search communities…"
                            className="text-foreground placeholder:text-muted-foreground"
                          />
                          <CommandList>
                            <CommandEmpty className="text-muted-foreground py-6 text-center text-base">No community found.</CommandEmpty>
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
                </div>
              )}

              {/* Step 3 — Location */}
              {step === 3 && (
                <div className="space-y-8 animate-in fade-in slide-in-from-right-4 duration-300">
                  <div>
                    <p className="text-4xl font-bold tracking-tight text-foreground">Where's it at?</p>
                  </div>

                  <div className="space-y-2">
                    <div className="flex items-center gap-2">
                      <label className="text-xs font-semibold uppercase tracking-widest text-muted-foreground">
                        Location Name
                      </label>
                      {isFetchingLocation && <Loader2 className="h-3 w-3 animate-spin text-muted-foreground" />}
                    </div>
                    <Input
                      value={locationName}
                      onChange={e => setLocationName(e.target.value)}
                      placeholder="Location name…"
                      className="bg-card border-border text-foreground placeholder:text-muted-foreground h-14 text-lg focus-visible:ring-primary focus-visible:border-primary"
                    />
                  </div>

                  <div className="rounded-2xl overflow-hidden border bg-card h-150 relative">
                    <LocationPickerMap
                      onLocationSelect={handleLocationSelect}
                    />
                  </div>
                </div>
              )}
            </div>

            {/* Navigation */}
            <div className="flex items-center justify-between pt-6">
              <Button
                variant="ghost"
                onClick={() => (step === 1 ? navigate('/events') : setStep((s) => s - 1))}
                className="text-muted-foreground hover:text-foreground hover:bg-accent gap-2 text-base h-12 px-6"
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
                        <Sparkles className="h-5 w-5" /> Create Event
                      </>
                    )
                  }
                </Button>
              )}
            </div>
          </div>

          {/* ── Right: Live Preview Card ─────────────────────────────── */}
          <div className="hidden lg:block sticky top-24">
            <p className="text-xs font-semibold uppercase tracking-widest text-muted-foreground mb-4">Preview</p>
            <div className="rounded-2xl border bg-card shadow-sm overflow-hidden">
              <div className="p-6 space-y-5">
                <div>
                  <h3 className={cn(
                    'font-bold text-xl leading-snug transition-all wrap-break-word',
                    title ? 'text-foreground' : 'text-muted-foreground italic',
                  )}>
                    {title || 'Your event title…'}
                  </h3>
                  <p className={cn(
                    'mt-2 text-base leading-relaxed line-clamp-4 transition-all wrap-break-word',
                    description ? 'text-muted-foreground/90' : 'text-muted-foreground/60 italic',
                  )}>
                    {description || 'Description will appear here…'}
                  </p>
                </div>

                <div className="space-y-3 pt-4 border-t">
                  <div className="flex items-center gap-3 text-base">
                    <Calendar className="h-5 w-5 text-primary shrink-0" />
                    <span className={formattedDate ? 'text-foreground/90' : 'text-muted-foreground/60 italic'}>
                      {formattedDate || 'Date not set'}
                    </span>
                  </div>

                  <div className="flex items-center gap-3 text-base">
                    <Users className="h-5 w-5 text-primary shrink-0" />
                    <span className={selectedCommunity ? 'text-foreground/90' : 'text-muted-foreground/60 italic'}>
                      {selectedCommunity?.name || 'No community'}
                    </span>
                  </div>

                  <div className="flex items-center gap-3 text-base">
                    <MapPin className="h-5 w-5 text-primary shrink-0" />
                    <span className={locationName ? 'text-foreground/90' : 'text-muted-foreground/60 italic'}>
                      {locationName || 'No location'}
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

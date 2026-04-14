import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { Check, ChevronsUpDown, Loader2 } from 'lucide-react'
import { toast } from 'sonner'
import { Card, CardContent, CardHeader, CardTitle, CardDescription } from './ui/card'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Textarea } from './ui/textarea'
import { Label } from './ui/label'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { PageLayout } from './Navbar'
import { LocationPickerMap } from './LocationPickerMap'
import { createEvent, fetchCommunities } from '../features/events/api'
import { cn } from '../lib/utils'

export function CreateEvent() {
  const queryClient = useQueryClient()
  const navigate = useNavigate()
  
  const { data: communities = [] } = useQuery({ queryKey: ['communities-list'], queryFn: fetchCommunities })

  const [title, setTitle] = useState('')
  const [description, setDescription] = useState('')
  const [scheduledAt, setScheduledAt] = useState('')
  const [topicId, setCommunityId] = useState<number | null>(null)
  const [communityOpen, setCommunityOpen] = useState(false)
  const [location, setLocation] = useState<{lat: number, lng: number} | null>(null)
  const [locationName, setLocationName] = useState('')
  const [isSubmitting, setIsSubmitting] = useState(false)

  const mutation = useMutation({
    mutationFn: createEvent,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['events'] })
      toast.success('Event created!')
      navigate('/events')
    },
    onError: (err: any) => {
      toast.error(err.message || 'Failed to create event')
      setIsSubmitting(false)
    }
  })

  function onSubmit(e: React.FormEvent) {
    e.preventDefault()
    setIsSubmitting(true)

    const payload = {
      title,
      description,
      scheduledAt: new Date(scheduledAt).toISOString(),
      ...(topicId !== null ? { topicId } : {}),
      latitude: location?.lat,
      longitude: location?.lng,
      locationName: locationName || undefined,
    }

    mutation.mutate({
      ...payload
    })
  }

  const selectedCommunity = communities.find(c => c.id === topicId)

  return (
    <PageLayout>
      <div className="max-w-3xl mx-auto space-y-6">
        <Card>
          <CardHeader>
            <CardTitle>Create a New Event</CardTitle>
            <CardDescription>Fill out the details below to host a new event.</CardDescription>
          </CardHeader>
          <CardContent>
            <form onSubmit={onSubmit} className="space-y-4">
              <div className="space-y-2">
                <Label htmlFor="title">Title</Label>
                <Input
                  id="title"
                  required
                  value={title}
                  onChange={e => setTitle(e.target.value)}
                  placeholder="Movie night, Hackathon, etc."
                />
              </div>

              <div className="space-y-2">
                <Label htmlFor="desc">Description</Label>
                <Textarea
                  id="desc"
                  required
                  value={description}
                  onChange={e => setDescription(e.target.value)}
                  placeholder="What is this event about?"
                  rows={4}
                />
              </div>

              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div className="space-y-2">
                  <Label htmlFor="when">Date & Time (Local)</Label>
                  <Input
                    id="when"
                    type="datetime-local"
                    required
                    value={scheduledAt}
                    onChange={e => setScheduledAt(e.target.value)}
                  />
                </div>
              </div>

              <div className="space-y-2">
                <Label>Community</Label>
                <Popover open={communityOpen} onOpenChange={setCommunityOpen}>
                  <PopoverTrigger asChild>
                    <Button
                      variant="outline"
                      role="combobox"
                      className="w-full justify-between font-normal"
                    >
                      {selectedCommunity ? selectedCommunity.name : "Select a community..."}
                      <ChevronsUpDown className="h-4 w-4 shrink-0 opacity-50" />
                    </Button>
                  </PopoverTrigger>
                  <PopoverContent className="w-full p-0" align="start">
                    <Command>
                      <CommandInput placeholder="Search communities..." />
                      <CommandList>
                        <CommandEmpty>No community found.</CommandEmpty>
                        <CommandGroup>
                          {communities.map((c) => (
                            <CommandItem
                              key={c.id}
                              value={c.name}
                              onSelect={() => {
                                setCommunityId(c.id === topicId ? null : c.id)
                                setCommunityOpen(false)
                              }}
                            >
                              <Check
                                className={cn(
                                  "mr-2 h-4 w-4",
                                  topicId === c.id ? "opacity-100" : "opacity-0"
                                )}
                              />
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
                <Label>Location</Label>
                <div className="h-75 border rounded-md overflow-hidden relative z-0">
                  <LocationPickerMap
                    onLocationSelect={(lat, lng) => setLocation({ lat, lng })}
                  />
                </div>
                {location && (
                  <div className="flex flex-col gap-2 mt-2">
                    <p className="text-sm text-muted-foreground">
                      Selected Coordinates: {location.lat.toFixed(4)}, {location.lng.toFixed(4)}
                    </p>
                    <Input 
                      placeholder="Location Name (e.g. Central Park)" 
                      value={locationName}
                      onChange={e => setLocationName(e.target.value)}
                    />
                  </div>
                )}
              </div>

              <div className="pt-4 flex justify-end gap-2">
                <Button type="button" variant="ghost" onClick={() => navigate('/events')} disabled={isSubmitting}>
                  Cancel
                </Button>
                <Button type="submit" disabled={isSubmitting}>
                  {isSubmitting && <Loader2 className="mr-2 h-4 w-4 animate-spin" />}
                  Create Event
                </Button>
              </div>
            </form>
          </CardContent>
        </Card>
      </div>
    </PageLayout>
  )
}
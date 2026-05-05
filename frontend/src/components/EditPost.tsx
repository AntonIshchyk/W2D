import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState, useEffect } from 'react'
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
import { fetchPost, updatePost, POST_TYPE_LABELS } from '../api/posts'
import { fetchCommunities } from '../api/communities'
import { useEntityForm } from '../hooks/useEntityForm'
import { cn } from '../lib/utils'
import type { Post } from '../types/posts'
import { PostCard } from './PostCard'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { PostType } from '../types/posts'

const STEPS = [
  { id: 1, label: 'Details', icon: Info },
  { id: 2, label: 'Location', icon:  MapPin },
  { id: 3, label: 'Photos', icon: Image },
]



export function EditPost() {
  const { postId } = useParams<{ postId: string }>()
  const queryClient = useQueryClient()
  const navigate = useNavigate()

  const { data: existingPost, isLoading: isLoadingPost } = useQuery({
    queryKey: ['post', postId],
    queryFn: () => fetchPost(Number(postId)),
    enabled: !!postId && !isNaN(Number(postId)),
  })

  const { data: communities = [] } = useQuery({
    queryKey: ['communities-list'],
    queryFn: fetchCommunities,
  })

  const [postType, setPostType] = useState<number>(PostType.ExperienceShare)

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
  } = useEntityForm(existingPost)

  useEffect(() => {
    if (existingPost && existingPost.type !== undefined) setPostType(existingPost.type)
  }, [existingPost])

  const mutation = useMutation({
    mutationFn: () => updatePost(Number(postId), {
      title,
      description,
      type: postType,
      ...(communityId !== null ? { communityId } : {}),
      locationName: locationInput.trim() || undefined,
      latitude: location?.lat,
      longitude: location?.lng,
      photoUrls,
    }),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      queryClient.invalidateQueries({ queryKey: ['post', postId] })
      toast.success('Post updated!')
      navigate(`/posts/${postId}`)
    },
    onError: (err: unknown) => {
      const message = err instanceof Error ? err.message : 'Failed to update post'
      toast.error(message)
    },
  })

  const selectedCommunity = communities.find(c => c.id === communityId)

  function handleSubmit() {
    if (!validateDetails()) {
      setStep(1)
      toast.error('Please fix the required fields before updating the post.')
      return
    }

    mutation.mutate()
  }

  const previewPost: Post = {
    id: existingPost?.id ?? 0,
    title: title || 'Your post title…',
    description: description || 'Description will appear here…',
    type: postType as PostType,
    author: existingPost?.author ?? { id: 0, username: 'You' },
    communityId: selectedCommunity?.id ?? existingPost?.communityId ?? 0,
    communityName: selectedCommunity?.name ?? existingPost?.communityName ?? 'Open to everyone',
    score: existingPost?.score ?? 0,
    locationName: locationInput || undefined,
    latitude: location?.lat,
    longitude: location?.lng,
    photoUrls: photoUrls ?? [],
    commentCount: existingPost?.commentCount ?? 0,
    createdAt: existingPost?.createdAt ?? new Date().toISOString(),
    updatedAt: new Date().toISOString(),
  }

  if (isLoadingPost) {
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

  if (!existingPost) {
    return (
      <PageLayout>
        <div className="max-w-3xl mx-auto">
          <h2 className="text-xl font-semibold mb-2">Post not found</h2>
          <Button variant="ghost" onClick={() => navigate('/posts')}>
            Back to posts
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
                      placeholder="Give your post a title"
                      className={cn(
                        'bg-card border-border text-foreground placeholder:text-muted-foreground h-12 text-base focus-visible:ring-primary focus-visible:border-primary',
                        detailErrors.title && 'border-destructive focus-visible:ring-destructive focus-visible:border-destructive',
                      )}
                    />
                    {detailErrors.title && <p className="text-xs text-destructive">{detailErrors.title}</p>}
                  </div>

                  <div className="space-y-2">
                    <label className="text-xs font-semibold uppercase tracking-widest">
                      Type
                    </label>
                    <Select value={postType.toString()} onValueChange={(v) => setPostType(Number(v))}>
                      <SelectTrigger className="h-12 bg-card border-border text-foreground hover:bg-accent hover:text-accent-foreground font-normal text-sm">
                        <SelectValue />
                      </SelectTrigger>
                      <SelectContent className="rounded-2xl">
                        {Object.entries(POST_TYPE_LABELS).map(([value, label]) => (
                          <SelectItem key={value} value={value}>
                            {label}
                          </SelectItem>
                        ))}
                      </SelectContent>
                    </Select>
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
                      placeholder="Share the details of your post"
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
                    Post Photos
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
                onClick={() => (step === 1 ? navigate(`/posts/${postId}`) : setStep((s) => s - 1))}
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
                        Update Post
                      </>
                    )
                  }
                </Button>
              )}
            </div>
          </div>

          <div className="hidden lg:block sticky top-24">
            <p className="text-sm font-semibold uppercase tracking-widest mb-4">Preview</p>
              <PostCard
                post={previewPost}
                currentUser={null}
                onVote={() => {}}
                isPreview
                className="rounded-2xl border bg-card shadow-sm overflow-hidden cursor-default"
              />
          </div>
        </div>
      </div>
    </PageLayout>
  )
}

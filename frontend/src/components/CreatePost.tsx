import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { Info, MapPin, Image } from 'lucide-react'
import { toast } from 'sonner'
import { createPost, POST_TYPE_ICONS, POST_TYPE_LABELS } from '../api/posts'
import { fetchCommunities } from '../api/communities'
import { extractErrorMessage } from '../lib/utils/errors'
import type { Post } from '../types/posts'
import { PostCard } from './PostCard'
import { PostType } from '../types/posts'
import { useEntityForm } from '../hooks/useEntityForm'
import { CreateEntityPage } from './createEntity/CreateEntityPage'
import { DetailsStep } from './createEntity/DetailsStep'
import { LocationStep } from './createEntity/LocationStep'
import { PhotosStep } from './createEntity/PhotosStep'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'

const STEPS = [
  { id: 1, label: 'Details', icon: Info },
  { id: 2, label: 'Location', icon: MapPin },
  { id: 3, label: 'Photos', icon: Image },
]

export function CreatePost() {
  const queryClient = useQueryClient()
  const navigate = useNavigate()

  const { data: communities = [] } = useQuery({
    queryKey: ['communities-list'],
    queryFn: fetchCommunities,
  })

  const [postType, setPostType] = useState<number | null>(null)
  const [typeError, setTypeError] = useState<string | null>(null)

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
  } = useEntityForm()

  const mutation = useMutation({
    mutationFn: createPost,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      toast.success('Post created!')
      navigate('/posts')
    },
    onError: (err: unknown) => {
      const message = extractErrorMessage(err)
      toast.error(message)
    },
  })

  const selectedCommunity = communities.find(c => c.id === communityId)
  const selectedType = postType !== null ? (postType as PostType) : null
  const SelectedTypeIcon = selectedType ? POST_TYPE_ICONS[selectedType] : null

  function handleSubmit() {
    if (!validateDetails()) {
      setStep(1)
      toast.error('Please fix the required fields before creating the post.')
      return
    }

    if (postType === null) {
      setStep(1)
      setTypeError('Type is required.')
      toast.error('Please pick a post type.')
      return
    }

    mutation.mutate({
      title,
      description,
      type: postType,
      ...(communityId !== null ? { communityId } : {}),
      locationName: locationInput.trim() || undefined,
      latitude: location?.lat,
      longitude: location?.lng,
      photoUrls,
    })
  }

  const previewPost: Post = {
    id: 0,
    title: title || 'Your post title…',
    description: description || 'Description will appear here…',
    type: (postType ?? PostType.ExperienceShare) as PostType,
    author: { id: 0, username: 'You' },
    communityId: selectedCommunity?.id ?? 0,
    communityName: selectedCommunity?.name ?? 'Open to everyone',
    score: 0,
    locationName: locationInput || undefined,
    latitude: location?.lat,
    longitude: location?.lng,
    photoUrls: photoUrls ?? [],
    commentCount: 0,
    createdAt: new Date().toISOString(),
    updatedAt: new Date().toISOString(),
  }

  return (
    <CreateEntityPage
      steps={STEPS}
      currentStep={step}
      onStepChange={(s) => {
        if (s === 1 && step === 1 && !validateDetails()) return
        setStep(s)
      }}
      onSubmit={handleSubmit}
      isPending={mutation.isPending}
      submitLabel="Create Post"
      preview={
        <PostCard
          post={previewPost}
          currentUser={null}
          onVote={() => {}}
          isPreview
          className="rounded-2xl border bg-card shadow-sm overflow-hidden cursor-default"
        />
      }
    >
      {step === 1 && (
        <DetailsStep
          title={title}
          onTitleChange={setTitle}
          description={description}
          onDescriptionChange={setDescription}
          communities={communities}
          selectedCommunityId={communityId}
          onCommunitySelect={setCommunityId}
          communityOpen={communityOpen}
          onCommunityOpenChange={setCommunityOpen}
          detailErrors={detailErrors}
          onErrorClear={(field) => setDetailErrors((prev) => ({ ...prev, [field]: undefined }))}
          extraFields={
            <div className="space-y-2">
              <label className="text-xs font-semibold uppercase tracking-widest">
                Type <span className="text-destructive">*</span>
              </label>
              <Select
                value={postType?.toString()}
                onValueChange={(v) => {
                  setPostType(Number(v))
                  if (typeError) {
                    setTypeError(null)
                  }
                }}
              >
                <SelectTrigger
                  className={`h-12 bg-card border-border text-foreground data-placeholder:text-foreground hover:bg-accent hover:text-accent-foreground font-normal text-sm ${
                    typeError ? 'border-destructive focus:ring-destructive focus:border-destructive' : ''
                  }`}
                >
                  <SelectValue
                    placeholder="Pick a type"
                    className="text-foreground"
                  >
                    {selectedType && SelectedTypeIcon ? (
                      <span className="inline-flex items-center gap-2 text-sm">
                        <SelectedTypeIcon className="h-3.5 w-3.5" />
                        {POST_TYPE_LABELS[selectedType]}
                      </span>
                    ) : null}
                  </SelectValue>
                </SelectTrigger>
                <SelectContent className="rounded-2xl">
                  {Object.entries(POST_TYPE_LABELS).map(([value, label]) => (
                    <SelectItem key={value} value={value}>
                      {(() => {
                        const typeValue = Number(value) as PostType
                        const TypeIcon = POST_TYPE_ICONS[typeValue]

                        return (
                          <span className="flex items-center gap-2">
                            {TypeIcon && <TypeIcon className="h-4 w-4" />}
                            <span className="text-sm">
                              {label}
                            </span>
                          </span>
                        )
                      })()}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              {typeError && <p className="text-xs text-destructive">{typeError}</p>}
            </div>
          }
        />
      )}

      {step === 2 && (
        <LocationStep
          locationInput={locationInput}
          onLocationInputChange={setLocationInput}
          location={location}
          onLocationSelect={handleLocationSelect}
          isFetching={isFetchingLocation}
          isSearching={isSearchingLocation}
          searchResults={locationSearchResults}
          showResults={showLocationResults}
          onShowResultsChange={setShowLocationResults}
          onApplySearchResult={applyLocationSearchResult}
        />
      )}

      {step === 3 && (
        <PhotosStep
          photoUrls={photoUrls}
          onPhotoUrlsChange={setPhotoUrls}
          maxFiles={4}
          disabled={mutation.isPending}
          photoLabel="Post Photos"
        />
      )}
    </CreateEntityPage>
  )
}

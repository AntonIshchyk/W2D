import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useState, useEffect } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { Info, MapPin, Image } from 'lucide-react'
import { toast } from 'sonner'
import { fetchPost, updatePost, POST_TYPE_LABELS } from '../api/posts'
import { fetchCommunities } from '../api/communities'
import { useEntityForm } from '../hooks/useEntityForm'
import { extractErrorMessage } from '../lib/utils/errors'
import type { Post } from '../types/posts'
import { PostCard } from './PostCard'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { PostType } from '../types/posts'
import { EditEntityPage } from './create/EditEntityPage'
import { DetailsStep } from './createEntity/DetailsStep'
import { LocationStep } from './createEntity/LocationStep'
import { PhotosStep } from './createEntity/PhotosStep'

const STEPS = [
  { id: 1, label: 'Details', icon: Info },
  { id: 2, label: 'Location', icon: MapPin },
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
      const message = extractErrorMessage(err)
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
    locationName: locationInput || existingPost?.locationName || undefined,
    latitude: location?.lat ?? existingPost?.latitude,
    longitude: location?.lng ?? existingPost?.longitude,
    photoUrls: photoUrls ?? [],
    commentCount: existingPost?.commentCount ?? 0,
    createdAt: existingPost?.createdAt ?? new Date().toISOString(),
    updatedAt: new Date().toISOString(),
  }

  return (
    <EditEntityPage
      steps={STEPS}
      currentStep={step}
      onStepChange={setStep}
      onSubmit={handleSubmit}
      isPending={mutation.isPending}
      isLoading={isLoadingPost}
      entity={existingPost}
      submitLabel="Update Post"
      backUrl={`/posts/${postId}`}
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
          onErrorClear={(field: string) => setDetailErrors((prev) => ({ ...prev, [field]: undefined }))}
          extraFields={
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
    </EditEntityPage>
  )
}

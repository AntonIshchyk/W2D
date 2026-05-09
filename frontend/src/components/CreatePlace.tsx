import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { Info, MapPin, Image } from 'lucide-react'
import { toast } from 'sonner'
import { createPlace } from '../api/places'
import { fetchCommunities } from '../api/communities'
import { extractErrorMessage } from '../lib/utils/errors'
import type { Place } from '../types/places'
import { PlaceCard } from './PlaceCard'
import { useEntityForm } from '../hooks/useEntityForm'
import { CreateEntityPage } from './entity/CreateEntityPage'
import { DetailsStep } from './entity/DetailsStep'
import { LocationStep } from './entity/LocationStep'
import { PhotosStep } from './entity/PhotosStep'

const STEPS = [
  { id: 1, label: 'Details', icon: Info },
  { id: 2, label: 'Location', icon: MapPin },
  { id: 3, label: 'Photos', icon: Image },
]

export function CreatePlace() {
  const queryClient = useQueryClient()
  const navigate = useNavigate()

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
    handleUseMyLocation,
    validateDetails,
  } = useEntityForm()

  const mutation = useMutation({
    mutationFn: createPlace,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['places'] })
      toast.success('Place created!')
      navigate('/places')
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
      toast.error('Please fix the required fields before creating the place.')
      return
    }

    mutation.mutate({
      title,
      description,
      ...(communityId !== null ? { communityId } : {}),
      latitude: location?.lat,
      longitude: location?.lng,
      locationName: locationInput.trim() || undefined,
      photoUrls,
    })
  }

  const previewPlace: Place = {
    id: 0,
    title: title || 'Your place title…',
    description: description || 'Description will appear here…',
    userId: 0,
    userName: 'You',
    communityId: selectedCommunity?.id ?? null,
    communityName: selectedCommunity?.name ?? 'For everyone',
    latitude: location?.lat,
    longitude: location?.lng,
    locationName: locationInput || 'Choose a spot on the map',
    score: 0,
    commentCount: 0,
    photoUrls: photoUrls ?? [],
    createdAt: new Date().toISOString(),
    updatedAt: new Date().toISOString(),
  }

  return (
    <CreateEntityPage
      steps={STEPS}
      currentStep={step}
      onStepChange={setStep}
      onSubmit={handleSubmit}
      isPending={mutation.isPending}
      submitLabel="Create Place"
      preview={
        <PlaceCard
          place={previewPlace}
          isPreview
          className='rounded-2xl border bg-card shadow-sm overflow-hidden cursor-default'
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
          onUseMyLocation={handleUseMyLocation}
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
          photoLabel="Place Photos"
        />
      )}
    </CreateEntityPage>
  )
}

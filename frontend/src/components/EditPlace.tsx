import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { useNavigate, useParams } from 'react-router-dom'
import { Info, MapPin, Image } from 'lucide-react'
import { toast } from 'sonner'
import { updatePlace, fetchPlace } from '../api/places'
import { fetchCommunities } from '../api/communities'
import { extractErrorMessage } from '../lib/utils/errors'
import type { Place } from '../types/places'
import { PlaceCard } from './PlaceCard'
import { useEntityForm } from '../hooks/useEntityForm'
import { EditEntityPage } from './entity/EditEntityPage'
import { DetailsStep } from './entity/DetailsStep'
import { LocationStep } from './entity/LocationStep'
import { PhotosStep } from './entity/PhotosStep'

const STEPS = [
  { id: 1, label: 'Details', icon: Info },
  { id: 2, label: 'Location', icon: MapPin },
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
    handleUseMyLocation,
    validateDetails,
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
      navigate(`/places/${placeId}`)
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
    communityName: selectedCommunity?.name ?? existingPlace?.communityName ?? 'For everyone',
    latitude: location?.lat ?? existingPlace?.latitude,
    longitude: location?.lng ?? existingPlace?.longitude,
    locationName: locationInput || existingPlace?.locationName || 'Choose a spot on the map',
    score: existingPlace?.score ?? 0,
    commentCount: existingPlace?.commentCount ?? 0,
    photoUrls: photoUrls ?? [],
    createdAt: existingPlace?.createdAt ?? new Date().toISOString(),
    updatedAt: new Date().toISOString(),
  }

  return (
    <EditEntityPage
      steps={STEPS}
      currentStep={step}
      onStepChange={setStep}
      onSubmit={handleSubmit}
      isPending={mutation.isPending}
      isLoading={isLoadingPlace}
      entity={existingPlace}
      submitLabel="Update Place"
      backUrl="/places"
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
          onErrorClear={(field: string) => setDetailErrors((prev) => ({ ...prev, [field]: undefined }))}
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
    </EditEntityPage>
  )
}

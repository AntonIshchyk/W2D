import { useState, useEffect } from 'react'
import { z } from 'zod'
import { toast } from 'sonner'
import { useCitySearch } from './useCitySearch'
import { reverseGeocode } from '../api/places'
import type { CitySearchResult } from '../types/places'

export const eventDetailsSchema = z.object({
  title: z.string().trim().min(1, 'Title is required.'),
  description: z.string().trim().min(10, 'Description must be at least 10 characters.').max(500, 'Description must not exceed 500 characters.')
})

export type EventDetailsErrors = Partial<Record<keyof z.infer<typeof eventDetailsSchema>, string>>

export interface EntityFormData {
  title?: string
  description?: string
  communityId?: number | null
  latitude?: number
  longitude?: number
  locationName?: string
  photoUrls?: string[]
}

export function useEntityForm(existingData?: EntityFormData) {
  const [step, setStep] = useState(1)
  const [title, setTitle] = useState('')
  const [description, setDescription] = useState('')
  const [communityId, setCommunityId] = useState<number | null>(null)
  const [communityOpen, setCommunityOpen] = useState(false)
  const [location, setLocation] = useState<{ lat: number; lng: number } | null>(null)
  const [photoUrls, setPhotoUrls] = useState<string[]>([])
  const [isFetchingLocation, setIsFetchingLocation] = useState(false)
  const [detailErrors, setDetailErrors] = useState<EventDetailsErrors>({})

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

  useEffect(() => {
    if (!existingData) return

    setTitle(existingData.title ?? '')
    setDescription(existingData.description ?? '')
    setCommunityId(existingData.communityId ?? null)
    setPhotoUrls(existingData.photoUrls ?? [])
    setLocation(
      typeof existingData.latitude === 'number' && typeof existingData.longitude === 'number'
        ? { lat: existingData.latitude, lng: existingData.longitude }
        : null,
    )
    setLocationInputSilently(existingData.locationName ?? '')
  }, [existingData, setLocationInputSilently])

  const applyLocationSearchResult = (result: CitySearchResult) => {
    const lat = parseFloat(result.lat)
    const lng = parseFloat(result.lon)

    if (Number.isNaN(lat) || Number.isNaN(lng)) return

    setLocation({ lat, lng })
    setLocationInputSilently(result.display_name)
  }

  const handleUseMyLocation = async () => {
    if (!('geolocation' in navigator)) {
      toast.error('Please enable geolocation in your browser')
      return
    }

    setIsFetchingLocation(true)

    navigator.geolocation.getCurrentPosition(
      async (pos) => {
        const lat = pos.coords.latitude
        const lng = pos.coords.longitude

        setLocation({ lat, lng })

        try {
          const displayName = await reverseGeocode(lat, lng)
          if (displayName) setLocationInputSilently(displayName)
        } catch {
          toast.error('Could not resolve your location')
        } finally {
          setIsFetchingLocation(false)
        }
      },
      () => {
        toast.error('Could not get your location')
        setIsFetchingLocation(false)
      },
      { enableHighAccuracy: true, timeout: 10_000 },
    )
  }

  const handleLocationSelect = async (lat: number, lng: number) => {
    setLocation({ lat, lng })
    setIsFetchingLocation(true)
    try {
      const displayName = await reverseGeocode(lat, lng)
      if (displayName) setLocationInputSilently(displayName)
    } catch {
      return
    } finally {
      setIsFetchingLocation(false)
    }
  }

  const validateDetails = () => {
    const parsed = eventDetailsSchema.safeParse({ title, description })

    if (parsed.success) {
      setDetailErrors({})
      return true
    }

    const fieldErrors = parsed.error.flatten().fieldErrors
    setDetailErrors({
      title: fieldErrors.title?.[0],
      description: fieldErrors.description?.[0]
    })
    return false
  }

  return {
    step, setStep,
    title, setTitle,
    description, setDescription,
    communityId, setCommunityId,
    communityOpen, setCommunityOpen,
    location, setLocation,
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
  }
}
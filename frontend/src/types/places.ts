export interface Community {
  id: number
  name: string
}

export interface Place {
  id: number
  title: string
  description: string
  userId: number
  userName: string
  userPhotoUrl?: string | null
  communityId: number | null
  communityName: string | null
  latitude?: number
  longitude?: number
  locationName?: string
  photoUrls: string[]
  createdAt: string
  updatedAt: string
}

export interface PlaceQueryBounds {
  minLat: number
  maxLat: number
  minLng: number
  maxLng: number
}

export interface CreatePlaceRequest {
  title: string
  description: string
  communityId?: number | null
  latitude?: number
  longitude?: number
  locationName?: string
  photoUrls?: string[]
}

export interface UpdatePlaceRequest {
  title?: string
  description?: string
  communityId?: number | null
  latitude?: number
  longitude?: number
  locationName?: string
  photoUrls?: string[]
}

export interface CitySearchResult {
  lat: string
  lon: string
  display_name: string
  boundingbox?: string[]
}

export type ViewMode = 'map' | 'list'

export type SearchLocation = {
  name: string
  lat: number
  lon: number
  bounds: PlaceQueryBounds
}

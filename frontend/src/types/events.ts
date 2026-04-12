export interface Community {
  id: number
  name: string
}

export interface Event {
  id: number
  title: string
  description: string
  organizerId: number
  organizerName: string
  topicId: number | null
  communityName: string | null
  scheduledAt: string
  status: string
  latitude?: number
  longitude?: number
  locationName?: string
  placeId?: string
  createdAt: string
  updatedAt: string
}

export interface EventQueryBounds {
  minLat: number
  maxLat: number
  minLng: number
  maxLng: number
}

export interface CreateEventRequest {
  title: string
  description: string
  scheduledAt: string
  topicId?: number | null
  latitude?: number
  longitude?: number
  locationName?: string
}

export interface UpdateEventRequest {
  title?: string
  description?: string
  scheduledAt?: string
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
  bounds: EventQueryBounds
}

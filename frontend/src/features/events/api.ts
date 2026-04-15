import { API_ENDPOINTS, getAuthHeaders } from '../../config/api'
import { PAGINATION } from '../../config/constants'
import { ensureResponseOk } from '../../lib/utils/http'
import type {
  CitySearchResult,
  Community,
  CreateEventRequest,
  Event,
  EventQueryBounds,
  UpdateEventRequest,
} from '../../types/events'

export async function fetchEvents(
  communityId?: number,
  bounds?: EventQueryBounds
): Promise<Event[]> {
  const params = new URLSearchParams()

  if (communityId) params.append('communityId', communityId.toString())

  if (bounds) {
    params.append('minLat', bounds.minLat.toString())
    params.append('maxLat', bounds.maxLat.toString())
    params.append('minLng', bounds.minLng.toString())
    params.append('maxLng', bounds.maxLng.toString())
  }

  const response = await fetch(`${API_ENDPOINTS.events.base}?${params}`, {
    headers: getAuthHeaders(),
  })

  await ensureResponseOk(response, 'Failed to fetch events')

  return response.json()
}

export async function fetchCommunities(): Promise<Community[]> {
  const response = await fetch(
    `${API_ENDPOINTS.communities.base}?limit=${PAGINATION.COMMUNITIES_FETCH_SIZE}`,
    { headers: getAuthHeaders() }
  )

  await ensureResponseOk(response, 'Failed to fetch communities')

  const json = await response.json()
  return Array.isArray(json) ? json : (json.items ?? [])
}

export async function createEvent(data: CreateEventRequest): Promise<Event> {
  const response = await fetch(API_ENDPOINTS.events.base, {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(data),
  })

  await ensureResponseOk(response, 'Failed to create event')

  return response.json()
}

export async function fetchEvent(id: number): Promise<Event> {
  const response = await fetch(API_ENDPOINTS.events.byId(id), {
    headers: getAuthHeaders(),
  })

  await ensureResponseOk(response, 'Event not found')

  return response.json()
}

export async function updateEvent(id: number, data: UpdateEventRequest): Promise<Event> {
  const response = await fetch(API_ENDPOINTS.events.byId(id), {
    method: 'PUT',
    headers: getAuthHeaders(),
    body: JSON.stringify(data),
  })

  await ensureResponseOk(response, 'Failed to update event')

  return response.json()
}

export async function deleteEvent(id: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.events.byId(id), {
    method: 'DELETE',
    headers: getAuthHeaders(),
  })

  await ensureResponseOk(response, 'Failed to delete event')
}

export async function searchCities(query: string): Promise<CitySearchResult[]> {
  const response = await fetch(
    `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(query)}`
  )

  await ensureResponseOk(response, 'Search failed')

  return response.json()
}

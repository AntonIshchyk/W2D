import { API_ENDPOINTS, getAuthHeaders } from '../../config/api'
import { PAGINATION } from '../../config/constants'
import type {
  CitySearchResult,
  Community,
  CreateEventRequest,
  Event,
  EventQueryBounds,
  UpdateEventRequest,
} from '../../types/events'

function getErrorMessage(fallback: string, payload: unknown): string {
  if (payload && typeof payload === 'object' && 'message' in payload) {
    const maybeMessage = (payload as { message?: unknown }).message
    if (typeof maybeMessage === 'string' && maybeMessage.trim()) {
      return maybeMessage
    }
  }
  return fallback
}

export async function fetchEvents(
  topicId?: number,
  bounds?: EventQueryBounds
): Promise<Event[]> {
  const params = new URLSearchParams()

  if (topicId) params.append('topicId', topicId.toString())

  if (bounds) {
    params.append('minLat', bounds.minLat.toString())
    params.append('maxLat', bounds.maxLat.toString())
    params.append('minLng', bounds.minLng.toString())
    params.append('maxLng', bounds.maxLng.toString())
  }

  const response = await fetch(`${API_ENDPOINTS.events.base}?${params}`, {
    headers: getAuthHeaders(),
  })

  if (!response.ok) throw new Error('Failed to fetch events')

  return response.json()
}

export async function fetchCommunities(): Promise<Community[]> {
  const response = await fetch(
    `${API_ENDPOINTS.communities.base}?limit=${PAGINATION.COMMUNITIES_FETCH_SIZE}`,
    { headers: getAuthHeaders() }
  )

  if (!response.ok) throw new Error('Failed to fetch communities')

  const json = await response.json()
  return Array.isArray(json) ? json : (json.items ?? [])
}

export async function createEvent(data: CreateEventRequest): Promise<Event> {
  const response = await fetch(API_ENDPOINTS.events.base, {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(data),
  })

  if (!response.ok) {
    let msg = 'Failed to create event'
    try {
      msg = getErrorMessage(msg, await response.json())
    } catch {
      // Keep fallback message.
    }
    throw new Error(msg)
  }

  return response.json()
}

export async function fetchEvent(id: number): Promise<Event> {
  const response = await fetch(API_ENDPOINTS.events.byId(id), {
    headers: getAuthHeaders(),
  })

  if (!response.ok) throw new Error('Event not found')

  return response.json()
}

export async function updateEvent(id: number, data: UpdateEventRequest): Promise<Event> {
  const response = await fetch(API_ENDPOINTS.events.byId(id), {
    method: 'PUT',
    headers: getAuthHeaders(),
    body: JSON.stringify(data),
  })

  if (!response.ok) {
    let msg = 'Failed to update event'
    try {
      msg = getErrorMessage(msg, await response.json())
    } catch {
      // Keep fallback message.
    }
    throw new Error(msg)
  }

  return response.json()
}

export async function deleteEvent(id: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.events.byId(id), {
    method: 'DELETE',
    headers: getAuthHeaders(),
  })

  if (!response.ok) throw new Error('Failed to delete event')
}

export async function searchCities(query: string): Promise<CitySearchResult[]> {
  const response = await fetch(
    `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(query)}`
  )

  if (!response.ok) throw new Error('Search failed')

  return response.json()
}

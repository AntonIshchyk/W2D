import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { ensureResponseOk } from '../lib/utils/http'
import type {
  CitySearchResult,
  CreateEventRequest,
  Event,
  EventQueryBounds,
  UpdateEventRequest,
} from '../types/events'

export async function fetchEvents(
  communityIds?: number[],
  bounds?: EventQueryBounds
): Promise<Event[]> {
  const params = new URLSearchParams()

  if (communityIds && communityIds.length > 0) {
    communityIds.forEach((id) => params.append('communityId', id.toString()))
  }

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
    `https://photon.komoot.io/api/?q=${encodeURIComponent(query)}&limit=8`
  )

  await ensureResponseOk(response, 'Search failed')

  const data = await response.json()
  
  const results: CitySearchResult[] = []
  const seenNames = new Set<string>()

  for (const f of data.features) {
    const props = f.properties
    const coords = f.geometry.coordinates
    const nameParts = [props.name, props.city, props.state, props.country].filter(Boolean)
    const uniqueNameParts = Array.from(new Set(nameParts))
    const displayName = uniqueNameParts.join(', ')

    if (seenNames.has(displayName)) continue
    seenNames.add(displayName)

    let boundingbox: string[] | undefined = undefined
    if (props.extent) {
      const minLon = Math.min(props.extent[0], props.extent[2]).toString()
      const maxLon = Math.max(props.extent[0], props.extent[2]).toString()
      const minLat = Math.min(props.extent[1], props.extent[3]).toString()
      const maxLat = Math.max(props.extent[1], props.extent[3]).toString()
      boundingbox = [minLat, maxLat, minLon, maxLon]
    }

    results.push({
      lat: coords[1].toString(),
      lon: coords[0].toString(),
      display_name: displayName,
      boundingbox,
    })
  }

  return results
}

export async function reverseGeocode(lat: number, lng: number): Promise<string | null> {
  const response = await fetch(`https://photon.komoot.io/reverse?lon=${lng}&lat=${lat}`)
  await ensureResponseOk(response, 'Reverse geocoding failed')

  const data = await response.json()
  if (!data.features || data.features.length === 0) {
    return null
  }

  const props = data.features[0].properties
  const nameParts = [props.name, props.city, props.state, props.country].filter(Boolean)
  const uniqueNameParts = Array.from(new Set(nameParts))
  return uniqueNameParts.join(', ') || null
}

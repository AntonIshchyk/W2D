import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { ensureResponseOk } from '../lib/utils/http'
import type {
  CitySearchResult,
  CreatePlaceRequest,
  Place,
  PlaceQueryBounds,
  UpdatePlaceRequest,
} from '../types/places'

const COORDINATE_PAIR_REGEX =
  /^\s*[-+]?\d+(?:\.\d+)?\s*,\s*[-+]?\d+(?:\.\d+)?\s*$/
const NUMERIC_LABEL_REGEX = /^\s*[-+]?\d+(?:\.\d+)?\s*$/

function normalizeLocationPart(value: unknown): string | null {
  if (typeof value !== 'string') return null

  const trimmed = value.trim()
  if (!trimmed) return null

  if (COORDINATE_PAIR_REGEX.test(trimmed) || NUMERIC_LABEL_REGEX.test(trimmed)) {
    return null
  }

  return trimmed
}

function buildDisplayName(props: Record<string, unknown>): string | null {
  const candidates = [
    props.name,
    props.street,
    props.district,
    props.city,
    props.county,
    props.state,
    props.country,
  ]

  const uniqueParts: string[] = []
  const seen = new Set<string>()

  for (const part of candidates) {
    const normalized = normalizeLocationPart(part)
    if (!normalized) continue

    const key = normalized.toLowerCase()
    if (seen.has(key)) continue

    seen.add(key)
    uniqueParts.push(normalized)
  }

  return uniqueParts.length > 0 ? uniqueParts.join(', ') : null
}

export async function fetchPlaces(
  communityIds?: number[],
  bounds?: PlaceQueryBounds,
  userId?: number
): Promise<Place[]> {
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

  if (typeof userId === 'number') {
    params.append('userId', userId.toString())
  }

  const response = await fetch(`${API_ENDPOINTS.places.base}?${params}`, {
    headers: getAuthHeaders(),
  })

  await ensureResponseOk(response, 'Failed to fetch places')

  return response.json()
}

export async function createPlace(data: CreatePlaceRequest): Promise<Place> {
  const response = await fetch(API_ENDPOINTS.places.base, {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(data),
  })

  await ensureResponseOk(response, 'Failed to create place')

  return response.json()
}

export async function fetchPlace(id: number): Promise<Place> {
  const response = await fetch(API_ENDPOINTS.places.byId(id), {
    headers: getAuthHeaders(),
  })

  await ensureResponseOk(response, 'Place not found')

  return response.json()
}

export async function updatePlace(id: number, data: UpdatePlaceRequest): Promise<Place> {
  const response = await fetch(API_ENDPOINTS.places.byId(id), {
    method: 'PUT',
    headers: getAuthHeaders(),
    body: JSON.stringify(data),
  })

  await ensureResponseOk(response, 'Failed to update place')

  return response.json()
}

export async function deletePlace(id: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.places.byId(id), {
    method: 'DELETE',
    headers: getAuthHeaders(),
  })

  await ensureResponseOk(response, 'Failed to delete place')
}

export async function votePlace(placeId: number, value: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.places.vote(placeId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify({ value }),
  })

  await ensureResponseOk(response, 'Failed to vote on place')
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
    const props = (f.properties ?? {}) as Record<string, unknown>
    const coords = f.geometry.coordinates
    const displayName = buildDisplayName(props)

    if (!displayName) continue

    if (seenNames.has(displayName)) continue
    seenNames.add(displayName)

    let boundingbox: string[] | undefined = undefined
    const extent = Array.isArray(props.extent) ? props.extent : null
    if (extent && extent.length >= 4) {
      const e0 = Number(extent[0])
      const e1 = Number(extent[1])
      const e2 = Number(extent[2])
      const e3 = Number(extent[3])

      if ([e0, e1, e2, e3].every((n) => Number.isFinite(n))) {
        const minLon = Math.min(e0, e2).toString()
        const maxLon = Math.max(e0, e2).toString()
        const minLat = Math.min(e1, e3).toString()
        const maxLat = Math.max(e1, e3).toString()
        boundingbox = [minLat, maxLat, minLon, maxLon]
      }
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
  const response = await fetch(
    `https://nominatim.openstreetmap.org/reverse?lat=${lat}&lon=${lng}&format=json`
  )

  await ensureResponseOk(response, 'Reverse geocoding failed')

  const data = await response.json()

  return data.display_name ?? null
}

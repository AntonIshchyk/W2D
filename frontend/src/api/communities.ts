import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PAGINATION } from '../config/constants'
import { ensureResponseOk } from '../lib/utils/http'

export interface Community {
  id: number
  name: string
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

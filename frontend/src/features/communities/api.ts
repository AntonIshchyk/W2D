import { API_ENDPOINTS, getAuthHeaders } from '../../config/api'

export interface Community {
  id: number
  name: string
}

export async function fetchCommunities(): Promise<Community[]> {
  const response = await fetch(API_ENDPOINTS.communities.base, { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch communities')
  return response.json()
}

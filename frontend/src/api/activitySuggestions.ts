import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { ensureResponseOk } from '../lib/utils/http'
import type {
  ActivitySuggestionRequest,
  ActivitySuggestionResponse,
} from '../types/activitySuggestions'

export async function getActivitySuggestions(
  request: ActivitySuggestionRequest
): Promise<ActivitySuggestionResponse> {
  const response = await fetch(API_ENDPOINTS.activities.suggestions, {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(request),
  })

  await ensureResponseOk(response, 'Failed to get activity suggestions')

  return response.json()
}

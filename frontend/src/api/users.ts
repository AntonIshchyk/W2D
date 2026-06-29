import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { ensureResponseOk } from '../lib/utils/http'

export interface LoginResponse {
  token: string
}

export interface UpdateCurrentUserProfileRequest {
  username: string
  bio: string
}

export async function googleLogin(credential: string): Promise<LoginResponse> {
  const response = await fetch(API_ENDPOINTS.users.googleLogin, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ credential }),
  })

  await ensureResponseOk(response, 'Google login failed')

  return response.json()
}

export async function updateCurrentUserProfile(
  payload: UpdateCurrentUserProfileRequest
): Promise<LoginResponse> {
  const response = await fetch(API_ENDPOINTS.users.me, {
    method: 'PUT',
    headers: getAuthHeaders(),
    body: JSON.stringify(payload),
  })

  await ensureResponseOk(response, 'Failed to update profile')

  return response.json()
}

export async function deleteCurrentUserAccount(): Promise<void> {
  const response = await fetch(API_ENDPOINTS.users.me, {
    method: 'DELETE',
    headers: getAuthHeaders(),
  })

  await ensureResponseOk(response, 'Failed to delete account')
}

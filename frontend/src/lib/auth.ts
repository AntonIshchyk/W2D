import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { clearAuthToken } from '../hooks/useAuthSync'

export interface UserInfo {
  userId: number
  email: string
  username: string
  bio?: string | null
  profilePhotoUrl?: string | null
  profileSetupComplete: boolean
}

export class ApiError extends Error {
  status: number
  constructor(message: string, status: number) {
    super(message)
    this.name = 'ApiError'
    this.status = status
  }
}

export function isTokenExpired(token: string): boolean {
  try {
    const base64Url = token.split('.')[1]
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/')
    const payload = JSON.parse(atob(base64))
    return payload.exp * 1000 < Date.now()
  } catch {
    return true
  }
}

export async function fetchCurrentUser(): Promise<UserInfo> {
  const token = localStorage.getItem('token')
  
  if (!token) {
    throw new ApiError('No token', 401)
  }

  if (isTokenExpired(token)) {
    clearAuthToken()
    throw new ApiError('Token expired', 401)
  }

  const response = await fetch(API_ENDPOINTS.users.me, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new ApiError('Unauthorized', response.status)
  }

  return await response.json() as UserInfo
}

import { API_ENDPOINTS, getAuthHeaders } from '../config/api'

export interface UserInfo {
  userId: number
  email: string
  name: string
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
    const payload = JSON.parse(atob(token.split('.')[1]))
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
    localStorage.removeItem('token')
    throw new ApiError('Token expired', 401)
  }

  const response = await fetch(API_ENDPOINTS.users.me, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new ApiError('Unauthorized', response.status)
  }

  return response.json()
}

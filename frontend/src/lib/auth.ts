import { API_ENDPOINTS, getAuthHeaders } from '../config/api'

export interface UserInfo {
  userId: number
  email: string
  name: string
  age: number
  gender: string
}

export async function fetchCurrentUser(): Promise<UserInfo> {
  const token = localStorage.getItem('token')
  
  if (!token) {
    throw new Error('No token')
  }

  const response = await fetch(API_ENDPOINTS.users.me, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Unauthorized')
  }

  return response.json()
}

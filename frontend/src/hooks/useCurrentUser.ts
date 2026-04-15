import { useQuery } from '@tanstack/react-query'
import { fetchCurrentUser, isTokenExpired } from '../lib/auth'
import { getAuthToken } from '../lib/authToken'

export function useCurrentUser() {
  const token = getAuthToken()
  
  return useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    enabled: !!token && !isTokenExpired(token ?? ''),
    retry: false,
  })
}

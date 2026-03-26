import { useQuery } from '@tanstack/react-query'
import { fetchCurrentUser, isTokenExpired } from '../lib/auth'

export function useCurrentUser() {
  const token = localStorage.getItem('token')
  
  return useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    enabled: !!token && !isTokenExpired(token ?? ''),
    retry: false,
  })
}

import { useEffect } from 'react'
import { useQueryClient } from '@tanstack/react-query'

/**
 * Hook that clears React Query cache whenever the authentication token changes.
 * This ensures that cached data from a previous user session is not shown to a new user.
 */
export function useAuthSync() {
  const queryClient = useQueryClient()

  useEffect(() => {
    const currentToken = localStorage.getItem('token')
    const lastToken = sessionStorage.getItem('lastToken')

    // If token has changed (login, logout, or token swap), clear cache
    if (currentToken !== lastToken) {
      queryClient.clear()
      sessionStorage.setItem('lastToken', currentToken || '')
    }

    // Listen for storage events from other tabs
    const handleStorageChange = (e: StorageEvent) => {
      if (e.key === 'token' && e.newValue !== e.oldValue) {
        queryClient.clear()
        sessionStorage.setItem('lastToken', e.newValue || '')
      }
    }

    window.addEventListener('storage', handleStorageChange)

    return () => {
      window.removeEventListener('storage', handleStorageChange)
    }
  }, [queryClient])
}

import { useEffect, useCallback } from 'react'
import { useQueryClient } from '@tanstack/react-query'

/**
 * Hook that clears React Query cache whenever the authentication token changes.
 * This ensures that cached data from a previous user session is not shown to a new user.
 * Handles both same-tab and cross-tab token changes.
 */
export function useAuthSync() {
  const queryClient = useQueryClient()

  const syncToken = useCallback(() => {
    const currentToken = localStorage.getItem('token')
    const lastToken = sessionStorage.getItem('lastToken')

    if (currentToken !== lastToken) {
      queryClient.clear()
      sessionStorage.setItem('lastToken', currentToken || '')
    }
  }, [queryClient])

  useEffect(() => {
    // Initial sync
    syncToken()

    // Listen for storage events from other tabs
    const handleStorageChange = (e: StorageEvent) => {
      if (e.key === 'token' && e.newValue !== e.oldValue) {
        queryClient.clear()
        sessionStorage.setItem('lastToken', e.newValue || '')
      }
    }

    // Listen for same-tab custom events (fired on login/logout)
    const handleTokenChange = () => syncToken()

    window.addEventListener('storage', handleStorageChange)
    window.addEventListener('token-changed', handleTokenChange)

    return () => {
      window.removeEventListener('storage', handleStorageChange)
      window.removeEventListener('token-changed', handleTokenChange)
    }
  }, [queryClient, syncToken])
}

/**
 * Helper to set/remove token and dispatch a same-tab event.
 * Use this instead of raw localStorage calls for login/logout.
 */
export function setAuthToken(token: string) {
  localStorage.setItem('token', token)
  window.dispatchEvent(new Event('token-changed'))
}

export function clearAuthToken() {
  localStorage.removeItem('token')
  window.dispatchEvent(new Event('token-changed'))
}

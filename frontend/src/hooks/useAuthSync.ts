import { useEffect, useCallback } from 'react'
import { useQueryClient } from '@tanstack/react-query'
import { clearAuthTokenStorage, getAuthToken, setAuthTokenStorage } from '../lib/authToken'

export function useAuthSync() {
  const queryClient = useQueryClient()

  const syncToken = useCallback(() => {
    const currentToken = getAuthToken()
    const lastToken = sessionStorage.getItem('lastToken')

    if (currentToken !== lastToken) {
      queryClient.clear()
      sessionStorage.setItem('lastToken', currentToken || '')
    }
  }, [queryClient])

  useEffect(() => {
    syncToken()

    const handleStorageChange = (e: StorageEvent) => {
      if (e.key === 'token' && e.newValue !== e.oldValue) {
        queryClient.clear()
        sessionStorage.setItem('lastToken', e.newValue || '')
      }
    }

    const handleTokenChange = () => syncToken()

    window.addEventListener('storage', handleStorageChange)
    window.addEventListener('token-changed', handleTokenChange)

    return () => {
      window.removeEventListener('storage', handleStorageChange)
      window.removeEventListener('token-changed', handleTokenChange)
    }
  }, [queryClient, syncToken])
}

export function setAuthToken(token: string) {
  setAuthTokenStorage(token)
  window.dispatchEvent(new Event('token-changed'))
}

export function clearAuthToken() {
  clearAuthTokenStorage()
  window.dispatchEvent(new Event('token-changed'))
}

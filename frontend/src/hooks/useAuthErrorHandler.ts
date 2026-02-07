import { useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { ApiError } from '../lib/auth'
import { clearAuthToken } from './useAuthSync'

/**
 * Custom hook to handle authentication errors by redirecting to login.
 * Only acts on 401 Unauthorized errors — not network failures or 500s.
 */
export function useAuthErrorHandler(isError: boolean, error?: Error | null) {
  const navigate = useNavigate()

  useEffect(() => {
    if (isError && error instanceof ApiError && error.status === 401) {
      clearAuthToken()
      navigate('/login')
    }
  }, [isError, error, navigate])
}

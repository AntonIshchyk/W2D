import { useEffect } from 'react'
import { useNavigate } from 'react-router-dom'

/**
 * Custom hook to handle authentication errors by redirecting to login
 * and clearing the token from localStorage
 */
export function useAuthErrorHandler(isError: boolean) {
  const navigate = useNavigate()

  useEffect(() => {
    if (isError) {
      localStorage.removeItem('token')
      navigate('/login')
    }
  }, [isError, navigate])
}

import React, { useMemo } from 'react'
import { Navigate, useLocation } from 'react-router-dom'
import { isTokenExpired } from '../lib/auth'
import { clearAuthToken } from '../hooks/useAuthSync'

export const ProtectedRoute = React.memo(({ children }: { children: React.ReactNode }) => {
  const location = useLocation()
  
  // Cache localStorage reads
  const token = localStorage.getItem('token')
  const isOnboardingPending = localStorage.getItem('onboarding_pending') === '1'

  // Memoize navigation logic
  const navigationTarget = useMemo(() => {
    if (!token || isTokenExpired(token)) {
      if (token) clearAuthToken()
      return '/login'
    }
    
    const isOnOnboarding = location.pathname === '/onboarding'
    if (isOnboardingPending && !isOnOnboarding) return '/onboarding'
    if (!isOnboardingPending && isOnOnboarding) return '/'
    
    return null
  }, [token, isTokenExpired, isOnboardingPending, location.pathname])

  if (navigationTarget) {
    return <Navigate to={navigationTarget} replace />
  }

  return <>{children}</>
})

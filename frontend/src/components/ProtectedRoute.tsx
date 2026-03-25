import React, { useMemo } from 'react'
import { Navigate, useLocation } from 'react-router-dom'
import { isTokenExpired } from '../lib/auth'
import { clearAuthToken } from '../hooks/useAuthSync'
import { useCurrentUser } from '../hooks/useCurrentUser'

export const ProtectedRoute = React.memo(({ children }: { children: React.ReactNode }) => {
  const location = useLocation()
  
  // Cache localStorage reads
  const token = localStorage.getItem('token')
  
  // Use server-side onboarding state
  const { data: currentUser } = useCurrentUser()

  // Memoize navigation logic
  const navigationTarget = useMemo(() => {
    if (!token || isTokenExpired(token)) {
      if (token) clearAuthToken()
      return '/login'
    }
    
    if (!currentUser) return null // Still loading user data
    
    const isOnOnboarding = location.pathname === '/onboarding'
    const isOnboardingComplete = currentUser.onboardingCompleted
    
    if (!isOnboardingComplete && !isOnOnboarding) return '/onboarding'
    if (isOnboardingComplete && isOnOnboarding) return '/'
    
    return null
  }, [token, currentUser, location.pathname])

  if (navigationTarget) {
    return <Navigate to={navigationTarget} replace />
  }

  return <>{children}</>
})

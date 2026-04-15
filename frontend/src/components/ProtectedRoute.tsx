import React, { useMemo } from 'react'
import { Navigate, useLocation } from 'react-router-dom'
import { isTokenExpired } from '../lib/auth'
import { clearAuthToken } from '../hooks/useAuthSync'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { getAuthToken } from '../lib/authToken'

export const ProtectedRoute = React.memo(({ children }: { children: React.ReactNode }) => {
  const location = useLocation()
  
  const token = getAuthToken()
  
  // Use server-side profile setup state
  const { data: currentUser } = useCurrentUser()

  // Memoize navigation logic
  const navigationTarget = useMemo(() => {
    if (!token || isTokenExpired(token)) {
      if (token) clearAuthToken()
      return '/login'
    }
    
    if (!currentUser) return null // Still loading user data
    
    const isProfileSetup = location.pathname === '/profile-setup'
    const isSetupComplete = currentUser.profileSetupComplete
    
    if (!isSetupComplete && !isProfileSetup) return '/profile-setup'
    if (isSetupComplete && isProfileSetup) return '/'
    
    return null
  }, [token, currentUser, location.pathname])

  if (navigationTarget) {
    return <Navigate to={navigationTarget} replace />
  }

  return <>{children}</>
})

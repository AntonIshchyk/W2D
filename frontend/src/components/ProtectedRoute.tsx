import React from 'react'
import { Navigate, useLocation } from 'react-router-dom'
import { ApiError, isTokenExpired } from '../lib/auth'
import { clearAuthToken } from '../hooks/useAuthSync'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { getAuthToken } from '../lib/authToken'

export const ProtectedRoute = React.memo(({ children }: { children: React.ReactNode }) => {
  const location = useLocation()
  const token = getAuthToken()
  const { data: currentUser, isLoading, isError, error } = useCurrentUser()

  if (!token || isTokenExpired(token)) {
    if (token) clearAuthToken()
    return <Navigate to="/login" replace state={{ from: location }} />
  }

  if (isError) {
    if (error instanceof ApiError && error.status === 401) {
      clearAuthToken()
    }
    return <Navigate to="/login" replace state={{ from: location }} />
  }

  if (isLoading || !currentUser) {
    return null
  }

  const isProfileSetupPage = location.pathname === '/profile-setup'
  const isSetupComplete = currentUser.profileSetupComplete

  if (!isSetupComplete && !isProfileSetupPage) {
    return <Navigate to="/profile-setup" replace state={{ from: location }} />
  }

  if (isSetupComplete && isProfileSetupPage) {
    return <Navigate to="/" replace />
  }

  return <>{children}</>
})

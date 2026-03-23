import { Navigate, useLocation } from 'react-router-dom'
import { isTokenExpired } from '../lib/auth'
import { clearAuthToken } from '../hooks/useAuthSync'

export function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const location = useLocation()
  const token = localStorage.getItem('token')

  if (!token || isTokenExpired(token)) {
    if (token) clearAuthToken()
    return <Navigate to="/login" replace />
  }

  const isOnboardingPending = localStorage.getItem('onboarding_pending') === '1'
  if (isOnboardingPending && location.pathname !== '/onboarding') {
    return <Navigate to="/onboarding" replace />
  }

  if (!isOnboardingPending && location.pathname === '/onboarding') {
    return <Navigate to="/" replace />
  }

  return <>{children}</>
}

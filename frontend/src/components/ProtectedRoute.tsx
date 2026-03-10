import { Navigate } from 'react-router-dom'
import { isTokenExpired } from '../lib/auth'
import { clearAuthToken } from '../hooks/useAuthSync'

export function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const token = localStorage.getItem('token')

  if (!token || isTokenExpired(token)) {
    if (token) clearAuthToken()
    return <Navigate to="/login" replace />
  }

  return <>{children}</>
}

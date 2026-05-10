import { useMutation } from '@tanstack/react-query'
import { useLocation, useNavigate } from 'react-router-dom'
import { useGoogleLogin } from '@react-oauth/google'
import { toast } from 'sonner'
import { setAuthToken } from '../hooks/useAuthSync'
import { googleLogin } from '../api/users'
import { PlacesMap } from './PlacesMap'
import logo from '../assets/logo.png'
import googleIcon from '../assets/google.png'
import type { Place } from '../types/places'

const MOCK_PLACES = [
  { id: 1, latitude: 51.924, longitude: 4.481, title: 'Rooftop Bar',   score: 48 },
  { id: 2, latitude: 51.920, longitude: 4.476, title: 'Canal Walk',    score: 91 },
  { id: 3, latitude: 51.918, longitude: 4.484, title: 'Hidden Garden', score: 34 },
] as Place[]

export function Login() {
  const navigate = useNavigate()
  const location = useLocation()
  const redirectPath = (location.state as { from?: { pathname?: string } } | null)?.from?.pathname ?? '/'

  const googleMutation = useMutation({
    mutationFn: googleLogin,
    onSuccess: (data) => {
      setAuthToken(data.token)
      navigate(redirectPath)
    },
    onError: (error: Error) => {
      toast.error(error.message)
    },
  })

  const login = useGoogleLogin({
    onSuccess: (tokenResponse) => {
      googleMutation.mutate(tokenResponse.access_token)
    },
    onError: () => toast.error('Google login failed'),
  })

  return (
    <div className="min-h-screen flex text-foreground">
      <div className="hidden lg:block lg:w-[58%] relative overflow-hidden">
        <div className="absolute inset-0 pointer-events-none">
          <PlacesMap
            places={MOCK_PLACES}
            onBoundsChange={() => {}}
            initialCenter={[51.922, 4.479]}
            initialZoom={14}
          />
        </div>
        <div className="absolute inset-0 bg-linear-to-b from-transparent via-background/50 to-background pointer-events-none" />
        <div className="absolute inset-0 bg-linear-to-r from-background via-transparent to-transparent pointer-events-none" />
        <div className="absolute bottom-10 left-10 z-10">
          <h2 className="text-2xl font-bold tracking-tight text-foreground leading-tight">
            Discover places and people of your interests
          </h2>
        </div>
      </div>

      <div className="flex-1 flex flex-col items-center justify-center bg-background">
        <div className="w-full max-w-[320px] flex flex-col items-center text-center">

          <img src={logo} alt="W2D" className="h-auto w-auto" />

          <div className="w-full">
            <button
              type="button"
              onClick={() => login()}
              disabled={googleMutation.isPending}
              className="w-full flex items-center justify-center gap-3 h-14 px-6 rounded-xl border border-border bg-card text-foreground text-base font-semibold shadow-sm hover:border-primary transition-colors disabled:opacity-50 disabled:cursor-not-allowed"
            >
              <img src={googleIcon} className="h-5 w-5" alt="Google Icon" />
              {googleMutation.isPending ? 'Signing in…' : 'Continue with Google'}
            </button>
          </div>
        </div>
      </div>
    </div>
  )
}

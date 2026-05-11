import { useMutation } from '@tanstack/react-query'
import { useLocation, useNavigate } from 'react-router-dom'
import { GoogleLogin } from '@react-oauth/google'
import { toast } from 'sonner'
import { setAuthToken } from '../hooks/useAuthSync'
import { googleLogin } from '../api/users'
import { lazy, Suspense } from 'react'
const PlacesMap = lazy(() => import('./PlacesMap').then(m => ({ default: m.PlacesMap })))
import logo from '../assets/logo.png'
import type { Place } from '../types/places'

type MapMarker = { id: number; latitude: number; longitude: number; title: string; score: number }
const MOCK_PLACES: MapMarker[] = [
  { id: 1, latitude: 51.924, longitude: 4.481, title: 'Rooftop Bar', score: 48 },
  { id: 2, latitude: 51.920, longitude: 4.476, title: 'Canal Walk', score: 91 },
  { id: 3, latitude: 51.918, longitude: 4.484, title: 'Hidden Garden', score: 34 },
]

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

  return (
    <div className="min-h-screen flex text-foreground">
      <div className="hidden lg:block lg:w-[58%] relative overflow-hidden">
          <div className="absolute inset-0 pointer-events-none">
          <Suspense>
            <PlacesMap
              places={MOCK_PLACES as unknown as Place[]}
              onBoundsChange={() => {}}
              initialCenter={[51.922, 4.479]}
              initialZoom={14}
            />
          </Suspense>
        </div>
        <div className="absolute inset-0 bg-linear-to-b from-transparent via-background/50 to-background pointer-events-none" />
        <div className="absolute inset-0 bg-linear-to-r from-background via-transparent to-transparent pointer-events-none" />
        <div className="absolute bottom-10 left-10 z-10">
          <h2 className="text-2xl font-semibold leading-tight">
            Discover places and people of your interests
          </h2>
        </div>
      </div>

      <div className="flex-1 flex flex-col items-center justify-center bg-background">
        <div className="w-full max-w-[320px] flex flex-col items-center text-center">

          <img src={logo} alt="W2D" className="h-auto w-auto" />

          <div className="w-full">
            <GoogleLogin
              onSuccess={(cr) => {
                if (!cr.credential) {
                  return
                }
                googleMutation.mutate(cr.credential)
              }}
              onError={() => toast.error('Google login failed')}
              useOneTap
            />
          </div>
        </div>
      </div>
    </div>
  )
}

import { useMutation } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { GoogleLogin } from '@react-oauth/google'
import { toast } from 'sonner'
import { API_ENDPOINTS } from '../config/api'
import { setAuthToken } from '../hooks/useAuthSync'

interface LoginResponse {
  token: string
  isOnboardingComplete: boolean
}

interface GoogleLoginInput {
  credential: string
  googleName?: string
  googlePicture?: string
}

function parseJwtPayload(token: string): Record<string, unknown> | null {
  try {
    const payloadPart = token.split('.')[1]
    const normalized = payloadPart.replace(/-/g, '+').replace(/_/g, '/')
    const padded = normalized.padEnd(normalized.length + (4 - (normalized.length % 4 || 4)) % 4, '=')
    const payloadJson = atob(padded)
    return JSON.parse(payloadJson) as Record<string, unknown>
  } catch {
    return null
  }
}

export function Login() {
  const navigate = useNavigate()

  const googleMutation = useMutation({
    mutationFn: async (input: GoogleLoginInput) => {
      const response = await fetch(API_ENDPOINTS.users.googleLogin, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ credential: input.credential }),
      })

      if (!response.ok) {
        let errorMsg = 'Google login failed'
        try { const body = await response.json(); errorMsg = body.message || errorMsg } catch {}
        throw new Error(errorMsg)
      }

      return await response.json() as LoginResponse
    },
    onSuccess: (data, input) => {
      setAuthToken(data.token)

      if (!data.isOnboardingComplete) {
        localStorage.setItem('onboarding_pending', '1')
        sessionStorage.setItem('google_profile_defaults', JSON.stringify({
          name: input.googleName ?? '',
          picture: input.googlePicture ?? '',
        }))
        toast.success('Signed in. Let\'s finish your profile.')
        navigate('/onboarding')
        return
      }

      localStorage.removeItem('onboarding_pending')
      toast.success('Signed in with Google!')
      navigate('/')
    },
    onError: (error: Error) => {
      toast.error(error.message)
    }
  })

  return (
    <div className="min-h-screen flex">
      {/* Left — placeholder, slightly wider for future content */}
      <div className="hidden lg:block lg:w-[58%] bg-gray-900" />

      {/* Right — sign in */}
      <div className="flex-1 flex flex-col items-center justify-center px-10 py-16 bg-white">
        <div className="w-full max-w-[320px] space-y-10">

          {/* Brand */}
          <div className="space-y-1">
            <h1 className="text-3xl font-black tracking-tight text-gray-900">W2D</h1>
            <p className="text-[11px] font-medium tracking-widest uppercase text-gray-400">
              What to do
            </p>
          </div>

          {/* Headline */}
          <div className="space-y-2">
            <h2 className="text-xl font-semibold text-gray-900 leading-snug">
              Find your people,<br />make plans.
            </h2>
            <p className="text-sm text-gray-500 leading-relaxed">
              Join communities you love and organise events with others.
            </p>
          </div>

          <div className="space-y-4">
            <div className="rounded-lg border border-gray-100 p-3 bg-gray-50 inline-block">
              <GoogleLogin
                onSuccess={(cr) => {
                  if (!cr.credential) {
                    return
                  }

                  const payload = parseJwtPayload(cr.credential)
                  const googleName = typeof payload?.name === 'string' ? payload.name : undefined
                  const googlePicture = typeof payload?.picture === 'string' ? payload.picture : undefined

                  googleMutation.mutate({
                    credential: cr.credential,
                    googleName,
                    googlePicture,
                  })
                }}
                onError={() => toast.error('Google login failed')}
                useOneTap
              />
            </div>
          </div>

          <p className="text-[11px] text-gray-300 leading-relaxed">
            By signing in you agree to share good times and have fun.
          </p>
        </div>
      </div>
    </div>
  )
}


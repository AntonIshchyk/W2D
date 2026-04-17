import { useMutation } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { GoogleLogin } from '@react-oauth/google'
import { toast } from 'sonner'
import { setAuthToken } from '../hooks/useAuthSync'
import { googleLogin } from '../api/users'

export function Login() {
  const navigate = useNavigate()

  const googleMutation = useMutation({
    mutationFn: googleLogin,
    onSuccess: (data) => {
      setAuthToken(data.token)
      navigate('/')
    },
    onError: (error: Error) => {
      toast.error(error.message)
    }
  })

  return (
    <div className="min-h-screen flex text-foreground">
      {/* Left — placeholder, slightly wider for future content */}
      <div className="hidden lg:block lg:w-[58%] bg-primary" />

      {/* Right — sign in */}
      <div className="flex-1 flex flex-col items-center justify-center px-10 py-16 bg-background">
        <div className="w-full max-w-[320px] space-y-10">

          {/* Brand */}
          <div className="space-y-1">
            <h1 className="text-3xl font-black tracking-tight text-foreground">W2D</h1>
            <p className="text-[11px] font-medium tracking-widest uppercase text-muted-foreground">
              What to do
            </p>
          </div>

          {/* Headline */}
          <div className="space-y-2">
            <h2 className="text-xl font-semibold text-foreground leading-snug">
              Find your people,<br />make plans.
            </h2>
            <p className="text-sm text-muted-foreground leading-relaxed">
              Join communities you love and organise events with others.
            </p>
          </div>

          <div className="space-y-4">
            <div className="rounded-lg border border-border p-3 bg-card inline-block">
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

          <p className="text-[11px] text-muted-foreground/70 leading-relaxed">
            By signing in you agree to share good times and have fun.
          </p>
        </div>
      </div>
    </div>
  )
}


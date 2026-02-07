import { useMutation } from '@tanstack/react-query'
import { useState } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { GoogleLogin } from '@react-oauth/google'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Label } from './ui/label'
import { API_ENDPOINTS } from '../config/api'
import { setAuthToken } from '../hooks/useAuthSync'

interface LoginData {
  email: string
  password: string
}

interface LoginResponse {
  token: string
  userId: number
  email: string
  name: string
}

async function loginUser(data: LoginData): Promise<LoginResponse> {
  const response = await fetch(API_ENDPOINTS.users.login, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data),
  })

  if (!response.ok) {
    let errorMsg = 'Login failed'
    try { const body = await response.json(); errorMsg = body.message || errorMsg } catch {}
    throw new Error(errorMsg)
  }

  return response.json()
}

export function Login() {
  const navigate = useNavigate()
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const mutation = useMutation({
    mutationFn: loginUser,
    onSuccess: (data) => {
      setAuthToken(data.token)
      navigate('/')
    }
  })

  const googleMutation = useMutation({
    mutationFn: async (credential: string) => {
      const response = await fetch(API_ENDPOINTS.users.googleLogin, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ credential }),
      })

      if (!response.ok) {
        let errorMsg = 'Google login failed'
        try { const body = await response.json(); errorMsg = body.message || errorMsg } catch {}
        throw new Error(errorMsg)
      }

      return response.json()
    },
    onSuccess: (data) => {
      setAuthToken(data.token)
      navigate('/')
    }
  })

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    mutation.mutate({ email, password })
  }

  return (
    <div className="min-h-screen bg-gray-50 flex">
      {/* Left branding panel */}
      <div className="hidden lg:flex lg:w-1/2 bg-gray-900 items-end p-12">
        <div>
          <h1 className="text-5xl font-black text-white tracking-tight mb-3">W2D</h1>
          <p className="text-gray-500 text-sm">Figure out what to do.</p>
        </div>
      </div>

      {/* Right form panel */}
      <div className="flex-1 flex items-center justify-center p-8">
        <div className="w-full max-w-sm">
          <h2 className="text-lg font-semibold text-gray-900 mb-6">Sign in</h2>
        
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="email">Email</Label>
            <Input
              id="email"
              type="email"
              placeholder="your@email.com"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              autoComplete="email"
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="password">Password</Label>
            <Input
              id="password"
              type="password"
              placeholder="••••••••"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              autoComplete="current-password"
              required
            />
          </div>

          <Button 
            type="submit" 
            disabled={mutation.isPending}
            className="w-full"
          >
            {mutation.isPending ? 'Loading...' : 'Login'}
          </Button>

          {mutation.isError && (
            <p className="text-red-600 text-sm">{mutation.error.message}</p>
          )}
        </form>

        <div className="relative my-6">
          <div className="absolute inset-0 flex items-center">
            <div className="w-full border-t border-gray-300"></div>
          </div>
          <div className="relative flex justify-center text-sm">
            <span className="px-2 bg-white text-gray-500">Or continue with</span>
          </div>
        </div>

        <div className="flex justify-center">
          <GoogleLogin
            onSuccess={(credentialResponse) => {
              if (credentialResponse.credential) {
                googleMutation.mutate(credentialResponse.credential)
              }
            }}
            onError={() => {
              console.error('Google Login Failed')
            }}
            useOneTap
          />
        </div>

        {googleMutation.isError && (
          <p className="text-red-600 text-sm text-center mt-2">{googleMutation.error.message}</p>
        )}

        <div className="mt-6 text-center">
          <p className="text-sm text-gray-400">
            Don't have an account?{' '}
            <Link to="/signup" className="text-gray-900 hover:underline font-medium">
              Sign up
            </Link>
          </p>
        </div>
      </div>
    </div>
    </div>
  )
}


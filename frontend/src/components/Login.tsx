import { useMutation } from '@tanstack/react-query'
import { useState } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { GoogleLogin } from '@react-oauth/google'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Label } from './ui/label'
import { API_ENDPOINTS } from '../config/api'

interface LoginData {
  email: string
  password: string
}

interface LoginResponse {
  token: string
  userId: number
  email: string
  name: string
  age: number
  gender: 'Male' | 'Female'
}

async function loginUser(data: LoginData): Promise<LoginResponse> {
  const response = await fetch(API_ENDPOINTS.users.login, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data),
  })

  if (!response.ok) {
    const error = await response.json()
    throw new Error(error.message || 'Login failed')
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
      localStorage.setItem('token', data.token)
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
        const error = await response.json()
        throw new Error(error.message || 'Google login failed')
      }

      return response.json()
    },
    onSuccess: (data) => {
      localStorage.setItem('token', data.token)
      navigate('/')
    }
  })

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    mutation.mutate({ email, password })
  }

  return (
    <div className="min-h-screen bg-gray-50 flex items-center justify-center p-4">
      <div className="w-full max-w-md bg-white rounded-lg shadow-md p-8">
        <h2 className="text-2xl font-bold text-gray-900 mb-6">Login</h2>
        
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

          {mutation.isSuccess && (
            <p className="text-green-600 text-sm">Login successful!</p>
          )}
          
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
          <p className="text-sm text-gray-600">
            Don't have an account?{' '}
            <Link to="/signup" className="text-blue-600 hover:text-blue-800 font-medium">
              Sign up
            </Link>
          </p>
        </div>
      </div>
    </div>
  )
}


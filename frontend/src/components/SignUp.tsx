import { useMutation } from '@tanstack/react-query'
import { useState } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { Button } from './ui/button'
import { Input } from './ui/input'
import { Label } from './ui/label'
import { API_ENDPOINTS } from '../config/api'

interface SignUpData {
  name: string
  email: string
  password: string
}

interface SignUpResponse {
  token: string
  email: string
  name: string
}

async function signUpUser(data: SignUpData): Promise<SignUpResponse> {
  const response = await fetch(API_ENDPOINTS.users.register, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data),
  })

  if (!response.ok) {
    const error = await response.json()
    throw new Error(error.message || 'Sign up failed')
  }

  return response.json()
}

export function SignUp() {
  const navigate = useNavigate()
  const [name, setName] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const mutation = useMutation({
    mutationFn: signUpUser,
    onSuccess: (data) => {
      localStorage.setItem('token', data.token)
      navigate('/')
    }
  })

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    mutation.mutate({ 
      name,
      email, 
      password
    })
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
          <h2 className="text-lg font-semibold text-gray-900 mb-6">Create account</h2>
        
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="name">Name</Label>
            <Input
              id="name"
              type="text"
              placeholder="John Doe"
              value={name}
              onChange={(e) => setName(e.target.value)}
              autoComplete="name"
              required
            />
          </div>

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
              autoComplete="new-password"
              required
            />
          </div>

          <Button 
            type="submit" 
            disabled={mutation.isPending}
            className="w-full"
          >
            {mutation.isPending ? 'Loading...' : 'Sign up'}
          </Button>

          {mutation.isSuccess && (
            <p className="text-green-600 text-sm">Sign up successful!</p>
          )}
          
          {mutation.isError && (
            <p className="text-red-600 text-sm">{mutation.error.message}</p>
          )}
        </form>

        <div className="mt-6 text-center">
          <p className="text-sm text-gray-400">
            Already have an account?{' '}
            <Link to="/login" className="text-gray-900 hover:underline font-medium">
              Sign in
            </Link>
          </p>
        </div>
      </div>
    </div>
    </div>
  )
}

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
  age: number
  gender: 'Male' | 'Female'
}

interface SignUpResponse {
  token: string
  email: string
  name: string
  age: number
  gender: 'Male' | 'Female'
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
  const [age, setAge] = useState('')
  const [gender, setGender] = useState<'Male' | 'Female' | ''>('')

  const mutation = useMutation({
    mutationFn: signUpUser,
    onSuccess: (data) => {
      localStorage.setItem('token', data.token)
      navigate('/')
    }
  })

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    if (!gender) return
    mutation.mutate({ 
      name,
      email, 
      password,
      age: parseInt(age),
      gender
    })
  }

  return (
    <div className="min-h-screen bg-gray-50 flex items-center justify-center p-4">
      <div className="w-full max-w-md bg-white rounded-lg shadow-md p-8">
        <h2 className="text-2xl font-bold text-gray-900 mb-6">Sign up</h2>
        
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

          <div className="space-y-2">
            <Label htmlFor="age">Age</Label>
            <Input
              id="age"
              type="number"
              placeholder="18"
              value={age}
              onChange={(e) => setAge(e.target.value)}
              required
              min="1"
              max="120"
            />
          </div>

          <div className="space-y-2">
            <Label>Gender</Label>
            <div className="flex gap-4">
              <label className="flex items-center gap-2 cursor-pointer">
                <input
                  type="radio"
                  name="gender"
                  value="Male"
                  checked={gender === 'Male'}
                  onChange={(e) => setGender(e.target.value as 'Male' | 'Female')}
                  required
                  className="w-4 h-4 cursor-pointer"
                />
                <span className="text-sm">Male</span>
              </label>
              <label className="flex items-center gap-2 cursor-pointer">
                <input
                  type="radio"
                  name="gender"
                  value="Female"
                  checked={gender === 'Female'}
                  onChange={(e) => setGender(e.target.value as 'Male' | 'Female')}
                  required
                  className="w-4 h-4 cursor-pointer"
                />
                <span className="text-sm">Female</span>
              </label>
            </div>
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
          <p className="text-sm text-gray-600">
            Already have an account?{' '}
            <Link to="/login" className="text-blue-600 hover:text-blue-800 font-medium">
              Login
            </Link>
          </p>
        </div>
      </div>
    </div>
  )
}

import { useQuery } from '@tanstack/react-query'
import { useNavigate, Link } from 'react-router-dom'
import { useEffect } from 'react'
import { Navbar } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'

interface UserInfo {
  userId: number
  email: string
  name: string
  age: number
  gender: string
}

async function fetchCurrentUser(): Promise<UserInfo> {
  const token = localStorage.getItem('token')
  
  if (!token) {
    throw new Error('No token')
  }

  const response = await fetch(API_ENDPOINTS.users.me, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Unauthorized')
  }

  return response.json()
}

export function Home() {
  const navigate = useNavigate()
  
  const { data: user, isLoading, isError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  useEffect(() => {
    if (isError) {
      localStorage.removeItem('token')
      navigate('/login')
    }
  }, [isError, navigate])

  if (isLoading) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <p className="text-gray-600">Loading...</p>
      </div>
    )
  }

  if (isError) {
    return null
  }

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar userName={user?.name} />
      
      <div className="max-w-4xl mx-auto p-4 py-16">
        <div className="text-center mb-12">
          <h1 className="text-4xl font-bold text-gray-900 mb-4">
            Welcome back, {user?.name}!
          </h1>
          <p className="text-lg text-gray-600">
            What would you like to do today?
          </p>
        </div>

        <div className="grid md:grid-cols-2 gap-6">
          <Link 
            to="/activities" 
            className="bg-white p-8 rounded-lg shadow-md hover:shadow-lg transition-shadow border border-gray-200"
          >
            <h2 className="text-2xl font-bold text-gray-900 mb-2">Browse Activities</h2>
            <p className="text-gray-600">
              Discover activities to help you decide what to do when bored
            </p>
          </Link>

          <Link 
            to="/profile" 
            className="bg-white p-8 rounded-lg shadow-md hover:shadow-lg transition-shadow border border-gray-200"
          >
            <h2 className="text-2xl font-bold text-gray-900 mb-2">Your Profile</h2>
            <p className="text-gray-600">
              View and manage your personal information
            </p>
          </Link>
        </div>
      </div>
    </div>
  )
}

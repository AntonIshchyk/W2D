import { useQuery } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
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

export function Profile() {
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
      <div className="min-h-screen bg-gray-50">
        <Navbar />
        <div className="flex items-center justify-center py-20">
          <p className="text-gray-600">Loading...</p>
        </div>
      </div>
    )
  }

  if (isError) {
    return null
  }

  if (!user) {
    return null
  }

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar userName={user.name} />
      
      <div className="max-w-4xl mx-auto p-4 py-8">
        <div className="bg-white rounded-lg shadow-md p-8">
          <h1 className="text-3xl font-bold text-gray-900 mb-6">Your Profile</h1>
          <div className="space-y-4">
            <div className="border-b pb-4">
              <label className="text-sm font-medium text-gray-500">Name</label>
              <p className="text-lg text-gray-900">{user.name}</p>
            </div>
            <div className="border-b pb-4">
              <label className="text-sm font-medium text-gray-500">Email</label>
              <p className="text-lg text-gray-900">{user.email}</p>
            </div>
            <div className="border-b pb-4">
              <label className="text-sm font-medium text-gray-500">Age</label>
              <p className="text-lg text-gray-900">{user.age}</p>
            </div>
            <div className="border-b pb-4">
              <label className="text-sm font-medium text-gray-500">Gender</label>
              <p className="text-lg text-gray-900">{user.gender}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

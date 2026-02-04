import { useQuery } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { useEffect, useState } from 'react'
import { Button } from './ui/button'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'

interface UserInfo {
  userId: number
  email: string
  name: string
  age: number
  gender: string
}

interface Activity {
  id: number
  title: string
  description: string
  categoryId: number
  category?: {
    id: number
    name: string
  }
  locationType: number
  costLevel?: number
  physicalActivityLevel?: number
  sociability?: number
  equipmentLevel?: number
  entryLevel?: number
  tags: any[]
  createdAt: string
  updatedAt: string
}

interface PaginatedResult {
  items: Activity[]
  pageNumber: number
  pageSize: number
  totalCount: number
  totalPages: number
  hasPreviousPage: boolean
  hasNextPage: boolean
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

async function fetchActivities(pageNumber: number): Promise<PaginatedResult> {
  const response = await fetch(`${API_ENDPOINTS.activities.base}?pageNumber=${pageNumber}&pageSize=10`)

  if (!response.ok) {
    throw new Error('Failed to fetch activities')
  }

  return response.json()
}

export function Home() {
  const navigate = useNavigate()
  const [currentPage, setCurrentPage] = useState(1)
  
  const { data: user, isLoading, isError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: activitiesData, isLoading: activitiesLoading } = useQuery({
    queryKey: ['activities', currentPage],
    queryFn: () => fetchActivities(currentPage),
    retry: false
  })

  useEffect(() => {
    if (isError) {
      localStorage.removeItem('token')
      navigate('/login')
    }
  }, [isError, navigate])

  const handleLogout = () => {
    localStorage.removeItem('token')
    navigate('/login')
  }

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
    <div className="min-h-screen bg-gray-50 p-4">
      <div className="max-w-6xl mx-auto">
        <div className="bg-white rounded-lg shadow-md p-8 mb-6">
          <div className="flex justify-between items-center mb-6">
            <h1 className="text-3xl font-bold text-gray-900">Welcome, {user?.name}!</h1>
            <Button onClick={handleLogout} variant="outline">
              Logout
            </Button>
          </div>
          
          <div className="space-y-4">
            <div className="bg-gray-50 p-4 rounded-lg">
              <h2 className="text-lg font-semibold text-gray-700 mb-3">Your Profile</h2>
              <div className="space-y-2">
                <p className="text-gray-600">
                  <span className="font-medium">Email:</span> {user?.email}
                </p>
                <p className="text-gray-600">
                  <span className="font-medium">Age:</span> {user?.age}
                </p>
                <p className="text-gray-600">
                  <span className="font-medium">Gender:</span> {user?.gender}
                </p>
              </div>
            </div>
          </div>
        </div>

        <div className="bg-white rounded-lg shadow-md p-8">
          <h2 className="text-2xl font-bold text-gray-900 mb-4">Activities</h2>
          
          {activitiesLoading ? (
            <p className="text-gray-600">Loading activities...</p>
          ) : (
            <div className="space-y-4">
              {activitiesData?.items.map((activity) => (
                <div key={activity.id} className="border border-gray-200 rounded-lg p-4 hover:bg-gray-50 transition-colors">
                  <div className="flex justify-between items-start mb-2">
                    <h3 className="text-lg font-semibold text-gray-900">{activity.title}</h3>
                    {activity.category && (
                      <span className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded">
                        {activity.category.name}
                      </span>
                    )}
                  </div>
                  <p className="text-gray-600 text-sm mb-2">{activity.description}</p>
                  <div className="flex gap-2 flex-wrap">
                    {activity.tags.map((tag: any) => (
                      <span key={tag.id} className="bg-gray-100 text-gray-700 text-xs px-2 py-1 rounded">
                        {tag.name}
                      </span>
                    ))}
                  </div>
                </div>
              ))}
              
              {activitiesData && activitiesData.items.length === 0 && (
                <p className="text-gray-500 text-center py-8">No activities found</p>
              )}
              
              {activitiesData && activitiesData.totalCount > 0 && (
                <div className="mt-6 flex items-center justify-between border-t pt-4">
                  <div className="text-sm text-gray-600">
                    Showing {activitiesData.items.length} of {activitiesData.totalCount} activities
                    (Page {activitiesData.pageNumber} of {activitiesData.totalPages})
                  </div>
                  <div className="flex gap-2">
                    <Button
                      onClick={() => setCurrentPage(p => p - 1)}
                      disabled={!activitiesData.hasPreviousPage}
                      variant="outline"
                      size="sm"
                    >
                      Previous
                    </Button>
                    <Button
                      onClick={() => setCurrentPage(p => p + 1)}
                      disabled={!activitiesData.hasNextPage}
                      variant="outline"
                      size="sm"
                    >
                      Next
                    </Button>
                  </div>
                </div>
              )}
            </div>
          )}
        </div>
      </div>
    </div>
  )
}

import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { useEffect, useState } from 'react'
import { Button } from './ui/button'
import { Navbar } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'

interface UserInfo {
  userId: number
  email: string
  name: string
  age: number
  gender: string
}

interface ActivitySchedule {
  id: number
  activityId: number
  plannedDate: string
  completedDate?: string
  status: string
  notes?: string
  activity: {
    id: number
    title: string
    description: string
    category?: {
      id: number
      name: string
    }
    tags: Array<{
      id: number
      name: string
    }>
  }
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

async function fetchPlannedActivities(): Promise<ActivitySchedule[]> {
  const response = await fetch(API_ENDPOINTS.schedules.planned, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch planned activities')
  }

  return response.json()
}

async function fetchCompletedActivities(): Promise<ActivitySchedule[]> {
  const response = await fetch(API_ENDPOINTS.schedules.completed, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch completed activities')
  }

  return response.json()
}

async function fetchHistoryActivities(): Promise<ActivitySchedule[]> {
  const response = await fetch(API_ENDPOINTS.schedules.history, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch history')
  }

  return response.json()
}

export function Profile() {
  const navigate = useNavigate()
  const queryClient = useQueryClient()
  const [activeTab, setActiveTab] = useState<'profile' | 'planned' | 'completed'>('profile')
  
  const { data: user, isLoading, isError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: plannedActivities, error: plannedError } = useQuery({
    queryKey: ['schedules', 'planned'],
    queryFn: fetchPlannedActivities,
    retry: false,
    enabled: !!user
  })

  const { data: historyActivities, error: historyError } = useQuery({
    queryKey: ['schedules', 'history'],
    queryFn: fetchHistoryActivities,
    retry: false,
    enabled: !!user
  })

  const completeMutation = useMutation({
    mutationFn: async (scheduleId: number) => {
      const response = await fetch(API_ENDPOINTS.schedules.complete(scheduleId), {
        method: 'PATCH',
        headers: getAuthHeaders(),
        body: JSON.stringify({})
      })

      if (!response.ok) {
        throw new Error('Failed to mark as completed')
      }

      return response.json()
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['schedules'] })
    }
  })

  const cancelMutation = useMutation({
    mutationFn: async (scheduleId: number) => {
      const response = await fetch(API_ENDPOINTS.schedules.cancel(scheduleId), {
        method: 'PATCH',
        headers: getAuthHeaders()
      })

      if (!response.ok) {
        throw new Error('Failed to cancel')
      }

      return response.json()
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['schedules'] })
    }
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
      
      <div className="max-w-6xl mx-auto p-4 py-8">
        {/* Tabs */}
        <div className="flex gap-2 mb-6">
          <button
            onClick={() => setActiveTab('profile')}
            className={`px-4 py-2 rounded-lg font-medium transition-colors ${
              activeTab === 'profile'
                ? 'bg-blue-600 text-white'
                : 'bg-white text-gray-700 hover:bg-gray-100'
            }`}
          >
            Profile
          </button>
          <button
            onClick={() => setActiveTab('planned')}
            className={`px-4 py-2 rounded-lg font-medium transition-colors ${
              activeTab === 'planned'
                ? 'bg-blue-600 text-white'
                : 'bg-white text-gray-700 hover:bg-gray-100'
            }`}
          >
            Planned Activities ({plannedActivities?.length ?? 0})
          </button>
          <button
            onClick={() => setActiveTab('completed')}
            className={`px-4 py-2 rounded-lg font-medium transition-colors ${
              activeTab === 'completed'
                ? 'bg-blue-600 text-white'
                : 'bg-white text-gray-700 hover:bg-gray-100'
            }`}
          >
            History ({historyActivities?.length ?? 0})
          </button>
        </div>

        {/* Profile Tab */}
        {activeTab === 'profile' && (
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
        )}

        {/* Planned Activities Tab */}
        {activeTab === 'planned' && (
          <div className="bg-white rounded-lg shadow-md p-8">
            <h1 className="text-3xl font-bold text-gray-900 mb-6">Planned Activities</h1>
            {plannedError && (
              <div className="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded mb-4">
                Error loading planned activities.
              </div>
            )}
            <div className="space-y-4">
              {plannedActivities && plannedActivities.length > 0 ? (
                plannedActivities.map((schedule) => (
                  <div key={schedule.id} className="border border-gray-200 rounded-lg p-4">
                    <div className="flex justify-between items-start mb-2">
                      <div className="flex-1">
                        <h3 className="text-lg font-semibold text-gray-900">{schedule.activity.title}</h3>
                        <p className="text-sm text-gray-600 mt-1">
                          Planned for: {new Date(schedule.plannedDate).toLocaleDateString()}
                        </p>
                      </div>
                      {schedule.activity.category && (
                        <span className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded">
                          {schedule.activity.category.name}
                        </span>
                      )}
                    </div>
                    <p className="text-gray-600 text-sm mb-2">{schedule.activity.description}</p>
                    {schedule.notes && (
                      <p className="text-gray-900 text-sm mb-2"><span className="font-medium">Note:</span> {schedule.notes}</p>
                    )}
                    <div className="flex gap-2 flex-wrap mb-3">
                      {schedule.activity.tags.map((tag) => (
                        <span key={tag.id} className="bg-gray-100 text-gray-700 text-xs px-2 py-1 rounded">
                          {tag.name}
                        </span>
                      ))}
                    </div>
                    <div className="flex gap-2">
                      <Button
                        onClick={() => completeMutation.mutate(schedule.id)}
                        disabled={completeMutation.isPending}
                        size="sm"
                        className="bg-green-600 hover:bg-green-700"
                      >
                        Mark as Completed
                      </Button>
                      <Button
                        onClick={() => cancelMutation.mutate(schedule.id)}
                        disabled={cancelMutation.isPending}
                        size="sm"
                        className="bg-red-600 hover:bg-red-700 text-white"
                      >
                        Cancel
                      </Button>
                    </div>
                  </div>
                ))
              ) : (
                <p className="text-gray-500 text-center py-8">No planned activities yet</p>
              )}
            </div>
          </div>
        )}

        {/* Completed Activities Tab */}
        {activeTab === 'completed' && (
          <div className="bg-white rounded-lg shadow-md p-8">
            <h1 className="text-3xl font-bold text-gray-900 mb-6">Activity History</h1>
            {historyError && (
              <div className="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded mb-4">
                Error loading history.
              </div>
            )}
            <div className="space-y-4">
              {historyActivities && historyActivities.length > 0 ? (
                historyActivities.map((schedule) => {
                  const isCompleted = schedule.status === "Completed"
                  return (
                  <div key={schedule.id} className={`rounded-lg p-4 border-l-4 ${
                    isCompleted 
                      ? 'bg-green-50 border-green-500' 
                      : 'bg-red-50 border-red-500'
                  }`}>
                    <div className="flex justify-between items-start mb-2">
                      <div className="flex-1">
                        <div className="flex items-center gap-2">
                          {isCompleted ? (
                            <svg className="w-5 h-5 text-green-600 shrink-0" fill="currentColor" viewBox="0 0 20 20">
                              <path fillRule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clipRule="evenodd" />
                            </svg>
                          ) : (
                            <svg className="w-5 h-5 text-red-600 shrink-0" fill="currentColor" viewBox="0 0 20 20">
                              <path fillRule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clipRule="evenodd" />
                            </svg>
                          )}
                          <h3 className="text-lg font-semibold text-gray-900">{schedule.activity.title}</h3>
                          <span className={`text-xs font-medium px-2 py-0.5 rounded ${
                            isCompleted 
                              ? 'bg-green-600 text-white' 
                              : 'bg-red-600 text-white'
                          }`}>
                            {isCompleted ? 'Completed' : 'Cancelled'}
                          </span>
                        </div>
                        <p className="text-sm text-gray-600 mt-1 ml-7">
                          {isCompleted && schedule.completedDate
                            ? `Completed on: ${new Date(schedule.completedDate).toLocaleDateString()}`
                            : `Planned for: ${new Date(schedule.plannedDate).toLocaleDateString()}`
                          }
                        </p>
                      </div>
                      {schedule.activity.category && (
                        <span className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded">
                          {schedule.activity.category.name}
                        </span>
                      )}
                    </div>
                    <p className="text-gray-600 text-sm mb-2 ml-7">{schedule.activity.description}</p>
                    {schedule.notes && (
                      <p className="text-gray-900 text-sm mb-2 ml-7"><span className="font-medium">Note:</span> {schedule.notes}</p>
                    )}
                    <div className="flex gap-2 flex-wrap ml-7">
                      {schedule.activity.tags.map((tag) => (
                        <span key={tag.id} className="bg-gray-100 text-gray-700 text-xs px-2 py-1 rounded">
                          {tag.name}
                        </span>
                      ))}
                    </div>
                  </div>
                  )
                })
              ) : (
                <p className="text-gray-500 text-center py-8">No activity history yet</p>
              )}
            </div>
          </div>
        )}
      </div>
    </div>
  )
}

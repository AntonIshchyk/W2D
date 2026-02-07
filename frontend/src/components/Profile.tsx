import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useState } from 'react'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'

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

async function fetchPlannedActivities(): Promise<ActivitySchedule[]> {
  const response = await fetch(API_ENDPOINTS.schedules.planned, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch planned activities')
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
  const queryClient = useQueryClient()
  const [activeTab, setActiveTab] = useState<'planned' | 'completed'>('planned')
  
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

  useAuthErrorHandler(isError)

  if (isLoading) {
    return (
      <PageLayout>
        <div className="flex items-center justify-center py-20">
          <p className="text-sm text-gray-400 tracking-wide uppercase">Loading...</p>
        </div>
      </PageLayout>
    )
  }

  if (isError) {
    return null
  }

  if (!user) {
    return null
  }

  return (
    <PageLayout>
      <div className="grid grid-cols-1 lg:grid-cols-[280px_1fr] gap-8">
        {/* Left — sticky user card */}
        <div className="lg:sticky lg:top-10 lg:self-start">
          <div className="bg-white border border-gray-200 rounded-2xl p-6">
            {/* Avatar placeholder */}
            <div className="w-14 h-14 bg-gray-900 rounded-full flex items-center justify-center text-white text-xl font-bold mb-4">
              {user.name.charAt(0).toUpperCase()}
            </div>
            <h2 className="text-lg font-semibold text-gray-900">{user.name}</h2>
            <p className="text-sm text-gray-400 mt-0.5">{user.email}</p>

            {/* Stats */}
            <div className="flex gap-4 mt-5 pt-5 border-t border-gray-100">
              <div>
                <div className="text-lg font-semibold text-gray-900">{plannedActivities?.length ?? 0}</div>
                <div className="text-[11px] text-gray-400 uppercase tracking-wide">Planned</div>
              </div>
              <div>
                <div className="text-lg font-semibold text-gray-900">
                  {historyActivities?.filter(s => s.status === 'Completed').length ?? 0}
                </div>
                <div className="text-[11px] text-gray-400 uppercase tracking-wide">Done</div>
              </div>
            </div>
          </div>
        </div>

        {/* Right — content area */}
        <div>
          {/* Tab row */}
          <div className="flex gap-1 mb-6 bg-gray-100 rounded-lg p-0.5 w-fit">
            <button
              onClick={() => setActiveTab('planned')}
              className={`px-4 py-2 rounded-md text-sm font-medium transition-all ${
                activeTab === 'planned'
                  ? 'bg-white text-gray-900 shadow-sm'
                  : 'text-gray-500 hover:text-gray-700'
              }`}
            >
              Planned
            </button>
            <button
              onClick={() => setActiveTab('completed')}
              className={`px-4 py-2 rounded-md text-sm font-medium transition-all ${
                activeTab === 'completed'
                  ? 'bg-white text-gray-900 shadow-sm'
                  : 'text-gray-500 hover:text-gray-700'
              }`}
            >
              History
            </button>
          </div>

          {/* Planned Activities */}
          {activeTab === 'planned' && (
            <div>
              {plannedError && (
                <div className="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg mb-4 text-sm">
                  Error loading planned activities.
                </div>
              )}
              <div className="space-y-3">
                {plannedActivities && plannedActivities.length > 0 ? (
                  plannedActivities.map((schedule) => (
                    <div key={schedule.id} className="bg-white border border-gray-200 rounded-xl p-5 group hover:border-gray-400 transition-colors">
                      <div className="flex items-start justify-between mb-2">
                        <div>
                          <h3 className="text-sm font-semibold text-gray-900">{schedule.activity.title}</h3>
                          <p className="text-xs text-gray-400 mt-0.5">
                            {new Date(schedule.plannedDate).toLocaleDateString('en-US', { weekday: 'short', month: 'short', day: 'numeric' })}
                          </p>
                        </div>
                        {schedule.activity.category && (
                          <span className="text-[11px] font-medium text-gray-500 bg-gray-100 px-2 py-0.5 rounded-full">
                            {schedule.activity.category.name}
                          </span>
                        )}
                      </div>
                      <p className="text-sm text-gray-500 line-clamp-1 mb-3">{schedule.activity.description}</p>
                      {schedule.notes && (
                        <p className="text-xs text-gray-500 mb-3 italic">{schedule.notes}</p>
                      )}
                      <div className="flex items-center justify-between">
                        <div className="flex gap-1.5 flex-wrap">
                          {schedule.activity.tags.map((tag) => (
                            <span key={tag.id} className="text-[11px] text-gray-400">#{tag.name}</span>
                          ))}
                        </div>
                        <div className="flex gap-2 opacity-0 group-hover:opacity-100 transition-opacity">
                          <button
                            onClick={() => completeMutation.mutate(schedule.id)}
                            disabled={completeMutation.isPending}
                            className="text-xs font-medium text-green-600 hover:text-green-700"
                          >
                            Done
                          </button>
                          <button
                            onClick={() => cancelMutation.mutate(schedule.id)}
                            disabled={cancelMutation.isPending}
                            className="text-xs font-medium text-gray-400 hover:text-red-500"
                          >
                            Cancel
                          </button>
                        </div>
                      </div>
                    </div>
                  ))
                ) : (
                  <div className="text-center py-16">
                    <p className="text-gray-400 text-sm">No planned activities</p>
                  </div>
                )}
              </div>
            </div>
          )}

          {/* History */}
          {activeTab === 'completed' && (
            <div>
              {historyError && (
                <div className="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg mb-4 text-sm">
                  Error loading history.
                </div>
              )}
              <div className="space-y-3">
                {historyActivities && historyActivities.length > 0 ? (
                  historyActivities.map((schedule) => {
                    const isCompleted = schedule.status === "Completed"
                    return (
                      <div key={schedule.id} className={`border rounded-xl p-5 flex items-start gap-3 ${
                        isCompleted 
                          ? 'bg-green-50/50 border-green-200' 
                          : 'bg-red-50/50 border-red-200'
                      }`}>
                        {/* Status icon */}
                        <div className={`shrink-0 w-7 h-7 rounded-full flex items-center justify-center ${
                          isCompleted ? 'bg-green-100' : 'bg-red-100'
                        }`}>
                          {isCompleted ? (
                            <svg className="w-4 h-4 text-green-600" fill="currentColor" viewBox="0 0 20 20">
                              <path fillRule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clipRule="evenodd" />
                            </svg>
                          ) : (
                            <svg className="w-4 h-4 text-red-500" fill="currentColor" viewBox="0 0 20 20">
                              <path fillRule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clipRule="evenodd" />
                            </svg>
                          )}
                        </div>

                        <div className="flex-1 min-w-0">
                          <div className="flex items-center gap-2 mb-0.5">
                            <h3 className="text-sm font-semibold text-gray-900">{schedule.activity.title}</h3>
                          </div>
                          <p className="text-xs text-gray-400">
                            {isCompleted && schedule.completedDate
                              ? `Completed ${new Date(schedule.completedDate).toLocaleDateString('en-US', { month: 'short', day: 'numeric' })}`
                              : `Was planned for ${new Date(schedule.plannedDate).toLocaleDateString('en-US', { month: 'short', day: 'numeric' })}`
                            }
                          </p>
                          {schedule.notes && (
                            <p className="text-xs text-gray-500 mt-1 italic">{schedule.notes}</p>
                          )}
                        </div>

                        {schedule.activity.category && (
                          <span className="shrink-0 text-[11px] font-medium text-gray-500 bg-white/60 px-2 py-0.5 rounded-full">
                            {schedule.activity.category.name}
                          </span>
                        )}
                      </div>
                    )
                  })
                ) : (
                  <div className="text-center py-16">
                    <p className="text-gray-400 text-sm">No history yet</p>
                  </div>
                )}
              </div>
            </div>
          )}
        </div>
      </div>
    </PageLayout>
  )
}

import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback } from 'react'
import { Button } from './ui/button'
import { Navbar } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'

interface Tag {
  id: number
  name: string
}

interface Category {
  id: number
  name: string
}

interface Activity {
  id: number
  title: string
  description: string
  categoryId: number
  category?: Category
  locationType: number
  costLevel?: number
  physicalActivityLevel?: number
  sociability?: number
  equipmentLevel?: number
  entryLevel?: number
  tags: Tag[]
  createdAt: string
  updatedAt: string
}

interface ScrollResult {
  items: Activity[]
  nextCursor: number | null
  hasMore: boolean
  totalCount: number
}

async function fetchActivities(cursor: number | null, categoryId?: number, tagIds?: number[]): Promise<ScrollResult> {
  const params = new URLSearchParams({
    limit: '20'
  })

  if (cursor !== null) {
    params.append('cursor', cursor.toString())
  }

  if (categoryId) {
    params.append('categoryId', categoryId.toString())
  }

  if (tagIds && tagIds.length > 0) {
    tagIds.forEach(id => params.append('tagIds', id.toString()))
  }

  const response = await fetch(`${API_ENDPOINTS.activities.base}?${params}`, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch activities')
  }

  return response.json()
}

async function fetchCategories(): Promise<Category[]> {
  const response = await fetch(API_ENDPOINTS.categories.base)

  if (!response.ok) {
    throw new Error('Failed to fetch categories')
  }

  return response.json()
}

async function fetchTags(): Promise<Tag[]> {
  const response = await fetch(API_ENDPOINTS.tags.base)

  if (!response.ok) {
    throw new Error('Failed to fetch tags')
  }

  return response.json()
}

export function Activities() {
  const [selectedCategory, setSelectedCategory] = useState<number | undefined>(undefined)
  const [selectedTags, setSelectedTags] = useState<number[]>([])
  const observerTarget = useRef<HTMLDivElement>(null)
  
  const { isError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: categories } = useQuery({
    queryKey: ['categories'],
    queryFn: fetchCategories,
    staleTime: Infinity,
    gcTime: Infinity
  })

  const { data: tags } = useQuery({
    queryKey: ['tags'],
    queryFn: fetchTags,
    staleTime: Infinity,
    gcTime: Infinity
  })

  const {
    data,
    fetchNextPage,
    hasNextPage,
    isFetchingNextPage,
    isLoading
  } = useInfiniteQuery({
    queryKey: ['activities', selectedCategory, selectedTags],
    queryFn: ({ pageParam }) => fetchActivities(pageParam, selectedCategory, selectedTags),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false
  })

  useAuthErrorHandler(isError)

  // Intersection Observer for infinite scroll
  const handleObserver = useCallback((entries: IntersectionObserverEntry[]) => {
    const [target] = entries
    if (target.isIntersecting && hasNextPage && !isFetchingNextPage) {
      fetchNextPage()
    }
  }, [fetchNextPage, hasNextPage, isFetchingNextPage])

  useEffect(() => {
    const element = observerTarget.current
    const option = { threshold: 0.1 }
    const observer = new IntersectionObserver(handleObserver, option)
    
    if (element) observer.observe(element)
    
    return () => {
      if (element) observer.unobserve(element)
    }
  }, [handleObserver])

  const queryClient = useQueryClient()
  const [scheduleDialogOpen, setScheduleDialogOpen] = useState(false)
  const [selectedActivityId, setSelectedActivityId] = useState<number | null>(null)
  const [plannedDate, setPlannedDate] = useState('')
  const [notes, setNotes] = useState('')

  // Flatten all activities from all pages
  const allActivities = data?.pages.flatMap(page => page.items) ?? []
  const totalCount = data?.pages[0]?.totalCount ?? 0

  const scheduleMutation = useMutation({
    mutationFn: async (data: { activityId: number; plannedDate: string; notes?: string }) => {
      const response = await fetch(API_ENDPOINTS.schedules.base, {
        method: 'POST',
        headers: getAuthHeaders(),
        body: JSON.stringify({
          activityId: data.activityId,
          plannedDate: data.plannedDate,
          notes: data.notes
        })
      })

      if (!response.ok) {
        throw new Error('Failed to schedule activity')
      }

      return response.json()
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['schedules'] })
      setScheduleDialogOpen(false)
      setSelectedActivityId(null)
      setPlannedDate('')
      setNotes('')
    }
  })

  const handleScheduleClick = (activityId: number) => {
    setSelectedActivityId(activityId)
    setScheduleDialogOpen(true)
  }

  const handleScheduleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    if (selectedActivityId && plannedDate) {
      // Convert date to ISO string format for API
      const dateObj = new Date(plannedDate)
      dateObj.setHours(12, 0, 0, 0) // Set to noon to avoid timezone issues
      
      scheduleMutation.mutate({
        activityId: selectedActivityId,
        plannedDate: dateObj.toISOString(),
        notes: notes || undefined
      })
    }
  }

  const handleTagToggle = (tagId: number) => {
    setSelectedTags(prev => 
      prev.includes(tagId) 
        ? prev.filter(id => id !== tagId)
        : [...prev, tagId]
    )
  }

  if (isError) {
    return null
  }

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />
      
      <div className="max-w-6xl mx-auto p-4 py-8">
        <div className="bg-white rounded-lg shadow-md p-8">
          <h1 className="text-3xl font-bold text-gray-900 mb-6">Activities</h1>
          
          {/* Filters */}
          <div className="mb-6 space-y-4">
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Filter by Category
              </label>
              <select
                value={selectedCategory ?? ''}
                onChange={(e) => setSelectedCategory(e.target.value ? Number(e.target.value) : undefined)}
                className="w-full md:w-64 px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              >
                <option value="">All Categories</option>
                {categories?.map((category) => (
                  <option key={category.id} value={category.id}>
                    {category.name}
                  </option>
                ))}
              </select>
            </div>

            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Filter by Tags
              </label>
              <div className="flex flex-wrap gap-2">
                {tags?.map((tag) => (
                  <button
                    key={tag.id}
                    onClick={() => handleTagToggle(tag.id)}
                    className={`px-3 py-1 rounded-full text-sm font-medium transition-colors ${
                      selectedTags.includes(tag.id)
                        ? 'bg-blue-600 text-white'
                        : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
                    }`}
                  >
                    {tag.name}
                  </button>
                ))}
              </div>
            </div>

            {(selectedCategory || selectedTags.length > 0) && (
              <button
                onClick={() => {
                  setSelectedCategory(undefined)
                  setSelectedTags([])
                }}
                className="text-sm text-blue-600 hover:text-blue-800 font-medium"
              >
                Clear all filters
              </button>
            )}
          </div>

          <div className="border-t pt-6">
            <div className="space-y-4">
              {isLoading ? (
                <p className="text-gray-600">Loading activities...</p>
              ) : (
                <>
              {allActivities.map((activity) => (
                <div key={activity.id} className="border border-gray-200 rounded-lg p-4 hover:bg-gray-50 transition-colors">
                  <div className="flex justify-between items-start mb-2">
                    <h3 className="text-lg font-semibold text-gray-900">{activity.title}</h3>
                    {activity.category && (
                      <span className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded whitespace-nowrap">
                        {activity.category.name}
                      </span>
                    )}
                  </div>
                  <p className="text-gray-600 text-sm mb-3">{activity.description}</p>
                  <div className="flex items-center justify-between gap-4">
                    <div className="flex gap-2 flex-wrap flex-1 min-w-0">
                      {activity.tags.map((tag) => (
                        <span key={tag.id} className="bg-gray-100 text-gray-700 text-xs px-2 py-1 rounded">
                          {tag.name}
                        </span>
                      ))}
                    </div>
                    <Button
                      onClick={() => handleScheduleClick(activity.id)}
                      size="sm"
                      className="text-xs shrink-0"
                    >
                      Plan Activity
                    </Button>
                  </div>
                </div>
              ))}
              
              {allActivities.length === 0 && !isLoading && (
                <p className="text-gray-500 text-center py-8">
                  {selectedCategory || selectedTags.length > 0 
                    ? 'No activities found matching your filters' 
                    : 'No activities found'}
                </p>
              )}
              
              {allActivities.length > 0 && (
                <div className="mt-6 border-t pt-4">
                  <div className="text-sm text-gray-600 text-center">
                    Showing {allActivities.length} of {totalCount} activities
                  </div>
                </div>
              )}

              {/* Intersection Observer Target */}
              <div ref={observerTarget} className="h-10 flex items-center justify-center">
                {isFetchingNextPage && (
                  <p className="text-gray-500 text-sm">Loading more activities...</p>
                )}
              </div>
                </>
              )}
            </div>
          </div>
        </div>
      </div>

      {/* Schedule Dialog */}
      {scheduleDialogOpen && (
        <div 
          className="fixed inset-0 bg-black/50 flex items-center justify-center p-4"
          style={{ zIndex: 9999 }}
          onClick={(e) => {
            if (e.target === e.currentTarget) {
              setScheduleDialogOpen(false)
              setSelectedActivityId(null)
              setPlannedDate('')
              setNotes('')
            }
          }}
        >
          <div className="bg-white rounded-lg shadow-xl p-6 max-w-md w-full relative" onClick={(e) => e.stopPropagation()}>
            <h2 className="text-2xl font-bold text-gray-900 mb-6">Plan Activity</h2>
            <form onSubmit={handleScheduleSubmit}>
              <div className="mb-4">
                <label className="block text-sm font-medium text-gray-700 mb-2">
                  Planned Date
                </label>
                <input
                  type="date"
                  value={plannedDate}
                  onChange={(e) => setPlannedDate(e.target.value)}
                  min={new Date().toISOString().split('T')[0]}
                  required
                  className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
              </div>
              <div className="mb-4">
                <label className="block text-sm font-medium text-gray-700 mb-2">
                  Notes (Optional)
                </label>
                <textarea
                  value={notes}
                  onChange={(e) => setNotes(e.target.value)}
                  rows={3}
                  className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                  placeholder="Add any notes about this activity..."
                />
              </div>
              <div className="flex justify-end gap-2">
                <Button
                  type="button"
                  variant="outline"
                  onClick={() => {
                    setScheduleDialogOpen(false)
                    setSelectedActivityId(null)
                    setPlannedDate('')
                    setNotes('')
                  }}
                >
                  Cancel
                </Button>
                <Button
                  type="submit"
                  disabled={scheduleMutation.isPending}
                >
                  {scheduleMutation.isPending ? 'Scheduling...' : 'Schedule'}
                </Button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  )
}

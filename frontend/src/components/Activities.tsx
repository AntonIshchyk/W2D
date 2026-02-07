import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback } from 'react'
import { Button } from './ui/button'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { PAGINATION } from '../config/constants'

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
    limit: PAGINATION.DEFAULT_PAGE_SIZE.toString()
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

  const locationLabels: Record<number, string> = { 0: 'Indoor', 1: 'Outdoor', 2: 'Both' }
  const costLabels: Record<number, string> = { 0: 'Free', 1: '$', 2: '$$', 3: '$$$' }
  const physicalLabels: Record<number, string> = { 0: 'Chill', 1: 'Light', 2: 'Moderate', 3: 'Intense' }

  return (
    <PageLayout>
      {/* Header row */}
      <div className="flex items-end justify-between mb-8">
        <div>
          <h1 className="text-3xl font-bold text-gray-900">Activities</h1>
          {totalCount > 0 && (
            <p className="text-sm text-gray-400 mt-1">{totalCount} total</p>
          )}
        </div>
      </div>

      {/* Inline filters */}
      <div className="mb-8 space-y-3">
        <div className="flex items-center gap-3 flex-wrap">
          {/* Category as pills */}
          <button
            onClick={() => setSelectedCategory(undefined)}
            className={`px-3 py-1.5 rounded-full text-xs font-medium transition-all ${
              !selectedCategory
                ? 'bg-gray-900 text-white'
                : 'bg-gray-100 text-gray-600 hover:bg-gray-200'
            }`}
          >
            All
          </button>
          {categories?.map((category) => (
            <button
              key={category.id}
              onClick={() => setSelectedCategory(selectedCategory === category.id ? undefined : category.id)}
              className={`px-3 py-1.5 rounded-full text-xs font-medium transition-all ${
                selectedCategory === category.id
                  ? 'bg-gray-900 text-white'
                  : 'bg-gray-100 text-gray-600 hover:bg-gray-200'
              }`}
            >
              {category.name}
            </button>
          ))}
        </div>

        {/* Tags as smaller toggles */}
        {tags && tags.length > 0 && (
          <div className="flex items-center gap-2 flex-wrap">
            <span className="text-xs text-gray-400 mr-1">Tags</span>
            {tags.map((tag) => (
              <button
                key={tag.id}
                onClick={() => handleTagToggle(tag.id)}
                className={`px-2.5 py-1 rounded-md text-xs transition-all ${
                  selectedTags.includes(tag.id)
                    ? 'bg-blue-600 text-white'
                    : 'bg-white border border-gray-200 text-gray-500 hover:border-gray-400'
                }`}
              >
                {tag.name}
              </button>
            ))}
            {(selectedCategory || selectedTags.length > 0) && (
              <button
                onClick={() => { setSelectedCategory(undefined); setSelectedTags([]) }}
                className="text-xs text-gray-400 hover:text-gray-600 ml-2 underline"
              >
                clear
              </button>
            )}
          </div>
        )}
      </div>

      {/* Activity grid */}
      {isLoading ? (
        <div className="flex items-center justify-center py-20">
          <p className="text-sm text-gray-400 tracking-wide uppercase">Loading...</p>
        </div>
      ) : (
        <>
          <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-4">
            {allActivities.map((activity) => (
              <div
                key={activity.id}
                className="group bg-white border border-gray-200 rounded-xl p-5 hover:border-gray-400 hover:shadow-sm transition-all duration-200 flex flex-col"
              >
                {/* Top: category badge */}
                <div className="flex items-start justify-between mb-3">
                  <h3 className="text-base font-semibold text-gray-900 leading-snug pr-2">
                    {activity.title}
                  </h3>
                  {activity.category && (
                    <span className="shrink-0 text-[11px] font-medium text-gray-500 bg-gray-100 px-2 py-0.5 rounded-full">
                      {activity.category.name}
                    </span>
                  )}
                </div>

                {/* Description */}
                <p className="text-sm text-gray-500 line-clamp-2 mb-4 flex-1">
                  {activity.description}
                </p>

                {/* Meta chips */}
                <div className="flex items-center gap-2 flex-wrap mb-4 text-[11px]">
                  {activity.locationType !== undefined && locationLabels[activity.locationType] && (
                    <span className="bg-gray-50 text-gray-500 px-2 py-0.5 rounded">
                      {locationLabels[activity.locationType]}
                    </span>
                  )}
                  {activity.costLevel !== undefined && costLabels[activity.costLevel] && (
                    <span className="bg-gray-50 text-gray-500 px-2 py-0.5 rounded">
                      {costLabels[activity.costLevel]}
                    </span>
                  )}
                  {activity.physicalActivityLevel !== undefined && physicalLabels[activity.physicalActivityLevel] && (
                    <span className="bg-gray-50 text-gray-500 px-2 py-0.5 rounded">
                      {physicalLabels[activity.physicalActivityLevel]}
                    </span>
                  )}
                </div>

                {/* Tags + action */}
                <div className="flex items-end justify-between gap-3 pt-3 border-t border-gray-100">
                  <div className="flex gap-1.5 flex-wrap min-w-0">
                    {activity.tags.slice(0, 3).map((tag) => (
                      <span key={tag.id} className="text-[11px] text-gray-400">
                        #{tag.name}
                      </span>
                    ))}
                    {activity.tags.length > 3 && (
                      <span className="text-[11px] text-gray-300">+{activity.tags.length - 3}</span>
                    )}
                  </div>
                  <button
                    onClick={() => handleScheduleClick(activity.id)}
                    className="shrink-0 text-xs font-medium text-gray-400 hover:text-gray-900 opacity-0 group-hover:opacity-100 transition-all"
                  >
                    + Plan
                  </button>
                </div>
              </div>
            ))}
          </div>

          {allActivities.length === 0 && (
            <div className="text-center py-20">
              <p className="text-gray-400">
                {selectedCategory || selectedTags.length > 0 
                  ? 'Nothing matches those filters' 
                  : 'No activities yet'}
              </p>
            </div>
          )}

          {/* Infinite scroll target */}
          <div ref={observerTarget} className="h-10 flex items-center justify-center mt-6">
            {isFetchingNextPage && (
              <p className="text-xs text-gray-400">Loading more...</p>
            )}
          </div>
        </>
      )}

      {/* Schedule Dialog */}
      {scheduleDialogOpen && (
        <div 
          className="fixed inset-0 bg-black/40 backdrop-blur-sm flex items-center justify-center p-4 z-100"
          onClick={(e) => {
            if (e.target === e.currentTarget) {
              setScheduleDialogOpen(false)
              setSelectedActivityId(null)
              setPlannedDate('')
              setNotes('')
            }
          }}
        >
          <div className="bg-white rounded-2xl shadow-2xl p-7 max-w-sm w-full relative" onClick={(e) => e.stopPropagation()}>
            <h2 className="text-lg font-semibold text-gray-900 mb-5">Plan Activity</h2>
            <form onSubmit={handleScheduleSubmit}>
              <div className="mb-4">
                <label className="block text-xs font-medium text-gray-500 mb-1.5 uppercase tracking-wide">
                  Date
                </label>
                <input
                  type="date"
                  value={plannedDate}
                  onChange={(e) => setPlannedDate(e.target.value)}
                  min={new Date().toISOString().split('T')[0]}
                  required
                  className="w-full px-3 py-2 border border-gray-200 rounded-lg focus:outline-none focus:ring-2 focus:ring-gray-900 text-sm"
                />
              </div>
              <div className="mb-5">
                <label className="block text-xs font-medium text-gray-500 mb-1.5 uppercase tracking-wide">
                  Notes
                </label>
                <textarea
                  value={notes}
                  onChange={(e) => setNotes(e.target.value)}
                  rows={2}
                  className="w-full px-3 py-2 border border-gray-200 rounded-lg focus:outline-none focus:ring-2 focus:ring-gray-900 text-sm"
                  placeholder="Optional notes..."
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
                  className="text-sm"
                >
                  Cancel
                </Button>
                <Button
                  type="submit"
                  disabled={scheduleMutation.isPending}
                  className="text-sm"
                >
                  {scheduleMutation.isPending ? 'Saving...' : 'Schedule'}
                </Button>
              </div>
            </form>
          </div>
        </div>
      )}
    </PageLayout>
  )
}

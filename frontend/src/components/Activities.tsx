import { useQuery } from '@tanstack/react-query'
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

async function fetchActivities(pageNumber: number, categoryId?: number, tagIds?: number[]): Promise<PaginatedResult> {
  const params = new URLSearchParams({
    pageNumber: pageNumber.toString(),
    pageSize: '10'
  })

  if (categoryId) {
    params.append('categoryId', categoryId.toString())
  }

  if (tagIds && tagIds.length > 0) {
    tagIds.forEach(id => params.append('tagIds', id.toString()))
  }

  const response = await fetch(`${API_ENDPOINTS.activities.base}?${params}`)

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
  const navigate = useNavigate()
  const [currentPage, setCurrentPage] = useState(1)
  const [selectedCategory, setSelectedCategory] = useState<number | undefined>(undefined)
  const [selectedTags, setSelectedTags] = useState<number[]>([])
  
  const { data: user, isError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: categories } = useQuery({
    queryKey: ['categories'],
    queryFn: fetchCategories,
    retry: false
  })

  const { data: tags } = useQuery({
    queryKey: ['tags'],
    queryFn: fetchTags,
    retry: false
  })

  const { data: activitiesData, isLoading: activitiesLoading } = useQuery({
    queryKey: ['activities', currentPage, selectedCategory, selectedTags],
    queryFn: () => fetchActivities(currentPage, selectedCategory, selectedTags),
    retry: false
  })

  useEffect(() => {
    if (isError) {
      localStorage.removeItem('token')
      navigate('/login')
    }
  }, [isError, navigate])

  // Reset to page 1 when filters change
  useEffect(() => {
    setCurrentPage(1)
  }, [selectedCategory, selectedTags])

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
      <Navbar userName={user?.name} />
      
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
                    {activity.tags.map((tag) => (
                      <span key={tag.id} className="bg-gray-100 text-gray-700 text-xs px-2 py-1 rounded">
                        {tag.name}
                      </span>
                    ))}
                  </div>
                </div>
              ))}
              
              {activitiesData && activitiesData.items.length === 0 && (
                <p className="text-gray-500 text-center py-8">
                  {selectedCategory || selectedTags.length > 0 
                    ? 'No activities found matching your filters' 
                    : 'No activities found'}
                </p>
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
    </div>
  )
}

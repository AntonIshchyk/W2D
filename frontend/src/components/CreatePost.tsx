import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { Button } from './ui/button'
import { Navbar } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PostType } from '../types/posts'
import type { CreatePostRequest } from '../types/posts'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { PAGINATION } from '../config/constants'

interface Activity {
  id: number
  title: string
}

async function fetchActivities(): Promise<Activity[]> {
  const response = await fetch(`${API_ENDPOINTS.activities.base}?limit=${PAGINATION.ACTIVITIES_FETCH_SIZE}`, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch activities')
  }

  const data = await response.json()
  return data.items || []
}

async function createPost(data: CreatePostRequest): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.base, {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(data)
  })

  if (!response.ok) {
    const error = await response.json()
    throw new Error(error.message || 'Failed to create post')
  }
}

const POST_TYPE_OPTIONS = [
  { value: PostType.ExperienceShare, label: 'Experience Share', description: 'Share your experience with an activity' },
  { value: PostType.Guide, label: 'Guide', description: 'Create a how-to guide for others' },
  { value: PostType.Question, label: 'Question', description: 'Ask the community for advice' },
  { value: PostType.Recommendation, label: 'Recommendation', description: 'Recommend an activity or location' },
  { value: PostType.Achievement, label: 'Achievement', description: 'Celebrate your accomplishments' },
  { value: PostType.Challenge, label: 'Challenge', description: 'Challenge others to try something' }
]

export function CreatePost() {
  const navigate = useNavigate()
  const queryClient = useQueryClient()
  const [title, setTitle] = useState('')
  const [content, setContent] = useState('')
  const [type, setType] = useState<number>(PostType.ExperienceShare)
  const [activityId, setActivityId] = useState<number | ''>('')
  const [locationName, setLocationName] = useState('')
  const [rating, setRating] = useState<number | ''>('')
  const [durationMinutes, setDurationMinutes] = useState<number | ''>('')
  const [cost, setCost] = useState<number | ''>('')
  const [currencyCode, setCurrencyCode] = useState('USD')

  const { data: currentUser, isError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: activities } = useQuery({
    queryKey: ['activities'],
    queryFn: fetchActivities
  })

  const createMutation = useMutation({
    mutationFn: createPost,
    onSuccess: () => {
      // Invalidate posts queries to refetch with new post
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      navigate('/posts')
    }
  })

  useAuthErrorHandler(isError)

  if (isError) {
    return null
  }

  if (!currentUser) {
    navigate('/login')
    return null
  }

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()

    if (!activityId) {
      alert('Please select an activity')
      return
    }

    const postData: CreatePostRequest = {
      title,
      content,
      type,
      activityId: Number(activityId),
      locationName: locationName || undefined,
      rating: rating ? Number(rating) : undefined,
      durationMinutes: durationMinutes ? Number(durationMinutes) : undefined,
      cost: cost ? Number(cost) : undefined,
      currencyCode: cost ? currencyCode : undefined
    }

    createMutation.mutate(postData)
  }

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />
      
      <div className="max-w-3xl mx-auto p-4 py-8">
        <div className="bg-white rounded-lg shadow-md p-8">
          <h1 className="text-3xl font-bold text-gray-900 mb-6">Create a Post</h1>
          
          <form onSubmit={handleSubmit} className="space-y-6">
            {/* Post Type */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Post Type *
              </label>
              <div className="grid grid-cols-1 md:grid-cols-2 gap-3">
                {POST_TYPE_OPTIONS.map((option) => (
                  <label
                    key={option.value}
                    className={`border rounded-lg p-4 cursor-pointer transition-all ${
                      type === option.value
                        ? 'border-blue-600 bg-blue-50'
                        : 'border-gray-300 hover:border-gray-400'
                    }`}
                  >
                    <input
                      type="radio"
                      name="type"
                      value={option.value}
                      checked={type === option.value}
                      onChange={(e) => setType(Number(e.target.value))}
                      className="sr-only"
                    />
                    <div className="font-semibold text-gray-900 mb-1">{option.label}</div>
                    <div className="text-sm text-gray-600">{option.description}</div>
                  </label>
                ))}
              </div>
            </div>

            {/* Activity */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Activity *
              </label>
              <select
                value={activityId}
                onChange={(e) => setActivityId(e.target.value ? Number(e.target.value) : '')}
                required
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              >
                <option value="">Select an activity</option>
                {activities?.map((activity) => (
                  <option key={activity.id} value={activity.id}>
                    {activity.title}
                  </option>
                ))}
              </select>
            </div>

            {/* Title */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Title *
              </label>
              <input
                type="text"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                required
                minLength={3}
                maxLength={200}
                placeholder="Give your post a descriptive title"
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              <p className="mt-1 text-sm text-gray-500">{title.length}/200 characters</p>
            </div>

            {/* Content */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Content *
              </label>
              <textarea
                value={content}
                onChange={(e) => setContent(e.target.value)}
                required
                minLength={10}
                maxLength={2000}
                rows={8}
                placeholder="Share your thoughts, experiences, or questions..."
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              <p className="mt-1 text-sm text-gray-500">{content.length}/2000 characters</p>
            </div>

            {/* Location */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Location (Optional)
              </label>
              <input
                type="text"
                value={locationName}
                onChange={(e) => setLocationName(e.target.value)}
                maxLength={500}
                placeholder="Where did this activity take place?"
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>

            {/* Rating */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Rating (Optional)
              </label>
              <select
                value={rating}
                onChange={(e) => setRating(e.target.value ? Number(e.target.value) : '')}
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              >
                <option value="">No rating</option>
                <option value="5">⭐⭐⭐⭐⭐ Excellent</option>
                <option value="4">⭐⭐⭐⭐ Good</option>
                <option value="3">⭐⭐⭐ Average</option>
                <option value="2">⭐⭐ Below Average</option>
                <option value="1">⭐ Poor</option>
              </select>
            </div>

            {/* Duration */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Duration in Minutes (Optional)
              </label>
              <input
                type="number"
                value={durationMinutes}
                onChange={(e) => setDurationMinutes(e.target.value ? Number(e.target.value) : '')}
                min={1}
                max={10000}
                placeholder="How long did it take?"
                className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>

            {/* Cost */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Cost (Optional)
              </label>
              <div className="flex gap-2">
                <input
                  type="number"
                  value={cost}
                  onChange={(e) => setCost(e.target.value ? Number(e.target.value) : '')}
                  min={0}
                  step="0.01"
                  placeholder="Amount"
                  className="flex-1 px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
                <select
                  value={currencyCode}
                  onChange={(e) => setCurrencyCode(e.target.value)}
                  className="w-24 px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                >
                  <option value="USD">USD</option>
                  <option value="EUR">EUR</option>
                  <option value="GBP">GBP</option>
                  <option value="JPY">JPY</option>
                  <option value="CAD">CAD</option>
                  <option value="AUD">AUD</option>
                </select>
              </div>
            </div>

            {/* Buttons */}
            <div className="flex justify-end gap-3 pt-6 border-t">
              <Button
                type="button"
                variant="outline"
                onClick={() => navigate('/posts')}
              >
                Cancel
              </Button>
              <Button
                type="submit"
                disabled={createMutation.isPending}
              >
                {createMutation.isPending ? 'Creating...' : 'Create Post'}
              </Button>
            </div>

            {createMutation.isError && (
              <div className="mt-4 p-4 bg-red-50 border border-red-200 rounded-md">
                <p className="text-sm text-red-800">
                  {createMutation.error?.message || 'Failed to create post. Please try again.'}
                </p>
              </div>
            )}
          </form>
        </div>
      </div>
    </div>
  )
}

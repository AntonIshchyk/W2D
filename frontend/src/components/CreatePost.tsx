import { useState } from 'react'
import { useNavigate, Navigate } from 'react-router-dom'
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import { Check, ChevronsUpDown } from 'lucide-react'
import { Button } from './ui/button'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PostType } from '../types/posts'
import type { CreatePostRequest } from '../types/posts'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { PAGINATION } from '../config/constants'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { cn } from '../lib/utils'

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
    let errorMsg = 'Failed to create post'
    try { const body = await response.json(); errorMsg = body.message || errorMsg } catch {}
    throw new Error(errorMsg)
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
  const [activityOpen, setActivityOpen] = useState(false)
  const [locationName, setLocationName] = useState('')
  const [rating, setRating] = useState<number | ''>('')
  const [durationMinutes, setDurationMinutes] = useState<number | ''>('')
  const [cost, setCost] = useState<number | ''>('')
  const [currencyCode, setCurrencyCode] = useState('USD')

  const { data: currentUser, isError, error: userError } = useQuery({
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
      toast.success('Post created successfully!')
      navigate('/posts')
    },
    onError: (error: Error) => {
      toast.error(error.message)
    }
  })

  useAuthErrorHandler(isError, userError)

  if (isError) {
    return null
  }

  if (!currentUser) {
    return <Navigate to="/login" replace />
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
    <PageLayout>
      <div className="max-w-2xl">
        {/* Back link */}
        <button
          onClick={() => navigate('/posts')}
          className="text-xs text-gray-400 hover:text-gray-600 mb-6 flex items-center gap-1 transition-colors"
        >
          <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 19l-7-7 7-7" />
          </svg>
          Posts
        </button>

        <h1 className="text-2xl font-bold text-gray-900 mb-6">New Post</h1>
          
          <form onSubmit={handleSubmit} className="space-y-6">
            {/* Post Type */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Post Type *
              </label>
              <Select value={type.toString()} onValueChange={(value) => setType(Number(value))}>
                <SelectTrigger className="w-full">
                  <SelectValue placeholder="Select post type" />
                </SelectTrigger>
                <SelectContent>
                  {POST_TYPE_OPTIONS.map((option) => (
                    <SelectItem key={option.value} value={option.value.toString()}>
                      <div>
                        <div className="font-medium">{option.label}</div>
                        <div className="text-xs text-muted-foreground">{option.description}</div>
                      </div>
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>

            {/* Activity */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Activity *
              </label>
              <Popover open={activityOpen} onOpenChange={setActivityOpen}>
                <PopoverTrigger asChild>
                  <Button
                    variant="outline"
                    role="combobox"
                    aria-expanded={activityOpen}
                    className="w-full justify-between"
                  >
                    {activityId
                      ? activities?.find((activity) => activity.id === activityId)?.title
                      : "Select an activity..."}
                    <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
                  </Button>
                </PopoverTrigger>
                <PopoverContent className="w-full p-0" align="start">
                  <Command>
                    <CommandInput placeholder="Search activities..." />
                    <CommandList>
                      <CommandEmpty>No activity found.</CommandEmpty>
                      <CommandGroup>
                        {activities?.map((activity) => (
                          <CommandItem
                            key={activity.id}
                            value={activity.title}
                            onSelect={() => {
                              setActivityId(activity.id)
                              setActivityOpen(false)
                            }}
                          >
                            <Check
                              className={cn(
                                "mr-2 h-4 w-4",
                                activityId === activity.id ? "opacity-100" : "opacity-0"
                              )}
                            />
                            {activity.title}
                          </CommandItem>
                        ))}
                      </CommandGroup>
                    </CommandList>
                  </Command>
                </PopoverContent>
              </Popover>
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
          </form>
        </div>
    </PageLayout>
  )
}

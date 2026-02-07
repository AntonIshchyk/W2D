import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback } from 'react'
import { useNavigate } from 'react-router-dom'
import { Button } from './ui/button'
import { Navbar } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { PostType } from '../types/posts'
import type { Post, ScrollResult } from '../types/posts'
import { PAGINATION } from '../config/constants'

interface Activity {
  id: number
  title: string
}

async function fetchPosts(
  cursor: number | null, 
  activityId?: number, 
  userId?: number,
  type?: number,
  sortBy?: string
): Promise<ScrollResult<Post>> {
  const params = new URLSearchParams({
    limit: PAGINATION.DEFAULT_PAGE_SIZE.toString()
  })

  if (cursor !== null) {
    params.append('cursor', cursor.toString())
  }

  if (activityId) {
    params.append('activityId', activityId.toString())
  }

  if (userId) {
    params.append('userId', userId.toString())
  }

  if (type) {
    params.append('type', type.toString())
  }

  if (sortBy) {
    params.append('sortBy', sortBy)
  }

  const response = await fetch(`${API_ENDPOINTS.posts.base}?${params}`, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch posts')
  }

  return response.json()
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

async function votePost(postId: number, value: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.vote(postId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify({ value })
  })

  if (!response.ok) {
    throw new Error('Failed to vote on post')
  }
}

const POST_TYPE_LABELS: Record<PostType, string> = {
  [PostType.ExperienceShare]: 'Experience',
  [PostType.Guide]: 'Guide',
  [PostType.Question]: 'Question',
  [PostType.Recommendation]: 'Recommendation',
  [PostType.Achievement]: 'Achievement',
  [PostType.Challenge]: 'Challenge'
}

const POST_TYPE_COLORS: Record<PostType, string> = {
  [PostType.ExperienceShare]: 'bg-blue-100 text-blue-800',
  [PostType.Guide]: 'bg-green-100 text-green-800',
  [PostType.Question]: 'bg-yellow-100 text-yellow-800',
  [PostType.Recommendation]: 'bg-purple-100 text-purple-800',
  [PostType.Achievement]: 'bg-orange-100 text-orange-800',
  [PostType.Challenge]: 'bg-red-100 text-red-800'
}

export function Posts() {
  const navigate = useNavigate()
  const [selectedActivity, setSelectedActivity] = useState<number | undefined>(undefined)
  const [selectedType, setSelectedType] = useState<number | undefined>(undefined)
  const [sortBy, setSortBy] = useState<string>('new')
  const observerTarget = useRef<HTMLDivElement>(null)
  
  const { data: currentUser, isError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: activities } = useQuery({
    queryKey: ['activities'],
    queryFn: fetchActivities,
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
    queryKey: ['posts', selectedActivity, selectedType, sortBy],
    queryFn: ({ pageParam }) => fetchPosts(pageParam, selectedActivity, undefined, selectedType, sortBy),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false
  })

  const queryClient = useQueryClient()

  const voteMutation = useMutation({
    mutationFn: ({ postId, value }: { postId: number; value: number }) => 
      votePost(postId, value),
    onSuccess: (_, variables) => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      queryClient.invalidateQueries({ queryKey: ['post', variables.postId.toString()] })
    }
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

  // Flatten all posts from all pages
  const allPosts = data?.pages.flatMap(page => page.items) ?? []
  const totalCount = data?.pages[0]?.totalCount ?? 0

  const handleVote = (postId: number, currentVote: number | undefined, newValue: number) => {
    // If clicking the same vote, remove it (set to 0)
    const value = currentVote === newValue ? 0 : newValue
    voteMutation.mutate({ postId, value })
  }

  const formatDate = (dateString: string) => {
    const date = new Date(dateString)
    const now = new Date()
    const diffMs = now.getTime() - date.getTime()
    const diffMins = Math.floor(diffMs / 60000)
    const diffHours = Math.floor(diffMs / 3600000)
    const diffDays = Math.floor(diffMs / 86400000)

    if (diffMins < 1) return 'just now'
    if (diffMins < 60) return `${diffMins}m ago`
    if (diffHours < 24) return `${diffHours}h ago`
    if (diffDays < 7) return `${diffDays}d ago`
    return date.toLocaleDateString()
  }

  if (isError) {
    return null
  }

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />
      
      <div className="max-w-4xl mx-auto p-4 py-8">
        <div className="bg-white rounded-lg shadow-md p-8">
          <div className="flex justify-between items-center mb-6">
            <h1 className="text-3xl font-bold text-gray-900">Community Posts</h1>
            {currentUser && (
              <Button onClick={() => navigate('/posts/create')}>
                Create Post
              </Button>
            )}
          </div>
          
          {/* Filters */}
          <div className="mb-6 space-y-4">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-2">
                  Sort By
                </label>
                <select
                  value={sortBy}
                  onChange={(e) => setSortBy(e.target.value)}
                  className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                >
                  <option value="new">New (Latest First)</option>
                  <option value="hot">Hot (Most Popular)</option>
                  <option value="top">Top (Highest Rated)</option>
                </select>
              </div>

              <div>
                <label className="block text-sm font-medium text-gray-700 mb-2">
                  Filter by Activity
                </label>
                <select
                  value={selectedActivity ?? ''}
                  onChange={(e) => setSelectedActivity(e.target.value ? Number(e.target.value) : undefined)}
                  className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                >
                  <option value="">All Activities</option>
                  {activities?.map((activity) => (
                    <option key={activity.id} value={activity.id}>
                      {activity.title}
                    </option>
                  ))}
                </select>
              </div>
            </div>

            <div>
              <label className="block text-sm font-medium text-gray-700 mb-2">
                Filter by Type
              </label>
              <div className="flex flex-wrap gap-2">
                {Object.entries(POST_TYPE_LABELS).map(([value, label]) => (
                  <button
                    key={value}
                    onClick={() => setSelectedType(selectedType === Number(value) ? undefined : Number(value))}
                    className={`px-3 py-1 rounded-full text-sm font-medium transition-colors ${
                      selectedType === Number(value)
                        ? 'bg-blue-600 text-white'
                        : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
                    }`}
                  >
                    {label}
                  </button>
                ))}
              </div>
            </div>

            {(selectedActivity || selectedType || sortBy !== 'new') && (
              <button
                onClick={() => {
                  setSelectedActivity(undefined)
                  setSelectedType(undefined)
                  setSortBy('new')
                }}
                className="text-sm text-blue-600 hover:text-blue-800 font-medium"
              >
                Clear all filters
              </button>
            )}
          </div>

          <div className="border-t pt-6">
            <div className="space-y-6">
              {isLoading ? (
                <p className="text-gray-600">Loading posts...</p>
              ) : (
                <>
                  {allPosts.map((post) => (
                    <div key={post.id} className="border border-gray-200 rounded-lg p-6 hover:shadow-md transition-shadow">
                      <div className="flex gap-4">
                        {/* Vote buttons */}
                        <div className="flex flex-col items-center gap-1">
                          <button
                            onClick={() => handleVote(post.id, post.currentUserVote, 1)}
                            disabled={!currentUser}
                            className={`p-1 rounded hover:bg-gray-100 transition-colors ${
                              post.currentUserVote === 1 ? 'text-orange-600' : 'text-gray-400'
                            } ${!currentUser ? 'cursor-not-allowed opacity-50' : ''}`}
                          >
                            <svg className="w-6 h-6" fill="currentColor" viewBox="0 0 20 20">
                              <path d="M5.293 9.707a1 1 0 010-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 01-1.414 1.414L11 7.414V15a1 1 0 11-2 0V7.414L6.707 9.707a1 1 0 01-1.414 0z" />
                            </svg>
                          </button>
                          <span className={`text-sm font-semibold ${
                            post.score > 0 ? 'text-orange-600' : post.score < 0 ? 'text-blue-600' : 'text-gray-600'
                          }`}>
                            {post.score}
                          </span>
                          <button
                            onClick={() => handleVote(post.id, post.currentUserVote, -1)}
                            disabled={!currentUser}
                            className={`p-1 rounded hover:bg-gray-100 transition-colors ${
                              post.currentUserVote === -1 ? 'text-blue-600' : 'text-gray-400'
                            } ${!currentUser ? 'cursor-not-allowed opacity-50' : ''}`}
                          >
                            <svg className="w-6 h-6" fill="currentColor" viewBox="0 0 20 20">
                              <path d="M14.707 10.293a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 111.414-1.414L9 12.586V5a1 1 0 012 0v7.586l2.293-2.293a1 1 0 011.414 0z" />
                            </svg>
                          </button>
                        </div>

                        {/* Post content */}
                        <div className="flex-1 min-w-0">
                          <div className="flex items-center gap-2 mb-2 flex-wrap">
                            <span className={`text-xs font-medium px-2.5 py-0.5 rounded ${
                              POST_TYPE_COLORS[post.type as PostType]
                            }`}>
                              {POST_TYPE_LABELS[post.type as PostType]}
                            </span>
                            {post.activityTitle && (
                              <span className="text-xs text-gray-600">
                                • {post.activityTitle}
                              </span>
                            )}
                          </div>
                          
                          <h3 
                            className="text-xl font-semibold text-gray-900 mb-2 cursor-pointer hover:text-blue-600"
                            onClick={() => navigate(`/posts/${post.id}`)}
                          >
                            {post.title}
                          </h3>
                          
                          <p className="text-gray-700 mb-3 line-clamp-3">{post.content}</p>
                          
                          {post.rating && (
                            <div className="flex items-center gap-1 mb-2">
                              {[...Array(5)].map((_, i) => (
                                <svg
                                  key={i}
                                  className={`w-4 h-4 ${i < post.rating! ? 'text-yellow-400' : 'text-gray-300'}`}
                                  fill="currentColor"
                                  viewBox="0 0 20 20"
                                >
                                  <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                                </svg>
                              ))}
                            </div>
                          )}
                          
                          <div className="flex items-center gap-4 text-sm text-gray-500">
                            <span>by {post.userName || 'Anonymous'}</span>
                            <span>•</span>
                            <span>{formatDate(post.createdAt)}</span>
                            {post.commentCount > 0 && (
                              <>
                                <span>•</span>
                                <span>{post.commentCount} comments</span>
                              </>
                            )}
                          </div>
                        </div>
                      </div>
                    </div>
                  ))}
                  
                  {allPosts.length === 0 && !isLoading && (
                    <p className="text-gray-500 text-center py-8">
                      {selectedActivity || selectedType
                        ? 'No posts found matching your filters' 
                        : 'No posts yet. Be the first to create one!'}
                    </p>
                  )}
                  
                  {allPosts.length > 0 && (
                    <div className="mt-6 border-t pt-4">
                      <div className="text-sm text-gray-600 text-center">
                        Showing {allPosts.length} of {totalCount} posts
                      </div>
                    </div>
                  )}

                  {/* Intersection Observer Target */}
                  <div ref={observerTarget} className="h-10 flex items-center justify-center">
                    {isFetchingNextPage && (
                      <p className="text-gray-500 text-sm">Loading more posts...</p>
                    )}
                  </div>
                </>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { Button } from './ui/button'
import { PageLayout } from './Navbar'
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
  
  const { data: currentUser, isError, error: userError } = useQuery({
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

  useAuthErrorHandler(isError, userError)

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
    <PageLayout>
      {/* Header */}
      <div className="flex items-center justify-between mb-6">
        <h1 className="text-3xl font-bold text-gray-900">Posts</h1>
        {currentUser && (
          <Button onClick={() => navigate('/posts/create')} className="text-sm">
            New Post
          </Button>
        )}
      </div>

      {/* Filters — compact inline bar */}
      <div className="flex items-center gap-4 flex-wrap mb-6 pb-5 border-b border-gray-200">
        {/* Sort tabs */}
        <div className="flex bg-gray-100 rounded-lg p-0.5">
          {[
            { value: 'new', label: 'New' },
            { value: 'hot', label: 'Hot' },
            { value: 'top', label: 'Top' }
          ].map((s) => (
            <button
              key={s.value}
              onClick={() => setSortBy(s.value)}
              className={`px-3 py-1.5 rounded-md text-xs font-medium transition-all ${
                sortBy === s.value
                  ? 'bg-white text-gray-900 shadow-sm'
                  : 'text-gray-500 hover:text-gray-700'
              }`}
            >
              {s.label}
            </button>
          ))}
        </div>

        {/* Activity filter */}
        <select
          value={selectedActivity ?? ''}
          onChange={(e) => setSelectedActivity(e.target.value ? Number(e.target.value) : undefined)}
          className="text-xs text-gray-600 bg-transparent border border-gray-200 rounded-lg px-3 py-1.5 focus:outline-none focus:ring-1 focus:ring-gray-400"
        >
          <option value="">All activities</option>
          {activities?.map((activity) => (
            <option key={activity.id} value={activity.id}>
              {activity.title}
            </option>
          ))}
        </select>

        {/* Type pills */}
        <div className="flex items-center gap-1.5 flex-wrap">
          {Object.entries(POST_TYPE_LABELS).map(([value, label]) => (
            <button
              key={value}
              onClick={() => setSelectedType(selectedType === Number(value) ? undefined : Number(value))}
              className={`px-2.5 py-1 rounded-md text-xs transition-all ${
                selectedType === Number(value)
                  ? 'bg-gray-900 text-white'
                  : 'bg-white border border-gray-200 text-gray-500 hover:border-gray-400'
              }`}
            >
              {label}
            </button>
          ))}
        </div>

        {(selectedActivity || selectedType || sortBy !== 'new') && (
          <button
            onClick={() => { setSelectedActivity(undefined); setSelectedType(undefined); setSortBy('new') }}
            className="text-xs text-gray-400 hover:text-gray-600 underline"
          >
            clear
          </button>
        )}
      </div>

      {/* Post list — compact density */}
      <div className="max-w-4xl">
        {isLoading ? (
          <div className="flex items-center justify-center py-20">
            <p className="text-sm text-gray-400 tracking-wide uppercase">Loading...</p>
          </div>
        ) : (
          <>
            <div className="divide-y divide-gray-100">
              {allPosts.map((post) => (
                <div key={post.id} className="group py-4 flex gap-4">
                  {/* Compact vote */}
                  <div className="flex flex-col items-center gap-0.5 pt-0.5">
                    <button
                      onClick={() => handleVote(post.id, post.currentUserVote, 1)}
                      disabled={!currentUser}
                      aria-label="Upvote"
                      className={`p-0.5 rounded transition-colors ${
                        post.currentUserVote === 1 ? 'text-orange-500' : 'text-gray-300 hover:text-gray-500'
                      } ${!currentUser ? 'cursor-not-allowed' : ''}`}
                    >
                      <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
                        <path d="M5.293 9.707a1 1 0 010-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 01-1.414 1.414L11 7.414V15a1 1 0 11-2 0V7.414L6.707 9.707a1 1 0 01-1.414 0z" />
                      </svg>
                    </button>
                    <span className={`text-xs font-semibold tabular-nums ${
                      post.score > 0 ? 'text-orange-500' : post.score < 0 ? 'text-blue-500' : 'text-gray-400'
                    }`}>
                      {post.score}
                    </span>
                    <button
                      onClick={() => handleVote(post.id, post.currentUserVote, -1)}
                      disabled={!currentUser}
                      aria-label="Downvote"
                      className={`p-0.5 rounded transition-colors ${
                        post.currentUserVote === -1 ? 'text-blue-500' : 'text-gray-300 hover:text-gray-500'
                      } ${!currentUser ? 'cursor-not-allowed' : ''}`}
                    >
                      <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
                        <path d="M14.707 10.293a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 111.414-1.414L9 12.586V5a1 1 0 012 0v7.586l2.293-2.293a1 1 0 011.414 0z" />
                      </svg>
                    </button>
                  </div>

                  {/* Content */}
                  <div className="flex-1 min-w-0">
                    {/* Meta line */}
                    <div className="flex items-center gap-2 mb-1 text-xs text-gray-400">
                      <span className={`font-medium px-1.5 py-0.5 rounded text-[11px] ${
                        POST_TYPE_COLORS[post.type as PostType] ?? 'bg-gray-100 text-gray-800'
                      }`}>
                        {POST_TYPE_LABELS[post.type as PostType] ?? 'Other'}
                      </span>
                      <span>{post.userName || 'Anon'}</span>
                      <span className="text-gray-300">&middot;</span>
                      <span>{formatDate(post.createdAt)}</span>
                      {post.activityTitle && (
                        <>
                          <span className="text-gray-300">&middot;</span>
                          <span className="text-gray-500">{post.activityTitle}</span>
                        </>
                      )}
                    </div>

                    {/* Title */}
                    <Link 
                      to={`/posts/${post.id}`}
                      className="text-sm font-semibold text-gray-900 mb-1 block hover:text-blue-600 transition-colors"
                    >
                      {post.title}
                    </Link>
                    
                    {/* Preview text */}
                    <p className="text-sm text-gray-500 line-clamp-1">{post.content}</p>

                    {/* Footer */}
                    <div className="flex items-center gap-3 mt-1.5 text-xs text-gray-400">
                      {post.rating && (
                        <span className="flex items-center gap-0.5">
                          {[...Array(post.rating)].map((_, i) => (
                            <svg key={i} className="w-3 h-3 text-yellow-400" fill="currentColor" viewBox="0 0 20 20">
                              <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                            </svg>
                          ))}
                        </span>
                      )}
                      {post.commentCount > 0 && (
                        <span>{post.commentCount} comments</span>
                      )}
                    </div>
                  </div>
                </div>
              ))}
            </div>

            {allPosts.length === 0 && (
              <div className="text-center py-20">
                <p className="text-gray-400">
                  {selectedActivity || selectedType
                    ? 'Nothing matches those filters' 
                    : 'No posts yet'}
                </p>
              </div>
            )}

            {/* Infinite scroll target */}
            <div ref={observerTarget} className="h-10 flex items-center justify-center">
              {isFetchingNextPage && (
                <p className="text-xs text-gray-400">Loading more...</p>
              )}
            </div>
          </>
        )}
      </div>
    </PageLayout>
  )
}

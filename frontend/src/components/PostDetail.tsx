import { useParams, useNavigate } from 'react-router-dom'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PostType } from '../types/posts'
import type { Post } from '../types/posts'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'

async function fetchPost(id: number): Promise<Post> {
  const response = await fetch(API_ENDPOINTS.posts.byId(id), {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch post')
  }

  return response.json()
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

async function deletePost(postId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.byId(postId), {
    method: 'DELETE',
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to delete post')
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

export function PostDetail() {
  const { id } = useParams<{ id: string }>()
  const navigate = useNavigate()
  const queryClient = useQueryClient()

  const { data: currentUser, isError: userError, error: userQueryError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: post, isLoading, isError } = useQuery({
    queryKey: ['post', id],
    queryFn: () => fetchPost(Number(id)),
    enabled: !!id && !isNaN(Number(id))
  })

  const voteMutation = useMutation({
    mutationFn: ({ postId, value }: { postId: number; value: number }) => 
      votePost(postId, value),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['post', id] })
      queryClient.invalidateQueries({ queryKey: ['posts'] })
    }
  })

  const deleteMutation = useMutation({
    mutationFn: deletePost,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      navigate('/posts')
    }
  })

  useAuthErrorHandler(userError, userQueryError)

  const handleVote = (currentVote: number | undefined, newValue: number) => {
    if (!currentUser || !id) return
    const value = currentVote === newValue ? 0 : newValue
    voteMutation.mutate({ postId: Number(id), value })
  }

  const handleDelete = () => {
    if (!id) return
    if (window.confirm('Are you sure you want to delete this post? This action cannot be undone.')) {
      deleteMutation.mutate(Number(id))
    }
  }

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString('en-US', {
      year: 'numeric',
      month: 'long',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    })
  }

  if (isLoading) {
    return (
      <PageLayout>
        <div className="flex items-center justify-center py-20">
          <p className="text-sm text-gray-400 tracking-wide uppercase">Loading...</p>
        </div>
      </PageLayout>
    )
  }

  if (isError || !post) {
    return (
      <PageLayout>
        <div className="max-w-3xl">
          <h2 className="text-xl font-semibold text-gray-900 mb-2">Not Found</h2>
          <p className="text-sm text-gray-500 mb-4">This post doesn't exist or has been removed.</p>
          <button onClick={() => navigate('/posts')} className="text-sm text-gray-400 hover:text-gray-600 underline">
            Back to posts
          </button>
        </div>
      </PageLayout>
    )
  }

  return (
    <PageLayout>
      <div className="max-w-3xl">
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

        <div className="flex gap-6">
            {/* Vote buttons */}
            <div className="flex flex-col items-center gap-2 pt-2">
              <button
                onClick={() => handleVote(post.currentUserVote, 1)}
                disabled={!currentUser}
                aria-label="Upvote"
                className={`p-2 rounded hover:bg-gray-100 transition-colors ${
                  post.currentUserVote === 1 ? 'text-orange-600' : 'text-gray-400'
                } ${!currentUser ? 'cursor-not-allowed opacity-50' : ''}`}
              >
                <svg className="w-8 h-8" fill="currentColor" viewBox="0 0 20 20">
                  <path d="M5.293 9.707a1 1 0 010-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 01-1.414 1.414L11 7.414V15a1 1 0 11-2 0V7.414L6.707 9.707a1 1 0 01-1.414 0z" />
                </svg>
              </button>
              <span className={`text-xl font-bold ${
                post.score > 0 ? 'text-orange-600' : post.score < 0 ? 'text-blue-600' : 'text-gray-600'
              }`}>
                {post.score}
              </span>
              <button
                onClick={() => handleVote(post.currentUserVote, -1)}
                disabled={!currentUser}
                aria-label="Downvote"
                className={`p-2 rounded hover:bg-gray-100 transition-colors ${
                  post.currentUserVote === -1 ? 'text-blue-600' : 'text-gray-400'
                } ${!currentUser ? 'cursor-not-allowed opacity-50' : ''}`}
              >
                <svg className="w-8 h-8" fill="currentColor" viewBox="0 0 20 20">
                  <path d="M14.707 10.293a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 111.414-1.414L9 12.586V5a1 1 0 012 0v7.586l2.293-2.293a1 1 0 011.414 0z" />
                </svg>
              </button>
            </div>

            {/* Post content */}
            <div className="flex-1 min-w-0">
              <div className="flex items-center gap-2 mb-4 flex-wrap">
                <span className={`text-sm font-medium px-3 py-1 rounded ${
                  POST_TYPE_COLORS[post.type as PostType] ?? 'bg-gray-100 text-gray-800'
                }`}>
                  {POST_TYPE_LABELS[post.type as PostType] ?? 'Other'}
                </span>
                {post.activityTitle && (
                  <span className="text-sm text-gray-600">
                    in {post.activityTitle}
                  </span>
                )}
              </div>

              <h1 className="text-3xl font-bold text-gray-900 mb-4">{post.title}</h1>

              <div className="flex items-center gap-4 text-sm text-gray-500 mb-6 pb-6 border-b">
                <span>Posted by {post.userName || 'Anonymous'}</span>
                <span>•</span>
                <span>{formatDate(post.createdAt)}</span>
              </div>

              <div className="prose max-w-none mb-6">
                <p className="text-gray-700 whitespace-pre-wrap">{post.content}</p>
              </div>

              {/* Additional details */}
              {(post.locationName || post.rating || post.durationMinutes || post.cost) && (
                <div className="bg-gray-50 rounded-lg p-6 mb-6">
                  <h3 className="text-lg font-semibold text-gray-900 mb-4">Details</h3>
                  <div className="space-y-3">
                    {post.locationName && (
                      <div className="flex items-start gap-2">
                        <svg className="w-5 h-5 text-gray-500 mt-0.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" />
                        </svg>
                        <div>
                          <div className="text-sm font-medium text-gray-700">Location</div>
                          <div className="text-sm text-gray-600">{post.locationName}</div>
                        </div>
                      </div>
                    )}

                    {post.rating && (
                      <div className="flex items-start gap-2">
                        <svg className="w-5 h-5 text-gray-500 mt-0.5" fill="currentColor" viewBox="0 0 20 20">
                          <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                        </svg>
                        <div>
                          <div className="text-sm font-medium text-gray-700">Rating</div>
                          <div className="flex items-center gap-1">
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
                        </div>
                      </div>
                    )}

                    {post.durationMinutes && (
                      <div className="flex items-start gap-2">
                        <svg className="w-5 h-5 text-gray-500 mt-0.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" />
                        </svg>
                        <div>
                          <div className="text-sm font-medium text-gray-700">Duration</div>
                          <div className="text-sm text-gray-600">
                            {post.durationMinutes < 60 
                              ? `${post.durationMinutes} minutes` 
                              : `${Math.floor(post.durationMinutes / 60)}h ${post.durationMinutes % 60}m`}
                          </div>
                        </div>
                      </div>
                    )}

                    {post.cost && (
                      <div className="flex items-start gap-2">
                        <svg className="w-5 h-5 text-gray-500 mt-0.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                        </svg>
                        <div>
                          <div className="text-sm font-medium text-gray-700">Cost</div>
                          <div className="text-sm text-gray-600">
                            {post.currencyCode} {post.cost.toFixed(2)}
                          </div>
                        </div>
                      </div>
                    )}
                  </div>
                </div>
              )}

              {/* Action buttons for post owner */}
              {currentUser && currentUser.userId === post.userId && (
                <div className="pt-6 border-t">
                  <button
                    onClick={handleDelete}
                    disabled={deleteMutation.isPending}
                    className="text-xs font-medium text-gray-400 hover:text-red-500 transition-colors"
                  >
                    {deleteMutation.isPending ? 'Deleting...' : 'Delete this post'}
                  </button>
                  {deleteMutation.isError && (
                    <p className="text-xs text-red-500 mt-2">
                      {deleteMutation.error?.message || 'Failed to delete post'}
                    </p>
                  )}
                </div>
              )}
            </div>
          </div>
        </div>
    </PageLayout>
  )
}

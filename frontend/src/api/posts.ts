import { BookOpen, HelpCircle, Map, Target, ThumbsUp, Trophy } from 'lucide-react'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PAGINATION } from '../config/constants'
import { ensureResponseOk, sendVoteRequest } from '../lib/utils/http'
import { PostType } from '../types/posts'
import type { CreatePostRequest, Post, ScrollResult } from '../types/posts'

export interface FetchPostsParams {
  cursor: number | null
  communityId?: number
  userId?: number
  type?: number
  sortBy?: string
}

export async function fetchPosts(
  { cursor, communityId, userId, type, sortBy }: FetchPostsParams
): Promise<ScrollResult<Post>> {
  const params = new URLSearchParams({ limit: PAGINATION.DEFAULT_PAGE_SIZE.toString() })
  if (cursor !== null) params.append('cursor', cursor.toString())
  if (communityId) params.append('communityId', communityId.toString())
  if (userId) params.append('userId', userId.toString())
  if (type) params.append('type', type.toString())
  if (sortBy) params.append('sortBy', sortBy)
  const response = await fetch(`${API_ENDPOINTS.posts.base}?${params}`, { headers: getAuthHeaders() })
  await ensureResponseOk(response, 'Failed to fetch posts')
  return response.json()
}

export async function fetchPost(id: number): Promise<Post> {
  const response = await fetch(API_ENDPOINTS.posts.byId(id), { headers: getAuthHeaders() })
  await ensureResponseOk(response, 'Failed to fetch post')
  return response.json()
}

export async function createPost(data: CreatePostRequest): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.base, {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(data)
  })

  await ensureResponseOk(response, 'Failed to create post')
}

export async function votePost(postId: number, value: number): Promise<void> {
  await sendVoteRequest(
    API_ENDPOINTS.posts.vote(postId),
    { ...getAuthHeaders(), 'Content-Type': 'application/json' },
    value,
    'Failed to vote on post'
  )
}

export async function deletePost(postId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.byId(postId), {
    method: 'DELETE',
    headers: getAuthHeaders(),
  })
  await ensureResponseOk(response, 'Failed to delete post')
}

export const POST_TYPE_LABELS: Record<PostType, string> = {
  [PostType.ExperienceShare]: 'Experience',
  [PostType.Guide]: 'Guide',
  [PostType.Question]: 'Question',
  [PostType.Recommendation]: 'Recommendation',
  [PostType.Achievement]: 'Achievement',
  [PostType.Challenge]: 'Challenge'
}

export const POST_TYPE_COLORS: Record<PostType, { bg: string; text: string, border: string }> = {
  [PostType.ExperienceShare]: { bg: 'bg-blue-50', text: 'text-blue-700', border: 'border-blue-200' },
  [PostType.Guide]:           { bg: 'bg-emerald-50', text: 'text-emerald-700', border: 'border-emerald-200' },
  [PostType.Question]:        { bg: 'bg-amber-50', text: 'text-amber-700', border: 'border-amber-200' },
  [PostType.Recommendation]:  { bg: 'bg-purple-50', text: 'text-purple-700', border: 'border-purple-200' },
  [PostType.Achievement]:     { bg: 'bg-rose-50', text: 'text-rose-700', border: 'border-rose-200' },
  [PostType.Challenge]:       { bg: 'bg-red-50', text: 'text-red-700', border: 'border-red-200' },
}

export const POST_TYPE_ICONS: Record<PostType, typeof BookOpen> = {
  [PostType.ExperienceShare]: BookOpen,
  [PostType.Guide]: Map,
  [PostType.Question]: HelpCircle,
  [PostType.Recommendation]: ThumbsUp,
  [PostType.Achievement]: Trophy,
  [PostType.Challenge]: Target,
}

import { API_ENDPOINTS, getAuthHeaders } from '../../config/api'
import type { Comment } from '../../types/posts'

export async function fetchComments(postId: number): Promise<Comment[]> {
  const response = await fetch(API_ENDPOINTS.posts.comments(postId), { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch comments')
  return response.json()
}

export async function createComment(postId: number, content: string, photoUrl?: string, parentCommentId?: number): Promise<Comment> {
  const body: Record<string, unknown> = {}
  if (content.trim()) body.content = content.trim()
  if (photoUrl) body.photoUrl = photoUrl
  if (parentCommentId !== undefined) body.parentCommentId = parentCommentId

  const response = await fetch(API_ENDPOINTS.posts.comments(postId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(body),
  })
  if (!response.ok) throw new Error('Failed to create comment')
  return response.json()
}

export async function deleteComment(postId: number, commentId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.commentById(postId, commentId), {
    method: 'DELETE', headers: getAuthHeaders(),
  })
  if (!response.ok) throw new Error('Failed to delete comment')
}

export async function voteComment(postId: number, commentId: number, value: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.commentVote(postId, commentId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify({ value }),
  })
  if (!response.ok) throw new Error('Failed to vote on comment')
}

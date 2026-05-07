import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { ensureResponseOk, sendVoteRequest } from '../lib/utils/http'
import type { Comment } from '../types/posts'

export interface CreateCommentParams {
  postId: number
  content?: string
  photoUrl?: string
  parentCommentId?: number
}

export interface UpdateCommentParams {
  postId: number
  commentId: number
  content?: string
  photoUrl?: string
}

export async function fetchComments(postId: number): Promise<Comment[]> {
  const response = await fetch(API_ENDPOINTS.posts.comments(postId), { headers: getAuthHeaders() })
  await ensureResponseOk(response, 'Failed to fetch comments')
  return response.json()
}

export async function createComment({
  postId,
  content,
  photoUrl,
  parentCommentId,
}: CreateCommentParams): Promise<Comment> {
  const body: Record<string, unknown> = {}
  if (content?.trim()) body.content = content.trim()
  if (photoUrl) body.photoUrl = photoUrl
  if (parentCommentId !== undefined) body.parentCommentId = parentCommentId

  const response = await fetch(API_ENDPOINTS.posts.comments(postId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(body),
  })
  await ensureResponseOk(response, 'Failed to create comment')
  return response.json()
}

export async function deleteComment(postId: number, commentId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.commentById(postId, commentId), {
    method: 'DELETE', headers: getAuthHeaders(),
  })
  await ensureResponseOk(response, 'Failed to delete comment')
}

export async function updateComment({
  postId,
  commentId,
  content,
  photoUrl,
}: UpdateCommentParams): Promise<Comment> {
  const body: Record<string, unknown> = {}
  if (content?.trim()) body.content = content.trim()
  if (photoUrl !== undefined) body.photoUrl = photoUrl

  const response = await fetch(API_ENDPOINTS.posts.commentById(postId, commentId), {
    method: 'PUT',
    headers: getAuthHeaders(),
    body: JSON.stringify(body),
  })

  await ensureResponseOk(response, 'Failed to update comment')
  return response.json()
}

export async function voteComment(postId: number, commentId: number, value: number): Promise<void> {
  await sendVoteRequest(
    API_ENDPOINTS.posts.commentVote(postId, commentId),
    getAuthHeaders(),
    value,
    'Failed to vote on comment'
  )
}

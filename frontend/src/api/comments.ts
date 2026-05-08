import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { ensureResponseOk, sendVoteRequest } from '../lib/utils/http'
import type { Comment } from '../types/posts'

export type CommentTarget = 'posts' | 'places'

function getCommentRoutes(target: CommentTarget) {
  return target === 'posts' ? API_ENDPOINTS.posts : API_ENDPOINTS.places
}

export interface CreateCommentParams {
  target: CommentTarget
  entityId: number
  content?: string
  photoUrl?: string
  parentCommentId?: number
}

export interface UpdateCommentParams {
  target: CommentTarget
  entityId: number
  commentId: number
  content?: string
  photoUrl?: string
}

export async function fetchComments(target: CommentTarget, entityId: number): Promise<Comment[]> {
  const response = await fetch(getCommentRoutes(target).comments(entityId), { headers: getAuthHeaders() })
  await ensureResponseOk(response, 'Failed to fetch comments')
  return response.json()
}

export async function createComment({
  target,
  entityId,
  content,
  photoUrl,
  parentCommentId,
}: CreateCommentParams): Promise<Comment> {
  const body: Record<string, unknown> = {}
  if (content?.trim()) body.content = content.trim()
  if (photoUrl) body.photoUrl = photoUrl
  if (parentCommentId !== undefined) body.parentCommentId = parentCommentId

  const response = await fetch(getCommentRoutes(target).comments(entityId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(body),
  })
  await ensureResponseOk(response, 'Failed to create comment')
  return response.json()
}

export async function deleteComment(target: CommentTarget, entityId: number, commentId: number): Promise<void> {
  const response = await fetch(getCommentRoutes(target).commentById(entityId, commentId), {
    method: 'DELETE', headers: getAuthHeaders(),
  })
  await ensureResponseOk(response, 'Failed to delete comment')
}

export async function updateComment({
  target,
  entityId,
  commentId,
  content,
  photoUrl,
}: UpdateCommentParams): Promise<Comment> {
  const body: Record<string, unknown> = {}
  if (content?.trim()) body.content = content.trim()
  if (photoUrl !== undefined) body.photoUrl = photoUrl

  const response = await fetch(getCommentRoutes(target).commentById(entityId, commentId), {
    method: 'PUT',
    headers: getAuthHeaders(),
    body: JSON.stringify(body),
  })

  await ensureResponseOk(response, 'Failed to update comment')
  return response.json()
}

export async function voteComment(target: CommentTarget, entityId: number, commentId: number, value: number): Promise<void> {
  await sendVoteRequest(
    getCommentRoutes(target).commentVote(entityId, commentId),
    getAuthHeaders(),
    value,
    'Failed to vote on comment'
  )
}

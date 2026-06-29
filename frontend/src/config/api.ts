import { getAuthToken } from '../lib/authToken'

// Centralized API configuration
const API_BASE_URL = import.meta.env.VITE_API_URL || 'http://localhost:5207';

export const API_ENDPOINTS = {
  users: {
    googleLogin: `${API_BASE_URL}/api/users/google-login`,
    me: `${API_BASE_URL}/api/users/me`,
  },
  communities: {
    base: `${API_BASE_URL}/api/communities`,
  },
  places: {
    base: `${API_BASE_URL}/api/places`,
    byId: (id: number) => `${API_BASE_URL}/api/places/${id}`,
    vote: (id: number) => `${API_BASE_URL}/api/places/${id}/vote`,
    comments: (placeId: number) => `${API_BASE_URL}/api/places/${placeId}/comments`,
    commentById: (placeId: number, commentId: number) => `${API_BASE_URL}/api/places/${placeId}/comments/${commentId}`,
    commentVote: (placeId: number, commentId: number) => `${API_BASE_URL}/api/places/${placeId}/comments/${commentId}/vote`,
  },
  posts: {
    base: `${API_BASE_URL}/api/posts`,
    byId: (id: number) => `${API_BASE_URL}/api/posts/${id}`,
    vote: (id: number) => `${API_BASE_URL}/api/posts/${id}/vote`,
    comments: (postId: number) => `${API_BASE_URL}/api/posts/${postId}/comments`,
    commentById: (postId: number, commentId: number) => `${API_BASE_URL}/api/posts/${postId}/comments/${commentId}`,
    commentVote: (postId: number, commentId: number) => `${API_BASE_URL}/api/posts/${postId}/comments/${commentId}/vote`,
  },
  uploads: {
      presign: `${API_BASE_URL}/api/uploads/presign`,
    }
} as const;

export function getAuthHeaders(): HeadersInit {
  const token = getAuthToken();
  return {
    'Content-Type': 'application/json',
    ...(token && { Authorization: `Bearer ${token}` }),
  };
}

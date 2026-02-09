// Centralized API configuration
const API_BASE_URL = import.meta.env.VITE_API_URL || 'http://localhost:5207';

export const API_ENDPOINTS = {
  users: {
    register: `${API_BASE_URL}/api/users/register`,
    login: `${API_BASE_URL}/api/users/login`,
    googleLogin: `${API_BASE_URL}/api/users/google-login`,
    me: `${API_BASE_URL}/api/users/me`,
    setPassword: `${API_BASE_URL}/api/users/set-password`,
    changePassword: `${API_BASE_URL}/api/users/change-password`,
  },
  activities: {
    base: `${API_BASE_URL}/api/activities`,
    byId: (id: number) => `${API_BASE_URL}/api/activities/${id}`,
  },
  categories: {
    base: `${API_BASE_URL}/api/categories`,
    byId: (id: number) => `${API_BASE_URL}/api/categories/${id}`,
  },
  tags: {
    base: `${API_BASE_URL}/api/tags`,
    byId: (id: number) => `${API_BASE_URL}/api/tags/${id}`,
  },
  schedules: {
    base: `${API_BASE_URL}/api/useractivities`,
    planned: `${API_BASE_URL}/api/useractivities/planned`,
    completed: `${API_BASE_URL}/api/useractivities/completed`,
    history: `${API_BASE_URL}/api/useractivities/history`,
    byId: (id: number) => `${API_BASE_URL}/api/useractivities/${id}`,
    complete: (id: number) => `${API_BASE_URL}/api/useractivities/${id}/complete`,
    cancel: (id: number) => `${API_BASE_URL}/api/useractivities/${id}/cancel`,
  },
  posts: {
    base: `${API_BASE_URL}/api/posts`,
    byId: (id: number) => `${API_BASE_URL}/api/posts/${id}`,
    vote: (id: number) => `${API_BASE_URL}/api/posts/${id}/vote`,
    comments: (postId: number) => `${API_BASE_URL}/api/posts/${postId}/comments`,
    commentById: (postId: number, commentId: number) => `${API_BASE_URL}/api/posts/${postId}/comments/${commentId}`,
    commentVote: (postId: number, commentId: number) => `${API_BASE_URL}/api/posts/${postId}/comments/${commentId}/vote`,
  },
} as const;

export function getAuthHeaders(): HeadersInit {
  const token = localStorage.getItem('token');
  return {
    'Content-Type': 'application/json',
    ...(token && { Authorization: `Bearer ${token}` }),
  };
}

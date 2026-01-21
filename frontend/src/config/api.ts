// Centralized API configuration
const API_BASE_URL = import.meta.env.VITE_API_URL || 'http://localhost:5207';

export const API_ENDPOINTS = {
  users: {
    register: `${API_BASE_URL}/api/users/register`,
    login: `${API_BASE_URL}/api/users/login`,
    me: `${API_BASE_URL}/api/users/me`,
    list: `${API_BASE_URL}/api/users`,
  },
  activities: {
    base: `${API_BASE_URL}/api/activities`,
    byId: (id: number) => `${API_BASE_URL}/api/activities/${id}`,
    approve: (id: number) => `${API_BASE_URL}/api/activities/${id}/approve`,
    reject: (id: number) => `${API_BASE_URL}/api/activities/${id}/reject`,
  },
  categories: {
    base: `${API_BASE_URL}/api/categories`,
    byId: (id: number) => `${API_BASE_URL}/api/categories/${id}`,
  },
  tags: {
    base: `${API_BASE_URL}/api/tags`,
    byId: (id: number) => `${API_BASE_URL}/api/tags/${id}`,
  },
} as const;

export function getAuthHeaders(): HeadersInit {
  const token = localStorage.getItem('token');
  return {
    'Content-Type': 'application/json',
    ...(token && { Authorization: `Bearer ${token}` }),
  };
}

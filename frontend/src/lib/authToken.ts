const AUTH_TOKEN_KEY = 'token'

export function getAuthToken(): string | null {
  return localStorage.getItem(AUTH_TOKEN_KEY)
}

export function hasAuthToken(): boolean {
  return getAuthToken() !== null
}

export function setAuthTokenStorage(token: string): void {
  localStorage.setItem(AUTH_TOKEN_KEY, token)
}

export function clearAuthTokenStorage(): void {
  localStorage.removeItem(AUTH_TOKEN_KEY)
}

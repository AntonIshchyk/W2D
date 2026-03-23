import { useEffect, useMemo, useState } from 'react'
import { useMutation, useQuery } from '@tanstack/react-query'
import { Navigate, useNavigate } from 'react-router-dom'
import { toast } from 'sonner'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { setAuthToken } from '../hooks/useAuthSync'

interface GoogleProfileDefaults {
  name?: string
  picture?: string
}

interface LoginResponse {
  token: string
}

const ONBOARDING_PENDING_KEY = 'onboarding_pending'
const GOOGLE_DEFAULTS_KEY = 'google_profile_defaults'

function createUsernameSuggestion(input: string): string {
  const normalized = input
    .toLowerCase()
    .replace(/[^a-z0-9_\s]/g, '')
    .trim()
    .replace(/\s+/g, '_')

  return normalized.slice(0, 20)
}

function buildGoogleSuggestion(googleName: string | undefined, email: string, currentUsername: string): string {
  const emailSeed = email.split('@')[0]

  const fromGoogle = createUsernameSuggestion(googleName ?? '')
  if (fromGoogle.length >= 3) {
    return fromGoogle
  }

  const fromEmail = createUsernameSuggestion(emailSeed)
  if (fromEmail.length >= 3) {
    return fromEmail
  }

  return currentUsername || 'user123'
}

export function Onboarding() {
  const navigate = useNavigate()
  const [googleDefaults, setGoogleDefaults] = useState<GoogleProfileDefaults>({})
  const [username, setUsername] = useState('')
  const [bio, setBio] = useState('')
  const [profilePhotoUrl, setProfilePhotoUrl] = useState('')

  const { data: currentUser, isLoading: isUserLoading, isError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false,
  })

  useEffect(() => {
    const rawDefaults = sessionStorage.getItem(GOOGLE_DEFAULTS_KEY)
    if (!rawDefaults) {
      return
    }

    try {
      const defaults = JSON.parse(rawDefaults) as GoogleProfileDefaults
      setGoogleDefaults(defaults)
    } catch {
      setGoogleDefaults({})
    }
  }, [])

  useEffect(() => {
    if (!currentUser) {
      return
    }

    setUsername(currentUser.username ?? '')
    setBio(currentUser.bio ?? '')
    setProfilePhotoUrl(currentUser.profilePhotoUrl ?? googleDefaults.picture ?? '')

    if (!currentUser.onboardingCompleted) {
      localStorage.setItem(ONBOARDING_PENDING_KEY, '1')
    }
  }, [currentUser, googleDefaults.picture])

  const usernameError = useMemo(() => {
    if (!username) {
      return 'Username is required.'
    }
    if (!/^[a-z0-9_]{3,20}$/.test(username)) {
      return 'Use 3-20 chars: lowercase letters, numbers, underscore.'
    }
    return null
  }, [username])

  const completeMutation = useMutation({
    mutationFn: async () => {
      const response = await fetch(API_ENDPOINTS.users.onboarding, {
        method: 'PUT',
        headers: getAuthHeaders(),
        body: JSON.stringify({
          username,
          bio,
          profilePhotoUrl,
        }),
      })

      if (!response.ok) {
        let message = 'Failed to complete onboarding'
        try {
          const body = await response.json() as { message?: string }
          message = body.message ?? message
        } catch {
          // Ignore parsing errors and show fallback message.
        }
        throw new Error(message)
      }

      return await response.json() as LoginResponse
    },
    onSuccess: (data) => {
      setAuthToken(data.token)
      localStorage.removeItem(ONBOARDING_PENDING_KEY)
      sessionStorage.removeItem(GOOGLE_DEFAULTS_KEY)
      toast.success('Profile is ready!')
      navigate('/')
    },
    onError: (error: Error) => {
      toast.error(error.message)
    },
  })

  if (isUserLoading) {
    return (
      <div className="min-h-screen bg-stone-100 flex items-center justify-center">
        <p className="text-sm text-stone-500">Preparing onboarding...</p>
      </div>
    )
  }

  if (isError || !currentUser) {
    return <Navigate to="/login" replace />
  }

  if (currentUser.onboardingCompleted) {
    localStorage.removeItem(ONBOARDING_PENDING_KEY)
    return <Navigate to="/" replace />
  }

  return (
    <div className="min-h-screen bg-linear-to-br from-stone-100 via-white to-amber-50 px-4 py-8 md:py-12">
      <div className="mx-auto grid max-w-5xl gap-8 lg:grid-cols-2">
        <section className="rounded-3xl border border-stone-200 bg-white p-6 md:p-8 shadow-sm">
          <p className="text-xs font-semibold tracking-[0.2em] uppercase text-stone-400">Onboarding</p>
          <h1 className="mt-2 text-3xl font-black tracking-tight text-stone-900">Set up your profile</h1>
          <p className="mt-2 text-sm text-stone-500">
            Pick your username and add a short bio.
          </p>

          <div className="mt-8 space-y-5">
            <div>
              <div className="flex items-center justify-between gap-3">
                <label className="block text-xs font-semibold tracking-wide uppercase text-stone-500">Username</label>
                <button
                  type="button"
                  onClick={() => {
                    const suggestion = buildGoogleSuggestion(
                      googleDefaults.name,
                      currentUser.email,
                      currentUser.username,
                    )

                    if (suggestion === username) {
                      toast.info('You are already using that suggestion.')
                      return
                    }

                    setUsername(suggestion)
                    toast.success(`Suggested @${suggestion}`)
                  }}
                  className="rounded-xl border border-stone-300 px-3 py-1.5 text-xs font-semibold text-stone-700 hover:bg-stone-100"
                >
                  Use Google suggestion
                </button>
              </div>
              <input
                value={username}
                onChange={(e) => setUsername(e.target.value.toLowerCase().replace(/[^a-z0-9_]/g, '').slice(0, 20))}
                placeholder="your_handle"
                className="mt-2 w-full rounded-xl border border-stone-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-stone-800"
              />
              <p className="mt-1 text-xs text-stone-500">This becomes your public handle.</p>
              {usernameError && <p className="mt-1 text-xs text-rose-600">{usernameError}</p>}
            </div>

            <div>
              <label className="block text-xs font-semibold tracking-wide uppercase text-stone-500">Bio</label>
              <textarea
                value={bio}
                onChange={(e) => setBio(e.target.value.slice(0, 160))}
                rows={4}
                placeholder="Tell the community what you like doing..."
                className="mt-2 w-full rounded-xl border border-stone-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-stone-800"
              />
              <p className="mt-1 text-right text-xs text-stone-400">{bio.length}/160</p>
            </div>

            <div>
              <label className="block text-xs font-semibold tracking-wide uppercase text-stone-500">Profile photo URL</label>
              <input
                value={profilePhotoUrl}
                onChange={(e) => setProfilePhotoUrl(e.target.value.slice(0, 500))}
                placeholder="https://..."
                className="mt-2 w-full rounded-xl border border-stone-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-stone-800"
              />
            </div>

            <button
              type="button"
              disabled={completeMutation.isPending || !!usernameError}
              onClick={() => completeMutation.mutate()}
              className="w-full rounded-xl bg-stone-900 px-4 py-3 text-sm font-semibold text-white transition hover:bg-stone-800 disabled:cursor-not-allowed disabled:bg-stone-300"
            >
              {completeMutation.isPending ? 'Saving...' : 'Finish onboarding'}
            </button>
          </div>
        </section>

        <section className="rounded-3xl border border-stone-200 bg-white p-6 md:p-8 shadow-sm">
          <p className="text-xs font-semibold tracking-[0.2em] uppercase text-stone-400">Live preview</p>
          <div className="mt-6 rounded-2xl border border-stone-200 bg-stone-50 p-6">
            <div className="flex items-center gap-4">
              {profilePhotoUrl ? (
                <img
                  src={profilePhotoUrl}
                  alt="Profile preview"
                  className="h-16 w-16 rounded-full object-cover border border-stone-200"
                  onError={(e) => {
                    (e.currentTarget as HTMLImageElement).style.display = 'none'
                  }}
                />
              ) : (
                <div className="flex h-16 w-16 items-center justify-center rounded-full border border-stone-300 bg-white text-xl font-bold text-stone-500">
                  {(username.trim() || '?').charAt(0).toUpperCase()}
                </div>
              )}
              <div>
                <h2 className="text-lg font-bold text-stone-900">@{username || 'your_handle'}</h2>
              </div>
            </div>

            <p className="mt-4 text-sm leading-relaxed text-stone-700">
              {bio.trim() || 'Your bio will appear here so people can quickly understand what you are into.'}
            </p>
          </div>
        </section>
      </div>
    </div>
  )
}

import { useEffect, useState, useCallback } from 'react'
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { Navigate, useNavigate } from 'react-router-dom'
import { toast } from 'sonner'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { setAuthToken } from '../hooks/useAuthSync'
import { PhotoUpload } from './PhotoUpload'

interface LoginResponse {
  token: string
}

export function Onboarding() {
  const navigate = useNavigate()
  const queryClient = useQueryClient()

  // State grouped together
  const [profile, setProfile] = useState({
    username: '',
    bio: '',
    profilePhotoUrls: [] as string[],
  })

  const [submitError, setSubmitError] = useState<string | null>(null)

  const { data: currentUser, isLoading: isUserLoading, isError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false,
  })

  // Initialize state from user data
  useEffect(() => {
    if (!currentUser) return

    setProfile({
      username: currentUser.username ?? '',
      bio: currentUser.bio ?? '',
      profilePhotoUrls: currentUser.profilePhotoUrl ? [currentUser.profilePhotoUrl] : [],
    })
  }, [currentUser])

  const handleInputChange = useCallback(
    (field: keyof typeof profile, value: string | string[]) => {
      setProfile((prev) => ({ ...prev, [field]: value }))
    },
    []
  )

  // Mutation to complete onboarding
  const completeMutation = useMutation({
    mutationFn: async () => {
      const response = await fetch(API_ENDPOINTS.users.onboarding, {
        method: 'PUT',
        headers: getAuthHeaders(),
        body: JSON.stringify({
          username: profile.username,
          bio: profile.bio,
          profilePhotoUrl: profile.profilePhotoUrls[0] ?? null,
        }),
      })

      if (!response.ok) {
        const body = await response.json().catch(() => ({}))
        throw new Error(body.message ?? 'Failed to complete onboarding')
      }

      return response.json()
    },
    onSuccess: async (data) => {
      await queryClient.invalidateQueries({ queryKey: ['currentUser'] })
      setAuthToken(data.token)
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

  if (isError || !currentUser) return <Navigate to="/login" replace />
  if (currentUser.onboardingCompleted) {
    return <Navigate to="/" replace />
  }

  const handleSubmit = () => {
    // Reset previous submit error
    setSubmitError(null)

    // Validation only on submit
    const username = profile.username.trim()
    if (!username) {
      setSubmitError('Username is required.')
      return
    }
    if (!/^[A-Za-z0-9_]{3,20}$/.test(username)) {
      setSubmitError('Use 3-20 chars: letters, numbers, underscore.')
      return
    }

    // If validation passes, run mutation
    completeMutation.mutate()
  }

  return (
    <div className="min-h-screen bg-linear-to-br from-stone-100 via-white to-amber-50 px-4 py-8 md:py-12">
      <div className="mx-auto grid max-w-5xl gap-8 lg:grid-cols-2">
        {/* Form Section */}
        <section className="rounded-3xl border border-stone-200 bg-white p-6 md:p-8 shadow-sm">
          <p className="text-xs font-semibold tracking-[0.2em] uppercase text-stone-400">Onboarding</p>
          <h1 className="mt-2 text-3xl font-black tracking-tight text-stone-900">Set up your profile</h1>
          <p className="mt-2 text-sm text-stone-500">Pick your username and add a short bio.</p>

          <div className="mt-8 space-y-5">
            {/* Username */}
            <div>
              <label className="block text-xs font-semibold tracking-wide uppercase text-stone-500">Username</label>
              <input
                value={profile.username}
                onChange={(e) =>
                  handleInputChange('username', e.target.value.replace(/[^A-Za-z0-9_]/g, '').slice(0, 20))
                }
                placeholder="your_handle"
                className="mt-2 w-full rounded-xl border border-stone-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-stone-800"
              />
              {submitError && <p className="mt-1 text-xs text-rose-600">{submitError}</p>}
            </div>

            {/* Bio */}
            <div>
              <label className="block text-xs font-semibold tracking-wide uppercase text-stone-500">Bio</label>
              <textarea
                value={profile.bio}
                onChange={(e) => handleInputChange('bio', e.target.value.slice(0, 160))}
                rows={4}
                placeholder="Tell the community what you like doing..."
                className="mt-2 w-full rounded-xl border border-stone-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-stone-800"
              />
              <p className="mt-1 text-right text-xs text-stone-400">{profile.bio.length}/160</p>
            </div>

            {/* Profile Photo */}
            <div>
              <label className="block text-xs font-semibold tracking-wide uppercase text-stone-500">Profile photo</label>
              <div className="mt-2 rounded-xl border border-stone-300 p-3">
                <PhotoUpload
                  value={profile.profilePhotoUrls}
                  onChange={(urls) => handleInputChange('profilePhotoUrls', urls.slice(0, 1))}
                  maxPhotos={1}
                  disabled={completeMutation.isPending}
                />
              </div>
            </div>

            <button
              type="button"
              disabled={completeMutation.isPending}
              onClick={handleSubmit}
              className="w-full rounded-xl bg-stone-900 px-4 py-3 text-sm font-semibold text-white transition hover:bg-stone-800 disabled:cursor-not-allowed disabled:bg-stone-300"
            >
              {completeMutation.isPending ? 'Saving...' : 'Finish onboarding'}
            </button>
          </div>
        </section>

        {/* Preview Section */}
        <section className="rounded-3xl border border-stone-200 bg-white p-6 md:p-8 shadow-sm">
          <p className="text-xs font-semibold tracking-[0.2em] uppercase text-stone-400">Live preview</p>
          <div className="mt-6 rounded-2xl border border-stone-200 bg-stone-50 p-6">
            <div className="flex items-center gap-4">
              {profile.profilePhotoUrls[0] ? (
                <img
                  src={profile.profilePhotoUrls[0]}
                  alt="Profile preview"
                  className="h-16 w-16 rounded-full object-cover border border-stone-200"
                  onError={(e) => {
                    (e.currentTarget as HTMLImageElement).style.display = 'none'
                  }}
                />
              ) : (
                <div className="flex h-16 w-16 items-center justify-center rounded-full border border-stone-300 bg-white text-xl font-bold text-stone-500">
                  {(profile.username.trim() || '?').charAt(0).toUpperCase()}
                </div>
              )}
              <div>
                <h2 className="text-lg font-bold text-stone-900">@{profile.username || 'your_handle'}</h2>
              </div>
            </div>

            <p className="mt-4 text-sm leading-relaxed text-stone-700">
              {profile.bio.trim() || 'Your bio will appear here so people can quickly understand what you are into.'}
            </p>
          </div>
        </section>
      </div>
    </div>
  )
}

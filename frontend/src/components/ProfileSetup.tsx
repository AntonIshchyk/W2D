import { useEffect, useState, useCallback } from 'react'
import { useMutation, useQueryClient } from '@tanstack/react-query'
import { Navigate, useNavigate } from 'react-router-dom'
import { toast } from 'sonner'
import { setAuthToken } from '../hooks/useAuthSync'
import { AvatarUpload } from './AvatarUpload'
import { isValidImageUrl } from '../lib/utils/validation'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { updateCurrentUserProfile } from '../api/users'


export function ProfileSetup() {
  const navigate = useNavigate()
  const queryClient = useQueryClient()

  // State grouped together
  const [profile, setProfile] = useState({
    username: '',
    bio: '',
    profilePhotoUrls: [] as string[],
  })

  const [submitError, setSubmitError] = useState<string | null>(null)
  const [isInitialized, setIsInitialized] = useState(false)

  const { data: currentUser, isLoading: isUserLoading, isError } = useCurrentUser()

  // Initialize state from user data
  useEffect(() => {
    if (!currentUser || isInitialized) return

    setProfile({
      username: currentUser.profileSetupComplete ? (currentUser.username ?? '') : '',
      bio: currentUser.bio ?? '',
      profilePhotoUrls: currentUser.profilePhotoUrl && isValidImageUrl(currentUser.profilePhotoUrl) ? [currentUser.profilePhotoUrl] : [],
    })
    setIsInitialized(true)
  }, [currentUser, isInitialized])

  const handleInputChange = useCallback(
    (field: keyof typeof profile, value: string | string[]) => {
      setProfile((prev) => ({ ...prev, [field]: value }))
    },
    []
  )

  // Mutation to update user profile
  const completeMutation = useMutation({
    mutationFn: () => updateCurrentUserProfile({
      username: profile.username,
      bio: profile.bio,
      profilePhotoUrl: profile.profilePhotoUrls[0] ?? null,
    }),
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
        <p className="text-sm text-stone-500">Preparing profile setup...</p>
      </div>
    )
  }

  if (isError || !currentUser) return <Navigate to="/login" replace />
  if (currentUser.profileSetupComplete) {
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
    <div className="flex min-h-screen items-center justify-center bg-muted/30 px-4 py-12 sm:px-6 lg:px-8">
      <div className="w-full max-w-xl space-y-10 rounded-[2rem] bg-background p-10 shadow-sm ring-1 ring-border sm:p-14">
        
        {/* Header */}
        <div className="text-center">
          <h2 className="text-4xl font-black tracking-tight text-foreground">Complete your profile</h2>
          <p className="mt-3 text-base text-muted-foreground">Add a photo, pick a username, and write a short bio.</p>
        </div>

        <div className="mt-12 space-y-8">
          {/* Avatar Upload (Centered prominently at the top) */}
          <div className="flex flex-col items-center justify-center space-y-4 pb-4 pt-2">
            <AvatarUpload
              value={profile.profilePhotoUrls[0] || ''}
              onChange={(url) => handleInputChange('profilePhotoUrls', url ? [url] : [])}
              disabled={completeMutation.isPending}
            />
            <p className="text-sm font-bold uppercase tracking-widest text-foreground">Profile Photo (Optional)</p>
          </div>

          <div className="space-y-6">
            {/* Username */}
            <div>
              <label className="block text-sm font-bold tracking-wide uppercase text-foreground">Username *</label>
              <div className="relative mt-2.5">
                <div className="pointer-events-none absolute inset-y-0 left-0 flex items-center pl-4">
                  <span className="text-foreground font-medium sm:text-base">@</span>
                </div>
                <input
                  value={profile.username}
                  onChange={(e) =>
                    handleInputChange('username', e.target.value.replace(/[^A-Za-z0-9_]/g, '').slice(0, 20))
                  }
                  placeholder="your_handle"
                  className="block w-full rounded-2xl border border-input bg-background py-3.5 pl-10 pr-4 text-base text-foreground placeholder:text-muted-foreground focus:border-ring focus:outline-none focus:ring-1 focus:ring-ring"
                />
              </div>
              {submitError && <p className="mt-2 text-sm text-destructive">{submitError}</p>}
            </div>

            {/* Bio */}
            <div>
              <label className="block text-sm font-bold tracking-wide uppercase text-foreground">Bio (Optional)</label>
              <textarea
                value={profile.bio}
                onChange={(e) => handleInputChange('bio', e.target.value.slice(0, 160))}
                rows={4}
                placeholder="Tell us a little about yourself..."
                className="mt-2.5 block w-full rounded-2xl border border-input bg-background p-4 text-base text-foreground placeholder:text-muted-foreground focus:border-ring focus:outline-none focus:ring-1 focus:ring-ring"
              />
              <p className="mt-2 text-right text-sm font-medium text-muted-foreground">{profile.bio.length}/160</p>
            </div>
          </div>

          <div className="pt-4">
            <button
              type="button"
              disabled={completeMutation.isPending}
              onClick={handleSubmit}
              className="w-full rounded-2xl bg-primary px-6 py-4 text-base font-bold text-primary-foreground transition hover:opacity-90 disabled:cursor-not-allowed disabled:opacity-50"
            >
              {completeMutation.isPending ? 'Saving...' : 'Finish setup'}
            </button>
          </div>
        </div>
      </div>
    </div>
  )
}

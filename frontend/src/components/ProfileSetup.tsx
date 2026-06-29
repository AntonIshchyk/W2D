import { useEffect, useState, useCallback } from 'react'
import { useMutation, useQueryClient } from '@tanstack/react-query'
import { Navigate, useLocation, useNavigate } from 'react-router-dom'
import { toast } from 'sonner'
import { z } from 'zod'
import { setAuthToken } from '../hooks/useAuthSync'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { updateCurrentUserProfile } from '../api/users'

const profileSetupSchema = z.object({
  username: z
    .string()
    .trim()
    .min(1, 'Username is required.')
    .regex(/^[A-Za-z0-9_]{3,20}$/, 'Use 3-20 chars: letters, numbers, underscore.'),
  bio: z.string().max(160, 'Bio must be 160 characters or less.'),
})

type ProfileSetupErrors = Partial<Record<keyof z.infer<typeof profileSetupSchema>, string>>


export function ProfileSetup() {
  const navigate = useNavigate()
  const location = useLocation()
  const queryClient = useQueryClient()
  const redirectPath = (location.state as { from?: { pathname?: string } } | null)?.from?.pathname ?? '/'

  const [profile, setProfile] = useState({
    username: '',
    bio: '',
  })

  const [submitError, setSubmitError] = useState<string | null>(null)
  const [fieldErrors, setFieldErrors] = useState<ProfileSetupErrors>({})
  const [isInitialized, setIsInitialized] = useState(false)

  const { data: currentUser, isLoading: isUserLoading, isError } = useCurrentUser()

  useEffect(() => {
    if (!currentUser || isInitialized) return

    setProfile({
      username: currentUser.profileSetupComplete ? (currentUser.username ?? '') : '',
      bio: currentUser.bio ?? '',
    })
    setIsInitialized(true)
  }, [currentUser, isInitialized])

  const handleInputChange = useCallback(
    (field: keyof typeof profile, value: string | string[]) => {
      setProfile((prev) => ({ ...prev, [field]: value }))

      if (field === 'username' || field === 'bio') {
        setFieldErrors((prev) => ({ ...prev, [field]: undefined }))
      }
    },
    []
  )

  const completeMutation = useMutation({
    mutationFn: () => updateCurrentUserProfile({
      username: profile.username,
      bio: profile.bio,
    }),
    onSuccess: async (data) => {
      await queryClient.invalidateQueries({ queryKey: ['currentUser'] })
      setAuthToken(data.token)
      navigate(redirectPath)
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
    return <Navigate to={redirectPath} replace />
  }

  const handleSubmit = () => {
    setSubmitError(null)
    const parsed = profileSetupSchema.safeParse({
      username: profile.username,
      bio: profile.bio,
    })

    if (!parsed.success) {
      const errors = parsed.error.flatten().fieldErrors
      setFieldErrors({
        username: errors.username?.[0],
        bio: errors.bio?.[0],
      })
      return
    }

    setFieldErrors({})

    completeMutation.mutate()
  }

  return (
    <div className="flex min-h-screen items-center justify-center bg-muted/30 px-4 py-12 sm:px-6 lg:px-8">
      <div className="w-full max-w-xl space-y-10 rounded-[2rem] bg-background p-10 shadow-sm ring-1 ring-border sm:p-14">
        
        <div className="text-center">
          <h2 className="text-4xl font-black tracking-tight text-foreground">Complete your profile</h2>
        </div>

        <div className="mt-12 space-y-8">
          <div className="space-y-6">
            <div>
              <label className="block text-sm font-bold tracking-wide uppercase text-foreground">
                Username <span className="text-destructive">*</span>
              </label>
              <div className="relative mt-2.5">
                <input
                  value={profile.username}
                  onChange={(e) =>
                    handleInputChange('username', e.target.value.replace(/[^A-Za-z0-9_]/g, '').slice(0, 20))
                  }
                  placeholder="user_name"
                  className={[
                    'block w-full rounded-2xl border border-input bg-background py-3.5 pl-4 pr-4 text-base text-foreground placeholder:text-muted-foreground focus:border-ring focus:outline-none focus:ring-1 focus:ring-ring',
                    fieldErrors.username ? 'border-destructive focus:border-destructive focus:ring-destructive' : '',
                  ].join(' ')}
                />
              </div>
              {fieldErrors.username && <p className="mt-2 text-sm text-destructive">{fieldErrors.username}</p>}
              {!fieldErrors.username && submitError && <p className="mt-2 text-sm text-destructive">{submitError}</p>}
            </div>

            <div>
              <label className="block text-sm font-bold tracking-wide uppercase text-foreground">Bio (Optional)</label>
              <textarea
                value={profile.bio}
                onChange={(e) => handleInputChange('bio', e.target.value.slice(0, 160))}
                rows={4}
                placeholder="What are your interests? Share a bit about yourself!"
                className={[
                  'mt-2.5 block w-full rounded-2xl border border-input bg-background p-4 text-base text-foreground placeholder:text-muted-foreground focus:border-ring focus:outline-none focus:ring-1 focus:ring-ring',
                  fieldErrors.bio ? 'border-destructive focus:border-destructive focus:ring-destructive' : '',
                ].join(' ')}
              />
              {fieldErrors.bio && <p className="mt-2 text-sm text-destructive">{fieldErrors.bio}</p>}
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

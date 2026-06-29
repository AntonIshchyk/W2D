import { useEffect, useState } from 'react'
import { useMutation, useQueryClient } from '@tanstack/react-query'
import { Navigate, useNavigate } from 'react-router-dom'
import { z } from 'zod'
import { setAuthToken } from '../hooks/useAuthSync'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { updateCurrentUserProfile } from '../api/users'
import { PageLayout } from './Navbar'

const editProfileSchema = z.object({
  username: z
    .string()
    .trim()
    .regex(/^[A-Za-z0-9_]{3,20}$/, 'Use 3-20 chars: letters, numbers, underscore.'),
  bio: z.string().max(160, 'Bio must be 160 characters or less.'),
})

type EditProfileErrors = Partial<Record<keyof z.infer<typeof editProfileSchema>, string>>

export function EditProfile() {
  const navigate = useNavigate()
  const queryClient = useQueryClient()

  const [profile, setProfile] = useState({
    username: '',
    bio: '',
  })

  const [submitError, setSubmitError] = useState<string | null>(null)
  const [fieldErrors, setFieldErrors] = useState<EditProfileErrors>({})
  const [isInitialized, setIsInitialized] = useState(false)

  const { data: currentUser, isLoading: isUserLoading, isError } = useCurrentUser()

  useEffect(() => {
    if (!currentUser || isInitialized) return

    setProfile({
      username: currentUser.username ?? '',
      bio: currentUser.bio ?? '',
    })
    setIsInitialized(true)
  }, [currentUser, isInitialized])

  const handleInputChange = (field: keyof typeof profile, value: string | string[]) => {
    if (field === 'username') {
      const filtered = (value as string).replace(/[^A-Za-z0-9_]/g, '').slice(0, 20)
      setProfile((prev) => ({ ...prev, [field]: filtered }))
    } else if (field === 'bio') {
      const limited = (value as string).slice(0, 160)
      setProfile((prev) => ({ ...prev, [field]: limited }))
    }

    if (field === 'username' || field === 'bio') {
      setFieldErrors((prev) => ({ ...prev, [field]: undefined }))
    }
  }

  const updateMutation = useMutation({
    mutationFn: () => updateCurrentUserProfile({
      username: profile.username,
      bio: profile.bio,
    }),
    onSuccess: async (data) => {
      setAuthToken(data.token)
      await queryClient.invalidateQueries({ queryKey: ['currentUser'] })
      navigate('/profile')
    },
    onError: (error: Error) => {
      try {
        const errorData = JSON.parse(error.message)
        if (errorData.errors && typeof errorData.errors === 'object') {
          const validationErrors: EditProfileErrors = {}
          if (errorData.errors.Username) {
            validationErrors.username = errorData.errors.Username[0]
          }
          if (errorData.errors.Bio) {
            validationErrors.bio = errorData.errors.Bio[0]
          }
          if (Object.keys(validationErrors).length > 0) {
            setFieldErrors(validationErrors)
            setSubmitError(null)
          } else {
            setSubmitError(errorData.title || 'Failed to update profile')
          }
        } else {
          setSubmitError(error.message)
        }
      } catch {
        setSubmitError(error.message)
      }
    },
  })

  if (isUserLoading) {
    return (
      <PageLayout>
        <div className="flex items-center justify-center min-h-screen">
          <p className="text-sm text-muted-foreground">Loading profile...</p>
        </div>
      </PageLayout>
    )
  }

  if (isError || !currentUser) return <Navigate to="/login" replace />

  const handleSubmit = () => {
    setSubmitError(null)
    const parsed = editProfileSchema.safeParse({
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
    updateMutation.mutate()
  }

  return (
    <PageLayout>
      <div className="flex min-h-screen items-center justify-center px-4 py-12 sm:px-6 lg:px-8">
        <div className="w-full max-w-xl space-y-10 rounded-[2rem] bg-background p-10 shadow-sm ring-1 ring-border sm:p-14">
          <div className="text-center">
            <h2 className="text-4xl font-black tracking-tight text-foreground">Edit your profile</h2>
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
                    onChange={(e) => handleInputChange('username', e.target.value)}
                    placeholder="user_name"
                    className={[
                      'block w-full rounded-2xl border border-input bg-background py-3.5 pl-4 pr-4 text-base text-foreground placeholder:text-muted-foreground focus:border-ring focus:outline-none focus:ring-1 focus:ring-ring',
                      fieldErrors.username ? 'border-destructive focus:border-destructive focus:ring-destructive' : '',
                    ].join(' ')}
                    disabled={updateMutation.isPending}
                  />
                </div>
                {fieldErrors.username && <p className="mt-2 text-sm text-destructive">{fieldErrors.username}</p>}
                {!fieldErrors.username && submitError && <p className="mt-2 text-sm text-destructive">{submitError}</p>}
              </div>

              <div>
                <label className="block text-sm font-bold tracking-wide uppercase text-foreground">Bio (Optional)</label>
                <textarea
                  value={profile.bio}
                  onChange={(e) => handleInputChange('bio', e.target.value)}
                  rows={4}
                  placeholder="What are your interests? Share a bit about yourself!"
                  className={[
                    'mt-2.5 block w-full rounded-2xl border border-input bg-background p-4 text-base text-foreground placeholder:text-muted-foreground focus:border-ring focus:outline-none focus:ring-1 focus:ring-ring',
                    fieldErrors.bio ? 'border-destructive focus:border-destructive focus:ring-destructive' : '',
                  ].join(' ')}
                  disabled={updateMutation.isPending}
                />
                {fieldErrors.bio && <p className="mt-2 text-sm text-destructive">{fieldErrors.bio}</p>}
                <p className="mt-2 text-right text-sm font-medium text-muted-foreground">{profile.bio.length}/160</p>
              </div>
            </div>

            <div className="flex gap-3 pt-4">
              <button
                type="button"
                disabled={updateMutation.isPending}
                onClick={() => navigate('/profile')}
                className="flex-1 rounded-2xl border border-input bg-background px-6 py-4 text-base font-bold text-foreground transition hover:bg-muted disabled:cursor-not-allowed disabled:opacity-50"
              >
                Cancel
              </button>
              <button
                type="button"
                disabled={updateMutation.isPending}
                onClick={handleSubmit}
                className="flex-1 rounded-2xl bg-primary px-6 py-4 text-base font-bold text-primary-foreground transition hover:opacity-90 disabled:cursor-not-allowed disabled:opacity-50"
              >
                {updateMutation.isPending ? 'Saving...' : 'Save Changes'}
              </button>
            </div>
          </div>
        </div>
      </div>
    </PageLayout>
  )
}

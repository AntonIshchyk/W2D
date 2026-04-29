import { PageLayout } from './Navbar'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { Card, CardContent, CardHeader, CardTitle } from './ui/card'
import { Avatar, AvatarFallback, AvatarImage } from './ui/avatar'
import { Separator } from './ui/separator'
import { Skeleton } from './ui/skeleton'
import { isValidPhotoUrl } from '../lib/utils/validation'

export function Profile() {
  const { data: user, isLoading, isError, error: userError } = useCurrentUser()

  useAuthErrorHandler(isError, userError)

  if (isLoading) {
    return (
      <PageLayout>
        <div className="max-w-md mx-auto">
          <Card>
            <CardHeader>
              <Skeleton className="h-14 w-14 rounded-full" />
              <Skeleton className="h-5 w-32" />
              <Skeleton className="h-4 w-48" />
            </CardHeader>
          </Card>
        </div>
      </PageLayout>
    )
  }

  if (isError || !user) {
    return null
  }

  return (
    <PageLayout>
      <div className="max-w-md mx-auto">
        <Card className="overflow-hidden border-2">
          <div className="h-24 bg-linear-to-br from-primary via-primary/80 to-primary/60" />

          <CardHeader className="-mt-10 relative">
            <Avatar className="h-20 w-20 border-4 border-background shadow-lg">
              {user.profilePhotoUrl && isValidPhotoUrl(user.profilePhotoUrl) && <AvatarImage src={user.profilePhotoUrl} alt={user.username} />}
                <AvatarFallback className="bg-linear-to-br from-primary to-primary/70 text-primary-foreground text-2xl font-bold">
                {user.username.charAt(0).toUpperCase()}
              </AvatarFallback>
            </Avatar>
            <CardTitle className="text-xl pt-2">@{user.username}</CardTitle>
          </CardHeader>

          <CardContent>
            <Separator />
            {user.bio && <p className="mt-4 text-lg leading-relaxed">{user.bio}</p>}
          </CardContent>
        </Card>
      </div>
    </PageLayout>
  )
}

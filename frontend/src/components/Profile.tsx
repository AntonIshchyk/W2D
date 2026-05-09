import { PageLayout } from './Navbar'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { Card, CardContent, CardHeader, CardTitle } from './ui/card'
import { Avatar, AvatarFallback, AvatarImage } from './ui/avatar'
import { Separator } from './ui/separator'
import { Skeleton } from './ui/skeleton'
import { isValidPhotoUrl } from '../lib/utils/validation'
import { useState } from 'react'
import { Tabs, TabsList, TabsTrigger, TabsContent } from './ui/tabs'
import { useInfiniteQuery, useQuery } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { fetchPosts } from '../api/posts'
import { fetchPlaces } from '../api/places'
import { PostCard } from './PostCard'
import { PlaceCard } from './PlaceCard'
import { LoadingSpinner } from './ui/loading-spinner'
import { Button } from './ui/button'
import { usePostVoteMutation } from '../hooks/usePostVoteMutation'
import { Pencil, Trash2, Menu } from 'lucide-react'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogDescription, DialogFooter } from './ui/dialog'
import { deleteCurrentUserAccount } from '../api/users'
import { clearAuthToken } from '../hooks/useAuthSync'

export function Profile() {
  const { data: user, isLoading, isError, error: userError } = useCurrentUser()
  const navigate = useNavigate()

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

  const [tab, setTab] = useState<'all' | 'posts' | 'places'>('all')
  const [showDeleteConfirm, setShowDeleteConfirm] = useState(false)
  const [isDeleting, setIsDeleting] = useState(false)

  const handleEdit = () => {
    navigate('/profile/edit')
  }

  const handleDeleteClick = () => {
    setShowDeleteConfirm(true)
  }

  const confirmDelete = async () => {
    setIsDeleting(true)
    try {
      await deleteCurrentUserAccount()
      clearAuthToken()
      navigate('/login')
    } catch (error) {
      setIsDeleting(false)
    }
  }

  const postsQuery = useInfiniteQuery({
    queryKey: ['user-posts', user.userId],
    queryFn: ({ pageParam = null }) => fetchPosts({ cursor: pageParam, userId: user.userId, sortBy: 'new' }),
    getNextPageParam: (last) => last.hasMore ? last.nextCursor : undefined,
    initialPageParam: null as number | null,
  })

  const placesQuery = useQuery({
    queryKey: ['places', user.userId],
    queryFn: () => fetchPlaces(undefined, undefined, user.userId),
  })

  const { handlePostVote } = usePostVoteMutation(['user-posts', user.userId])

  const allPosts = postsQuery.data?.pages.flatMap(p => p.items) ?? []
  const userPlaces = placesQuery.data ?? []

  return (
    <PageLayout>
      <div className="max-w-7xl mx-auto px-6">
        <div className="grid grid-cols-[320px_minmax(0,1fr)] gap-6">
          <div>
            <Card className="overflow-hidden border-2">
              <CardHeader className="flex-row items-start justify-between gap-4">
                <div className="flex items-center gap-4">
                  <Avatar className="h-16 w-16 border-2 border-background">
                    {user.profilePhotoUrl && isValidPhotoUrl(user.profilePhotoUrl) && <AvatarImage src={user.profilePhotoUrl} alt={user.username} />}
                    <AvatarFallback className="bg-linear-to-br from-primary to-primary/70 text-primary-foreground text-lg font-bold">
                      {user.username.charAt(0).toUpperCase()}
                    </AvatarFallback>
                  </Avatar>
                  <CardTitle className="text-xl">{user.username}</CardTitle>
                </div>
                <Popover>
                  <PopoverTrigger asChild>
                    <Button 
                      variant="ghost" 
                      size="sm"
                      className="h-9 w-9 p-0"
                    >
                      <Menu className="w-4 h-4" />
                    </Button>
                  </PopoverTrigger>
                  <PopoverContent align="end" className="w-40 p-2">
                    <div className="flex flex-col gap-1">
                      <Button 
                        variant="ghost" 
                        className="justify-start gap-2 h-9"
                        onClick={handleEdit}
                      >
                        <Pencil className="w-4 h-4" />
                        Edit Profile
                      </Button>
                      <Button 
                        variant="ghost" 
                        className="justify-start gap-2 h-9 text-destructive hover:text-destructive hover:bg-destructive/10"
                        onClick={handleDeleteClick}
                      >
                        <Trash2 className="w-4 h-4" />
                        Delete Account
                      </Button>
                    </div>
                  </PopoverContent>
                </Popover>
              </CardHeader>

              <CardContent>
                <Separator />
                <p className="mt-4 text-lg leading-relaxed">
                  {user.bio || 'No bio yet.'}
                </p>
              </CardContent>
            </Card>
          </div>

          <div>
            <Tabs value={tab} onValueChange={(v) => setTab(v as any)}>
              <TabsList>
                <TabsTrigger value="all">All</TabsTrigger>
                <TabsTrigger value="posts">Posts ({allPosts.length})</TabsTrigger>
                <TabsTrigger value="places">Places ({userPlaces.length})</TabsTrigger>
              </TabsList>

              <TabsContent value="all">
                <div className="space-y-4">
                  {postsQuery.isLoading ? (
                    <LoadingSpinner />
                  ) : allPosts.length === 0 ? (
                    <p className="text-sm text-muted-foreground">Nothing here yet.</p>
                  ) : (
                    allPosts.map(p => (
                      <PostCard key={p.id} post={p} currentUser={user} onVote={handlePostVote} />
                    ))
                  )}

                  {postsQuery.hasNextPage && (
                    <div className="pt-4">
                      <Button onClick={() => postsQuery.fetchNextPage()}>{postsQuery.isFetchingNextPage ? 'Loading…' : 'Load more'}</Button>
                    </div>
                  )}
                </div>
              </TabsContent>

              <TabsContent value="posts">
                <div className="space-y-4">
                  {postsQuery.isLoading ? (
                    <LoadingSpinner />
                  ) : allPosts.length === 0 ? (
                    <p className="text-sm text-muted-foreground">No posts yet.</p>
                  ) : (
                    allPosts.map(p => (
                      <PostCard key={p.id} post={p} currentUser={user} onVote={handlePostVote} />
                    ))
                  )}
                </div>
              </TabsContent>

              <TabsContent value="places">
                <div className="space-y-4">
                  {placesQuery.isLoading ? <LoadingSpinner /> : userPlaces.length === 0 ? (
                    <p className="text-sm text-muted-foreground">No places yet.</p>
                  ) : (
                    userPlaces.map((pl: any) => (
                      <PlaceCard key={pl.id} place={pl} currentUser={user} className="group bg-card border border-border/50 rounded-3xl p-5" />
                    ))
                  )}
                </div>
              </TabsContent>
            </Tabs>
          </div>
          </div>
        </div>

        <Dialog open={showDeleteConfirm} onOpenChange={setShowDeleteConfirm}>
          <DialogContent className="[&>button]:hidden">
            <DialogHeader>
              <DialogTitle>Delete Account</DialogTitle>
              <DialogDescription>
                Are you sure you want to delete your account? This action cannot be undone and all your data will be permanently deleted.
              </DialogDescription>
            </DialogHeader>
            <DialogFooter>
              <Button 
                variant="outline" 
                onClick={() => setShowDeleteConfirm(false)}
                disabled={isDeleting}
              >
                Cancel
              </Button>
              <Button 
                variant="destructive" 
                onClick={confirmDelete}
                disabled={isDeleting}
              >
                {isDeleting ? 'Deleting...' : 'Delete Account'}
              </Button>
            </DialogFooter>
          </DialogContent>
        </Dialog>
    </PageLayout>
  )
}

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
import { fetchPosts } from '../api/posts'
import { fetchPlaces } from '../api/places'
import { PostCard } from './PostCard'
import { PlaceCard } from './PlaceCard'
import { LoadingSpinner } from './ui/loading-spinner'
import { Button } from './ui/button'

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

  const [tab, setTab] = useState<'all' | 'posts' | 'places'>('all')

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

  const allPosts = postsQuery.data?.pages.flatMap(p => p.items) ?? []
  const userPlaces = placesQuery.data ?? []

  return (
    <PageLayout>
      <div className="max-w-7xl mx-auto px-6">
        <div className="grid grid-cols-[320px_minmax(0,1fr)] gap-6">
          <div>
            <Card className="overflow-hidden border-2">
              <CardHeader className="flex-row items-center gap-4">
                <Avatar className="h-16 w-16 border-2 border-background">
                  {user.profilePhotoUrl && isValidPhotoUrl(user.profilePhotoUrl) && <AvatarImage src={user.profilePhotoUrl} alt={user.username} />}
                  <AvatarFallback className="bg-linear-to-br from-primary to-primary/70 text-primary-foreground text-lg font-bold">
                    {user.username.charAt(0).toUpperCase()}
                  </AvatarFallback>
                </Avatar>
                <CardTitle className="text-xl">{user.username}</CardTitle>
              </CardHeader>

              <CardContent>
                <Separator />
                {user.bio && <p className="mt-4 text-lg leading-relaxed">{user.bio}</p>}
                <div className="mt-6 pt-4 flex gap-6">
                  <div className="flex flex-col">
                    <span className="text-lg font-bold text-foreground">{allPosts.length}</span>
                    <span className="text-xs text-muted-foreground">Posts</span>
                  </div>
                  <div className="flex flex-col">
                    <span className="text-lg font-bold text-foreground">{userPlaces.length}</span>
                    <span className="text-xs text-muted-foreground">Places</span>
                  </div>
                </div>
              </CardContent>
            </Card>
          </div>

          <div>
            <Tabs value={tab} onValueChange={(v) => setTab(v as any)}>
              <TabsList>
                <TabsTrigger value="all">All</TabsTrigger>
                <TabsTrigger value="posts">Posts</TabsTrigger>
                <TabsTrigger value="places">Places</TabsTrigger>
              </TabsList>

              <TabsContent value="all">
                <div className="space-y-4">
                  {postsQuery.isLoading ? (
                    <LoadingSpinner />
                  ) : allPosts.length === 0 ? (
                    <p className="text-sm text-muted-foreground">No posts yet.</p>
                  ) : (
                    allPosts.map(p => (
                      <PostCard key={p.id} post={p} currentUser={null} onVote={() => {}} />
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
                  {postsQuery.isLoading ? <LoadingSpinner /> : allPosts.map(p => (
                    <PostCard key={p.id} post={p} currentUser={null} onVote={() => {}} />
                  ))}
                </div>
              </TabsContent>

              <TabsContent value="places">
                <div className="space-y-4">
                  {placesQuery.isLoading ? <LoadingSpinner /> : userPlaces.length === 0 ? (
                    <p className="text-sm text-muted-foreground">No places yet.</p>
                  ) : (
                    userPlaces.map((pl: any) => (
                      <PlaceCard key={pl.id} place={pl} className="group bg-card border border-border/50 rounded-3xl p-5" />
                    ))
                  )}
                </div>
              </TabsContent>
            </Tabs>
          </div>
          </div>
        </div>
    </PageLayout>
  )
}

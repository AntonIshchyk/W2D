import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback, useMemo } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { toast } from 'sonner'
import { ArrowBigUp, ArrowBigDown, MessageSquare, Star, Plus, Check, ChevronsUpDown } from 'lucide-react'
import { Button } from './ui/button'
import { Card, CardContent } from './ui/card'
import { Badge } from './ui/badge'
import { Tabs, TabsList, TabsTrigger } from './ui/tabs'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { Skeleton } from './ui/skeleton'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { PostType } from '../types/posts'
import type { Post, ScrollResult } from '../types/posts'
import { PAGINATION } from '../config/constants'
import { formatRelativeTime } from '../lib/utils/date'
import { EmptyState } from './ui/empty-state'
import { LoadingSpinner } from './ui/loading-spinner'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { cn } from '../lib/utils'

interface Activity {
  id: number
  title: string
}

async function fetchPosts(
  cursor: number | null, 
  activityId?: number, 
  userId?: number,
  type?: number,
  sortBy?: string
): Promise<ScrollResult<Post>> {
  const params = new URLSearchParams({
    limit: PAGINATION.DEFAULT_PAGE_SIZE.toString()
  })

  if (cursor !== null) {
    params.append('cursor', cursor.toString())
  }

  if (activityId) {
    params.append('activityId', activityId.toString())
  }

  if (userId) {
    params.append('userId', userId.toString())
  }

  if (type) {
    params.append('type', type.toString())
  }

  if (sortBy) {
    params.append('sortBy', sortBy)
  }

  const response = await fetch(`${API_ENDPOINTS.posts.base}?${params}`, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch posts')
  }

  return response.json()
}

async function fetchActivities(): Promise<Activity[]> {
  const response = await fetch(`${API_ENDPOINTS.activities.base}?limit=${PAGINATION.ACTIVITIES_FETCH_SIZE}`, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch activities')
  }

  const data = await response.json()
  return data.items || []
}

async function votePost(postId: number, value: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.vote(postId), {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify({ value })
  })

  if (!response.ok) {
    throw new Error('Failed to vote on post')
  }
}

const POST_TYPE_LABELS: Record<PostType, string> = {
  [PostType.ExperienceShare]: 'Experience',
  [PostType.Guide]: 'Guide',
  [PostType.Question]: 'Question',
  [PostType.Recommendation]: 'Recommendation',
  [PostType.Achievement]: 'Achievement',
  [PostType.Challenge]: 'Challenge'
}

const POST_TYPE_VARIANTS: Record<PostType, 'default' | 'secondary' | 'outline' | 'destructive'> = {
  [PostType.ExperienceShare]: 'default',
  [PostType.Guide]: 'secondary',
  [PostType.Question]: 'outline',
  [PostType.Recommendation]: 'default',
  [PostType.Achievement]: 'secondary',
  [PostType.Challenge]: 'destructive'
}

export function Posts() {
  const navigate = useNavigate()
  const [selectedActivity, setSelectedActivity] = useState<number | undefined>(undefined)
  const [selectedType, setSelectedType] = useState<number | undefined>(undefined)
  const [sortBy, setSortBy] = useState<string>('new')
  const [activityOpen, setActivityOpen] = useState(false)
  const observerTarget = useRef<HTMLDivElement>(null)
  
  const { data: currentUser, isError, error: userError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: activities } = useQuery({
    queryKey: ['activities'],
    queryFn: fetchActivities,
    staleTime: Infinity,
    gcTime: Infinity
  })

  const {
    data,
    fetchNextPage,
    hasNextPage,
    isFetchingNextPage,
    isLoading
  } = useInfiniteQuery({
    queryKey: ['posts', selectedActivity, selectedType, sortBy],
    queryFn: ({ pageParam }) => fetchPosts(pageParam, selectedActivity, undefined, selectedType, sortBy),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false
  })

  const queryClient = useQueryClient()

  const voteMutation = useMutation({
    mutationFn: ({ postId, value }: { postId: number; value: number }) => 
      votePost(postId, value),
    onMutate: async ({ postId, value }: { postId: number; value: number }) => {
      // Optimistic update for posts list and post detail
      const key = ['posts', selectedActivity, selectedType, sortBy]
      await queryClient.cancelQueries({ queryKey: key })
      const previous = queryClient.getQueryData<any>(key)

      queryClient.setQueryData(key, (data: any) => {
        if (!data) return data
        return {
          ...data,
          pages: data.pages.map((page: any) => ({
            ...page,
            items: page.items.map((p: Post) => {
              if (p.id !== postId) return p
              const newVote = p.currentUserVote === value ? 0 : value
              const old = p.currentUserVote ?? 0
              const delta = newVote - old
              return { ...p, currentUserVote: newVote, score: p.score + delta }
            })
          }))
        }
      })

      // update single post cache if present
      const postKey = ['post', postId.toString()]
      const prevPost = queryClient.getQueryData(postKey)
      if (prevPost) {
        queryClient.setQueryData(postKey, (p: any) => {
          const newVote = p.currentUserVote === value ? 0 : value
          const old = p.currentUserVote ?? 0
          const delta = newVote - old
          return { ...p, currentUserVote: newVote, score: p.score + delta }
        })
      }

      return { previous }
    },
    onError: (err, vars, context: any) => {
      const key = ['posts', selectedActivity, selectedType, sortBy]
      if (context?.previous) {
        queryClient.setQueryData(key, context.previous)
      }
      if (vars?.postId) {
        queryClient.invalidateQueries({ queryKey: ['post', vars.postId.toString()] })
      }
      toast.error((err as Error).message)
    },
    onSettled: (_data, _error, variables) => {
      queryClient.invalidateQueries({ queryKey: ['posts', selectedActivity, selectedType, sortBy] })
      if (variables) queryClient.invalidateQueries({ queryKey: ['post', variables.postId.toString()] })
    }
  })

  useAuthErrorHandler(isError, userError)

  // Intersection Observer for infinite scroll
  const handleObserver = useCallback((entries: IntersectionObserverEntry[]) => {
    const [target] = entries
    if (target.isIntersecting && hasNextPage && !isFetchingNextPage) {
      fetchNextPage()
    }
  }, [fetchNextPage, hasNextPage, isFetchingNextPage])

  useEffect(() => {
    const element = observerTarget.current
    const option = { threshold: 0.1 }
    const observer = new IntersectionObserver(handleObserver, option)
    
    if (element) observer.observe(element)
    
    return () => {
      if (element) observer.unobserve(element)
      observer.disconnect()
    }
  }, [handleObserver])

  const allPosts = useMemo(
    () => data?.pages.flatMap(page => page.items) ?? [],
    [data?.pages]
  )

  const handleVote = (postId: number, currentVote: number | undefined, newValue: number) => {
    const value = currentVote === newValue ? 0 : newValue
    voteMutation.mutate({ postId, value })
  }

  if (isError) {
    return null
  }

  return (
    <PageLayout>
      {/* Improved header */}
      <div className="mb-8">
        <div className="flex items-center justify-between mb-6">
          <div>
            <h1 className="text-3xl font-bold">
              Posts
            </h1>
            <p className="text-muted-foreground mt-1">
              Share experiences and discuss activities
            </p>
          </div>
          {currentUser && (
            <Button onClick={() => navigate('/posts/create')} className="gap-2">
              <Plus className="h-4 w-4" />
              New Post
            </Button>
          )}
        </div>
      </div>

      {/* Filters */}
      <div className="mb-6 space-y-4">
        {/* Sort tabs */}
        <Tabs value={sortBy} onValueChange={setSortBy} className="w-full">
          <TabsList className="grid w-full max-w-sm grid-cols-3">
            <TabsTrigger value="new">
              New
            </TabsTrigger>
            <TabsTrigger value="hot">
              Hot
            </TabsTrigger>
            <TabsTrigger value="top">
              Top
            </TabsTrigger>
          </TabsList>
        </Tabs>

        {/* Activity and Type filters */}
        <div className="flex items-center gap-3 flex-wrap pb-4 border-b">
          <Popover open={activityOpen} onOpenChange={setActivityOpen}>
            <PopoverTrigger asChild>
                <Button
                variant="outline"
                role="combobox"
                aria-expanded={activityOpen}
                className="w-64 justify-between"
              >
                {selectedActivity
                  ? activities?.find((activity) => activity.id === selectedActivity)?.title
                  : "All activities"}
                <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
              </Button>
            </PopoverTrigger>
            <PopoverContent className="w-62.5 p-0" align="start">
              <Command>
                <CommandInput placeholder="Search activities..." />
                <CommandList>
                  <CommandEmpty>No activity found.</CommandEmpty>
                  <CommandGroup>
                    <CommandItem
                      value="all"
                      onSelect={() => {
                        setSelectedActivity(undefined)
                        setActivityOpen(false)
                      }}
                    >
                      <Check
                        className={cn(
                          "mr-2 h-4 w-4",
                          !selectedActivity ? "opacity-100" : "opacity-0"
                        )}
                      />
                      All activities
                    </CommandItem>
                    {activities?.map((activity) => (
                      <CommandItem
                        key={activity.id}
                        value={activity.title}
                        onSelect={() => {
                          setSelectedActivity(activity.id)
                          setActivityOpen(false)
                        }}
                      >
                        <Check
                          className={cn(
                            "mr-2 h-4 w-4",
                            selectedActivity === activity.id ? "opacity-100" : "opacity-0"
                          )}
                        />
                        {activity.title}
                      </CommandItem>
                    ))}
                  </CommandGroup>
                </CommandList>
              </Command>
            </PopoverContent>
          </Popover>

          <Select 
            value={selectedType?.toString() ?? 'all'} 
            onValueChange={(value) => setSelectedType(value === 'all' ? undefined : Number(value))}
          >
            <SelectTrigger className="w-48">
              <SelectValue placeholder="All types" />
            </SelectTrigger>
            <SelectContent>
              <SelectItem value="all">All types</SelectItem>
              {Object.entries(POST_TYPE_LABELS).map(([value, label]) => (
                <SelectItem key={value} value={value}>
                  {label}
                </SelectItem>
              ))}
            </SelectContent>
          </Select>

          {(selectedActivity || selectedType) && (
            <Button
              variant="ghost"
              size="sm"
              onClick={() => { 
                setSelectedActivity(undefined)
                setSelectedType(undefined)
              }}
              className="h-9 ml-auto"
            >
              Clear
            </Button>
          )}
        </div>
      </div>

      {/* Post list */}
      <div className="max-w-4xl space-y-4">
        {isLoading ? (
          <>
            {[...Array(5)].map((_, i) => (
              <Card key={i}>
                <CardContent className="p-4 flex gap-4">
                  <div className="flex flex-col items-center gap-2">
                    <Skeleton className="h-4 w-4" />
                    <Skeleton className="h-4 w-6" />
                    <Skeleton className="h-4 w-4" />
                  </div>
                  <div className="flex-1 space-y-2">
                    <Skeleton className="h-4 w-1/4" />
                    <Skeleton className="h-5 w-3/4" />
                    <Skeleton className="h-3 w-full" />
                  </div>
                </CardContent>
              </Card>
            ))}
          </>
        ) : (
          <>
            {allPosts.map((post) => (
              <Card 
                key={post.id} 
                className="hover:shadow-md transition-shadow"
              >
                <CardContent className="p-5 flex gap-5">
                  {/* Voting column with better design */}
                  <div className="flex flex-col items-center gap-1.5 pt-1">
                    <Button
                      variant={post.currentUserVote === 1 ? "default" : "ghost"}
                      size="icon"
                      className="h-8 w-8"
                      onClick={() => handleVote(post.id, post.currentUserVote, 1)}
                      disabled={!currentUser}
                    >
                      <ArrowBigUp className="h-5 w-5" fill={post.currentUserVote === 1 ? "currentColor" : "none"} />
                    </Button>
                    <span className={`text-base font-bold tabular-nums ${
                      post.score > 0 ? 'text-orange-500' : post.score < 0 ? 'text-blue-500' : 'text-muted-foreground'
                    }`}>
                      {post.score}
                    </span>
                    <Button
                      variant={post.currentUserVote === -1 ? "default" : "ghost"}
                      size="icon"
                      className="h-8 w-8"
                      onClick={() => handleVote(post.id, post.currentUserVote, -1)}
                      disabled={!currentUser}
                    >
                      <ArrowBigDown className="h-5 w-5" fill={post.currentUserVote === -1 ? "currentColor" : "none"} />
                    </Button>
                  </div>

                  {/* Content column */}
                  <div className="flex-1 min-w-0 space-y-3">
                    {/* Meta info */}
                    <div className="flex items-center gap-2 text-xs flex-wrap">
                      <Badge variant={POST_TYPE_VARIANTS[post.type as PostType] ?? 'outline'} className="font-medium">
                        {POST_TYPE_LABELS[post.type as PostType] ?? 'Other'}
                      </Badge>
                      <span className="text-muted-foreground">•</span>
                      <span className="font-medium text-foreground">{post.userName || 'Anonymous'}</span>
                      <span className="text-muted-foreground">•</span>
                      <span className="text-muted-foreground">{formatRelativeTime(post.createdAt)}</span>
                      {post.activityTitle && (
                        <>
                          <span className="text-muted-foreground">•</span>
                          <span className="font-medium">{post.activityTitle}</span>
                        </>
                      )}
                    </div>

                    {/* Title with better typography */}
                    <Link 
                      to={`/posts/${post.id}`}
                      className="block"
                    >
                      <h3 className="text-xl font-bold text-foreground group-hover:text-primary transition-colors line-clamp-2">
                        {post.title}
                      </h3>
                    </Link>
                    
                    {/* Preview with better readability */}
                    <p className="text-muted-foreground leading-relaxed line-clamp-2">
                      {post.content}
                    </p>

                    {/* Footer with icons */}
                    <div className="flex items-center gap-4 text-sm text-muted-foreground pt-2">
                      {post.rating != null && post.rating > 0 && (
                        <div className="flex items-center gap-1">
                          {[...Array(post.rating)].map((_, i) => (
                            <Star key={i} className="h-3.5 w-3.5 fill-yellow-400 text-yellow-400" />
                          ))}
                        </div>
                      )}
                      {post.commentCount > 0 && (
                        <Link 
                          to={`/posts/${post.id}`}
                          className="flex items-center gap-1.5 hover:text-foreground transition-colors"
                        >
                          <MessageSquare className="h-4 w-4" />
                          <span className="font-medium">{post.commentCount}</span>
                          <span>comments</span>
                        </Link>
                      )}
                    </div>
                  </div>
                </CardContent>
              </Card>
            ))}

            {allPosts.length === 0 && (
              <EmptyState
                icon={MessageSquare}
                title="No posts yet"
                description={
                  selectedActivity || selectedType
                    ? 'Try adjusting your filters'
                    : 'Be the first to share something!'
                }
                action={currentUser && !selectedActivity && !selectedType ? {
                  label: 'Create Post',
                  onClick: () => navigate('/posts/create')
                } : undefined}
              />
            )}

            {/* Infinite scroll target */}
            <div ref={observerTarget} className="h-10 flex items-center justify-center">
              {isFetchingNextPage && <LoadingSpinner text="Loading more..." />}
            </div>
          </>
        )}
      </div>
    </PageLayout>
  )
}

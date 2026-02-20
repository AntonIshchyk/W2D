import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback, useMemo } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { toast } from 'sonner'
import {
  ArrowBigUp, ArrowBigDown, MessageSquare, Star,
  Plus, Check, ChevronsUpDown, ImageIcon
} from 'lucide-react'
import { Button } from './ui/button'
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
  const params = new URLSearchParams({ limit: PAGINATION.DEFAULT_PAGE_SIZE.toString() })
  if (cursor !== null) params.append('cursor', cursor.toString())
  if (activityId) params.append('activityId', activityId.toString())
  if (userId) params.append('userId', userId.toString())
  if (type) params.append('type', type.toString())
  if (sortBy) params.append('sortBy', sortBy)
  const response = await fetch(`${API_ENDPOINTS.posts.base}?${params}`, { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch posts')
  return response.json()
}

async function fetchActivities(): Promise<Activity[]> {
  const response = await fetch(`${API_ENDPOINTS.activities.base}?limit=${PAGINATION.ACTIVITIES_FETCH_SIZE}`, { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch activities')
  const data = await response.json()
  return data.items || []
}

async function votePost(postId: number, value: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.vote(postId), {
    method: 'POST',
    headers: { ...getAuthHeaders(), 'Content-Type': 'application/json' },
    body: JSON.stringify({ value })
  })
  if (!response.ok) throw new Error('Failed to vote on post')
}

const POST_TYPE_LABELS: Record<PostType, string> = {
  [PostType.ExperienceShare]: 'Experience',
  [PostType.Guide]: 'Guide',
  [PostType.Question]: 'Question',
  [PostType.Recommendation]: 'Recommendation',
  [PostType.Achievement]: 'Achievement',
  [PostType.Challenge]: 'Challenge'
}

const POST_TYPE_COLORS: Record<PostType, { bg: string; text: string }> = {
  [PostType.ExperienceShare]: { bg: '#dbeafe', text: '#1e40af' },
  [PostType.Guide]:           { bg: '#dcfce7', text: '#166534' },
  [PostType.Question]:        { bg: '#fef9c3', text: '#854d0e' },
  [PostType.Recommendation]:  { bg: '#f3e8ff', text: '#6b21a8' },
  [PostType.Achievement]:     { bg: '#ffedd5', text: '#9a3412' },
  [PostType.Challenge]:       { bg: '#fee2e2', text: '#991b1b' },
}

// ── Photo grid for feed cards ─────────────────────────────────────────────────

function PhotoGrid({ urls, onClick }: { urls: string[]; onClick?: (i: number) => void }) {
  if (urls.length === 0) return null

  // 1 photo — wide
  if (urls.length === 1) {
    return (
      <div
        className="mt-3 rounded-xl overflow-hidden cursor-pointer"
        onClick={() => onClick?.(0)}
      >
        <img src={urls[0]} alt="" className="w-full max-h-80 object-cover" />
      </div>
    )
  }

  // 2 photos — side by side
  if (urls.length === 2) {
    return (
      <div className="mt-3 grid grid-cols-2 gap-1 rounded-xl overflow-hidden cursor-pointer">
        {urls.map((url, i) => (
          <img key={i} src={url} alt="" className="w-full h-48 object-cover" onClick={() => onClick?.(i)} />
        ))}
      </div>
    )
  }

  // 3 photos — one large left, two stacked right
  if (urls.length === 3) {
    return (
      <div className="mt-3 grid grid-cols-2 gap-1 rounded-xl overflow-hidden cursor-pointer" style={{ height: 240 }}>
        <img src={urls[0]} alt="" className="w-full h-full object-cover" onClick={() => onClick?.(0)} />
        <div className="grid grid-rows-2 gap-1">
          <img src={urls[1]} alt="" className="w-full h-full object-cover" onClick={() => onClick?.(1)} />
          <img src={urls[2]} alt="" className="w-full h-full object-cover" onClick={() => onClick?.(2)} />
        </div>
      </div>
    )
  }

  // 4+ photos — 2x2 grid with overflow indicator
  const shown = urls.slice(0, 4)
  const extra = urls.length - 4
  return (
    <div className="mt-3 grid grid-cols-2 gap-1 rounded-xl overflow-hidden cursor-pointer" style={{ height: 240 }}>
      {shown.map((url, i) => (
        <div key={i} className="relative" onClick={() => onClick?.(i)}>
          <img src={url} alt="" className="w-full h-full object-cover" />
          {i === 3 && extra > 0 && (
            <div className="absolute inset-0 bg-black/50 flex items-center justify-center">
              <span className="text-white text-xl font-bold">+{extra}</span>
            </div>
          )}
        </div>
      ))}
    </div>
  )
}

// ── Post card ─────────────────────────────────────────────────────────────────

function PostCard({
  post,
  currentUser,
  onVote,
}: {
  post: Post
  currentUser: any
  onVote: (postId: number, currentVote: number | undefined, newValue: number) => void
}) {
  const typeColor = POST_TYPE_COLORS[post.type as PostType]
  const hasPhotos = post.photoUrls && post.photoUrls.length > 0

  return (
    <article className="bg-card border rounded-xl overflow-hidden hover:shadow-sm transition-shadow">
      {/* Single hero image if only one photo — above the content */}
      {hasPhotos && post.photoUrls.length === 1 && (
        <Link to={`/posts/${post.id}`}>
          <img
            src={post.photoUrls[0]}
            alt=""
            className="w-full h-56 object-cover"
          />
        </Link>
      )}

      <div className="p-4 flex gap-3">
        {/* Vote column */}
        <div className="flex flex-col items-center gap-1 shrink-0 pt-0.5">
          <button
            type="button"
            onClick={() => onVote(post.id, post.currentUserVote, 1)}
            disabled={!currentUser}
            aria-label="Upvote"
            className={cn(
              'w-7 h-7 flex items-center justify-center rounded-md transition-all',
              post.currentUserVote === 1
                ? 'text-orange-500 bg-orange-50'
                : 'text-muted-foreground hover:text-orange-500 hover:bg-orange-50',
              !currentUser && 'cursor-not-allowed opacity-40'
            )}
          >
            <ArrowBigUp className="w-5 h-5" fill={post.currentUserVote === 1 ? 'currentColor' : 'none'} />
          </button>

          <span className={cn(
            'text-sm font-bold tabular-nums',
            post.score > 0 ? 'text-orange-500' :
            post.score < 0 ? 'text-blue-500' :
            'text-muted-foreground'
          )}>
            {post.score}
          </span>

          <button
            type="button"
            onClick={() => onVote(post.id, post.currentUserVote, -1)}
            disabled={!currentUser}
            aria-label="Downvote"
            className={cn(
              'w-7 h-7 flex items-center justify-center rounded-md transition-all',
              post.currentUserVote === -1
                ? 'text-blue-500 bg-blue-50'
                : 'text-muted-foreground hover:text-blue-500 hover:bg-blue-50',
              !currentUser && 'cursor-not-allowed opacity-40'
            )}
          >
            <ArrowBigDown className="w-5 h-5" fill={post.currentUserVote === -1 ? 'currentColor' : 'none'} />
          </button>
        </div>

        {/* Content */}
        <div className="flex-1 min-w-0">
          {/* Meta row */}
          <div className="flex items-center gap-1.5 flex-wrap mb-2">
            {typeColor && (
              <span
                className="text-xs font-medium px-2 py-0.5 rounded-full"
                style={{ background: typeColor.bg, color: typeColor.text }}
              >
                {POST_TYPE_LABELS[post.type as PostType]}
              </span>
            )}
            {post.activityTitle && (
              <span className="text-xs text-muted-foreground font-medium">
                {post.activityTitle}
              </span>
            )}
            <span className="text-xs text-muted-foreground/50 ml-auto">
              {formatRelativeTime(post.createdAt)}
            </span>
          </div>

          {/* Title */}
          <Link to={`/posts/${post.id}`}>
            <h3 className="font-semibold text-base leading-snug mb-1 hover:text-primary transition-colors line-clamp-2">
              {post.title}
            </h3>
          </Link>

          {/* Author */}
          <p className="text-xs text-muted-foreground mb-2">
            by {post.userName || 'Anonymous'}
          </p>

          {/* Content preview — skip if photo-dominant */}
          {(!hasPhotos || post.photoUrls.length > 1) && (
            <p className="text-sm text-muted-foreground line-clamp-2 leading-relaxed mb-2">
              {post.content}
            </p>
          )}

          {/* Multi-photo grid */}
          {hasPhotos && post.photoUrls.length > 1 && (
            <Link to={`/posts/${post.id}`}>
              <PhotoGrid urls={post.photoUrls} />
            </Link>
          )}

          {/* Footer */}
          <div className="flex items-center gap-3 mt-3 text-xs text-muted-foreground">
            {post.rating != null && post.rating > 0 && (
              <div className="flex items-center gap-0.5">
                {[...Array(post.rating)].map((_, i) => (
                  <Star key={i} className="h-3 w-3 fill-amber-400 text-amber-400" />
                ))}
              </div>
            )}
            {hasPhotos && post.photoUrls.length === 1 && (
              <span className="flex items-center gap-1">
                <ImageIcon className="h-3 w-3" />
                1 photo
              </span>
            )}
            <Link
              to={`/posts/${post.id}`}
              className="flex items-center gap-1 hover:text-foreground transition-colors ml-auto"
            >
              <MessageSquare className="h-3.5 w-3.5" />
              <span>{post.commentCount}</span>
            </Link>
          </div>
        </div>
      </div>
    </article>
  )
}

// ── Main component ────────────────────────────────────────────────────────────

export function Posts() {
  const navigate = useNavigate()
  const [selectedActivity, setSelectedActivity] = useState<number | undefined>()
  const [selectedType, setSelectedType]         = useState<number | undefined>()
  const [sortBy, setSortBy]                     = useState('new')
  const [activityOpen, setActivityOpen]         = useState(false)
  const observerTarget = useRef<HTMLDivElement>(null)

  const { data: currentUser, isError, error: userError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false,
  })

  const { data: activities } = useQuery({
    queryKey: ['activities'],
    queryFn: fetchActivities,
    staleTime: Infinity,
    gcTime: Infinity,
  })

  const { data, fetchNextPage, hasNextPage, isFetchingNextPage, isLoading } = useInfiniteQuery({
    queryKey: ['posts', selectedActivity, selectedType, sortBy],
    queryFn: ({ pageParam }) => fetchPosts(pageParam, selectedActivity, undefined, selectedType, sortBy),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false,
  })

  const queryClient = useQueryClient()

  const voteMutation = useMutation({
    mutationFn: ({ postId, value }: { postId: number; value: number }) => votePost(postId, value),
    onMutate: async ({ postId, value }) => {
      const key = ['posts', selectedActivity, selectedType, sortBy]
      await queryClient.cancelQueries({ queryKey: key })
      const previous = queryClient.getQueryData(key)
      queryClient.setQueryData(key, (data: any) => {
        if (!data) return data
        return {
          ...data,
          pages: data.pages.map((page: any) => ({
            ...page,
            items: page.items.map((p: Post) => {
              if (p.id !== postId) return p
              const newVote = p.currentUserVote === value ? 0 : value
              const delta = newVote - (p.currentUserVote ?? 0)
              return { ...p, currentUserVote: newVote, score: p.score + delta }
            })
          }))
        }
      })
      return { previous }
    },
    onError: (_err, vars, context: any) => {
      if (context?.previous) {
        queryClient.setQueryData(['posts', selectedActivity, selectedType, sortBy], context.previous)
      }
      toast.error('Failed to vote')
    },
    onSettled: (_data, _error, variables) => {
      queryClient.invalidateQueries({ queryKey: ['posts', selectedActivity, selectedType, sortBy] })
      if (variables) queryClient.invalidateQueries({ queryKey: ['post', variables.postId.toString()] })
    }
  })

  useAuthErrorHandler(isError, userError)

  const handleObserver = useCallback((entries: IntersectionObserverEntry[]) => {
    const [target] = entries
    if (target.isIntersecting && hasNextPage && !isFetchingNextPage) fetchNextPage()
  }, [fetchNextPage, hasNextPage, isFetchingNextPage])

  useEffect(() => {
    const el = observerTarget.current
    const observer = new IntersectionObserver(handleObserver, { threshold: 0.1 })
    if (el) observer.observe(el)
    return () => { if (el) observer.unobserve(el) }
  }, [handleObserver])

  const allPosts = useMemo(() => data?.pages.flatMap(p => p.items) ?? [], [data?.pages])

  const handleVote = (postId: number, currentVote: number | undefined, newValue: number) => {
    const value = currentVote === newValue ? 0 : newValue
    voteMutation.mutate({ postId, value })
  }

  if (isError) return null

  return (
    <PageLayout>
      <div className="mb-6 flex items-start justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold">Posts</h1>
          <p className="text-sm text-muted-foreground mt-0.5">Share experiences, ask questions, find tips</p>
        </div>
        {currentUser && (
          <Button type="button" size="sm" className="gap-2 shrink-0" onClick={() => navigate('/posts/create')}>
            <Plus className="h-4 w-4" />
            New post
          </Button>
        )}
      </div>

      {/* Sort + filters */}
      <div className="mb-5 space-y-3">
        <Tabs value={sortBy} onValueChange={setSortBy}>
          <TabsList>
            <TabsTrigger value="new">New</TabsTrigger>
            <TabsTrigger value="hot">Hot</TabsTrigger>
            <TabsTrigger value="top">Top</TabsTrigger>
          </TabsList>
        </Tabs>

        <div className="flex items-center gap-2 flex-wrap pb-4 border-b">
          <Popover open={activityOpen} onOpenChange={setActivityOpen}>
            <PopoverTrigger asChild>
              <Button variant="outline" role="combobox" className="h-8 text-xs gap-1.5">
                {selectedActivity
                  ? activities?.find(a => a.id === selectedActivity)?.title ?? 'Activity'
                  : 'All activities'}
                <ChevronsUpDown className="h-3.5 w-3.5 opacity-50" />
              </Button>
            </PopoverTrigger>
            <PopoverContent className="w-56 p-0" align="start">
              <Command>
                <CommandInput placeholder="Search…" />
                <CommandList>
                  <CommandEmpty>No activity found.</CommandEmpty>
                  <CommandGroup>
                    <CommandItem value="all" onSelect={() => { setSelectedActivity(undefined); setActivityOpen(false) }}>
                      <Check className={cn('mr-2 h-4 w-4', !selectedActivity ? 'opacity-100' : 'opacity-0')} />
                      All activities
                    </CommandItem>
                    {activities?.map(a => (
                      <CommandItem key={a.id} value={a.title} onSelect={() => { setSelectedActivity(a.id); setActivityOpen(false) }}>
                        <Check className={cn('mr-2 h-4 w-4', selectedActivity === a.id ? 'opacity-100' : 'opacity-0')} />
                        {a.title}
                      </CommandItem>
                    ))}
                  </CommandGroup>
                </CommandList>
              </Command>
            </PopoverContent>
          </Popover>

          <Select
            value={selectedType?.toString() ?? 'all'}
            onValueChange={v => setSelectedType(v === 'all' ? undefined : Number(v))}
          >
            <SelectTrigger className="h-8 text-xs w-36">
              <SelectValue placeholder="All types" />
            </SelectTrigger>
            <SelectContent>
              <SelectItem value="all">All types</SelectItem>
              {Object.entries(POST_TYPE_LABELS).map(([value, label]) => (
                <SelectItem key={value} value={value}>{label}</SelectItem>
              ))}
            </SelectContent>
          </Select>

          {(selectedActivity || selectedType) && (
            <Button type="button" variant="ghost" size="sm" className="h-8 text-xs ml-auto"
              onClick={() => { setSelectedActivity(undefined); setSelectedType(undefined) }}>
              Clear
            </Button>
          )}
        </div>
      </div>

      {/* Feed */}
      <div className="max-w-2xl space-y-3">
        {isLoading ? (
          [...Array(4)].map((_, i) => (
            <div key={i} className="border rounded-xl p-4 space-y-3">
              <Skeleton className="h-4 w-1/4" />
              <Skeleton className="h-5 w-3/4" />
              <Skeleton className="h-32 w-full rounded-lg" />
            </div>
          ))
        ) : allPosts.length === 0 ? (
          <EmptyState
            icon={MessageSquare}
            title="No posts yet"
            description={selectedActivity || selectedType ? 'Try adjusting your filters' : 'Be the first to share something!'}
            action={currentUser && !selectedActivity && !selectedType ? {
              label: 'Create Post',
              onClick: () => navigate('/posts/create')
            } : undefined}
          />
        ) : (
          <>
            {allPosts.map(post => (
              <PostCard
                key={post.id}
                post={post}
                currentUser={currentUser}
                onVote={handleVote}
              />
            ))}
            <div ref={observerTarget} className="h-10 flex items-center justify-center">
              {isFetchingNextPage && <LoadingSpinner text="Loading more…" />}
            </div>
          </>
        )}
      </div>
    </PageLayout>
  )
}

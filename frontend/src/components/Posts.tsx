import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback, useMemo } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { toast } from 'sonner'
import {
  MessageSquare,
  Plus, Check, ChevronsUpDown, ImageIcon, Flame, Clock, TrendingUp
} from 'lucide-react'
import { Button } from './ui/button'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { Skeleton } from './ui/skeleton'
import { PageLayout } from './Navbar'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { PostType } from '../types/posts'
import type { Post } from '../types/posts'
import { formatRelativeTime } from '../lib/utils/date'
import { EmptyState } from './ui/empty-state'
import { LoadingSpinner } from './ui/loading-spinner'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { cn } from '../lib/utils'
import { fetchPosts, votePost, POST_TYPE_LABELS, POST_TYPE_ICONS } from '../features/posts/api'
import { fetchCommunities } from '../features/communities/api'
import { PostCarousel } from './PostCarousel'

import { PostAuthorInfo } from './PostAuthorInfo'
import { VoteButtons } from './VoteButtons'

// ── Modern Post Card ────────────────────────────────────────────────────────

function PostCard({
  post,
  currentUser,
  onVote,
}: {
  post: Post
  currentUser: any
  onVote: (postId: number, currentVote: number | undefined, newValue: number) => void
}) {
  return (
    <article className="group bg-card border border-border/50 rounded-3xl p-5 md:p-6 hover:shadow-xl hover:shadow-primary/5 hover:border-primary/20 transition-all duration-300 flex flex-col">
      
      {/* Header Info */}
      <div className="flex items-center justify-between mb-4">
        <PostAuthorInfo author={post.author as any} type={post.type as PostType} />

        <div className="flex items-center gap-2">
          {post.communityName && (
            <span className="px-3 py-1 rounded-full text-xs font-bold border bg-primary text-primary-foreground border-primary">
              {post.communityName}
            </span>
          )}
        </div>
      </div>

      {/* Content */}
      <div className="flex-1">
        <Link to={`/posts/${post.id}`}>
          <h3 className="font-bold text-xl md:text-2xl text-foreground mb-2 group-hover:text-primary transition-colors line-clamp-2">
            {post.title}
          </h3>
        </Link>
        
        {post.description && (
          <p className="text-foreground text-sm md:text-base line-clamp-3 leading-relaxed">
            {post.description}
          </p>
        )}

        <PostCarousel urls={post.photoUrls || []} containerClassName="mt-4 mb-2 md:px-0" imageContainerClassName="h-75 md:h-112.5" />
      </div>

      {/* Footer Actions Minimal */}
      <div className="flex items-center justify-between mt-5 pt-4 border-t border-border/40">
        <div className="flex items-center gap-3">
          {/* Upvotes */}
          <VoteButtons
            score={post.score}
            currentUserVote={post.currentUserVote}
            onVote={(value) => onVote(post.id, post.currentUserVote, value)}
            disabled={!currentUser}
          />

          {/* Comments */}
          <Link
            to={`/posts/${post.id}`}
            className="flex items-center gap-2 text-sm font-bold text-muted-foreground hover:text-foreground hover:bg-muted/50 px-3 py-2 rounded-full transition-colors border border-transparent hover:border-border/50 bg-muted/40"
          >
            <MessageSquare className="w-4 h-4" />
            <span>{post.commentCount}</span>
          </Link>

          {/* Time (Next to comments) */}
          <div className="flex items-center gap-1.5 text-sm font-bold text-muted-foreground bg-muted/40 px-3 py-2 rounded-full border border-border/50">
            <Clock className="w-4 h-4 opacity-70" />
            <span>{formatRelativeTime(post.createdAt)}</span>
          </div>
        </div>
      </div>
    </article>
  )
}

// ── Main Page Component ─────────────────────────────────────────────────────

export function Posts() {
  const navigate = useNavigate()
  const [selectedCommunity, setSelectedCommunity] = useState<number | undefined>()
  const [selectedType, setSelectedType]         = useState<number | undefined>()
  const [sortBy, setSortBy]                     = useState('new')
  const [communityOpen, setCommunityOpen]         = useState(false)
  const observerTarget = useRef<HTMLDivElement>(null)

  const { data: currentUser, isError, error: userError } = useCurrentUser()

  const { data: communities } = useQuery({
    queryKey: ['communities'],
    queryFn: fetchCommunities,
    staleTime: Infinity,
    gcTime: Infinity,
  })

  const { data, fetchNextPage, hasNextPage, isFetchingNextPage, isLoading } = useInfiniteQuery({
    queryKey: ['posts', selectedCommunity, selectedType, sortBy],
    queryFn: ({ pageParam }) => fetchPosts({
      cursor: pageParam,
      topicId: selectedCommunity,
      type: selectedType,
      sortBy,
    }),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false,
  })

  const queryClient = useQueryClient()

  const voteMutation = useMutation({
    mutationFn: ({ postId, value }: { postId: number; value: number }) => votePost(postId, value),
    onMutate: async ({ postId, value }) => {
      // Optmistic update code...
      const key = ['posts', selectedCommunity, selectedType, sortBy]
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
    onError: (_err, context: any) => {
      if (context?.previous) {
        queryClient.setQueryData(['posts', selectedCommunity, selectedType, sortBy], context.previous)
      }
      toast.error('Failed to vote')
    },
    onSettled: (_data, _error, variables) => {
      queryClient.invalidateQueries({ queryKey: ['posts', selectedCommunity, selectedType, sortBy] })
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
      <div className="flex flex-col md:flex-row items-center justify-center gap-4 pb-6 mb-6 mt-2">
        <div className="flex items-center justify-center gap-3 overflow-x-auto no-scrollbar w-full md:w-auto">
            
            <div className="flex items-center gap-1 bg-muted/40 p-1 rounded-full border border-border/50 shrink-0">
              <button
                onClick={() => setSortBy('new')}
                className={cn("px-4 py-2 rounded-full text-sm font-medium transition-colors flex items-center gap-2", sortBy === 'new' ? "bg-background shadow-sm text-foreground" : "text-muted-foreground hover:text-foreground")}
              >
              <Clock className="w-4 h-4" /> New
            </button>
            <button
              onClick={() => setSortBy('hot')}
              className={cn("px-4 py-2 rounded-full text-sm font-medium transition-colors flex items-center gap-2", sortBy === 'hot' ? "bg-background shadow-sm text-orange-600" : "text-muted-foreground hover:text-foreground")}
            >
              <Flame className="w-4 h-4" /> Hot
            </button>
            <button
              onClick={() => setSortBy('top')}
              className={cn("px-4 py-2 rounded-full text-sm font-medium transition-colors flex items-center gap-2", sortBy === 'top' ? "bg-background shadow-sm text-blue-600" : "text-muted-foreground hover:text-foreground")}
            >
              <TrendingUp className="w-4 h-4" /> Top
            </button>
          </div>

          <div className="h-8 w-px bg-border/50 mx-1 shrink-0"></div>

          {(selectedCommunity !== undefined || selectedType !== undefined || sortBy !== 'new') && (
            <Button 
              variant="outline"
              size="sm"
              className="rounded-full h-10 px-3 text-destructive border-destructive/30 hover:bg-destructive/10 hover:border-destructive/50 shrink-0"
              onClick={() => { setSelectedCommunity(undefined); setSelectedType(undefined); setSortBy('new') }}
            >
              ✕ Reset
            </Button>
          )}

          <Popover open={communityOpen} onOpenChange={setCommunityOpen}>
            <PopoverTrigger asChild>
              <Button variant="outline" className="rounded-full h-10 gap-2 shrink-0 border-border/60 hover:border-primary/50 transition-colors">
                {selectedCommunity
                  ? communities?.find(c => c.id === selectedCommunity)?.name
                  : 'All Communities'}
                <ChevronsUpDown className="h-3 w-3 opacity-50 ml-1" />
              </Button>
            </PopoverTrigger>
            <PopoverContent className="w-56 p-0 rounded-2xl" align="start">
              <Command>
                <CommandInput placeholder="Search communities…" className="h-10" />
                <CommandList>
                  <CommandEmpty>No community found.</CommandEmpty>
                  <CommandGroup>
                    <CommandItem value="all" onSelect={() => { setSelectedCommunity(undefined); setCommunityOpen(false) }}>
                      <Check className={cn('mr-2 h-4 w-4', !selectedCommunity ? 'opacity-100' : 'opacity-0')} />
                      All communities
                    </CommandItem>
                    {communities?.map(a => (
                      <CommandItem key={a.id} value={a.name} onSelect={() => { setSelectedCommunity(a.id); setCommunityOpen(false) }}>
                        <Check className={cn('mr-2 h-4 w-4', selectedCommunity === a.id ? 'opacity-100' : 'opacity-0')} />
                        {a.name}
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
            <SelectTrigger className="h-10 rounded-full border-border/60 shrink-0 w-40 hover:border-primary/50 transition-colors">
              <SelectValue placeholder="All types" />
            </SelectTrigger>
            <SelectContent className="rounded-2xl">
              <SelectItem value="all">All types</SelectItem>
              {Object.entries(POST_TYPE_LABELS).map(([value, label]) => {
                const Icon = POST_TYPE_ICONS[Number(value) as PostType]
                return (
                  <SelectItem key={value} value={value}>
                    <div className="flex items-center gap-2">
                      {Icon && <Icon className="w-4 h-4" />}
                      <span>{label}</span>
                    </div>
                  </SelectItem>
                )
              })}
            </SelectContent>
          </Select>
        </div>

        {currentUser && (
          <Button
            className="rounded-full shadow-sm hover:shadow-md transition-all px-6 shrink-0 w-full md:w-auto flex items-center justify-center"
            onClick={() => navigate('/posts/create')}
          >
            <Plus className="h-4 w-4" />
            <span>Create Post</span>
          </Button>
        )}
      </div>

      {/* Post Feed */}
      <div className="max-w-3xl mx-auto space-y-6">
        {isLoading ? (
          [...Array(3)].map((_, i) => (
            <div key={i} className="border border-border/40 rounded-3xl p-6 space-y-4 shadow-sm bg-card">
              <div className="flex gap-4 items-center">
                <Skeleton className="h-12 w-12 rounded-full" />
                <div className="space-y-2 flex-1">
                  <Skeleton className="h-4 w-1/4" />
                  <Skeleton className="h-3 w-1/5" />
                </div>
              </div>
              <Skeleton className="h-6 w-3/4 mt-4" />
              <Skeleton className="h-24 w-full rounded-xl" />
            </div>
          ))
        ) : allPosts.length === 0 ? (
          <div className="py-20 text-center">
            <EmptyState
              icon={ImageIcon}
              title="No posts found"
              description="There are no posts here yet."
              action={currentUser && !selectedCommunity && !selectedType ? {
                label: 'Create Post',
                onClick: () => navigate('/posts/create')
              } : undefined}
            />
          </div>
        ) : (
          <div className="grid gap-6">
            {allPosts.map(post => (
              <PostCard
                key={post.id}
                post={post}
                currentUser={currentUser}
                onVote={handleVote}
              />
            ))}
            <div ref={observerTarget} className="h-20 flex items-center justify-center">
              {isFetchingNextPage && <LoadingSpinner text="Fetching…" />}
            </div>
          </div>
        )}
      </div>
    </PageLayout>
  )
}

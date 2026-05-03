import { useInfiniteQuery, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback, useMemo } from 'react'
import { useNavigate } from 'react-router-dom'
import {
  Plus, Check, ChevronsUpDown, ImageIcon, Clock, TrendingUp, X
} from 'lucide-react'
import { Button } from './ui/button'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { Skeleton } from './ui/skeleton'
import { PageLayout } from './Navbar'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { usePostVoteMutation } from '../hooks/usePostVoteMutation'
import { PostType } from '../types/posts'
import { EmptyState } from './ui/empty-state'
import { LoadingSpinner } from './ui/loading-spinner'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { cn } from '../lib/utils'
import { fetchPosts, POST_TYPE_LABELS, POST_TYPE_ICONS } from '../api/posts'
import { fetchCommunities } from '../api/communities'
import { PostCard } from './PostCard'

export function Posts() {
  const navigate = useNavigate()
  const [selectedCommunities, setSelectedCommunities] = useState<number[]>([])
  const [selectedType, setSelectedType]         = useState<number | undefined>()
  const [sortBy, setSortBy]                     = useState('top')
  const [communityOpen, setCommunityOpen]         = useState(false)
  const observerTarget = useRef<HTMLDivElement>(null)

  const { data: currentUser } = useCurrentUser()

  const { data: communities } = useQuery({
    queryKey: ['communities'],
    queryFn: fetchCommunities,
    staleTime: Infinity,
    gcTime: Infinity,
  })

  const { data, fetchNextPage, hasNextPage, isFetchingNextPage, isLoading } = useInfiniteQuery({
    queryKey: ['posts', selectedCommunities, selectedType, sortBy],
    queryFn: ({ pageParam }) => fetchPosts({
      cursor: pageParam,
      communityIds: selectedCommunities.length > 0 ? selectedCommunities : undefined,
      type: selectedType,
      sortBy,
    }),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false,
  })

  const { handlePostVote } = usePostVoteMutation(['posts', selectedCommunities, selectedType, sortBy])

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



  return (
    <PageLayout>
      <div className="flex flex-col items-center justify-center gap-3 pb-6 mb-6 mt-2">
        <div className="flex flex-col items-center gap-3 w-fit max-w-full">
          <div className="flex items-center justify-center gap-3 overflow-x-auto no-scrollbar w-fit max-w-full">
            <div className="flex items-center gap-1 bg-muted/40 p-1 rounded-full border border-border/50 shrink-0">
              <button
                onClick={() => setSortBy('top')}
                className={cn("px-4 py-2 rounded-full text-sm font-medium transition-colors flex items-center gap-2", sortBy === 'top' ? "bg-background shadow-sm text-foreground" : "text-foreground hover:text-primary")}
              >
                <TrendingUp className="w-4 h-4" /> Top
              </button>
              <button
                onClick={() => setSortBy('new')}
                className={cn("px-4 py-2 rounded-full text-sm font-medium transition-colors flex items-center gap-2", sortBy === 'new' ? "bg-background shadow-sm text-foreground" : "text-foreground hover:text-primary")}
              >
                <Clock className="w-4 h-4" /> New
              </button>
            </div>

            <Popover open={communityOpen} onOpenChange={setCommunityOpen}>
              <PopoverTrigger asChild>
                <Button variant="outline" className="rounded-full h-10 gap-2 shrink-0 border-border/60 hover:border-primary/50 transition-colors">
                  {selectedCommunities.length === 0
                    ? 'All Communities'
                    : selectedCommunities.length === 1
                      ? communities?.find(c => c.id === selectedCommunities[0])?.name
                      : `${selectedCommunities.length} Communities`}
                  <ChevronsUpDown className="h-3 w-3 opacity-50 ml-1" />
                </Button>
              </PopoverTrigger>
              <PopoverContent className="w-56 p-0 rounded-2xl" align="start">
                <Command>
                  <CommandInput placeholder="Search communities…" className="h-10" />
                  <CommandList>
                    <CommandEmpty>No community found.</CommandEmpty>
                    <CommandGroup>
                      <CommandItem value="all" onSelect={() => { setSelectedCommunities([]); setCommunityOpen(false) }}>
                        <Check className={cn('mr-2 h-4 w-4', selectedCommunities.length === 0 ? 'opacity-100' : 'opacity-0')} />
                        All communities
                      </CommandItem>
                      {communities?.map(a => (
                        <CommandItem key={a.id} value={a.name} onSelect={() => {
                          setSelectedCommunities(prev =>
                            prev.includes(a.id)
                              ? prev.filter(id => id !== a.id)
                              : [...prev, a.id]
                          )
                        }}>
                          <Check className={cn('mr-2 h-4 w-4', selectedCommunities.includes(a.id) ? 'opacity-100' : 'opacity-0')} />
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

            <Button
              className="rounded-full shadow-sm hover:shadow-md transition-all px-6 shrink-0 flex items-center gap-2"
              onClick={() => navigate('/posts/create')}
            >
              <Plus className="h-4 w-4" />
              <span>Create Post</span>
            </Button>
          </div>

          {(selectedCommunities.length > 0 || selectedType !== undefined || sortBy !== 'top') && (
            <Button
              variant="outline"
              size="sm"
              className="rounded-full h-9 w-full text-destructive border-destructive/40 hover:bg-destructive hover:text-white hover:border-destructive transition-colors"
              onClick={() => { setSelectedCommunities([]); setSelectedType(undefined); setSortBy('top') }}
            >
              <X/> Reset filters
            </Button>
          )}
        </div>
      </div>

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
              title="There are no posts yet"
              action={selectedCommunities.length === 0 && !selectedType ? {
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
                onVote={handlePostVote}
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

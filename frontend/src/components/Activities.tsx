import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback, useMemo } from 'react'
import { toast } from 'sonner'
import { Search, Calendar, MapPin, DollarSign, Activity as ActivityIcon, X, Check, ChevronsUpDown } from 'lucide-react'
import { Button } from './ui/button'
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from './ui/card'
import { Badge } from './ui/badge'
import { Dialog, DialogContent, DialogDescription, DialogFooter, DialogHeader, DialogTitle } from './ui/dialog'
import { Input } from './ui/input'
import { Label } from './ui/label'
import { Textarea } from './ui/textarea'
import { Skeleton } from './ui/skeleton'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { PAGINATION } from '../config/constants'
import { EmptyState } from './ui/empty-state'
import { LoadingSpinner } from './ui/loading-spinner'
import { cn } from '../lib/utils'

interface Tag {
  id: number
  name: string
}

interface Category {
  id: number
  name: string
}

interface Activity {
  id: number
  title: string
  description: string
  categoryId: number
  category?: Category
  locationType: string
  costLevel?: string
  physicalActivityLevel?: string
  sociability?: string
  equipmentLevel?: string
  entryLevel?: string
  tags: Tag[]
  createdAt: string
  updatedAt: string
}

interface ScrollResult {
  items: Activity[]
  nextCursor: number | null
  hasMore: boolean
  totalCount: number
}

async function fetchActivities(cursor: number | null, categoryId?: number, tagIds?: number[], search?: string): Promise<ScrollResult> {
  const params = new URLSearchParams({
    limit: PAGINATION.DEFAULT_PAGE_SIZE.toString()
  })

  if (cursor !== null) {
    params.append('cursor', cursor.toString())
  }

  if (categoryId) {
    params.append('categoryId', categoryId.toString())
  }

  if (tagIds && tagIds.length > 0) {
    tagIds.forEach(id => params.append('tagIds', id.toString()))
  }

  if (search) {
    params.append('search', search)
  }

  const response = await fetch(`${API_ENDPOINTS.activities.base}?${params}`, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch activities')
  }

  return response.json()
}

async function fetchCategories(): Promise<Category[]> {
  const response = await fetch(API_ENDPOINTS.categories.base)

  if (!response.ok) {
    throw new Error('Failed to fetch categories')
  }

  return response.json()
}

async function fetchTags(): Promise<Tag[]> {
  const response = await fetch(API_ENDPOINTS.tags.base)

  if (!response.ok) {
    throw new Error('Failed to fetch tags')
  }

  return response.json()
}

interface ScheduleData {
  activityId: number
  plannedDate: string
  notes?: string
}

async function scheduleActivity(data: ScheduleData): Promise<void> {
  const response = await fetch(API_ENDPOINTS.schedules.base, {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(data)
  })

  if (!response.ok) {
    throw new Error('Failed to schedule activity')
  }
}

const locationLabels: Record<string, { label: string; icon: typeof MapPin }> = {
  'Indoor': { label: 'Indoor', icon: MapPin },
  'Outdoor': { label: 'Outdoor', icon: MapPin },
  'Online': { label: 'Online', icon: MapPin },
  'Any': { label: 'Any Location', icon: MapPin }
}

const costLabels: Record<string, { label: string; variant: 'default' | 'secondary' | 'outline' }> = {
  'Low': { label: '$', variant: 'secondary' },
  'Medium': { label: '$$', variant: 'secondary' },
  'High': { label: '$$$', variant: 'secondary' }
}

const physicalLabels: Record<string, { label: string; variant: 'default' | 'secondary' | 'outline' }> = {
  'Low': { label: 'Chill', variant: 'outline' },
  'Medium': { label: 'Moderate', variant: 'outline' },
  'High': { label: 'Intense', variant: 'outline' }
}

export function Activities() {
  const [selectedCategory, setSelectedCategory] = useState<number | undefined>(undefined)
  const [selectedTags, setSelectedTags] = useState<number[]>([])
  const [searchQuery, setSearchQuery] = useState('')
  const [debouncedSearch, setDebouncedSearch] = useState('')
  const [categoryOpen, setCategoryOpen] = useState(false)
  const [tagsOpen, setTagsOpen] = useState(false)
  const [scheduleDialogOpen, setScheduleDialogOpen] = useState(false)
  const [selectedActivityId, setSelectedActivityId] = useState<number | null>(null)
  const [plannedDate, setPlannedDate] = useState('')
  const [notes, setNotes] = useState('')
  const observerTarget = useRef<HTMLDivElement>(null)
  
  const queryClient = useQueryClient()

  // Debounce search input
  useEffect(() => {
    const timer = setTimeout(() => {
      setDebouncedSearch(searchQuery)
    }, 300)

    return () => clearTimeout(timer)
  }, [searchQuery])

  const { data: currentUser, isError, error: userError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: categories } = useQuery({
    queryKey: ['categories'],
    queryFn: fetchCategories
  })

  const { data: tags } = useQuery({
    queryKey: ['tags'],
    queryFn: fetchTags
  })

  const {
    data,
    fetchNextPage,
    hasNextPage,
    isFetchingNextPage,
    isLoading
  } = useInfiniteQuery({
    queryKey: ['activities', selectedCategory, selectedTags, debouncedSearch],
    queryFn: ({ pageParam }) => fetchActivities(pageParam, selectedCategory, selectedTags, debouncedSearch || undefined),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false
  })

  const scheduleMutation = useMutation({
    mutationFn: scheduleActivity,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['schedules'] })
      setScheduleDialogOpen(false)
      setSelectedActivityId(null)
      setPlannedDate('')
      setNotes('')
      toast.success('Activity scheduled successfully!')
    },
    onError: (error: Error) => {
      toast.error(error.message)
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
    }
  }, [handleObserver])

  const allActivities = useMemo(
    () => data?.pages.flatMap(page => page.items) ?? [],
    [data?.pages]
  )

  const totalCount = useMemo(
    () => data?.pages[0]?.totalCount ?? 0,
    [data?.pages]
  )

  const handleScheduleClick = (activityId: number) => {
    if (!currentUser) {
      toast.error('Please login to schedule activities')
      return
    }
    setSelectedActivityId(activityId)
    setScheduleDialogOpen(true)
  }

  const handleScheduleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    if (selectedActivityId && plannedDate) {
      const dateObj = new Date(plannedDate)
      dateObj.setHours(12, 0, 0, 0)
      
      scheduleMutation.mutate({
        activityId: selectedActivityId,
        plannedDate: dateObj.toISOString(),
        notes: notes || undefined
      })
    }
  }

  const handleTagToggle = (tagId: number) => {
    setSelectedTags(prev => 
      prev.includes(tagId) 
        ? prev.filter(id => id !== tagId)
        : [...prev, tagId]
    )
  }

  if (isError) {
    return null
  }

  const selectedActivity = allActivities.find(a => a.id === selectedActivityId)

  return (
    <PageLayout>
      {/* Improved header with integrated search */}
      <div className="mb-8">
        <div className="flex items-center justify-between mb-6">
          <div>
            <h1 className="text-3xl font-bold">
              Activities
            </h1>
            <p className="text-muted-foreground mt-1">
              {totalCount > 0 ? `${totalCount} activities` : 'Browse activities'}
            </p>
          </div>
        </div>
        
        {/* Search bar */}
        <div className="relative">
          <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-muted-foreground" />
          <Input
            placeholder="Search activities..."
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            className="pl-10"
          />
        </div>
      </div>

      {/* Compact filter chips */}
      <div className="mb-6 flex items-center gap-3 flex-wrap pb-4 border-b">
        {/* Category filter */}
        <Popover open={categoryOpen} onOpenChange={setCategoryOpen}>
          <PopoverTrigger asChild>
            <Button
              variant="outline"
              role="combobox"
              aria-expanded={categoryOpen}
              className="w-50 justify-between h-9"
            >
              {selectedCategory
                ? categories?.find((cat) => cat.id === selectedCategory)?.name
                : "All Categories"}
              <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
            </Button>
          </PopoverTrigger>
          <PopoverContent className="w-50 p-0" align="start">
            <Command>
              <CommandInput placeholder="Search categories..." />
              <CommandList>
                <CommandEmpty>No category found.</CommandEmpty>
                <CommandGroup>
                  <CommandItem
                    value="all"
                    onSelect={() => {
                      setSelectedCategory(undefined)
                      setCategoryOpen(false)
                    }}
                  >
                    <Check
                      className={cn(
                        "mr-2 h-4 w-4",
                        !selectedCategory ? "opacity-100" : "opacity-0"
                      )}
                    />
                    All Categories
                  </CommandItem>
                  {categories?.map((cat) => (
                    <CommandItem
                      key={cat.id}
                      value={cat.name}
                      onSelect={() => {
                        setSelectedCategory(cat.id)
                        setCategoryOpen(false)
                      }}
                    >
                      <Check
                        className={cn(
                          "mr-2 h-4 w-4",
                          selectedCategory === cat.id ? "opacity-100" : "opacity-0"
                        )}
                      />
                      {cat.name}
                    </CommandItem>
                  ))}
                </CommandGroup>
              </CommandList>
            </Command>
          </PopoverContent>
        </Popover>

        {/* Tags filter */}
        <Popover open={tagsOpen} onOpenChange={setTagsOpen}>
          <PopoverTrigger asChild>
            <Button
              variant="outline"
              role="combobox"
              aria-expanded={tagsOpen}
              className="w-50 justify-between h-9"
            >
              {selectedTags.length > 0
                ? `${selectedTags.length} tag${selectedTags.length > 1 ? 's' : ''} selected`
                : "Select tags"}
              <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
            </Button>
          </PopoverTrigger>
          <PopoverContent className="w-62.5 p-0" align="start">
            <Command>
              <CommandInput placeholder="Search tags..." />
              <CommandList>
                <CommandEmpty>No tag found.</CommandEmpty>
                <CommandGroup>
                  {tags?.map((tag) => (
                    <CommandItem
                      key={tag.id}
                      value={tag.name}
                      onSelect={() => handleTagToggle(tag.id)}
                    >
                      <Check
                        className={cn(
                          "mr-2 h-4 w-4",
                          selectedTags.includes(tag.id) ? "opacity-100" : "opacity-0"
                        )}
                      />
                      {tag.name}
                    </CommandItem>
                  ))}
                </CommandGroup>
              </CommandList>
            </Command>
          </PopoverContent>
        </Popover>

        {/* Selected tags as badges */}
        {selectedTags.length > 0 && (
          <>
            <div className="h-4 w-px bg-border" />
            {selectedTags.map((tagId) => {
              const tag = tags?.find(t => t.id === tagId)
              return tag ? (
                <Badge
                  key={tagId}
                  variant="secondary"
                  className="cursor-pointer gap-1"
                  onClick={() => handleTagToggle(tagId)}
                >
                  {tag.name}
                  <X className="h-3 w-3" />
                </Badge>
              ) : null
            })}
          </>
        )}

        {(selectedCategory || selectedTags.length > 0) && (
          <Button
            variant="ghost"
            size="sm"
            onClick={() => { 
              setSelectedCategory(undefined)
              setSelectedTags([])
            }}
            className="h-9 ml-auto"
          >
            Clear all
          </Button>
        )}
      </div>

      {/* Improved activity grid with better visual hierarchy */}
      {isLoading ? (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
          {[...Array(6)].map((_, i) => (
            <Card key={i}>
              <CardHeader>
                <Skeleton className="h-5 w-3/4" />
                <Skeleton className="h-4 w-1/4 mt-2" />
              </CardHeader>
              <CardContent>
                <Skeleton className="h-4 w-full" />
                <Skeleton className="h-4 w-5/6 mt-2" />
              </CardContent>
            </Card>
          ))}
        </div>
      ) : (
        <>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
            {allActivities.map((activity) => (
              <Card 
                key={activity.id} 
                className="cursor-pointer hover:shadow-md transition-shadow group"
                onClick={() => handleScheduleClick(activity.id)}
              >
                <CardHeader className="pb-3">
                  <div className="flex items-start justify-between gap-3 mb-2">
                    <CardTitle className="text-base">
                      {activity.title}
                    </CardTitle>
                    {activity.category && (
                      <Badge className="shrink-0">
                        {activity.category.name}
                      </Badge>
                    )}
                  </div>
                  <CardDescription className="line-clamp-2 text-sm">
                    {activity.description}
                  </CardDescription>
                </CardHeader>

                <CardContent className="space-y-4">
                  {/* Visual meta info grid */}
                  <div className="grid grid-cols-2 gap-2 text-sm">
                    {activity.locationType && locationLabels[activity.locationType] && (
                      <div className="flex items-center gap-1.5">
                        <MapPin className="h-4 w-4 shrink-0 text-blue-500" />
                        <span className="truncate">{locationLabels[activity.locationType].label}</span>
                      </div>
                    )}
                    {activity.costLevel && (
                      <div className="flex items-center gap-1.5">
                        <DollarSign className="h-4 w-4 shrink-0 text-green-500" />
                        <span>{costLabels[activity.costLevel]?.label || activity.costLevel}</span>
                      </div>
                    )}
                    {activity.physicalActivityLevel && (
                      <div className="flex items-center gap-1.5">
                        <ActivityIcon className="h-4 w-4 shrink-0 text-orange-500" />
                        <span>{physicalLabels[activity.physicalActivityLevel]?.label || activity.physicalActivityLevel}</span>
                      </div>
                    )}
                  </div>

                  {/* Tags with better styling */}
                  {activity.tags.length > 0 && (
                    <div className="flex gap-1.5 flex-wrap pt-2 border-t">
                      {activity.tags.slice(0, 4).map((tag) => (
                        <Badge key={tag.id} variant="secondary" className="text-xs font-normal">
                          {tag.name}
                        </Badge>
                      ))}
                      {activity.tags.length > 4 && (
                        <Badge variant="outline" className="text-xs">
                          +{activity.tags.length - 4}
                        </Badge>
                      )}
                    </div>
                  )}
                </CardContent>

                <CardFooter className="pt-0">
                  <Button
                    variant="outline"
                    size="sm"
                    className="w-full gap-2"
                    onClick={(e) => {
                      e.stopPropagation()
                      handleScheduleClick(activity.id)
                    }}
                  >
                    <Calendar className="h-4 w-4" />
                  </Button>
                </CardFooter>
              </Card>
            ))}
          </div>

          {allActivities.length === 0 && (
            <EmptyState
              icon={ActivityIcon}
              title={searchQuery ? 'No matching activities' : 'No activities found'}
              description={
                selectedCategory || selectedTags.length > 0 || searchQuery
                  ? 'Try adjusting your filters'
                  : 'Activities will appear here'
              }
            />
          )}

          {/* Infinite scroll target */}
          <div ref={observerTarget} className="h-10 flex items-center justify-center mt-8">
            {isFetchingNextPage && <LoadingSpinner text="Loading more..." />}
          </div>
        </>
      )}

      {/* Schedule Dialog */}
      <Dialog open={scheduleDialogOpen} onOpenChange={setScheduleDialogOpen}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Schedule Activity</DialogTitle>
            <DialogDescription>
              {selectedActivity?.title}
            </DialogDescription>
          </DialogHeader>

          <form onSubmit={handleScheduleSubmit} className="space-y-4">
            <div className="space-y-2">
              <Label htmlFor="planned-date">Planned Date</Label>
              <Input
                id="planned-date"
                type="date"
                value={plannedDate}
                onChange={(e) => setPlannedDate(e.target.value)}
                required
                min={new Date().toISOString().split('T')[0]}
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="notes">Notes (Optional)</Label>
              <Textarea
                id="notes"
                placeholder="Add any notes..."
                value={notes}
                onChange={(e) => setNotes(e.target.value)}
                rows={3}
              />
            </div>

            <DialogFooter>
              <Button
                type="button"
                variant="outline"
                onClick={() => setScheduleDialogOpen(false)}
              >
                Cancel
              </Button>
              <Button type="submit" disabled={scheduleMutation.isPending}>
                {scheduleMutation.isPending ? 'Scheduling...' : 'Schedule'}
              </Button>
            </DialogFooter>
          </form>
        </DialogContent>
      </Dialog>
    </PageLayout>
  )
}

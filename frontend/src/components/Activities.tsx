import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback, useMemo } from 'react'
import { toast } from 'sonner'
import { Search, Calendar, MapPin, DollarSign, Activity as ActivityIcon, X } from 'lucide-react'
import { Button } from './ui/button'
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from './ui/card'
import { Badge } from './ui/badge'
import { Dialog, DialogContent, DialogDescription, DialogFooter, DialogHeader, DialogTitle } from './ui/dialog'
import { Input } from './ui/input'
import { Label } from './ui/label'
import { Textarea } from './ui/textarea'
import { Skeleton } from './ui/skeleton'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { PAGINATION } from '../config/constants'
import { EmptyState } from './ui/empty-state'
import { LoadingSpinner } from './ui/loading-spinner'

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
  const [searchOpen, setSearchOpen] = useState(false)
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
            <h1 className="text-4xl font-bold bg-linear-to-r from-gray-900 to-gray-600 bg-clip-text text-transparent">
              Discover Activities
            </h1>
            <p className="text-muted-foreground mt-2">
              {totalCount > 0 ? `${totalCount} activities to explore` : 'Browse activities'}
            </p>
          </div>
        </div>
        
        {/* Prominent search bar */}
        <div className="relative max-w-2xl">
          <Search className="absolute left-4 top-1/2 -translate-y-1/2 h-5 w-5 text-muted-foreground" />
          <Input
            placeholder="Search for activities, locations, or experiences..."
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            className="pl-12 h-12 text-base shadow-sm"
          />
        </div>
      </div>

      {/* Compact filter chips */}
      <div className="mb-6 flex items-center gap-3 flex-wrap pb-4 border-b">
        {/* Category filter */}
        <Select 
          value={selectedCategory?.toString() ?? 'all'} 
          onValueChange={(value) => setSelectedCategory(value === 'all' ? undefined : Number(value))}
        >
          <SelectTrigger className="w-45 h-9">
            <SelectValue placeholder="All Categories" />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value="all">All Categories</SelectItem>
            {categories?.map((cat) => (
              <SelectItem key={cat.id} value={cat.id.toString()}>
                {cat.name}
              </SelectItem>
            ))}
          </SelectContent>
        </Select>

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
                  #{tag.name}
                  <X className="h-3 w-3" />
                </Badge>
              ) : null
            })}
          </>
        )}

        {/* Tag picker button */}
        <Button
          variant="outline"
          size="sm"
          onClick={() => setSearchOpen(!searchOpen)}
          className="h-9"
        >
          Add tags
        </Button>

        {(selectedCategory || selectedTags.length > 0) && (
          <Button
            variant="ghost"
            size="sm"
            onClick={() => { 
              setSelectedCategory(undefined)
              setSelectedTags([])
            }}
            className="h-9"
          >
            Clear all
          </Button>
        )}
      </div>

      {/* Tag selector dialog */}
      {searchOpen && tags && (
        <Card className="mb-6 border-2">
          <CardHeader className="pb-3">
            <CardTitle className="text-sm">Select Tags</CardTitle>
          </CardHeader>
          <CardContent className="flex gap-2 flex-wrap max-h-40 overflow-y-auto">
            {tags.map((tag) => (
              <Badge
                key={tag.id}
                variant={selectedTags.includes(tag.id) ? 'default' : 'outline'}
                className="cursor-pointer"
                onClick={() => handleTagToggle(tag.id)}
              >
                #{tag.name}
              </Badge>
            ))}
          </CardContent>
          <CardFooter>
            <Button variant="ghost" size="sm" onClick={() => setSearchOpen(false)} className="w-full">
              Done
            </Button>
          </CardFooter>
        </Card>
      )}

      {/* Improved activity grid with better visual hierarchy */}
      {isLoading ? (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5">
          {[...Array(6)].map((_, i) => (
            <Card key={i} className="overflow-hidden">
              <div className="h-2 bg-linear-to-r from-primary/20 to-primary/5" />
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
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5">
            {allActivities.map((activity) => (
              <Card 
                key={activity.id} 
                className="group hover:shadow-lg hover:scale-[1.02] transition-all duration-200 overflow-hidden cursor-pointer border-2 hover:border-primary/20"
                onClick={() => handleScheduleClick(activity.id)}
              >
                {/* Colored top accent */}
                <div className="h-1.5 bg-linear-to-r from-primary via-primary/70 to-primary/40" />
                
                <CardHeader className="pb-3">
                  <div className="flex items-start justify-between gap-3 mb-2">
                    <CardTitle className="text-lg leading-snug group-hover:text-primary transition-colors">
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
                      <div className="flex items-center gap-1.5 text-muted-foreground">
                        <MapPin className="h-4 w-4 shrink-0" />
                        <span className="truncate">{locationLabels[activity.locationType].label}</span>
                      </div>
                    )}
                    {activity.costLevel && (
                      <div className="flex items-center gap-1.5 text-muted-foreground">
                        <DollarSign className="h-4 w-4 shrink-0" />
                        <span>{costLabels[activity.costLevel]?.label || activity.costLevel}</span>
                      </div>
                    )}
                    {activity.physicalActivityLevel && (
                      <div className="flex items-center gap-1.5 text-muted-foreground">
                        <ActivityIcon className="h-4 w-4 shrink-0" />
                        <span>{physicalLabels[activity.physicalActivityLevel]?.label || activity.physicalActivityLevel}</span>
                      </div>
                    )}
                  </div>

                  {/* Tags with better styling */}
                  {activity.tags.length > 0 && (
                    <div className="flex gap-1.5 flex-wrap pt-2 border-t">
                      {activity.tags.slice(0, 4).map((tag) => (
                        <Badge key={tag.id} variant="secondary" className="text-xs font-normal">
                          #{tag.name}
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
                    variant="default"
                    size="sm"
                    className="w-full gap-2 opacity-0 group-hover:opacity-100 transition-opacity"
                    onClick={(e) => {
                      e.stopPropagation()
                      handleScheduleClick(activity.id)
                    }}
                  >
                    <Calendar className="h-4 w-4" />
                    Schedule Activity
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

import { useInfiniteQuery, useMutation, useQueryClient, useQuery } from '@tanstack/react-query'
import { useState, useEffect, useRef, useCallback, useMemo } from 'react'
import { toast } from 'sonner'
import {
  Search, Calendar, MapPin, DollarSign, Activity as ActivityIcon,
  X, Check, ChevronsUpDown, Zap, Users, Wrench, GraduationCap, Wifi
} from 'lucide-react'
import { Button } from './ui/button'
import { Card, CardContent, CardFooter, CardHeader, CardTitle, CardDescription } from './ui/card'
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

async function fetchActivities(
  cursor: number | null,
  categoryId?: number,
  tagIds?: number[],
  search?: string
): Promise<ScrollResult> {
  const params = new URLSearchParams({ limit: PAGINATION.DEFAULT_PAGE_SIZE.toString() })
  if (cursor !== null) params.append('cursor', cursor.toString())
  if (categoryId) params.append('categoryId', categoryId.toString())
  if (tagIds && tagIds.length > 0) tagIds.forEach(id => params.append('tagIds', id.toString()))
  if (search) params.append('search', search)

  const response = await fetch(`${API_ENDPOINTS.activities.base}?${params}`, {
    headers: getAuthHeaders(),
  })
  if (!response.ok) throw new Error('Failed to fetch activities')
  return response.json()
}

async function fetchCategories(): Promise<Category[]> {
  const response = await fetch(API_ENDPOINTS.categories.base, { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch categories')
  return response.json()
}

async function fetchTags(): Promise<Tag[]> {
  const response = await fetch(API_ENDPOINTS.tags.base, { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch tags')
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
    headers: { ...getAuthHeaders(), 'Content-Type': 'application/json' },
    body: JSON.stringify(data),
  })
  if (!response.ok) throw new Error('Failed to schedule activity')
}

// ── Label maps ────────────────────────────────────────────────────────────────

const locationConfig: Record<string, { label: string; icon: React.ReactNode }> = {
  Indoor:  { label: 'Indoor',    icon: <MapPin className="h-3.5 w-3.5" /> },
  Outdoor: { label: 'Outdoor',   icon: <MapPin className="h-3.5 w-3.5" /> },
  Online:  { label: 'Online',    icon: <Wifi   className="h-3.5 w-3.5" /> },
  Any:     { label: 'Anywhere',  icon: <MapPin className="h-3.5 w-3.5" /> },
}

// No $ icon — just the label to avoid duplication with DollarSign icon
const costConfig: Record<string, { label: string; title: string }> = {
  Low:    { label: '$',   title: 'Budget-friendly' },
  Medium: { label: '$$',  title: 'Moderate cost' },
  High:   { label: '$$$', title: 'Premium' },
}

const physicalConfig: Record<string, { label: string }> = {
  Low:    { label: 'Chill' },
  Medium: { label: 'Moderate' },
  High:   { label: 'Intense' },
}

const sociabilityConfig: Record<string, { label: string }> = {
  Solo:   { label: 'Solo' },
  Group:  { label: 'Group' },
  Either: { label: 'Solo or group' },
}

const equipmentConfig: Record<string, { label: string }> = {
  None:     { label: 'No gear needed' },
  Minimal:  { label: 'Minimal gear' },
  Required: { label: 'Gear required' },
}

const entryConfig: Record<string, { label: string }> = {
  Beginner:     { label: 'Beginner' },
  Intermediate: { label: 'Intermediate' },
  Advanced:     { label: 'Advanced' },
  Any:          { label: 'All levels' },
}

// ── ActivityCard ──────────────────────────────────────────────────────────────

function ActivityCard({
  activity,
  onSchedule,
}: {
  activity: Activity
  onSchedule: (id: number) => void
}) {
  const loc     = activity.locationType ? locationConfig[activity.locationType] : null
  const cost    = activity.costLevel ? costConfig[activity.costLevel] : null
  const phys    = activity.physicalActivityLevel ? physicalConfig[activity.physicalActivityLevel] : null
  const social  = activity.sociability ? sociabilityConfig[activity.sociability] : null
  const equip   = activity.equipmentLevel ? equipmentConfig[activity.equipmentLevel] : null
  const entry   = activity.entryLevel ? entryConfig[activity.entryLevel] : null

  return (
    <Card className="flex flex-col h-full hover:shadow-sm transition-shadow">
      <CardHeader className="pb-2">
        <div className="flex items-start justify-between gap-2">
          <CardTitle className="text-base leading-snug">{activity.title}</CardTitle>
          {activity.category && (
            <Badge variant="secondary" className="shrink-0 text-xs">
              {activity.category.name}
            </Badge>
          )}
        </div>
        <CardDescription className="line-clamp-2 text-xs mt-1">
          {activity.description}
        </CardDescription>
      </CardHeader>

      <CardContent className="flex-1 space-y-3 pb-3">
        {/* Primary meta — location, cost, physical */}
        <div className="flex flex-wrap gap-x-3 gap-y-1.5 text-xs text-muted-foreground">
          {loc && (
            <span className="flex items-center gap-1">
              {loc.icon}
              {loc.label}
            </span>
          )}
          {cost && (
            <span
              className="flex items-center gap-1"
              title={cost.title}
            >
              <DollarSign className="h-3.5 w-3.5" />
              {/* Just the label — icon is the currency indicator, no duplicate $ */}
              <span>{cost.label}</span>
            </span>
          )}
          {phys && (
            <span className="flex items-center gap-1">
              <Zap className="h-3.5 w-3.5" />
              {phys.label}
            </span>
          )}
        </div>

        {/* Secondary meta — sociability, equipment, entry level */}
        {(social || equip || entry) && (
          <div className="flex flex-wrap gap-1.5">
            {social && (
              <span className="inline-flex items-center gap-1 text-xs bg-muted rounded-md px-2 py-0.5">
                <Users className="h-3 w-3" />
                {social.label}
              </span>
            )}
            {equip && (
              <span className="inline-flex items-center gap-1 text-xs bg-muted rounded-md px-2 py-0.5">
                <Wrench className="h-3 w-3" />
                {equip.label}
              </span>
            )}
            {entry && (
              <span className="inline-flex items-center gap-1 text-xs bg-muted rounded-md px-2 py-0.5">
                <GraduationCap className="h-3 w-3" />
                {entry.label}
              </span>
            )}
          </div>
        )}

        {/* Tags */}
        {activity.tags.length > 0 && (
          <div className="flex gap-1 flex-wrap pt-1 border-t">
            {activity.tags.slice(0, 4).map(tag => (
              <Badge key={tag.id} variant="outline" className="text-xs font-normal">
                {tag.name}
              </Badge>
            ))}
            {activity.tags.length > 4 && (
              <Badge variant="outline" className="text-xs text-muted-foreground">
                +{activity.tags.length - 4}
              </Badge>
            )}
          </div>
        )}
      </CardContent>

      {/* Footer — only the button is clickable, not the whole card */}
      <CardFooter className="pt-0">
        <Button
          type="button"
          variant="outline"
          size="sm"
          className="w-full gap-2 text-xs"
          onClick={() => onSchedule(activity.id)}
        >
          <Calendar className="h-3.5 w-3.5" />
          Schedule
        </Button>
      </CardFooter>
    </Card>
  )
}

// ── Main component ────────────────────────────────────────────────────────────

export function Activities() {
  const [selectedCategory, setSelectedCategory] = useState<number | undefined>(undefined)
  const [selectedTags, setSelectedTags]         = useState<number[]>([])
  const [searchQuery, setSearchQuery]           = useState('')
  const [debouncedSearch, setDebouncedSearch]   = useState('')
  const [categoryOpen, setCategoryOpen]         = useState(false)
  const [tagsOpen, setTagsOpen]                 = useState(false)
  const [scheduleDialogOpen, setScheduleDialogOpen] = useState(false)
  const [selectedActivityId, setSelectedActivityId] = useState<number | null>(null)
  const [plannedDate, setPlannedDate]           = useState('')
  const [notes, setNotes]                       = useState('')
  const observerTarget = useRef<HTMLDivElement>(null)
  const queryClient = useQueryClient()

  useEffect(() => {
    const t = setTimeout(() => setDebouncedSearch(searchQuery), 300)
    return () => clearTimeout(t)
  }, [searchQuery])

  const { data: currentUser, isError, error: userError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false,
  })

  const { data: categories } = useQuery({ queryKey: ['categories'], queryFn: fetchCategories })
  const { data: tags }       = useQuery({ queryKey: ['tags'],       queryFn: fetchTags })

  const { data, fetchNextPage, hasNextPage, isFetchingNextPage, isLoading } = useInfiniteQuery({
    queryKey: ['activities', selectedCategory, selectedTags, debouncedSearch],
    queryFn: ({ pageParam }) =>
      fetchActivities(pageParam, selectedCategory, selectedTags, debouncedSearch || undefined),
    getNextPageParam: (lastPage) => lastPage.hasMore ? lastPage.nextCursor : undefined,
    initialPageParam: null as number | null,
    retry: false,
  })

  const scheduleMutation = useMutation({
    mutationFn: scheduleActivity,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['schedules'] })
      setScheduleDialogOpen(false)
      setSelectedActivityId(null)
      setPlannedDate('')
      setNotes('')
      toast.success('Activity scheduled!')
    },
    onError: (error: Error) => toast.error(error.message),
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

  const allActivities = useMemo(
    () => data?.pages.flatMap(p => p.items) ?? [],
    [data?.pages]
  )
  const totalCount = data?.pages[0]?.totalCount ?? 0

  const handleScheduleClick = (activityId: number) => {
    if (!currentUser) {
      toast.error('Please log in to schedule activities')
      return
    }
    setSelectedActivityId(activityId)
    setScheduleDialogOpen(true)
  }

  const handleScheduleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    if (!selectedActivityId || !plannedDate) return
    const dateObj = new Date(plannedDate)
    dateObj.setHours(12, 0, 0, 0)
    scheduleMutation.mutate({
      activityId: selectedActivityId,
      plannedDate: dateObj.toISOString(),
      notes: notes || undefined,
    })
  }

  const handleTagToggle = (tagId: number) =>
    setSelectedTags(prev =>
      prev.includes(tagId) ? prev.filter(id => id !== tagId) : [...prev, tagId]
    )

  const hasFilters = !!(selectedCategory || selectedTags.length > 0)
  const selectedActivity = allActivities.find(a => a.id === selectedActivityId)

  if (isError) return null

  return (
    <PageLayout>
      {/* Header */}
      <div className="mb-6">
        <div className="flex items-baseline justify-between mb-4">
          <div>
            <h1 className="text-2xl font-bold">Activities</h1>
            <p className="text-sm text-muted-foreground mt-0.5">
              {totalCount > 0 ? `${totalCount} activities` : 'Browse activities'}
            </p>
          </div>
        </div>

        <div className="relative">
          <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-muted-foreground" />
          <Input
            placeholder="Search activities…"
            value={searchQuery}
            onChange={e => setSearchQuery(e.target.value)}
            className="pl-9"
          />
        </div>
      </div>

      {/* Filters */}
      <div className="mb-5 flex items-center gap-2 flex-wrap pb-4 border-b">
        {/* Category */}
        <Popover open={categoryOpen} onOpenChange={setCategoryOpen}>
          <PopoverTrigger asChild>
            <Button variant="outline" role="combobox" aria-expanded={categoryOpen} className="h-8 text-xs gap-1.5">
              {selectedCategory
                ? categories?.find(c => c.id === selectedCategory)?.name
                : 'Category'}
              <ChevronsUpDown className="h-3.5 w-3.5 shrink-0 opacity-50" />
            </Button>
          </PopoverTrigger>
          <PopoverContent className="w-48 p-0" align="start">
            <Command>
              <CommandInput placeholder="Search…" />
              <CommandList>
                <CommandEmpty>No category found.</CommandEmpty>
                <CommandGroup>
                  <CommandItem value="all" onSelect={() => { setSelectedCategory(undefined); setCategoryOpen(false) }}>
                    <Check className={cn('mr-2 h-4 w-4', !selectedCategory ? 'opacity-100' : 'opacity-0')} />
                    All categories
                  </CommandItem>
                  {categories?.map(cat => (
                    <CommandItem
                      key={cat.id}
                      value={cat.name}
                      onSelect={() => { setSelectedCategory(cat.id); setCategoryOpen(false) }}
                    >
                      <Check className={cn('mr-2 h-4 w-4', selectedCategory === cat.id ? 'opacity-100' : 'opacity-0')} />
                      {cat.name}
                    </CommandItem>
                  ))}
                </CommandGroup>
              </CommandList>
            </Command>
          </PopoverContent>
        </Popover>

        {/* Tags */}
        <Popover open={tagsOpen} onOpenChange={setTagsOpen}>
          <PopoverTrigger asChild>
            <Button variant="outline" role="combobox" aria-expanded={tagsOpen} className="h-8 text-xs gap-1.5">
              {selectedTags.length > 0 ? `${selectedTags.length} tag${selectedTags.length > 1 ? 's' : ''}` : 'Tags'}
              <ChevronsUpDown className="h-3.5 w-3.5 shrink-0 opacity-50" />
            </Button>
          </PopoverTrigger>
          <PopoverContent className="w-52 p-0" align="start">
            <Command>
              <CommandInput placeholder="Search tags…" />
              <CommandList>
                <CommandEmpty>No tag found.</CommandEmpty>
                <CommandGroup>
                  {tags?.map(tag => (
                    <CommandItem key={tag.id} value={tag.name} onSelect={() => handleTagToggle(tag.id)}>
                      <Check className={cn('mr-2 h-4 w-4', selectedTags.includes(tag.id) ? 'opacity-100' : 'opacity-0')} />
                      {tag.name}
                    </CommandItem>
                  ))}
                </CommandGroup>
              </CommandList>
            </Command>
          </PopoverContent>
        </Popover>

        {/* Active tag chips */}
        {selectedTags.length > 0 && (
          <>
            <div className="h-4 w-px bg-border" />
            {selectedTags.map(tagId => {
              const tag = tags?.find(t => t.id === tagId)
              return tag ? (
                <Badge
                  key={tagId}
                  variant="secondary"
                  className="cursor-pointer gap-1 text-xs h-8 px-2"
                  onClick={() => handleTagToggle(tagId)}
                >
                  {tag.name}
                  <X className="h-3 w-3" />
                </Badge>
              ) : null
            })}
          </>
        )}

        {hasFilters && (
          <Button
            type="button"
            variant="ghost"
            size="sm"
            onClick={() => { setSelectedCategory(undefined); setSelectedTags([]) }}
            className="h-8 text-xs ml-auto"
          >
            Clear filters
          </Button>
        )}
      </div>

      {/* Grid */}
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
      ) : allActivities.length === 0 ? (
        <EmptyState
          icon={ActivityIcon}
          title={searchQuery ? 'No matching activities' : 'No activities yet'}
          description={
            hasFilters || searchQuery
              ? 'Try adjusting your filters'
              : 'Activities will appear here'
          }
        />
      ) : (
        <>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
            {allActivities.map(activity => (
              <ActivityCard
                key={activity.id}
                activity={activity}
                onSchedule={handleScheduleClick}
              />
            ))}
          </div>

          <div ref={observerTarget} className="h-10 flex items-center justify-center mt-8">
            {isFetchingNextPage && <LoadingSpinner text="Loading more…" />}
          </div>
        </>
      )}

      {/* Schedule dialog */}
      <Dialog open={scheduleDialogOpen} onOpenChange={setScheduleDialogOpen}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Schedule activity</DialogTitle>
            {selectedActivity && (
              <DialogDescription>{selectedActivity.title}</DialogDescription>
            )}
          </DialogHeader>

          <form onSubmit={handleScheduleSubmit} className="space-y-4">
            <div className="space-y-1.5">
              <Label htmlFor="planned-date">Date</Label>
              <Input
                id="planned-date"
                type="date"
                value={plannedDate}
                onChange={e => setPlannedDate(e.target.value)}
                required
                min={new Date().toISOString().split('T')[0]}
              />
            </div>

            <div className="space-y-1.5">
              <Label htmlFor="notes">Notes <span className="text-muted-foreground font-normal">(optional)</span></Label>
              <Textarea
                id="notes"
                placeholder="Any notes…"
                value={notes}
                onChange={e => setNotes(e.target.value)}
                rows={3}
              />
            </div>

            <DialogFooter>
              <Button type="button" variant="outline" onClick={() => setScheduleDialogOpen(false)}>
                Cancel
              </Button>
              <Button type="submit" disabled={!plannedDate || scheduleMutation.isPending}>
                {scheduleMutation.isPending ? 'Scheduling…' : 'Schedule'}
              </Button>
            </DialogFooter>
          </form>
        </DialogContent>
      </Dialog>
    </PageLayout>
  )
}

import { useState, useMemo } from 'react'
import { useNavigate, Navigate } from 'react-router-dom'
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import {
  Check,
  ChevronsUpDown,
  FileText,
  MapPin,
  Star,
  Clock,
  Euro,
  ArrowLeft
} from 'lucide-react'

import { Button } from './ui/button'
import { Input } from './ui/input'
import { Textarea } from './ui/textarea'
import { Card, CardContent, CardHeader, CardTitle } from './ui/card'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PostType } from '../types/posts'
import type { CreatePostRequest } from '../types/posts'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { PAGINATION } from '../config/constants'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { cn } from '../lib/utils'

interface Activity {
  id: number
  title: string
}

async function fetchActivities(): Promise<Activity[]> {
  const response = await fetch(
    `${API_ENDPOINTS.activities.base}?limit=${PAGINATION.ACTIVITIES_FETCH_SIZE}`,
    { headers: getAuthHeaders() }
  )

  if (!response.ok) throw new Error('Failed to fetch activities')
  const data = await response.json()
  return data.items || []
}

async function createPost(data: CreatePostRequest): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.base, {
    method: 'POST',
    headers: getAuthHeaders(),
    body: JSON.stringify(data)
  })

  if (!response.ok) {
    let msg = 'Failed to create post'
    try { msg = (await response.json()).message || msg } catch {}
    throw new Error(msg)
  }
}

/* ---------- Field wrapper ---------- */

function Field({
  label,
  icon,
  children
}: {
  label: string
  icon?: React.ReactNode
  children: React.ReactNode
}) {
  return (
    <div className="space-y-2">
      <label className="flex items-center gap-2 text-sm font-medium text-muted-foreground">
        {icon}
        {label}
      </label>
      {children}
    </div>
  )
}

/* ---------- Component ---------- */

export function CreatePost() {
  const navigate = useNavigate()
  const queryClient = useQueryClient()

  const [title, setTitle] = useState('')
  const [content, setContent] = useState('')
  const [type, setType] = useState<number>(PostType.ExperienceShare)
  const [activityId, setActivityId] = useState<number | ''>('')

  const [activityOpen, setActivityOpen] = useState(false)
  const [locationName, setLocationName] = useState('')
  const [rating, setRating] = useState<number | ''>('')
  const [durationMinutes, setDurationMinutes] = useState<number | ''>('')
  const [cost, setCost] = useState<number | ''>('')
  const [currencyCode, setCurrencyCode] = useState('EUR')

  const { data: currentUser, isError, error: userError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: activities, isLoading: activitiesLoading } = useQuery({
    queryKey: ['activities'],
    queryFn: fetchActivities
  })

  useAuthErrorHandler(isError, userError)

  const selectedActivity = useMemo(
    () => activities?.find(a => a.id === activityId),
    [activities, activityId]
  )

  const createMutation = useMutation({
    mutationFn: createPost,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      toast.success('Post created successfully!')
      navigate('/posts')
    },
    onError: (e: Error) => toast.error(e.message)
  })

  if (isError) return null
  if (!currentUser) return <Navigate to="/login" replace />

  const parse = (v: number | '' | undefined) =>
    v === '' || v === undefined ? undefined : Number(v)

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()

    if (!activityId) {
      toast.error('Select an activity')
      return
    }

    const post: CreatePostRequest = {
      title,
      content,
      type,
      activityId: Number(activityId),
      locationName: locationName || undefined,
      rating: parse(rating),
      durationMinutes: parse(durationMinutes),
      cost: parse(cost),
      currencyCode: cost ? currencyCode : undefined
    }

    createMutation.mutate(post)
  }

  const isValid =
    title.length >= 3 &&
    content.length >= 10 &&
    activityId !== ''

  return (
    <PageLayout>
      <div className="max-w-2xl mx-auto space-y-6">

        <Button
          variant="ghost"
          className="w-fit"
          onClick={() => navigate('/posts')}
        >
          <ArrowLeft className="w-4 h-4 mr-2" />
          Back to posts
        </Button>

        <Card>
          <CardHeader>
            <CardTitle>New Post</CardTitle>
          </CardHeader>

          <CardContent>
            <form onSubmit={handleSubmit} className="space-y-8">

              <section className="space-y-6">

                <Field label="Post Type">
                  <Select value={type.toString()} onValueChange={v => setType(Number(v))}>
                    <SelectTrigger>
                      <SelectValue placeholder="Select type" />
                    </SelectTrigger>
                    <SelectContent>
                      {Object.values(PostType)
                        .filter(v => typeof v === 'number')
                        .map(v => {
                          const label = Object.keys(PostType).find(
                            key => (PostType as any)[key] === v
                          )
                          return (
                            <SelectItem key={v} value={String(v)}>
                              {label}
                            </SelectItem>
                          )
                        })}
                    </SelectContent>
                  </Select>
                </Field>

                <Field label="Activity">
                  <Popover open={activityOpen} onOpenChange={setActivityOpen}>
                    <PopoverTrigger asChild>
                      <Button variant="outline" className="justify-between w-full">
                        {selectedActivity?.title ||
                          (activitiesLoading ? 'Loading...' : 'Select activity')}
                        <ChevronsUpDown className="w-4 h-4 opacity-50" />
                      </Button>
                    </PopoverTrigger>

                    <PopoverContent className="p-0">
                      <Command>
                        <CommandInput placeholder="Search..." />
                        <CommandList>
                          <CommandEmpty>No results</CommandEmpty>
                          <CommandGroup>
                            {activities?.map(a => (
                              <CommandItem
                                key={a.id}
                                value={a.title}
                                onSelect={() => {
                                  setActivityId(a.id)
                                  setActivityOpen(false)
                                }}
                              >
                                <Check
                                  className={cn(
                                    "mr-2 h-4 w-4",
                                    activityId === a.id ? "opacity-100" : "opacity-0"
                                  )}
                                />
                                {a.title}
                              </CommandItem>
                            ))}
                          </CommandGroup>
                        </CommandList>
                      </Command>
                    </PopoverContent>
                  </Popover>
                </Field>

                <Field label="Title" icon={<FileText className="w-4 h-4" />}>
                  <Input value={title} onChange={e => setTitle(e.target.value)} maxLength={200} />
                </Field>

                <Field label="Content">
                  <Textarea
                    value={content}
                    onChange={e => setContent(e.target.value)}
                    rows={6}
                    maxLength={2000}
                  />
                </Field>
              </section>

              <section className="space-y-6">

                <Field label="Location" icon={<MapPin className="w-4 h-4" />}>
                  <Input value={locationName} onChange={e => setLocationName(e.target.value)} />
                </Field>

                <Field label="Rating" icon={<Star className="w-4 h-4" />}>
                  <Select
                    value={rating === '' ? '' : String(rating)}
                    onValueChange={v => setRating(v ? Number(v) : '')}
                  >
                    <SelectTrigger>
                      <SelectValue placeholder="No rating" />
                    </SelectTrigger>
                    <SelectContent>
                      {[5,4,3,2,1].map(r => (
                        <SelectItem key={r} value={String(r)}>
                          {'⭐'.repeat(r)}
                        </SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
                </Field>

                <Field label="Duration (min)" icon={<Clock className="w-4 h-4" />}>
                  <Input
                    type="number"
                    value={durationMinutes}
                    onChange={e =>
                      setDurationMinutes(e.target.value ? Number(e.target.value) : '')
                    }
                  />
                </Field>

                <Field label="Cost" icon={<Euro className="w-4 h-4" />}>
                  <div className="flex gap-2">
                    <Input
                      type="number"
                      value={cost}
                      onChange={e => setCost(e.target.value ? Number(e.target.value) : '')}
                    />
                    <Select value={currencyCode} onValueChange={setCurrencyCode}>
                      <SelectTrigger className="w-28">
                        <SelectValue />
                      </SelectTrigger>
                      <SelectContent>
                        <SelectItem value="EUR">EUR</SelectItem>
                        <SelectItem value="USD">USD</SelectItem>
                        <SelectItem value="GBP">GBP</SelectItem>
                      </SelectContent>
                    </Select>
                  </div>
                </Field>

              </section>

              <div className="flex justify-end gap-3 pt-6 border-t">
                <Button variant="outline" onClick={() => navigate('/posts')}>
                  Cancel
                </Button>
                <Button type="submit" disabled={!isValid || createMutation.isPending}>
                  {createMutation.isPending ? 'Creating…' : 'Create Post'}
                </Button>
              </div>

            </form>
          </CardContent>
        </Card>
      </div>
    </PageLayout>
  )
}

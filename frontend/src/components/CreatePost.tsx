import { useState, useMemo } from 'react'
import { useNavigate, Navigate } from 'react-router-dom'
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import {
  Check,
  ChevronsUpDown,
  FileText,
  MapPin,
  ArrowLeft
} from 'lucide-react'

import { Button } from './ui/button'
import { Input } from './ui/input'
import { Textarea } from './ui/textarea'
import { Card, CardContent, CardHeader, CardTitle } from './ui/card'
import { PageLayout } from './Navbar'
import { Label } from '@/components/ui/label'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PostType } from '../types/posts'
import type { CreatePostRequest } from '../types/posts'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from './ui/select'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from './ui/command'
import { cn } from '../lib/utils'
import { PhotoUpload } from './PhotoUpload'

interface Community {
  id: number
  name: string
}

async function fetchCommunities(): Promise<Community[]> {
  const response = await fetch(API_ENDPOINTS.communities.base, { headers: getAuthHeaders() })

  if (!response.ok) throw new Error('Failed to fetch communities')
  return response.json()
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
  const [description, setDescription] = useState('')
  const [type, setType] = useState<number>(PostType.ExperienceShare)
  const [topicId, setCommunityId] = useState<number | ''>('')

  const [communityOpen, setCommunityOpen] = useState(false)
  const [locationName, setLocationName] = useState('')
  const [photoUrls, setPhotoUrls] = useState<string[]>([])

  const { data: currentUser, isError, error: userError } = useCurrentUser()

  const { data: communities, isLoading: communitiesLoading } = useQuery({
    queryKey: ['communities'],
    queryFn: fetchCommunities
  })

  useAuthErrorHandler(isError, userError)

  const selectedCommunity = useMemo(
    () => communities?.find(a => a.id === topicId),
    [communities, topicId]
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

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()

    if (!topicId) {
      toast.error('Select a community')
      return
    }

    const post: CreatePostRequest = {
      title,
      description,
      type,
      topicId: Number(topicId),
      locationName: locationName || undefined,
      photoUrls
    }

    createMutation.mutate(post)
  }

  const isValid =
    title.length >= 3 &&
    description.length >= 10 &&
    topicId !== ''

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

                <Field label="Community">
                  <Popover open={communityOpen} onOpenChange={setCommunityOpen}>
                    <PopoverTrigger asChild>
                      <Button variant="outline" className="justify-between w-full">
                        {selectedCommunity?.name ||
                          (communitiesLoading ? 'Loading...' : 'Select community')}
                        <ChevronsUpDown className="w-4 h-4 opacity-50" />
                      </Button>
                    </PopoverTrigger>

                    <PopoverContent className="p-0">
                      <Command>
                        <CommandInput placeholder="Search..." />
                        <CommandList>
                          <CommandEmpty>No results</CommandEmpty>
                          <CommandGroup>
                            {communities?.map(c => (
                              <CommandItem
                                key={c.id}
                                value={c.name}
                                onSelect={() => {
                                  setCommunityId(c.id)
                                  setCommunityOpen(false)
                                }}
                              >
                                <Check
                                  className={cn(
                                    "mr-2 h-4 w-4",
                                    topicId === c.id ? "opacity-100" : "opacity-0"
                                  )}
                                />
                                {c.name}
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

                <Field label="Description">
                  <Textarea
                    value={description}
                    onChange={e => setDescription(e.target.value)}
                    rows={6}
                    maxLength={1000}
                  />
                </Field>
              </section>

              <section className="space-y-6">

                <Field label="Location" icon={<MapPin className="w-4 h-4" />}>
                  <Input value={locationName} onChange={e => setLocationName(e.target.value)} />
                </Field>

              </section>

              <div className="space-y-1.5">
                <Label>
                  Photos <span className="text-muted-foreground font-normal">(optional)</span>
                </Label>
                <PhotoUpload
                  value={photoUrls}
                  onChange={setPhotoUrls}
                  maxPhotos={4}
                />
              </div>

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


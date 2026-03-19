import { useMemo, useState } from 'react'
import { useQuery } from '@tanstack/react-query'
import { Search, Users } from 'lucide-react'
import { PageLayout } from './Navbar'
import { Card, CardContent, CardHeader, CardTitle, CardDescription } from './ui/card'
import { Input } from './ui/input'
import { Skeleton } from './ui/skeleton'
import { EmptyState } from './ui/empty-state'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'

interface Community {
  id: number
  name: string
  description?: string | null
}

async function fetchCommunities(): Promise<Community[]> {
  const response = await fetch(API_ENDPOINTS.communities.base, { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch communities')
  return response.json()
}

export function Communities() {
  const [search, setSearch] = useState('')

  const { data: communities, isLoading } = useQuery({
    queryKey: ['communities'],
    queryFn: fetchCommunities,
    retry: false,
  })

  const filtered = useMemo(() => {
    const q = search.trim().toLowerCase()
    if (!q) return communities ?? []

    return (communities ?? []).filter(c =>
      c.name.toLowerCase().includes(q) ||
      (c.description ?? '').toLowerCase().includes(q)
    )
  }, [communities, search])

  return (
    <PageLayout>
      <div className="mb-6">
        <h1 className="text-2xl font-bold">Communities</h1>
        <p className="text-sm text-muted-foreground mt-0.5">
          {communities?.length ? `${communities.length} communities` : 'Browse communities'}
        </p>
      </div>

      <div className="relative mb-6">
        <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-muted-foreground" />
        <Input
          value={search}
          onChange={e => setSearch(e.target.value)}
          className="pl-9"
          placeholder="Search communities..."
        />
      </div>

      {isLoading ? (
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
          {Array.from({ length: 6 }).map((_, i) => (
            <Card key={i}>
              <CardHeader>
                <Skeleton className="h-4 w-2/3" />
                <Skeleton className="h-3 w-full" />
              </CardHeader>
              <CardContent>
                <Skeleton className="h-3 w-5/6" />
              </CardContent>
            </Card>
          ))}
        </div>
      ) : filtered.length === 0 ? (
        <EmptyState
          icon={Users}
          title="No communities found"
          description="Try a different search term."
        />
      ) : (
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
          {filtered.map(community => (
            <Card key={community.id} className="h-full">
              <CardHeader className="pb-2">
                <CardTitle className="text-base">{community.name}</CardTitle>
                <CardDescription>
                  {community.description || 'No description yet.'}
                </CardDescription>
              </CardHeader>
            </Card>
          ))}
        </div>
      )}
    </PageLayout>
  )
}

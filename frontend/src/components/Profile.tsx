import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useMemo } from 'react'
import { toast } from 'sonner'
import { Check, X, Calendar } from 'lucide-react'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { formatDate } from '../lib/utils/date'
import { EmptyState } from './ui/empty-state'
import { Button } from './ui/button'
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from './ui/card'
import { Avatar, AvatarFallback } from './ui/avatar'
import { Badge } from './ui/badge'
import { Tabs, TabsContent, TabsList, TabsTrigger } from './ui/tabs'
import { Separator } from './ui/separator'
import { Skeleton } from './ui/skeleton'

interface ActivitySchedule {
  id: number
  activityId: number
  plannedDate: string
  completedDate?: string
  status: string
  notes?: string
  activity: {
    id: number
    title: string
    description: string
    category?: {
      id: number
      name: string
    }
    tags: Array<{
      id: number
      name: string
    }>
  }
}

async function fetchPlannedActivities(): Promise<ActivitySchedule[]> {
  const response = await fetch(API_ENDPOINTS.schedules.planned, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch planned activities')
  }

  return response.json()
}

async function fetchHistoryActivities(): Promise<ActivitySchedule[]> {
  const response = await fetch(API_ENDPOINTS.schedules.history, {
    headers: getAuthHeaders()
  })

  if (!response.ok) {
    throw new Error('Failed to fetch history')
  }

  return response.json()
}

export function Profile() {
  const queryClient = useQueryClient()

  
  const { data: user, isLoading, isError, error: userError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  const { data: plannedActivities, error: plannedError } = useQuery({
    queryKey: ['schedules', 'planned'],
    queryFn: fetchPlannedActivities,
    retry: false,
    enabled: !!user
  })

  const { data: historyActivities, error: historyError } = useQuery({
    queryKey: ['schedules', 'history'],
    queryFn: fetchHistoryActivities,
    retry: false,
    enabled: !!user
  })

  const completeMutation = useMutation({
    mutationFn: async (scheduleId: number) => {
      const response = await fetch(API_ENDPOINTS.schedules.complete(scheduleId), {
        method: 'PATCH',
        headers: getAuthHeaders(),
        body: JSON.stringify({})
      })

      if (!response.ok) {
        throw new Error('Failed to mark as completed')
      }

      return response.json()
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['schedules'] })
      toast.success('Activity marked as completed!')
    },
    onError: (error: Error) => {
      toast.error(error.message)
    }
  })

  const cancelMutation = useMutation({
    mutationFn: async (scheduleId: number) => {
      const response = await fetch(API_ENDPOINTS.schedules.cancel(scheduleId), {
        method: 'PATCH',
        headers: getAuthHeaders()
      })

      if (!response.ok) {
        throw new Error('Failed to cancel')
      }

      return response.json()
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['schedules'] })
      toast.success('Activity cancelled')
    },
    onError: (error: Error) => {
      toast.error(error.message)
    }
  })



  useAuthErrorHandler(isError, userError)

  const completedCount = useMemo(
    () => historyActivities?.filter(s => s.status === 'Completed').length ?? 0,
    [historyActivities]
  )

  const totalActivities = useMemo(
    () => (plannedActivities?.length ?? 0) + completedCount,
    [plannedActivities?.length, completedCount]
  )

  const completionRate = useMemo(
    () => totalActivities > 0 ? Math.round((completedCount / totalActivities) * 100) : 0,
    [completedCount, totalActivities]
  )

  if (isLoading) {
    return (
      <PageLayout>
        <div className="grid grid-cols-1 lg:grid-cols-[280px_1fr] gap-8">
          <Card className="lg:sticky lg:top-10 lg:self-start">
            <CardHeader>
              <Skeleton className="h-14 w-14 rounded-full" />
              <Skeleton className="h-5 w-32" />
              <Skeleton className="h-4 w-48" />
            </CardHeader>
          </Card>
          <div>
            <Skeleton className="h-10 w-64 mb-6" />
            <div className="space-y-3">
              {[...Array(3)].map((_, i) => (
                <Skeleton key={i} className="h-32 w-full" />
              ))}
            </div>
          </div>
        </div>
      </PageLayout>
    )
  }

  if (isError || !user) {
    return null
  }

  return (
    <PageLayout>
      <div className="grid grid-cols-1 lg:grid-cols-[320px_1fr] gap-8">
        {/* Improved User card */}
        <Card className="lg:sticky lg:top-10 lg:self-start overflow-hidden border-2">
          {/* Header accent */}
          <div className="h-24 bg-linear-to-br from-primary via-primary/80 to-primary/60" />
          
          <CardHeader className="-mt-10 relative">
            <Avatar className="h-20 w-20 border-4 border-background shadow-lg">
              <AvatarFallback className="bg-linear-to-br from-primary to-primary/70 text-white text-2xl font-bold">
                {user.name.charAt(0).toUpperCase()}
              </AvatarFallback>
            </Avatar>
            <CardTitle className="text-xl pt-2">{user.name}</CardTitle>
            <CardDescription className="text-sm">{user.email}</CardDescription>
          </CardHeader>

          <CardContent className="space-y-6">
            {/* Enhanced Stats Grid */}
            <div className="grid grid-cols-3 gap-3">
              <div className="text-center p-3 rounded-lg bg-orange-50 border border-orange-100">
                <div className="text-2xl font-bold text-orange-600">{plannedActivities?.length ?? 0}</div>
                <div className="text-xs text-orange-600/80 font-medium">Planned</div>
              </div>
              <div className="text-center p-3 rounded-lg bg-green-50 border border-green-100">
                <div className="text-2xl font-bold text-green-600">{completedCount}</div>
                <div className="text-xs text-green-600/80 font-medium">Completed</div>
              </div>
              <div className="text-center p-3 rounded-lg bg-purple-50 border border-purple-100">
                <div className="text-2xl font-bold text-purple-600">{completionRate}%</div>
                <div className="text-xs text-purple-600/80 font-medium">Success</div>
              </div>
            </div>
            {/* Progress bar */}
            {totalActivities > 0 && (
              <div className="space-y-2">
                <div className="flex justify-between text-xs text-muted-foreground">
                  <span>Progress</span>
                  <span>{completedCount} / {totalActivities}</span>
                </div>
                <div className="h-2 bg-muted rounded-full overflow-hidden">
                  <div 
                    className="h-full bg-primary transition-all duration-500"
                    style={{ width: `${completionRate}%` }}
                  />
                </div>
              </div>
            )}

            <Separator />


          </CardContent>
        </Card>

        {/* Right — Activities with better header */}
        <div>
          <div className="mb-6">
            <h2 className="text-2xl font-bold mb-1">
              My Activities
            </h2>
            <p className="text-muted-foreground text-sm">Track your planned activities</p>
          </div>
          
          <Tabs defaultValue="planned" className="w-full">
            <TabsList className="mb-6 grid w-full max-w-sm grid-cols-2">
              <TabsTrigger value="planned" className="gap-2">
                <Calendar className="h-4 w-4" />
                Planned ({plannedActivities?.length ?? 0})
              </TabsTrigger>
              <TabsTrigger value="history" className="gap-2">
                <Check className="h-4 w-4" />
                History ({historyActivities?.length ?? 0})
              </TabsTrigger>
            </TabsList>

            {/* Planned Activities */}
            <TabsContent value="planned" className="space-y-3">
              {plannedError && (
                <Card className="border-destructive">
                  <CardContent className="pt-6">
                    <p className="text-sm text-destructive">Error loading planned activities.</p>
                  </CardContent>
                </Card>
              )}
              {plannedActivities && plannedActivities.length > 0 ? (
                plannedActivities.map((schedule) => (
                  <Card key={schedule.id} className="hover:shadow-md transition-shadow">
                    <CardHeader className="pb-3">
                      <div className="flex items-start justify-between gap-3">
                        <div className="flex-1">
                          <CardTitle className="text-base">
                            {schedule.activity.title}
                          </CardTitle>
                          <CardDescription className="flex items-center gap-1.5 mt-2">
                            <Calendar className="h-3 w-3" />
                            <span className="text-xs">{formatDate(schedule.plannedDate)}</span>
                          </CardDescription>
                        </div>
                        {schedule.activity.category && (
                          <Badge className="shrink-0">
                            {schedule.activity.category.name}
                          </Badge>
                        )}
                      </div>
                    </CardHeader>

                    <CardContent className="space-y-3">
                      <p className="text-sm text-muted-foreground line-clamp-2 leading-relaxed">
                        {schedule.activity.description}
                      </p>
                      {schedule.notes && (
                        <div className="p-3 bg-muted/50 rounded-lg border border-muted">
                          <p className="text-xs text-muted-foreground italic">
                            "{schedule.notes}"
                          </p>
                        </div>
                      )}
                      {schedule.activity.tags.length > 0 && (
                        <div className="flex items-center gap-1.5 flex-wrap pt-2 border-t">
                          {schedule.activity.tags.map((tag) => (
                            <Badge key={tag.id} variant="secondary" className="text-xs">
                              {tag.name}
                            </Badge>
                          ))}
                        </div>
                      )}
                    </CardContent>

                    <CardFooter className="flex gap-2">
                      <Button
                        size="sm"
                        onClick={() => completeMutation.mutate(schedule.id)}
                        disabled={completeMutation.isPending}
                        className="flex-1 gap-1"
                      >
                        <Check className="h-3 w-3" />
                        Complete
                      </Button>
                      <Button
                        variant="ghost"
                        size="sm"
                        onClick={() => cancelMutation.mutate(schedule.id)}
                        disabled={cancelMutation.isPending}
                        className="gap-1"
                      >
                        <X className="h-3 w-3" />
                        Cancel
                      </Button>
                    </CardFooter>
                  </Card>
                ))
              ) : (
                <Card>
                  <CardContent className="py-16 text-center">
                    <p className="text-muted-foreground">No planned activities</p>
                  </CardContent>
                </Card>
              )}
            </TabsContent>

            {/* History */}
            <TabsContent value="history" className="space-y-3">
              {historyError && (
                <Card className="border-destructive">
                  <CardContent className="pt-6">
                    <p className="text-sm text-destructive">Error loading history.</p>
                  </CardContent>
                </Card>
              )}
              {historyActivities && historyActivities.length > 0 ? (
                <div className="space-y-3">
                  {historyActivities.map((schedule) => {
                    const isCompleted = schedule.status === "Completed"
                    return (
                      <Card 
                        key={schedule.id} 
                        className="transition-shadow hover:shadow-md"
                      >
                        <CardHeader>
                          <div className="flex items-start justify-between gap-3">
                            <div className="flex-1">
                              <div className="flex items-center gap-2 mb-1">
                                {isCompleted ? (
                                  <Check className="h-4 w-4 text-green-600" />
                                ) : (
                                  <X className="h-4 w-4 text-red-600" />
                                )}
                                <CardTitle className="text-base">{schedule.activity.title}</CardTitle>
                              </div>
                              <CardDescription className="flex items-center gap-1.5">
                                <Calendar className="h-3 w-3" />
                                {isCompleted && schedule.completedDate
                                  ? <span className="text-xs">Completed {formatDate(schedule.completedDate)}</span>
                                  : <span className="text-xs">Planned for {formatDate(schedule.plannedDate)}</span>
                                }
                              </CardDescription>
                            </div>
                            {schedule.activity.category && (
                              <Badge variant="secondary" className="shrink-0">
                                {schedule.activity.category.name}
                              </Badge>
                            )}
                          </div>
                        </CardHeader>

                        {schedule.notes && (
                          <CardContent>
                            <div className={`p-3 rounded-lg border ${
                              isCompleted ? 'bg-green-50 border-green-200' : 'bg-red-50 border-red-200'
                            }`}>
                              <p className="text-xs text-muted-foreground italic">"{schedule.notes}"</p>
                            </div>
                          </CardContent>
                        )}
                      </Card>
                    )
                  })}
                </div>
              ) : (
                <EmptyState
                  icon={Calendar}
                  title="No history yet"
                  description="Completed and cancelled activities will appear here"
                />
              )}
            </TabsContent>
          </Tabs>
        </div>
      </div>
    </PageLayout>
  )
}

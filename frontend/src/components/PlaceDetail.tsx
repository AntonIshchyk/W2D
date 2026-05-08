import { useParams, useNavigate } from 'react-router-dom'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { toast } from 'sonner'
import { ChevronLeft, MapPin, Clock, Trash2, Pencil, Menu, MessageSquare } from 'lucide-react'
import { PageLayout } from './Navbar'
import { useCurrentUser } from '../hooks/useCurrentUser'
import { useEntityVoteMutation } from '../hooks/useEntityVoteMutation'
import { formatRelativeTime } from '../lib/utils/date'
import { getGoogleMapsUrl } from '../lib/utils/maps'
import { Comments } from './EntityComments'
import { PhotoCarousel } from './PhotoCarousel'
import { fetchPlace, deletePlace, votePlace } from '../api/places'
import { VoteButtons } from './VoteButtons'
import { Button } from './ui/button'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { UserAvatar } from './UserAvatar'

export function PlaceDetail() {
  const { id } = useParams<{ id: string }>()
  const navigate = useNavigate()
  const queryClient = useQueryClient()
  const { data: currentUser } = useCurrentUser()

  const { data: place, isLoading, isError } = useQuery({
    queryKey: ['place', id],
    queryFn: () => fetchPlace(Number(id)),
    enabled: !!id && !isNaN(Number(id)),
  })

  const { handleVote: handleVoteMutation, voteMutation } = useEntityVoteMutation({
    queryKey: ['place', id],
    mutationFn: votePlace,
    invalidateKeys: [['places'], ['user-places']],
  })

  const deleteMutation = useMutation({
    mutationFn: deletePlace,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['places'] })
      toast.success('Place deleted')
      navigate('/places')
    },
    onError: (e: Error) => toast.error(e.message),
  })

  const handleVote = (currentVote: number | undefined | null, newValue: number) => {
    if (!currentUser || !id) return
    handleVoteMutation(Number(id), currentVote, newValue)
  }

  if (isLoading) return (
    <PageLayout>
      <div className="flex items-center justify-center py-20">
        <div className="flex items-center gap-2.5 text-muted-foreground">
          <svg className="w-4 h-4 animate-spin" fill="none" viewBox="0 0 24 24">
            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4" />
            <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8v8z" />
          </svg>
          <span className="text-sm">Loading…</span>
        </div>
      </div>
    </PageLayout>
  )

  if (isError || !place) return (
    <PageLayout>
      <div className="max-w-3xl mx-auto">
        <h2 className="text-xl font-semibold mb-2">Not found</h2>
        <p className="text-sm mb-4">This place doesn't exist or has been removed.</p>
        <button type="button" onClick={() => navigate('/places')}
          className="text-sm hover:text-foreground underline">
          Back to places
        </button>
      </div>
    </PageLayout>
  )

  const isOwner = currentUser != null && currentUser.userId != null && currentUser.userId === place.userId
  const photos = place.photoUrls ?? []
  const googleMapsUrl = getGoogleMapsUrl(place.latitude, place.longitude, place.locationName)

  return (
    <PageLayout>
      <div className="max-w-3xl mx-auto">
        <button type="button" onClick={() => navigate('/places')}
          className="group flex items-center gap-1.5 text-sm text-muted-foreground hover:text-foreground mb-6 transition-colors">
          <ChevronLeft className="w-4 h-4 transition-transform group-hover:-translate-x-0.5" />
          Back to places
        </button>

        <article className="bg-card border border-border/50 rounded-3xl p-6 md:p-8">
          <div className="flex items-center justify-between mb-5">
            <div className="min-w-0 flex items-center gap-3">
              <UserAvatar url={place.userPhotoUrl} username={place.userName} className="h-10 w-10" />
              <div className="min-w-0">
                <div className="flex items-center gap-2 mb-2">
                  <span className="text-sm font-medium text-muted-foreground">{place.userName}</span>
                  {place.communityName && (
                    <span className="px-3 py-1 rounded-full text-xs font-bold border bg-primary text-primary-foreground border-primary">
                      {place.communityName}
                    </span>
                  )}
                </div>
              </div>
            </div>

            <div className="flex items-center gap-2">
              {isOwner && (
                <Popover>
                  <PopoverTrigger asChild>
                    <Button variant="ghost" size="sm" className="h-8 w-8 p-0 rounded-full">
                      <Menu className="w-4 h-4" />
                    </Button>
                  </PopoverTrigger>
                  <PopoverContent align="end" className="w-40 p-2">
                    <div className="flex flex-col gap-1">
                      <Button 
                        variant="ghost" 
                        className="justify-start gap-2 h-9"
                        onClick={() => {
                          navigate(`/places/${place.id}/edit`)
                        }}
                      >
                        <Pencil className="w-4 h-4" />
                        Edit Place
                      </Button>
                      <Button 
                        variant="ghost" 
                        className="justify-start gap-2 h-9 text-destructive hover:text-destructive hover:bg-destructive/10"
                        onClick={() => {
                          if (window.confirm('Delete this place? This cannot be undone.')) {
                            deleteMutation.mutate(place.id)
                          }
                        }}
                        disabled={deleteMutation.isPending}
                      >
                        <Trash2 className="w-4 h-4" />
                        {deleteMutation.isPending ? 'Deleting…' : 'Delete'}
                      </Button>
                    </div>
                  </PopoverContent>
                </Popover>
              )}
            </div>
          </div>

          <h1 className={`text-2xl md:text-3xl font-bold text-foreground leading-snug ${place.locationName ? 'mb-2' : 'mb-4'}`}>
            {place.title}
          </h1>

          {place.locationName && (
            googleMapsUrl ? (
              <a
                href={googleMapsUrl}
                target="_blank"
                rel="noreferrer"
                className="flex items-center gap-1.5 text-primary hover:underline text-sm w-fit"
              >
                <MapPin className="w-4 h-4 shrink-0" />
                <span>{place.locationName}</span>
              </a>
            ) : (
              <div className="flex items-center gap-1.5 text-muted-foreground text-sm w-fit">
                <MapPin className="w-4 h-4 shrink-0" />
                <span>{place.locationName}</span>
              </div>
            )
          )}

          {photos.length > 0 && <PhotoCarousel urls={photos} />}

          {place.description && (
            <p className="text-sm md:text-base text-foreground leading-relaxed whitespace-pre-wrap mt-4 mb-6">
              {place.description}
            </p>
          )}

          <div className="flex items-center gap-3 pt-5 border-t border-border/40 mb-8 flex-wrap">
            <VoteButtons
              score={place.score}
              currentUserVote={place.currentUserVote ?? undefined}
              onVote={(val) => handleVote(place.currentUserVote ?? undefined, val)}
              disabled={!currentUser || voteMutation.isPending}
            />

            <div className="flex items-center gap-1.5 text-sm font-bold bg-muted/40 px-3 py-2 rounded-full border border-border/50">
              <MessageSquare className="w-4 h-4" />
              <span>{place.commentCount}</span>
            </div>

            <div className="flex items-center gap-1.5 text-sm font-bold bg-muted/40 px-3 py-2 rounded-full border border-border/50">
              <Clock className="w-4 h-4" />
              <span>{formatRelativeTime(place.createdAt)}</span>
            </div>
          </div>

          <Comments target="places" entityId={place.id} currentUserId={currentUser?.userId} />
        </article>
      </div>
    </PageLayout>
  )
}

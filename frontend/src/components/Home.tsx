import { lazy, Suspense } from 'react'
import { Link } from 'react-router-dom'
import { ArrowRight, Clock, Map, MapPin, MessageCircle, Sparkles, Users } from 'lucide-react'
import { PageLayout } from './Navbar'
import { PostAuthorInfo } from './PostAuthorInfo'
import { VoteButtons } from './VoteButtons'
import { PostType, type Post } from '../types/posts'
import type { LucideIcon } from 'lucide-react'
import type { Place } from '../types/places'
import parkImage from '../assets/park.jpg'
import suggestionsImage from '../assets/suggestions.png'

const PlacesMap = lazy(() => import('./PlacesMap').then((m) => ({ default: m.PlacesMap })))

const RHON_PLACE: Place = {
  id: 1,
  title: 'Bavarian Rhon Nature Park',
  description: 'Wide trails, quiet forest paths, and open highland views for a full-day nature reset.',
  userId: 1,
  userName: '',
  communityId: 2,
  communityName: 'Nature',
  latitude: 50.4977,
  longitude: 10.0707,
  locationName: 'Rhon, Bavaria',
  score: 37,
  commentCount: 12,
  currentUserVote: 1,
  photoUrls: [],
  createdAt: new Date(Date.now() - 1000 * 60 * 60 * 24 * 5).toISOString(),
  updatedAt: new Date(Date.now() - 1000 * 60 * 60 * 24 * 5).toISOString(),
}

const FEATURE_POST: Post = {
  id: 42,
  title: 'Best quiet place for a Saturday reset?',
  description:
    'Looking for somewhere peaceful, easy to reach, and good for a long walk after coffee. Preferably around Utrecht but open to nearby areas too. Any suggestions?',
  type: PostType.Question,
  author: {
    id: 7,
    username: 'Maria',
  },
  communityId: 3,
  communityName: 'Weekend Ideas',
  score: 32,
  locationName: 'Utrecht Centraal area',
  latitude: 52.0894,
  longitude: 5.1103,
  photoUrls: [],
  commentCount: 18,
  createdAt: new Date(Date.now() - 1000 * 60 * 38).toISOString(),
  updatedAt: new Date(Date.now() - 1000 * 60 * 38).toISOString(),
  currentUserVote: 1,
}

const FEATURE_COMMENTS = [
  {
    id: 1,
    name: 'Sam',
    content: 'Try the botanical gardens near the science park. Calm, green, and not too crowded.',
    score: 9,
    createdAt: '25min',
  },
  {
    id: 2,
    name: 'Lina',
    content: 'The canal route is great if you want coffee stops along the way.',
    score: 6,
    createdAt: '32min',
  },
]

function FeatureLink({
  to,
  icon: Icon,
  children,
}: {
  to: string
  icon: LucideIcon
  children: React.ReactNode
}) {
  return (
    <Link
      to={to}
      className="inline-flex w-fit items-center gap-2 rounded-full bg-primary px-5 py-3 text-sm font-bold text-primary-foreground shadow-lg shadow-primary/10 transition-transform hover:-translate-y-0.5"
    >
      <Icon className="h-4 w-4" />
      {children}
      <ArrowRight className="h-4 w-4" />
    </Link>
  )
}

export function Home() {
  return (
    <PageLayout fullWidth>
      <main className="h-screen overflow-y-auto scroll-smooth">
        <section className="grid min-h-screen items-center gap-10 px-5 py-10 md:px-10 lg:grid-cols-[1.05fr_0.95fr] lg:px-16">
          <div className="relative h-[58vh] min-h-105 overflow-hidden rounded-3xl border border-border bg-card shadow-2xl shadow-primary/10">
            <div className="absolute inset-0 pointer-events-none">
              <Suspense fallback={<div className="h-full w-full animate-pulse bg-muted" />}>
                <PlacesMap
                  places={[RHON_PLACE]}
                  onBoundsChange={() => {}}
                  initialCenter={[50.4977, 10.0707]}
                  initialZoom={10}
                  selectedPlaceId={RHON_PLACE.id}
                />
              </Suspense>
            </div>

            <article className="absolute right-4 top-4 w-[calc(100%-2rem)] max-w-sm rounded-3xl border border-border/70 bg-card p-4 shadow-2xl md:right-5 md:top-5 md:p-5">
              <div className="mb-4 flex items-center justify-between gap-3">
                <div className="min-w-0">
                  <p className="font-semibold text-foreground">{RHON_PLACE.userName}</p>
                </div>
                <span className="inline-flex shrink-0 items-center gap-1.5 rounded-full bg-primary px-3 py-1 text-xs font-bold text-primary-foreground">
                  <Users className="h-3 w-3" />
                  {RHON_PLACE.communityName}
                </span>
              </div>

              <h3 className="text-xl font-bold leading-snug text-foreground md:text-2xl">
                {RHON_PLACE.title}
              </h3>
              <div className="mt-2 flex w-fit items-center gap-1.5 text-sm text-primary">
                <MapPin className="h-4 w-4 shrink-0" />
                <span>{RHON_PLACE.locationName}</span>
              </div>

              <div className="mt-4 overflow-hidden rounded-2xl bg-muted">
                <img
                  src={parkImage}
                  alt="Bavarian Rhon Nature Park"
                  className="h-44 w-full object-cover md:h-52"
                />
              </div>

              <p className="mt-4 line-clamp-2 text-sm leading-6 text-foreground">
                {RHON_PLACE.description}
              </p>

              <div className="mt-5 flex items-center gap-3 border-t border-border/40 pt-4">
                <VoteButtons score={RHON_PLACE.score} currentUserVote={RHON_PLACE.currentUserVote ?? undefined} onVote={() => {}} />
                <div className="flex items-center gap-1.5 rounded-full border border-border/50 bg-muted/40 px-3 py-2 text-sm font-bold">
                  <MessageCircle className="h-4 w-4" />
                  <span>{RHON_PLACE.commentCount}</span>
                </div>
                <div className="flex items-center gap-1.5 rounded-full border border-border/50 bg-muted/40 px-3 py-2 text-sm font-bold">
                  <Clock className="h-4 w-4" />
                  <span>5 days ago</span>
                </div>
              </div>
            </article>
          </div>

          <div className="max-w-xl justify-self-center lg:justify-self-start">
            <h1 className="text-4xl font-black leading-tight tracking-normal md:text-6xl">
              Every pin - <br />a potential plan <br />for your day.
            </h1>
            <p className="mt-5 text-lg leading-8 text-muted-foreground">
              Explore local favorites pinned by the communities around you. <br />
              Share your own go-to spots and hidden gems to help others find their next adventure.
            </p>
            <div className="mt-8">
              <FeatureLink to="/places" icon={Map}>Explore places</FeatureLink>
            </div>
          </div>
        </section>

        <section className="grid min-h-screen items-center gap-10 border-t border-border px-5 py-10 md:px-10 lg:grid-cols-[0.9fr_1.1fr] lg:px-16">
          <div className="max-w-xl justify-self-center lg:justify-self-end">
            <h2 className="text-4xl font-black leading-tight tracking-normal md:text-6xl">
              Join the conversation around what to do next.
            </h2>
            <p className="mt-5 text-lg leading-8 text-muted-foreground">
              Share ideas, ask for recommendations, comment on local activities, and build
              communities around the things you care about.
            </p>
            <div className="mt-8">
              <FeatureLink to="/posts" icon={MessageCircle}>Browse posts</FeatureLink>
            </div>
          </div>

          <div className="relative mx-auto w-full max-w-2xl">
            <article className="rounded-3xl border border-border/50 bg-card p-5 shadow-2xl shadow-primary/10 md:p-7">
              <div className="mb-5 flex items-center justify-between gap-3">
                <PostAuthorInfo author={FEATURE_POST.author} type={FEATURE_POST.type} />
                <span className="rounded-full bg-primary px-3 py-1 text-xs font-bold text-primary-foreground">
                  {FEATURE_POST.communityName}
                </span>
              </div>

              <h3 className="text-2xl font-bold leading-snug text-foreground md:text-3xl">
                {FEATURE_POST.title}
              </h3>
              <div className="mt-2 flex w-fit items-center gap-1.5 text-sm text-primary">
                <MapPin className="h-4 w-4 shrink-0" />
                <span>{FEATURE_POST.locationName}</span>
              </div>

              <p className="mt-4 text-sm leading-7 text-foreground md:text-base">
                {FEATURE_POST.description}
              </p>

              <div className="mt-5 flex items-center gap-3 border-t border-border/40 pt-5">
                <VoteButtons
                  score={FEATURE_POST.score}
                  currentUserVote={FEATURE_POST.currentUserVote}
                  onVote={() => {}}
                />
                <div className="flex items-center gap-1.5 rounded-full border border-border/50 bg-muted/40 px-3 py-2 text-sm font-bold">
                  <MessageCircle className="h-4 w-4" />
                  <span>{FEATURE_POST.commentCount}</span>
                </div>
                <div className="flex items-center gap-1.5 rounded-full border border-border/50 bg-muted/40 px-3 py-2 text-sm font-bold">
                  <Clock className="h-4 w-4" />
                  <span>38m</span>
                </div>
              </div>

              <div className="mt-7 border-t border-border/60 pt-5">
                <div className="mb-4 flex items-center gap-2">
                  <h2 className="text-sm font-semibold text-foreground">
                    Comments{FEATURE_COMMENTS.length > 0 ? ` (${FEATURE_COMMENTS.length})` : ''}
                  </h2>
                </div>
                <div className="space-y-4">
                  {FEATURE_COMMENTS.map((comment) => (
                    <div key={comment.id} className="flex gap-2.5">
                      <VoteButtons
                        score={comment.score}
                        onVote={() => {}}
                        className="min-w-10 flex-col gap-0.5 border-transparent bg-transparent px-1 py-1"
                      />
                      <div className="min-w-0 flex-1 border-b border-border/60 pb-4 last:border-0 last:pb-0">
                        <div className="mb-1.5 flex items-center gap-2">
                          <div className="flex h-6 w-6 items-center justify-center rounded-full bg-accent text-xs font-black text-accent-foreground">
                            {comment.name.slice(0, 1)}
                          </div>
                          <span className="text-sm font-medium">{comment.name}</span>
                          <span className="text-sm text-muted-foreground">{comment.createdAt}</span>
                        </div>
                        <p className="text-sm leading-relaxed text-foreground">{comment.content}</p>
                      </div>
                    </div>
                  ))}
                </div>
              </div>
            </article>
          </div>
        </section>

        <section className="grid min-h-screen items-center gap-10 border-t border-border px-5 py-10 md:px-10 lg:grid-cols-[1.05fr_0.95fr] lg:px-16">
          <div className="relative h-[58vh] min-h-105 overflow-hidden rounded-3xl border border-border bg-card shadow-2xl shadow-primary/10 flex items-center justify-center">
            <img
              src={suggestionsImage}
              alt="AI Suggestions"
              className="h-full w-full object-contain"
            />
          </div>

          <div className="max-w-xl justify-self-center lg:justify-self-start">
            <h2 className="text-4xl font-black leading-tight tracking-normal md:text-6xl">
              Get suggestions W2D based on your preferences.
            </h2>
            <p className="mt-5 text-lg leading-8 text-muted-foreground">
              Answer a few questions and get personalized recommendations for things to do. 
              Whether you want to explore, relax, or connect with others.
            </p>
            <div className="mt-8">
              <FeatureLink to="/suggestions" icon={Sparkles}>Get suggestions</FeatureLink>
            </div>
          </div>
        </section>
      </main>
    </PageLayout>
  )
}

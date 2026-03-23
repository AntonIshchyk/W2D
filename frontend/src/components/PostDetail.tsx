import { useParams, useNavigate } from 'react-router-dom'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { useState } from 'react'
import { toast } from 'sonner'
import { X, ChevronLeft, ChevronRight } from 'lucide-react'
import { PageLayout } from './Navbar'
import { API_ENDPOINTS, getAuthHeaders } from '../config/api'
import { PostType } from '../types/posts'
import type { Post } from '../types/posts'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'
import { formatDate } from '../lib/utils/date'
import { Comments } from './Comments'

async function fetchPost(id: number): Promise<Post> {
  const response = await fetch(API_ENDPOINTS.posts.byId(id), { headers: getAuthHeaders() })
  if (!response.ok) throw new Error('Failed to fetch post')
  return response.json()
}

async function votePost(postId: number, value: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.vote(postId), {
    method: 'POST', headers: getAuthHeaders(), body: JSON.stringify({ value }),
  })
  if (!response.ok) throw new Error('Failed to vote on post')
}

async function deletePost(postId: number): Promise<void> {
  const response = await fetch(API_ENDPOINTS.posts.byId(postId), {
    method: 'DELETE', headers: getAuthHeaders(),
  })
  if (!response.ok) throw new Error('Failed to delete post')
}

const POST_TYPE_LABELS: Record<PostType, string> = {
  [PostType.ExperienceShare]: 'Experience',
  [PostType.Guide]: 'Guide',
  [PostType.Question]: 'Question',
  [PostType.Recommendation]: 'Recommendation',
  [PostType.Achievement]: 'Achievement',
  [PostType.Challenge]: 'Challenge',
}

const POST_TYPE_COLORS: Record<PostType, { bg: string; text: string }> = {
  [PostType.ExperienceShare]: { bg: '#dbeafe', text: '#1e40af' },
  [PostType.Guide]:           { bg: '#dcfce7', text: '#166534' },
  [PostType.Question]:        { bg: '#fef9c3', text: '#854d0e' },
  [PostType.Recommendation]:  { bg: '#f3e8ff', text: '#6b21a8' },
  [PostType.Achievement]:     { bg: '#ffedd5', text: '#9a3412' },
  [PostType.Challenge]:       { bg: '#fee2e2', text: '#991b1b' },
}

// ── Lightbox ──────────────────────────────────────────────────────────────────

function Lightbox({ urls, initialIndex, onClose }: {
  urls: string[]; initialIndex: number; onClose: () => void
}) {
  const [index, setIndex] = useState(initialIndex)
  const prev = () => setIndex(i => (i - 1 + urls.length) % urls.length)
  const next = () => setIndex(i => (i + 1) % urls.length)

  return (
    <div
      className="fixed inset-0 z-50 bg-black/90 flex items-center justify-center"
      onClick={onClose}
      onKeyDown={e => {
        if (e.key === 'ArrowLeft') prev()
        if (e.key === 'ArrowRight') next()
        if (e.key === 'Escape') onClose()
      }}
      tabIndex={0}
      // eslint-disable-next-line jsx-a11y/no-autofocus
      autoFocus
    >
      <button type="button" onClick={onClose}
        className="absolute top-4 right-4 text-white/70 hover:text-white transition-colors z-10">
        <X className="w-6 h-6" />
      </button>

      {urls.length > 1 && (
        <span className="absolute top-4 left-1/2 -translate-x-1/2 text-white/60 text-sm">
          {index + 1} / {urls.length}
        </span>
      )}

      {urls.length > 1 && (
        <button type="button" onClick={e => { e.stopPropagation(); prev() }}
          className="absolute left-4 text-white/60 hover:text-white transition-colors">
          <ChevronLeft className="w-8 h-8" />
        </button>
      )}

      <img
        src={urls[index]}
        alt=""
        className="max-w-[90vw] max-h-[85vh] object-contain rounded-lg"
        onClick={e => e.stopPropagation()}
      />

      {urls.length > 1 && (
        <button type="button" onClick={e => { e.stopPropagation(); next() }}
          className="absolute right-4 text-white/60 hover:text-white transition-colors">
          <ChevronRight className="w-8 h-8" />
        </button>
      )}

      {urls.length > 1 && (
        <div className="absolute bottom-4 left-1/2 -translate-x-1/2 flex gap-2">
          {urls.map((url, i) => (
            <button key={i} type="button" onClick={e => { e.stopPropagation(); setIndex(i) }}
              className={`w-12 h-12 rounded-md overflow-hidden border-2 transition-all ${
                i === index ? 'border-white opacity-100' : 'border-transparent opacity-40 hover:opacity-70'
              }`}>
              <img src={url} alt="" className="w-full h-full object-cover" />
            </button>
          ))}
        </div>
      )}
    </div>
  )
}

// ── Photo gallery ─────────────────────────────────────────────────────────────

function PhotoGallery({ urls, onOpen }: { urls: string[]; onOpen: (i: number) => void }) {
  if (urls.length === 0) return null

  if (urls.length === 1) return (
    <div className="mb-6 rounded-xl overflow-hidden cursor-pointer" onClick={() => onOpen(0)}>
      <img src={urls[0]} alt="" className="w-full max-h-112 object-cover" />
    </div>
  )

  if (urls.length === 2) return (
    <div className="mb-6 grid grid-cols-2 gap-1 rounded-xl overflow-hidden">
      {urls.map((url, i) => (
        <img key={i} src={url} alt="" className="w-full h-64 object-cover cursor-pointer" onClick={() => onOpen(i)} />
      ))}
    </div>
  )

  if (urls.length === 3) return (
    <div className="mb-6 rounded-xl overflow-hidden" style={{ display: 'grid', gridTemplateColumns: '2fr 1fr', gap: 4, height: 260 }}>
      <img src={urls[0]} alt="" className="w-full h-full object-cover cursor-pointer" onClick={() => onOpen(0)} />
      <div style={{ display: 'grid', gridTemplateRows: '1fr 1fr', gap: 4 }}>
        <img src={urls[1]} alt="" className="w-full h-full object-cover cursor-pointer" onClick={() => onOpen(1)} />
        <img src={urls[2]} alt="" className="w-full h-full object-cover cursor-pointer" onClick={() => onOpen(2)} />
      </div>
    </div>
  )

  // 4+
  return (
    <div className="mb-6 rounded-xl overflow-hidden space-y-1">
      <div className="grid grid-cols-2 gap-1">
        <img src={urls[0]} alt="" className="w-full h-56 object-cover cursor-pointer" onClick={() => onOpen(0)} />
        <img src={urls[1]} alt="" className="w-full h-56 object-cover cursor-pointer" onClick={() => onOpen(1)} />
      </div>
      <div className={`grid gap-1 ${urls.length === 4 ? 'grid-cols-2' : 'grid-cols-3'}`}>
        {urls.slice(2, 5).map((url, i) => (
          <div key={i} className="relative cursor-pointer" onClick={() => onOpen(i + 2)}>
            <img src={url} alt="" className="w-full h-32 object-cover" />
            {i === 2 && urls.length > 5 && (
              <div className="absolute inset-0 bg-black/50 flex items-center justify-center">
                <span className="text-white text-lg font-bold">+{urls.length - 5}</span>
              </div>
            )}
          </div>
        ))}
      </div>
    </div>
  )
}

// ── Main ──────────────────────────────────────────────────────────────────────

export function PostDetail() {
  const { id } = useParams<{ id: string }>()
  const navigate = useNavigate()
  const queryClient = useQueryClient()
  const [lightboxIndex, setLightboxIndex] = useState<number | null>(null)

  const { data: currentUser, isError: userError, error: userQueryError } = useQuery({
    queryKey: ['currentUser'], queryFn: fetchCurrentUser, retry: false,
  })

  const { data: post, isLoading, isError } = useQuery({
    queryKey: ['post', id],
    queryFn: () => fetchPost(Number(id)),
    enabled: !!id && !isNaN(Number(id)),
  })

  const voteMutation = useMutation({
    mutationFn: ({ postId, value }: { postId: number; value: number }) => votePost(postId, value),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['post', id] })
      queryClient.invalidateQueries({ queryKey: ['posts'] })
    },
    onError: (e: Error) => toast.error(e.message),
  })

  const deleteMutation = useMutation({
    mutationFn: deletePost,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['posts'] })
      toast.success('Post deleted')
      navigate('/posts')
    },
    onError: (e: Error) => toast.error(e.message),
  })

  useAuthErrorHandler(userError, userQueryError)

  const handleVote = (e: React.MouseEvent, currentVote: number | undefined, newValue: number) => {
    e.preventDefault(); e.stopPropagation()
    if (!currentUser || !id) return
    const value = currentVote === newValue ? 0 : newValue
    voteMutation.mutate({ postId: Number(id), value })
  }

  if (isLoading) return (
    <PageLayout>
      <div className="flex items-center justify-center py-20">
        <div className="flex items-center gap-2.5 text-gray-400">
          <svg className="w-4 h-4 animate-spin" fill="none" viewBox="0 0 24 24">
            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4" />
            <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8v8z" />
          </svg>
          <span className="text-sm">Loading…</span>
        </div>
      </div>
    </PageLayout>
  )

  if (isError || !post) return (
    <PageLayout>
      <div className="max-w-3xl">
        <h2 className="text-xl font-semibold mb-2">Not found</h2>
        <p className="text-sm text-gray-500 mb-4">This post doesn't exist or has been removed.</p>
        <button type="button" onClick={() => navigate('/posts')} className="text-sm text-gray-400 hover:text-gray-600 underline">
          Back to posts
        </button>
      </div>
    </PageLayout>
  )

  const typeStyle = POST_TYPE_COLORS[post.type as PostType]
  const isOwner = currentUser?.userId === post.userId
  const photos = post.photoUrls ?? []

  return (
    <>
      {lightboxIndex !== null && (
        <Lightbox urls={photos} initialIndex={lightboxIndex} onClose={() => setLightboxIndex(null)} />
      )}

      <PageLayout>
        <div className="max-w-3xl">
          <button type="button" onClick={() => navigate('/posts')}
            className="group flex items-center gap-1.5 text-xs text-gray-400 hover:text-gray-600 mb-6 transition-colors">
            <svg className="w-3.5 h-3.5 transition-transform group-hover:-translate-x-0.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 19l-7-7 7-7" />
            </svg>
            Back to posts
          </button>

          <div className="flex gap-5">
            {/* Vote column */}
            <div className="flex flex-col items-center gap-1 pt-1 shrink-0">
              <button type="button" onClick={e => handleVote(e, post.currentUserVote, 1)}
                disabled={!currentUser || voteMutation.isPending} aria-label="Upvote"
                className={`w-8 h-8 flex items-center justify-center rounded-md transition-all ${
                  post.currentUserVote === 1 ? 'text-orange-500 bg-orange-50 ring-1 ring-orange-200'
                  : 'text-gray-300 hover:text-orange-400 hover:bg-orange-50'
                } disabled:cursor-not-allowed disabled:opacity-40`}>
                <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
                  <path d="M5.293 9.707a1 1 0 010-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 01-1.414 1.414L11 7.414V15a1 1 0 11-2 0V7.414L6.707 9.707a1 1 0 01-1.414 0z" />
                </svg>
              </button>

              <span className={`text-sm font-semibold tabular-nums w-8 text-center ${
                post.score > 0 ? 'text-orange-500' : post.score < 0 ? 'text-blue-500' : 'text-gray-400'
              }`}>{post.score}</span>

              <button type="button" onClick={e => handleVote(e, post.currentUserVote, -1)}
                disabled={!currentUser || voteMutation.isPending} aria-label="Downvote"
                className={`w-8 h-8 flex items-center justify-center rounded-md transition-all ${
                  post.currentUserVote === -1 ? 'text-blue-500 bg-blue-50 ring-1 ring-blue-200'
                  : 'text-gray-300 hover:text-blue-400 hover:bg-blue-50'
                } disabled:cursor-not-allowed disabled:opacity-40`}>
                <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
                  <path d="M14.707 10.293a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 111.414-1.414L9 12.586V5a1 1 0 012 0v7.586l2.293-2.293a1 1 0 011.414 0z" />
                </svg>
              </button>
            </div>

            {/* Content */}
            <div className="flex-1 min-w-0">
              <div className="flex items-center justify-between gap-3 mb-3 flex-wrap">
                <div className="flex items-center gap-2 flex-wrap">
                  {typeStyle && (
                    <span className="text-xs font-medium px-2.5 py-1 rounded-md"
                      style={{ background: typeStyle.bg, color: typeStyle.text }}>
                      {POST_TYPE_LABELS[post.type as PostType] ?? 'Other'}
                    </span>
                  )}
                  {post.communityName && (
                    <span className="flex items-center gap-1 text-xs text-gray-500">
                      <svg className="w-3 h-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M7 7h.01M7 3h5c.512 0 1.024.195 1.414.586l7 7a2 2 0 010 2.828l-7 7a2 2 0 01-2.828 0l-7-7A2 2 0 013 12V7a4 4 0 014-4z" />
                      </svg>
                      {post.communityName}
                    </span>
                  )}
                </div>
                {isOwner && (
                  <button type="button" onClick={() => {
                    if (window.confirm('Delete this post? This cannot be undone.')) deleteMutation.mutate(post.id)
                  }} disabled={deleteMutation.isPending}
                    className="flex items-center gap-1 text-xs text-gray-300 hover:text-red-500 transition-colors ml-auto">
                    <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                    </svg>
                    {deleteMutation.isPending ? 'Deleting…' : 'Delete'}
                  </button>
                )}
              </div>

              <h1 className="text-2xl font-bold text-gray-900 leading-snug mb-3">{post.title}</h1>

              <div className="flex items-center gap-2 text-xs text-gray-400 mb-5 pb-5 border-b border-gray-100">
                <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
                </svg>
                <span>{post.userName || 'Anonymous'}</span>
                <span className="text-gray-200">·</span>
                <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" />
                </svg>
                <span>{formatDate(post.createdAt)}</span>
              </div>

              {/* Photos before body */}
              {photos.length > 0 && <PhotoGallery urls={photos} onOpen={setLightboxIndex} />}

              <div className="text-sm text-gray-700 leading-relaxed whitespace-pre-wrap mb-6">
                {post.description}
              </div>

              {post.locationName && (
                <div className="border border-gray-100 rounded-xl p-4 mb-6 space-y-3 bg-gray-50/50">
                  <p className="text-xs font-semibold text-gray-400 uppercase tracking-wider">Details</p>
                  {post.locationName && (
                    <div className="flex items-center gap-2 text-sm text-gray-700">
                      <svg className="w-4 h-4 text-gray-400 shrink-0" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" />
                      </svg>
                      {post.locationName}
                    </div>
                  )}
                </div>
              )}

              <Comments postId={post.id} currentUserId={currentUser?.userId} />
            </div>
          </div>
        </div>
      </PageLayout>
    </>
  )
}

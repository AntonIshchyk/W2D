export const PostType = {
  ExperienceShare: 1,
  Guide: 2,
  Question: 3,
  Recommendation: 4,
  Achievement: 5,
  Challenge: 6
} as const

export type PostType = typeof PostType[keyof typeof PostType]

export interface UserSummary {
  id: number
  username: string
  profilePhotoUrl?: string
}

export interface Post {
  id: number
  title: string
  description: string
  type: PostType
  author?: UserSummary
  topicId: number
  communityName?: string
  score: number
  locationName?: string
  latitude?: number
  longitude?: number
  photoUrls: string[]
  commentCount: number
  createdAt: string
  updatedAt: string
  currentUserVote?: number
}

export interface CreatePostRequest {
  title: string
  description: string
  type: number
  topicId: number
  locationName?: string
  latitude?: number
  longitude?: number
  photoUrl?: string
  photoUrls?: string[]
}

export interface UpdatePostRequest {
  title?: string
  description?: string
  type?: number
  locationName?: string
  latitude?: number
  longitude?: number
  photoUrl?: string
  photoUrls?: string[]
}

export interface ScrollResult<T> {
  items: T[]
  nextCursor: number | null
  hasMore: boolean
  totalCount: number
}

export interface Comment {
  id: number
  content: string
  userId: number
  userName?: string
  postId: number
  score: number
  photoUrl?: string
  createdAt: string
  updatedAt: string
  currentUserVote?: number
  isDeleted?: boolean
  parentCommentId?: number | null
  replies?: Comment[]
}

export interface Tag {
  id: number
  name: string
}

export interface Community {
  id: number
  name: string
}

export interface Event {
  id: number
  title: string
  description: string
  organizerId: number
  organizerName: string
  topicId: number | null
  communityName: string | null
  tags: Tag[]
  scheduledAt: string
  maxAttendees: number | null
  attendeeCount: number
  status: string
  currentUserRsvp: string | null
  latitude?: number
  longitude?: number
  locationName?: string
  placeId?: string
  createdAt: string
  updatedAt: string
}

export interface Attendee {
  userId: number
  userName: string | null
  status: string
  joinedAt: string
}

export interface ScrollResult<T> {
  items: T[]
  nextCursor: number | null
  hasMore: boolean
  totalCount: number
}

export interface EventQueryBounds {
  minLat: number
  maxLat: number
  minLng: number
  maxLng: number
}

export interface CreateEventRequest {
  title: string
  description: string
  scheduledAt: string
  topicId?: number | null
  tagIds?: number[]
  maxAttendees?: number | null
  latitude?: number
  longitude?: number
  locationName?: string
}

export interface UpdateEventRequest {
  title?: string
  description?: string
  scheduledAt?: string
  maxAttendees?: number | null
}

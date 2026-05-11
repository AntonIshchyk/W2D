export interface ActivitySuggestionRequest {
  social: string
  mood: string
  latitude: number
  longitude: number
  locationName?: string
  extraNotes?: string
}

export interface SuggestedPlace {
  id: number
  title: string
  locationName?: string
}

export interface ActivitySuggestionResponse {
  summary: string
  suggestions: string[]
  places: SuggestedPlace[]
}

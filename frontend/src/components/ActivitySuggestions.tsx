import { useState } from 'react'
import {
  HeartCrack,
  Frown,
  Heart,
  Home,
  Leaf,
  Loader2,
  Meh,
  Sparkles,
  Smile,
  User,
  Users,
  X,
  Zap,
  ArrowRight,
} from 'lucide-react'
import { PageLayout } from './Navbar'
import { Link } from 'react-router-dom'
import { Button } from './ui/button'
import { Textarea } from './ui/textarea'
import { LocationStep } from './entity/LocationStep'
import { OptionCard } from './OptionCard'
import { useEntityForm } from '../hooks/useEntityForm'
import { getActivitySuggestions } from '../api/activitySuggestions'
import { extractErrorMessage } from '../lib/utils/errors'
import type { ActivitySuggestionResponse } from '../types/activitySuggestions'

export interface SuggestionPreferences {
  social: string
  mood: string
  location: { lat: number; lng: number } | null
  locationName: string
  extraNotes: string
}

interface SuggestionsPanelProps {
  isOpen: boolean
  onClose: () => void
  result: ActivitySuggestionResponse | null
}

function SuggestionsPanel({ isOpen, onClose, result }: SuggestionsPanelProps) {
  return (
    <div
      className={[
        'fixed top-0 right-0 z-50 flex h-full w-full max-w-sm flex-col',
        'bg-card border-l border-border shadow-2xl',
        'transition-transform duration-300 ease-in-out',
        isOpen ? 'translate-x-0' : 'translate-x-full',
      ].join(' ')}
    >
      <div className="flex shrink-0 items-center justify-between border-b border-border px-5 py-4">
        <div className="flex items-center gap-2">
          <Sparkles className="h-4 w-4 text-primary" />
          <p className="text-sm font-medium text-foreground">Suggestions</p>
        </div>
        <button
          onClick={onClose}
          className="shrink-0 rounded-full p-1.5 text-muted-foreground transition-colors hover:bg-muted hover:text-foreground"
          aria-label="Close panel"
        >
          <X className="h-4 w-4" />
        </button>
      </div>

      <div className="flex-1 overflow-y-auto px-5 py-4">
        {result ? (
          <div className="flex flex-col gap-4">
            {result.summary && (
              <p className="text-sm leading-relaxed text-muted-foreground">
                {result.summary}
              </p>
            )}

            <div>
              <h3 className="mb-2 text-xs font-semibold uppercase tracking-wide text-foreground">Activity Ideas</h3>
              <ul className="flex flex-col gap-2">
                {result.suggestions.map((suggestion, index) => (
                  <li
                    key={`${index}-${suggestion}`}
                    className="rounded-xl border border-border bg-background px-4 py-3 text-sm leading-relaxed"
                  >
                    {suggestion}
                  </li>
                ))}
              </ul>
            </div>

            {result.places.length > 0 && (
              <div>
                <h3 className="mb-2 text-xs font-semibold uppercase tracking-wide text-foreground">Nearby Places</h3>
                <ul className="flex flex-col gap-2">
                  {result.places.map((place) => (
                    <li key={place.id} className="rounded-xl border border-border bg-background px-4 py-3">
                      <Link
                        to={`/places/${place.id}`}
                        className="flex flex-col gap-0.5 text-sm text-primary hover:underline"
                      >
                        <span className="font-medium">{place.title}</span>
                        {place.locationName && (
                          <span className="text-xs text-muted-foreground">{place.locationName}</span>
                        )}
                      </Link>
                    </li>
                  ))}
                </ul>
              </div>
            )}
          </div>
        ) : (
          <div className="flex h-full items-center justify-center text-sm text-muted-foreground">
            No suggestions yet
          </div>
        )}
      </div>
    </div>
  )
}

const SOCIAL_OPTIONS = [
  { value: 'alone', label: 'Just me', Icon: User },
  { value: 'partner', label: 'With partner', Icon: Heart },
  { value: 'friends', label: 'With friends', Icon: Users },
  { value: 'family', label: 'With family', Icon: Home },
]

const MOOD_OPTIONS = [
  { value: 'sad', label: 'Sad', Icon: Frown },
  { value: 'bored', label: 'Bored', Icon: Meh },
  { value: 'happy', label: 'Happy', Icon: Smile },
  { value: 'stressed', label: 'Stressed', Icon: HeartCrack },
  { value: 'calm', label: 'Calm', Icon: Leaf },
  { value: 'motivated', label: 'Motivated', Icon: Zap },
]

export function ActivitySuggestionsPage() {
  const [social, setSocial] = useState<string | null>(null)
  const [mood, setMood] = useState<string | null>(null)
  const [extraNotes, setExtraNotes] = useState('')
  const [isSubmitting, setIsSubmitting] = useState(false)
  const [submitError, setSubmitError] = useState<string | null>(null)
  const [result, setResult] = useState<ActivitySuggestionResponse | null>(null)
  const [panelOpen, setPanelOpen] = useState(false)

  const {
    location,
    locationInput,
    setLocationInput,
    isFetchingLocation,
    locationSearchResults,
    isSearchingLocation,
    showLocationResults,
    setShowLocationResults,
    applyLocationSearchResult,
    handleLocationSelect,
    handleUseMyLocation,
  } = useEntityForm()

  async function handleSubmit() {
    if (!social || !mood || !location) return

    setIsSubmitting(true)
    setSubmitError(null)

    const preferences = {
      social,
      mood,
      location,
      locationName: locationInput.trim(),
      extraNotes: extraNotes.trim(),
    } satisfies SuggestionPreferences

    try {
      const suggestions = await getActivitySuggestions({
        social: preferences.social,
        mood: preferences.mood,
        latitude: preferences.location.lat,
        longitude: preferences.location.lng,
        locationName: preferences.locationName || undefined,
        extraNotes: preferences.extraNotes || undefined,
      })

      setResult(suggestions)
      setPanelOpen(true)
    } catch (err: unknown) {
      setSubmitError(extractErrorMessage(err))
      setResult(null)
    } finally {
      setIsSubmitting(false)
    }
  }

  return (
    <PageLayout>
      <div
        onClick={() => setPanelOpen(false)}
        className={[
          'fixed inset-0 z-40 bg-black/20',
          'transition-opacity duration-300',
          panelOpen ? 'opacity-100 pointer-events-auto' : 'opacity-0 pointer-events-none',
        ].join(' ')}
      />

      <SuggestionsPanel isOpen={panelOpen} onClose={() => setPanelOpen(false)} result={result} />

      <div className="rounded-3xl border border-border bg-card p-4 shadow-sm sm:p-6">
        <div className="grid grid-cols-1 gap-4 lg:grid-cols-2">
          <div className="flex flex-col gap-3">
            <h2 className="text-lg font-semibold">Who are you going with?</h2>
            <div className="grid grid-cols-2 gap-2 sm:grid-cols-4">
              {SOCIAL_OPTIONS.map((opt) => (
                <OptionCard
                  key={opt.value}
                  {...opt}
                  selected={social === opt.value}
                  onClick={() => setSocial(opt.value)}
                />
              ))}
            </div>

            <h2 className="text-lg font-semibold">How are you feeling?</h2>
            <div className="grid grid-cols-2 gap-2 sm:grid-cols-3">
              {MOOD_OPTIONS.map((opt) => (
                <OptionCard
                  key={opt.value}
                  {...opt}
                  selected={mood === opt.value}
                  onClick={() => setMood(opt.value)}
                />
              ))}
            </div>

            <h2 className="text-lg font-semibold">
              Preferences and wishes{' '}
              <span className="text-sm font-normal text-muted-foreground">(optional)</span>
            </h2>
            <Textarea
              value={extraNotes}
              onChange={(e) => setExtraNotes(e.target.value)}
              placeholder="Any specific preferences, needs, or ideas you have in mind?"
              className="flex-1 resize-none"
            />
          </div>

          <LocationStep
            locationInput={locationInput}
            onLocationInputChange={setLocationInput}
            location={location}
            onLocationSelect={handleLocationSelect}
            isFetching={isFetchingLocation}
            isSearching={isSearchingLocation}
            onUseMyLocation={handleUseMyLocation}
            searchResults={locationSearchResults}
            showResults={showLocationResults}
            onShowResultsChange={setShowLocationResults}
            onApplySearchResult={applyLocationSearchResult}
          />
        </div>

        <Button
          variant="outline"
          size="lg"
          className="mt-4 rounded-full h-9 w-full text-primary border-primary/40 hover:bg-primary hover:text-white hover:border-primary transition-colors"
          onClick={handleSubmit}
          disabled={!social || !mood || !location || isSubmitting}
        >
          {isSubmitting ? (
            <>
              <Loader2 className="h-4 w-4 animate-spin" /> Thinking...
            </>
          ) : (
            <>
              <Sparkles className="h-4 w-4" /> Suggest activities
            </>
          )}
        </Button>

        {result && !panelOpen && (
          <button
            onClick={() => setPanelOpen(true)}
            className="mt-3 inline-flex w-full items-center justify-center gap-1 text-sm text-primary/80 transition-colors hover:text-primary"
          >
            Show suggestions
            <ArrowRight className="h-4 w-4" />
          </button>
        )}

        {submitError && (
          <p className="mt-2 text-sm text-destructive">{submitError}</p>
        )}
      </div>
    </PageLayout>
  )
}
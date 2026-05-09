import { useState } from 'react'
import {
  Brain,
  Frown,
  Heart,
  Home,
  Leaf,
  Meh,
  Sparkles,
  Smile,
  User,
  Users,
  Zap,
} from 'lucide-react'
import { PageLayout } from './Navbar'
import { Button } from './ui/button'
import { Textarea } from './ui/textarea'
import { LocationStep } from './entity/LocationStep'
import { OptionCard } from './OptionCard'
import { useEntityForm } from '../hooks/useEntityForm'

export interface SuggestionPreferences {
  social: string
  mood: string
  location: { lat: number; lng: number } | null
  locationName: string
  extraNotes: string
}

const SOCIAL_OPTIONS = [
  { value: 'alone', label: 'Just me', hint: 'Solo, your pace', Icon: User },
  { value: 'partner', label: 'With partner', hint: 'Date-friendly', Icon: Heart },
  { value: 'friends', label: 'With friends', hint: 'Group vibes', Icon: Users },
  { value: 'family', label: 'With family', hint: 'All-ages friendly', Icon: Home },
]

const MOOD_OPTIONS = [
  { value: 'sad', label: 'Sad', hint: 'Something gentle', Icon: Frown },
  { value: 'bored', label: 'Bored', hint: 'Surprise me', Icon: Meh },
  { value: 'happy', label: 'Happy', hint: 'Ready for anything', Icon: Smile },
  { value: 'calm', label: 'Calm', hint: 'Peaceful, low-key', Icon: Leaf },
  { value: 'stressed', label: 'Stressed', hint: 'Clear my head', Icon: Brain },
  { value: 'motivated', label: 'Motivated', hint: 'Need momentum', Icon: Zap },
]

export function ActivitySuggestionsPage() {
  const [social, setSocial] = useState<string | null>(null)
  const [mood, setMood]     = useState<string | null>(null)
  const [extraNotes, setExtraNotes] = useState('')

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

  function handleSubmit() {
    if (!social || !mood) return
    console.log('Activity prefs:', {
      social,
      mood,
      location,
      locationName: locationInput.trim(),
      extraNotes: extraNotes.trim(),
    } satisfies SuggestionPreferences)
  }

  return (
    <PageLayout>
      <div className="mx-auto max-w-5xl px-4 py-8 lg:px-8">
        <div className="rounded-3xl border border-border bg-card p-6 shadow-sm sm:p-8">
          <h2 className="mb-2 text-lg font-semibold">Who are you going with?</h2>
          <div className="grid grid-cols-2 gap-3 sm:grid-cols-4">
            {SOCIAL_OPTIONS.map((opt) => (
              <OptionCard
                key={opt.value}
                {...opt}
                selected={social === opt.value}
                onClick={() => setSocial(opt.value)}
              />
            ))}
          </div>
            
            <h2 className="my-2 text-lg font-semibold">How are you feeling?</h2>
              <div className="grid grid-cols-2 gap-3 sm:grid-cols-3">
                {MOOD_OPTIONS.map((opt) => (
                  <OptionCard
                    key={opt.value}
                    {...opt}
                    selected={mood === opt.value}
                    onClick={() => setMood(opt.value)}
                  />
                ))}
              </div>

              <h2 className="my-2 text-lg font-semibold">Preferences and wishes</h2>
              <Textarea
                value={extraNotes}
                onChange={(e) => setExtraNotes(e.target.value)}
                placeholder="Any specific preferences, needs, or ideas you have in mind?"
                className="min-h-28 resize-y"
              />

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

            <div className="mt-4 flex justify-end">
              <Button onClick={handleSubmit} disabled={!social || !mood} className="gap-2">
                <Sparkles className="h-4 w-4" />
                Find activities
              </Button>
            </div>
          </div>
        </div>
    </PageLayout>
  )
}
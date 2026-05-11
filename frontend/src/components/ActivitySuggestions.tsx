import { useState } from 'react'
import {
  HeartCrack,
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
    if (!social || !mood || !location) return
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

            <h2 className="text-lg font-semibold">Preferences and wishes <span className="text-sm font-normal text-muted-foreground">(optional)</span></h2>
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
            disabled={!social || !mood || !location}
          >
            <Sparkles className="h-4 w-4" /> Find activities
          </Button>
      </div>
    </PageLayout>
  )
}

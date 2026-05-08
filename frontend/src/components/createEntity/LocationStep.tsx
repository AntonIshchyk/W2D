import { Loader2, Search, MapPin } from 'lucide-react'
import { Input } from '../ui/input'
import { LocationPickerMap } from '../LocationPickerMap'
import type { CitySearchResult } from '../../types/places'

interface LocationStepProps {
  locationInput: string
  onLocationInputChange: (value: string) => void
  location: { lat: number; lng: number } | null
  onLocationSelect: (lat: number, lng: number) => Promise<void> | void
  isFetching: boolean
  isSearching: boolean
  searchResults: CitySearchResult[]
  showResults: boolean
  onShowResultsChange: (show: boolean) => void
  onApplySearchResult: (result: CitySearchResult) => void
}

export function LocationStep({
  locationInput,
  onLocationInputChange,
  location,
  onLocationSelect,
  isFetching,
  isSearching,
  searchResults,
  showResults,
  onShowResultsChange,
  onApplySearchResult,
}: LocationStepProps) {
  return (
    <div className="space-y-8 animate-in fade-in slide-in-from-right-4 duration-300">
      <div className="space-y-2 relative">
        <div className="flex items-center gap-2">
          <label className="text-xs font-semibold uppercase tracking-widest">
            Location
          </label>
          {isFetching && <Loader2 className="h-3 w-3 animate-spin text-muted-foreground" />}
        </div>
        <div className="relative">
          <Input
            value={locationInput}
            onChange={(e) => onLocationInputChange(e.target.value)}
            onFocus={() => searchResults.length > 0 && onShowResultsChange(true)}
            onBlur={() => setTimeout(() => onShowResultsChange(false), 150)}
            placeholder="Optional: search or drop a pin"
            className="pl-10 bg-card border-border text-foreground placeholder:text-muted-foreground h-12 text-base focus-visible:ring-primary focus-visible:border-primary"
            autoComplete="off"
          />
          {isSearching ? (
            <Loader2 className="h-4 w-4 animate-spin text-muted-foreground absolute left-3 top-1/2 -translate-y-1/2" />
          ) : (
            <Search className="h-4 w-4 text-muted-foreground absolute left-3 top-1/2 -translate-y-1/2" />
          )}
        </div>

        {showResults && searchResults.length > 0 && (
          <div className="absolute left-0 right-0 top-full mt-1 z-1200 rounded-md border bg-card shadow-lg overflow-hidden">
            {searchResults.slice(0, 8).map((result, idx) => (
              <button
                key={`${result.lat}-${result.lon}-${idx}`}
                type="button"
                className="w-full px-3 py-2 text-left text-sm hover:bg-accent transition-colors border-b last:border-b-0 flex items-start gap-2"
                onMouseDown={(e) => {
                  e.preventDefault()
                  onApplySearchResult(result)
                }}
              >
                <MapPin className="h-4 w-4 shrink-0 mt-0.5 text-muted-foreground" />
                <span className="line-clamp-1">{result.display_name}</span>
              </button>
            ))}
          </div>
        )}
      </div>

      <div className="rounded-2xl overflow-hidden border bg-card h-150 relative">
        <LocationPickerMap
          onLocationSelect={onLocationSelect}
          location={location ? [location.lat, location.lng] : null}
        />
      </div>
    </div>
  )
}

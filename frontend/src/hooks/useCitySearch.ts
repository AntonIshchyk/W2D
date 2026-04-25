import { useEffect, useRef, useState } from 'react'
import { searchCities } from '../api/events'
import type { CitySearchResult } from '../types/events'

type UseCitySearchOptions = {
  debounceMs?: number
  onSearchError?: () => void
}

export function useCitySearch(options?: UseCitySearchOptions) {
  const debounceMs = options?.debounceMs ?? 350
  const onSearchErrorRef = useRef(options?.onSearchError)
  const skipNextSearchRef = useRef(false)
  const [query, setQuery] = useState('')
  const [results, setResults] = useState<CitySearchResult[]>([])
  const [showResults, setShowResults] = useState(false)
  const [isSearching, setIsSearching] = useState(false)
  const searchDebounceRef = useRef<ReturnType<typeof setTimeout> | null>(null)

  useEffect(() => {
    onSearchErrorRef.current = options?.onSearchError
  }, [options?.onSearchError])

  useEffect(() => {
    if (searchDebounceRef.current) clearTimeout(searchDebounceRef.current)

    if (skipNextSearchRef.current) {
      skipNextSearchRef.current = false
      return
    }

    if (!query.trim()) {
      setResults([])
      setShowResults(false)
      setIsSearching(false)
      return
    }

    setIsSearching(true)
    searchDebounceRef.current = setTimeout(async () => {
      try {
        const nextResults = await searchCities(query)
        setResults(nextResults ?? [])
        setShowResults(true)
      } catch {
        setResults([])
        onSearchErrorRef.current?.()
      } finally {
        setIsSearching(false)
      }
    }, debounceMs)

    return () => {
      if (searchDebounceRef.current) clearTimeout(searchDebounceRef.current)
    }
  }, [query, debounceMs])

  const clear = () => {
    setQuery('')
    setResults([])
    setShowResults(false)
    setIsSearching(false)
  }

  const setQuerySilently = (nextQuery: string) => {
    skipNextSearchRef.current = true
    setQuery(nextQuery)
    setResults([])
    setShowResults(false)
    setIsSearching(false)
  }

  return {
    query,
    setQuery,
    setQuerySilently,
    results,
    isSearching,
    showResults,
    setShowResults,
    clear,
  }
}

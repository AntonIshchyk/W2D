import { useEffect, useRef } from 'react'
import { useMap, useMapEvents } from 'react-leaflet'
import type { PlaceQueryBounds } from '../types/places'

export interface FlyToTarget {
  center: [number, number]
  zoom: number
  id: number
}

interface MapControllerProps {
  onBoundsChange: (b: PlaceQueryBounds) => void
  onViewChange?: (center: [number, number], zoom: number) => void
  onMapClick: () => void
  flyToTarget?: FlyToTarget | null
}

export function MapController({
  onBoundsChange,
  onViewChange,
  onMapClick,
  flyToTarget,
}: MapControllerProps) {
  const map = useMap()
  const handledFlyIdRef = useRef<number | null>(null)

  useMapEvents({
    moveend: () => {
      const b = map.getBounds()
      onBoundsChange({
        minLat: b.getSouth(),
        maxLat: b.getNorth(),
        minLng: b.getWest(),
        maxLng: b.getEast(),
      })
      const c = map.getCenter()
      onViewChange?.([c.lat, c.lng], map.getZoom())
    },
    click: () => onMapClick(),
  })

  useEffect(() => {
    if (!flyToTarget) return
    if (flyToTarget.id === handledFlyIdRef.current) return
    handledFlyIdRef.current = flyToTarget.id
    map.flyTo(flyToTarget.center, flyToTarget.zoom, { duration: 1.8 })
  }, [flyToTarget, map])

  return null
}

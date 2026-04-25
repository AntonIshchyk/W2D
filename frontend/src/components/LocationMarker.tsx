import { useEffect, useState } from 'react'
import { Marker, useMapEvents } from 'react-leaflet'
import L from 'leaflet'

interface LocationMarkerProps {
  onLocationSelect: (lat: number, lng: number) => void
  defaultLocation?: [number, number]
  location?: [number, number] | null
}

export function LocationMarker({ onLocationSelect, defaultLocation, location }: LocationMarkerProps) {
  const [position, setPosition] = useState<L.LatLng | null>(
    defaultLocation ? new L.LatLng(defaultLocation[0], defaultLocation[1]) : null,
  )

  const map = useMapEvents({
    click(e) {
      setPosition(e.latlng)
      onLocationSelect(e.latlng.lat, e.latlng.lng)
      map.flyTo(e.latlng, map.getZoom())
    },
  })

  useEffect(() => {
    if (!location) return

    const [lat, lng] = location
    const next = new L.LatLng(lat, lng)
    setPosition((prev) => {
      if (prev && prev.lat === next.lat && prev.lng === next.lng) {
        return prev
      }
      return next
    })

    map.flyTo(next, Math.max(map.getZoom(), 13))
  }, [location, map])

  return position ? <Marker position={position} /> : null
}

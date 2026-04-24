import { useState } from 'react'
import { Marker, useMapEvents } from 'react-leaflet'
import L from 'leaflet'

interface LocationMarkerProps {
  onLocationSelect: (lat: number, lng: number) => void
  defaultLocation?: [number, number]
}

export function LocationMarker({ onLocationSelect, defaultLocation }: LocationMarkerProps) {
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

  return position ? <Marker position={position} /> : null
}

import { useEffect, useMemo, useState } from 'react'
import { Marker, useMapEvents } from 'react-leaflet'
import L from 'leaflet'

interface LocationMarkerProps {
  onLocationSelect: (lat: number, lng: number) => void
  defaultLocation?: [number, number]
  location?: [number, number] | null
}

export function LocationMarker({ onLocationSelect, defaultLocation, location }: LocationMarkerProps) {
  const [clickedPosition, setClickedPosition] = useState<L.LatLng | null>(
    defaultLocation ? new L.LatLng(defaultLocation[0], defaultLocation[1]) : null,
  )

  const map = useMapEvents({
    click(e) {
      setClickedPosition(e.latlng)
      onLocationSelect(e.latlng.lat, e.latlng.lng)
      map.flyTo(e.latlng, map.getZoom())
    },
  })

  const controlledPosition = useMemo(
    () => location ? new L.LatLng(location[0], location[1]) : null,
    [location],
  )

  useEffect(() => {
    if (controlledPosition) map.flyTo(controlledPosition, Math.max(map.getZoom(), 13))
  }, [controlledPosition, map])

  const position = controlledPosition ?? clickedPosition

  return position ? <Marker position={position} /> : null
}

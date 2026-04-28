import {
  MapContainer,
  TileLayer,
  Marker,
  ZoomControl,
} from 'react-leaflet'
import 'leaflet/dist/leaflet.css'
import L from 'leaflet'
import { ensureLeafletDefaultIcon } from '../utils/leafletIcon'
import { MapController, type FlyToTarget } from './MapController'
import type { Place, PlaceQueryBounds } from '../types/places'

ensureLeafletDefaultIcon()

interface PlacesMapProps {
  places: Place[]
  onBoundsChange: (bounds: PlaceQueryBounds) => void
  onViewChange?: (center: [number, number], zoom: number) => void
  flyToTarget?: FlyToTarget | null
  selectedPlaceId?: number | null
  onPlaceClick?: (place: Place | null) => void
  initialCenter?: [number, number]
  initialZoom?: number
}

export function PlacesMap({
  places,
  onBoundsChange,
  onViewChange,
  flyToTarget,
  selectedPlaceId,
  onPlaceClick,
  initialCenter = [20, 0],
  initialZoom = 2,
}: PlacesMapProps) {
  return (
    <div className="w-full h-full relative z-0">
      <MapContainer
        center={initialCenter}
        zoom={initialZoom}
        scrollWheelZoom
        zoomControl={false}
        style={{ height: '100%', width: '100%', zIndex: 0 }}
      >
        <ZoomControl position="bottomleft" />
        <TileLayer
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        <MapController
          onBoundsChange={onBoundsChange}
          onViewChange={onViewChange}
          onMapClick={() => onEventClick?.(null)}
          flyToTarget={flyToTarget}
        />
        {places.map((place) => {
          if (place.latitude == null || place.longitude == null) return null
          const isSelected = selectedPlaceId === place.id
          return (
            <Marker
              key={place.id}
              position={[place.latitude, place.longitude]}
              opacity={selectedPlaceId != null ? (isSelected ? 1 : 0.45) : 1}
              eventHandlers={{
                click: (e) => {
                  L.DomEvent.stopPropagation(e)
                  onPlaceClick?.(place)
                },
              }}
            />
          )
        })}
      </MapContainer>
    </div>
  )
}
export type { FlyToTarget }

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
import type { Event, EventQueryBounds } from '../types/events'

ensureLeafletDefaultIcon()

interface EventsMapProps {
  events: Event[]
  onBoundsChange: (bounds: EventQueryBounds) => void
  onViewChange?: (center: [number, number], zoom: number) => void
  flyToTarget?: FlyToTarget | null
  selectedEventId?: number | null
  onEventClick?: (event: Event | null) => void
  initialCenter?: [number, number]
  initialZoom?: number
}

export function EventsMap({
  events,
  onBoundsChange,
  onViewChange,
  flyToTarget,
  selectedEventId,
  onEventClick,
  initialCenter = [20, 0],
  initialZoom = 2,
}: EventsMapProps) {
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
        {events.map((event) => {
          if (event.latitude == null || event.longitude == null) return null
          const isSelected = selectedEventId === event.id
          return (
            <Marker
              key={event.id}
              position={[event.latitude, event.longitude]}
              opacity={selectedEventId != null ? (isSelected ? 1 : 0.45) : 1}
              eventHandlers={{
                click: (e) => {
                  L.DomEvent.stopPropagation(e)
                  onEventClick?.(event)
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


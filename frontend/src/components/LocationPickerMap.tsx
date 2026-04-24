import { MapContainer, TileLayer } from 'react-leaflet'
import 'leaflet/dist/leaflet.css'
import { ensureLeafletDefaultIcon } from '../utils/leafletIcon'
import { LocationMarker } from './LocationMarker'

ensureLeafletDefaultIcon()

interface LocationPickerProps {
  onLocationSelect: (lat: number, lng: number) => void
  defaultLocation?: [number, number]
}

export function LocationPickerMap({ onLocationSelect, defaultLocation }: LocationPickerProps) {
  return (
    <div className="w-full h-full min-h-full rounded-md overflow-hidden border">
      <MapContainer
        center={defaultLocation ?? [20, 0]}
        zoom={defaultLocation ? 13 : 2}
        scrollWheelZoom
        style={{ height: '100%', width: '100%', minHeight: '100%' }}
      >
        <TileLayer
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        <LocationMarker onLocationSelect={onLocationSelect} defaultLocation={defaultLocation} />
      </MapContainer>
    </div>
  )
}

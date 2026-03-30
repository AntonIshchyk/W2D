import { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, useMapEvents } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import L from 'leaflet';

// Fix Leaflet's default icon path issues in React
delete (L.Icon.Default.prototype as any)._getIconUrl;
L.Icon.Default.mergeOptions({
  iconUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon.png',
  iconRetinaUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon-2x.png',
  shadowUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-shadow.png',
});

interface LocationPickerProps {
  onLocationSelect: (lat: number, lng: number) => void;
  defaultLocation?: [number, number];
}

function LocationMarker({ onLocationSelect, defaultLocation }: LocationPickerProps) {
  const [position, setPosition] = useState<L.LatLng | null>(
    defaultLocation ? new L.LatLng(defaultLocation[0], defaultLocation[1]) : null
  )

  const map = useMapEvents({
    click(e) {
      setPosition(e.latlng)
      onLocationSelect(e.latlng.lat, e.latlng.lng)
      map.flyTo(e.latlng, map.getZoom())
    },
  })

  return position === null ? null : (
    <Marker position={position} />
  )
}

export function LocationPickerMap({ onLocationSelect, defaultLocation }: LocationPickerProps) {
  return (
    <div className="w-full h-[300px] rounded-md overflow-hidden border">
      <MapContainer 
        center={defaultLocation || [51.505, -0.09]} 
        zoom={13} 
        scrollWheelZoom={true} 
        style={{ height: '100%', width: '100%' }}
      >
        <TileLayer
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        <LocationMarker onLocationSelect={onLocationSelect} defaultLocation={defaultLocation} />
      </MapContainer>
    </div>
  );
}
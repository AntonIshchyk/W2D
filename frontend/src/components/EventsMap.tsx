import { useEffect } from 'react';
import { MapContainer, TileLayer, Marker, useMapEvents, useMap } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import L from 'leaflet';
import { ensureLeafletDefaultIcon } from '../utils/leafletIcon';
import type { Event, EventQueryBounds } from '../types/events';

ensureLeafletDefaultIcon();

interface EventsMapProps {
  events: Event[];
  onBoundsChange: (bounds: EventQueryBounds) => void;
  center?: [number, number];
  zoom?: number;
  selectedEventId?: number | null;
  onEventClick?: (event: Event | null) => void;
}

// Sub-component to handle map bounds detection, clicks, and update parent
function MapBoundsHandler({ onBoundsChange, onMapClick }: { onBoundsChange: (b: EventQueryBounds) => void, onMapClick?: () => void }) {
  useMapEvents({
    moveend: (e) => {
      const bounds = e.target.getBounds() as L.LatLngBounds;
      onBoundsChange({
        minLat: bounds.getSouth(),
        maxLat: bounds.getNorth(),
        minLng: bounds.getWest(),
        maxLng: bounds.getEast(),
      });
    },
    click: () => {
      onMapClick?.();
    }
  });
  return null;
}

// Sub-component to pan the map programmatically when a user searches for a city
function MapUpdater({ center, zoom, selectedEventId }: { center: [number, number]; zoom: number; selectedEventId?: number | null }) {
  const map = useMap();
  useEffect(() => {
    map.flyTo(center, zoom);
  }, [center, zoom, map]);

  useEffect(() => {
    // When the selected event changes, the container width might change
    // We need to invalidate the map size so it renders fully to the new bounds
    const timeout = setTimeout(() => {
      map.invalidateSize({ animate: true });
    }, 300); // 300ms matches the CSS transition duration
    
    return () => clearTimeout(timeout);
  }, [selectedEventId, map]);

  return null;
}

export function EventsMap({ events, onBoundsChange, center = [51.505, -0.09], zoom = 12, onEventClick, selectedEventId }: EventsMapProps) {
  return (
    <div className="w-full h-full relative z-0">
      <MapContainer
        center={center}
        zoom={zoom}
        scrollWheelZoom={true}
        style={{ height: '100%', width: '100%', zIndex: 0 }}
      >
        <TileLayer
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        <MapBoundsHandler onBoundsChange={onBoundsChange} onMapClick={() => onEventClick?.(null)} />
        <MapUpdater center={center} zoom={zoom} selectedEventId={selectedEventId} />

        {events.map((event) => {
          if (event.latitude == null || event.longitude == null) return null;
          
          const isSelected = selectedEventId === event.id;
          
          // Optionally we could change the icon for selected items, but for now we adjust opacity or similar
          // Alternatively, let's keep the marker standard
          return (
            <Marker
              key={event.id}
              position={[event.latitude, event.longitude]}
              opacity={selectedEventId ? (isSelected ? 1 : 0.5) : 1}
              eventHandlers={{
                click: (e) => {
                  L.DomEvent.stopPropagation(e)
                  onEventClick?.(event)
                }
              }}
            />
          );
        })}
      </MapContainer>
    </div>
  );
}

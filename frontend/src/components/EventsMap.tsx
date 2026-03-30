import { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup, useMapEvents, useMap } from 'react-leaflet';
import { useNavigate } from 'react-router-dom';
import 'leaflet/dist/leaflet.css';
import { Button } from './ui/button';
import { format } from 'date-fns';
import L from 'leaflet';
import { ensureLeafletDefaultIcon } from '../utils/leafletIcon';
import type { Event, EventQueryBounds } from '../types/events';

ensureLeafletDefaultIcon();

type PopupEvent = Event & { latitude: number; longitude: number };

interface EventsMapProps {
  events: Event[];
  onBoundsChange: (bounds: EventQueryBounds) => void;
  center?: [number, number];
  zoom?: number;
}

// Sub-component to handle map bounds detection and update parent
function MapBoundsHandler({ onBoundsChange }: { onBoundsChange: (b: EventQueryBounds) => void }) {
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
  });
  return null;
}

// Sub-component to pan the map programmatically when a user searches for a city
function MapUpdater({ center, zoom }: { center: [number, number]; zoom: number }) {
  const map = useMap();
  useEffect(() => {
    map.flyTo(center, zoom);
  }, [center, zoom, map]);
  return null;
}

export function EventsMap({ events, onBoundsChange, center = [51.505, -0.09], zoom = 12 }: EventsMapProps) {
  const navigate = useNavigate();
  const [popupInfo, setPopupInfo] = useState<PopupEvent | null>(null);

  return (
    <div className="w-full h-150 rounded-xl overflow-hidden border shadow-sm relative z-0">
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
        <MapBoundsHandler onBoundsChange={onBoundsChange} />
        <MapUpdater center={center} zoom={zoom} />

        {events.map((event) => {
          if (event.latitude == null || event.longitude == null) return null;
          
          return (
            <Marker
              key={event.id}
              position={[event.latitude, event.longitude]}
              eventHandlers={{
                click: () =>
                  setPopupInfo({
                    ...event,
                    latitude: event.latitude!,
                    longitude: event.longitude!,
                  })
              }}
            />
          );
        })}

        {popupInfo && (
          <Popup
            position={[popupInfo.latitude, popupInfo.longitude]}
            eventHandlers={{
              remove: () => setPopupInfo(null)
            }}
          >
            <div className="p-1 space-y-2 min-w-50">
              <h3 className="font-semibold text-sm leading-tight m-0">{popupInfo.title}</h3>
              <p className="text-xs text-muted-foreground line-clamp-2 m-0 mt-1">
                {popupInfo.description}
              </p>
              <div className="text-xs mt-1">
                {format(new Date(popupInfo.scheduledAt), 'MMM d, h:mm a')}
              </div>
              <Button 
                size="sm" 
                variant="default"
                className="w-full text-xs h-7 mt-2" 
                onClick={() => navigate(`/events/${popupInfo.id}`)}
              >
                View Details
              </Button>
            </div>
          </Popup>
        )}
      </MapContainer>
    </div>
  );
}
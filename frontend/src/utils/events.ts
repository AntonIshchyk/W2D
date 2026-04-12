const DEFAULT_CENTER: [number, number] = [20, 0]
const DEFAULT_ZOOM = 3

export function loadMapState(): { center: [number, number]; zoom: number } {
  try {
    const raw = localStorage.getItem('events.mapState')
    if (!raw) return { center: DEFAULT_CENTER, zoom: DEFAULT_ZOOM }
    const parsed = JSON.parse(raw)
    const lat  = Number(parsed.center?.[0])
    const lng  = Number(parsed.center?.[1])
    const zoom = Number(parsed.zoom)
    if (
      !isNaN(lat)  && lat  >= -90  && lat  <= 90 &&
      !isNaN(lng)  && lng  >= -180 && lng  <= 180 &&
      !isNaN(zoom) && zoom >= 0    && zoom <= 22
    ) {
      return { center: [lat, lng], zoom }
    }
  } catch {}
  return { center: DEFAULT_CENTER, zoom: DEFAULT_ZOOM }
}

export { DEFAULT_CENTER, DEFAULT_ZOOM }

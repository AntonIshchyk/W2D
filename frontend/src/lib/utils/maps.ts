export function getGoogleMapsUrl(latitude?: number | null, longitude?: number | null, locationName?: string | null): string | null {
  if (latitude != null && longitude != null) {
    return `https://www.google.com/maps/search/?api=1&query=${latitude},${longitude}`
  }
  if (locationName) {
    return `https://www.google.com/maps/search/?api=1&query=${encodeURIComponent(locationName)}`
  }
  return null
}

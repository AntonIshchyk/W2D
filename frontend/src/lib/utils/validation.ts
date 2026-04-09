export function isValidImageUrl(url: string): boolean {
  try {
    const parsed = new URL(url)
    return ['http:', 'https:'].includes(parsed.protocol) && /\.(jpg|jpeg|png|gif|webp)$/i.test(parsed.pathname)
  } catch {
    return false
  }
}

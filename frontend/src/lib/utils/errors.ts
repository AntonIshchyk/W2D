export function extractErrorMessage(err: unknown): string {
  if (err instanceof Error) {
    try {
      const parsed = JSON.parse(err.message)
      if (parsed.errors && typeof parsed.errors === 'object') {
        const messages: string[] = []
        for (const [fieldErrors] of Object.entries(parsed.errors)) {
          if (Array.isArray(fieldErrors)) {
            messages.push(...fieldErrors)
          }
        }
        if (messages.length > 0) {
          return messages.join(' ')
        }
      }
      if (parsed.title) {
        return parsed.title
      }
    } catch {
    }
    return err.message || 'An error occurred'
  }
  return 'An unknown error occurred'
}

/**
 * Ensures a fetch response is OK (status 200-299).
 * Throws an error with the provided message if the response is not OK.
 */
export async function ensureResponseOk(response: Response, errorMessage: string): Promise<void> {
  if (!response.ok) {
    let detail = ''
    try {
      const body = await response.json()
      detail = body.message || body.error || JSON.stringify(body)
    } catch {
      detail = response.statusText || `HTTP ${response.status}`
    }
    throw new Error(`${errorMessage}: ${detail}`)
  }
}

/**
 * Sends a vote request (typically POST/DELETE to a vote endpoint).
 */
export async function sendVoteRequest(
  url: string,
  headers: Record<string, string>,
  value: number,
  errorMessage: string
): Promise<void> {
  const response = await fetch(url, {
    method: value === 0 ? 'DELETE' : 'POST',
    headers,
    body: value === 0 ? undefined : JSON.stringify({ value }),
  })

  await ensureResponseOk(response, errorMessage)
}

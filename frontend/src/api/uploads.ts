import { getAuthHeaders } from '../config/api'
import { API_ENDPOINTS } from '../config/api'

export async function getPresignedUrl(file: File): Promise<{ uploadUrl: string; publicUrl: string }> {
  const res = await fetch(API_ENDPOINTS.uploads.presign, {
    method: 'POST',
    headers: { ...getAuthHeaders(), 'Content-Type': 'application/json' },
    body: JSON.stringify({ fileName: file.name, contentType: file.type }),
  })
  if (!res.ok) {
    const err = await res.json().catch(() => ({}))
    throw new Error(err.message ?? 'Failed to get upload URL')
  }
  return res.json()
}

export async function uploadToR2(uploadUrl: string, file: File): Promise<void> {
  const res = await fetch(uploadUrl, {
    method: 'PUT',
    headers: { 'Content-Type': file.type },
    body: file,
  })
  if (!res.ok) throw new Error('Upload to storage failed')
}

import { useState, useRef, useCallback } from 'react'
import { X, ImagePlus, Loader2 } from 'lucide-react'
import { getAuthHeaders } from '../config/api'
import { API_ENDPOINTS } from '../config/api'
import { toast } from 'sonner'

interface PhotoUploadProps {
  value: string[]
  onChange: (urls: string[]) => void
  maxPhotos?: number
  disabled?: boolean
}

interface UploadingFile {
  id: string
  previewUrl: string
  progress: 'uploading' | 'done' | 'error'
}

async function getPresignedUrl(file: File): Promise<{ uploadUrl: string; publicUrl: string }> {
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

async function uploadToR2(uploadUrl: string, file: File): Promise<void> {
  const res = await fetch(uploadUrl, {
    method: 'PUT',
    headers: { 'Content-Type': file.type },
    body: file,
  })
  if (!res.ok) throw new Error('Upload to storage failed')
}

const MAX_FILE_SIZE = 10 * 1024 * 1024 // 10MB
const ALLOWED_TYPES = ['image/jpeg', 'image/jpg', 'image/png', 'image/webp', 'image/gif']

export function PhotoUpload({
  value,
  onChange,
  maxPhotos = 4,
  disabled = false,
}: PhotoUploadProps) {
  const [uploading, setUploading] = useState<UploadingFile[]>([])
  const [isDragging, setIsDragging] = useState(false)
  const inputRef = useRef<HTMLInputElement>(null)

  const canAddMore = value.length + uploading.filter(u => u.progress === 'uploading').length < maxPhotos

  const processFile = useCallback(async (file: File) => {
    if (!ALLOWED_TYPES.includes(file.type)) {
      toast.error(`${file.name}: only JPEG, PNG, WebP or GIF allowed`)
      return
    }
    if (file.size > MAX_FILE_SIZE) {
      toast.error(`${file.name}: max file size is 10MB`)
      return
    }

    const tempId = crypto.randomUUID()
    const previewUrl = URL.createObjectURL(file)

    setUploading(prev => [...prev, { id: tempId, previewUrl, progress: 'uploading' }])

    try {
      const { uploadUrl, publicUrl } = await getPresignedUrl(file)
      await uploadToR2(uploadUrl, file)

      // Success — add real URL, remove from uploading
      onChange([...value, publicUrl])
      setUploading(prev => prev.filter(u => u.id !== tempId))
      URL.revokeObjectURL(previewUrl)
    } catch (err) {
      setUploading(prev =>
        prev.map(u => u.id === tempId ? { ...u, progress: 'error' } : u)
      )
      toast.error(`Failed to upload ${file.name}`)
    }
  }, [value, onChange])

  const handleFiles = useCallback((files: FileList | null) => {
    if (!files) return
    const remaining = maxPhotos - value.length
    Array.from(files).slice(0, remaining).forEach(processFile)
  }, [processFile, value.length, maxPhotos])

  const handleDrop = useCallback((e: React.DragEvent) => {
    e.preventDefault()
    setIsDragging(false)
    if (!disabled && canAddMore) handleFiles(e.dataTransfer.files)
  }, [disabled, canAddMore, handleFiles])

  const removePhoto = (url: string) => {
    onChange(value.filter(u => u !== url))
  }

  const removeUploading = (id: string) => {
    setUploading(prev => {
      const item = prev.find(u => u.id === id)
      if (item) URL.revokeObjectURL(item.previewUrl)
      return prev.filter(u => u.id !== id)
    })
  }

  const allPreviews = [
    ...value.map(url => ({ type: 'done' as const, url })),
    ...uploading.map(u => ({ type: u.progress, url: u.previewUrl, id: u.id })),
  ]

  return (
    <div className="space-y-2">
      {/* Preview grid */}
      {allPreviews.length > 0 && (
        <div className="grid grid-cols-4 gap-2">
          {allPreviews.map((item, i) => (
            <div key={i} className="relative aspect-square rounded-lg overflow-hidden bg-muted">
              <img
                src={item.url}
                alt=""
                className="w-full h-full object-cover"
              />
              {/* Uploading overlay */}
              {item.type === 'uploading' && (
                <div className="absolute inset-0 bg-black/40 flex items-center justify-center">
                  <Loader2 className="h-5 w-5 text-white animate-spin" />
                </div>
              )}
              {/* Error overlay */}
              {item.type === 'error' && (
                <div className="absolute inset-0 bg-red-500/40 flex items-center justify-center">
                  <span className="text-white text-xs font-medium">Failed</span>
                </div>
              )}
              {/* Remove button */}
              <button
                type="button"
                onClick={() => item.type === 'done'
                  ? removePhoto(item.url)
                  : removeUploading((item as any).id)
                }
                className="absolute top-1 right-1 w-5 h-5 rounded-full bg-black/60 text-white flex items-center justify-center hover:bg-black/80 transition-colors"
              >
                <X className="h-3 w-3" />
              </button>
            </div>
          ))}
        </div>
      )}

      {/* Drop zone — only show if can add more */}
      {canAddMore && !disabled && (
        <div
          onDragOver={e => { e.preventDefault(); setIsDragging(true) }}
          onDragLeave={() => setIsDragging(false)}
          onDrop={handleDrop}
          onClick={() => inputRef.current?.click()}
          className={`
            flex flex-col items-center justify-center gap-1.5 
            border-2 border-dashed rounded-lg p-4 cursor-pointer
            transition-colors text-center
            ${isDragging
              ? 'border-foreground bg-muted'
              : 'border-muted-foreground/25 hover:border-muted-foreground/50 hover:bg-muted/50'
            }
          `}
        >
          <ImagePlus className="h-5 w-5 text-muted-foreground" />
          <div>
            <p className="text-xs text-muted-foreground">
              Drop photos here or <span className="underline">browse</span>
            </p>
            <p className="text-xs text-muted-foreground/60 mt-0.5">
              JPEG, PNG, WebP · max 10MB · {maxPhotos - value.length} remaining
            </p>
          </div>
          <input
            ref={inputRef}
            type="file"
            accept={ALLOWED_TYPES.join(',')}
            multiple
            className="hidden"
            onChange={e => handleFiles(e.target.files)}
          />
        </div>
      )}

      {!canAddMore && (
        <p className="text-xs text-muted-foreground">
          Maximum {maxPhotos} photos reached
        </p>
      )}
    </div>
  )
}

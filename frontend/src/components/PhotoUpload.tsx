import { useState, useRef, useCallback } from 'react'
import { X, ImagePlus, Loader2 } from 'lucide-react'
import { toast } from 'sonner'

import { getPresignedUrl, uploadToR2 } from '../features/uploads/api'

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

const MAX_FILE_SIZE = 10 * 1024 * 1024
const ALLOWED_TYPES = ['image/jpeg', 'image/jpg', 'image/png', 'image/webp', 'image/gif']

export function PhotoUpload({
  value,
  onChange,
  maxPhotos = 4,
  disabled = false,
}: PhotoUploadProps) {
  const [uploading, setUploading] = useState<UploadingFile[]>([])
  const inputRef = useRef<HTMLInputElement>(null)
  const confirmedRef = useRef<string[]>(value)
  confirmedRef.current = value

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

      confirmedRef.current = [...confirmedRef.current, publicUrl]
      onChange(confirmedRef.current)

      setUploading(prev => prev.filter(u => u.id !== tempId))
      URL.revokeObjectURL(previewUrl)
    } catch (err) {
      setUploading(prev =>
        prev.map(u => u.id === tempId ? { ...u, progress: 'error' } : u)
      )
      toast.error(`Failed to upload ${file.name}`)
    }
  }, [onChange])

  const handleFiles = useCallback((files: FileList | null) => {
    if (!files) return
    const remaining = maxPhotos - value.length
    Array.from(files).slice(0, remaining).forEach(processFile)
  }, [processFile, value.length, maxPhotos])


  const removePhoto = (url: string) => {
    const next = value.filter(u => u !== url)
    confirmedRef.current = next
    onChange(next)
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
      {allPreviews.length > 0 && (
        <div className="grid grid-cols-4 gap-2">
          {allPreviews.map((item, i) => (
            <div key={i} className="relative aspect-square rounded-lg overflow-hidden bg-muted">
              <img src={item.url} alt="" className="w-full h-full object-cover" />

              {item.type === 'uploading' && (
                <div className="absolute inset-0 bg-black/40 flex items-center justify-center">
                  <Loader2 className="h-5 w-5 text-white animate-spin" />
                </div>
              )}

              {item.type === 'error' && (
                <div className="absolute inset-0 bg-red-500/40 flex items-center justify-center">
                  <span className="text-white text-xs font-medium">Failed</span>
                </div>
              )}

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

      {canAddMore && !disabled && (
        <div
          onClick={() => inputRef.current?.click()}
          className="inline-flex items-center justify-center p-2 rounded-full hover:bg-muted/50 text-muted-foreground hover:text-foreground transition-colors cursor-pointer w-fit"
          title={`Upload photo (max ${maxPhotos})`}
        >
          <ImagePlus className="h-5 w-5" />
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

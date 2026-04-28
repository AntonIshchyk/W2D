import { useRef, useState } from 'react'
import { AlertCircle, CheckCircle2, Loader2, Star, Upload, X } from 'lucide-react'
import { toast } from 'sonner'

import { getPresignedUrl, uploadToR2 } from '../api/uploads'

interface PlaceImageUploadProps {
  value: string[]
  onChange: (urls: string[]) => void
  maxFiles?: number
  disabled?: boolean
}

interface UploadListItem {
  id: string
  fileName: string
  sizeLabel: string
  status: 'uploading' | 'done' | 'error'
  publicUrl?: string
  errorMessage?: string
  previewUrl: string
}

const MAX_FILE_SIZE_MB = 10
const MAX_FILE_SIZE = MAX_FILE_SIZE_MB * 1024 * 1024
const ALLOWED_TYPES = ['image/jpeg', 'image/jpg', 'image/png', 'image/webp', 'image/gif']

function formatMb(bytes: number): string {
  return (bytes / (1024 * 1024)).toFixed(1)
}

function deriveUploadError(file: File): string | null {
  if (!ALLOWED_TYPES.includes(file.type)) {
    return 'Unsupported format. Allowed: JPEG, PNG, WebP, GIF.'
  }
  if (file.size > MAX_FILE_SIZE) {
    return `File is ${formatMb(file.size)}MB. Max allowed is ${MAX_FILE_SIZE_MB}MB.`
  }
  return null
}

export function PlaceImageUpload({
  value,
  onChange,
  maxFiles = 4,
  disabled = false,
}: PlaceImageUploadProps) {
  const [items, setItems] = useState<UploadListItem[]>([])
  const [isDragging, setIsDragging] = useState(false)
  const inputRef = useRef<HTMLInputElement>(null)
  const confirmedRef = useRef<string[]>(value)
  confirmedRef.current = value

  const activeUploads = items.filter((i) => i.status === 'uploading').length

  const canAddMore = value.length + activeUploads < maxFiles
  const isUploading = activeUploads > 0

  const openPicker = () => {
    if (disabled || !canAddMore) return
    inputRef.current?.click()
  }

  const clearFileInput = () => {
    if (inputRef.current) inputRef.current.value = ''
  }

  const reorderItemsForCover = (coverUrl: string) => {
    setItems((prev) => {
      const coverIndex = prev.findIndex((item) => item.publicUrl === coverUrl)
      if (coverIndex <= 0) return prev

      const next = [...prev]
      const [coverItem] = next.splice(coverIndex, 1)
      next.unshift(coverItem)
      return next
    })
  }

  const setCoverImage = (coverUrl: string) => {
    const next = [coverUrl, ...confirmedRef.current.filter((url) => url !== coverUrl)]
    confirmedRef.current = next
    onChange(next)
    reorderItemsForCover(coverUrl)
  }

  const uploadSingleFile = async (file: File) => {
    const tempId = crypto.randomUUID()
    const sizeLabel = `${formatMb(file.size)}MB`
    const previewUrl = URL.createObjectURL(file)
    const validationError = deriveUploadError(file)

    if (validationError) {
      setItems((prev) => [
        {
          id: tempId,
          fileName: file.name,
          sizeLabel,
          status: 'error',
          errorMessage: validationError,
          previewUrl,
        },
        ...prev,
      ])
      toast.error(`${file.name}: ${validationError}`)
      return
    }

    setItems((prev) => [
      {
        id: tempId,
        fileName: file.name,
        sizeLabel,
        status: 'uploading',
        previewUrl,
      },
      ...prev,
    ])

    try {
      const { uploadUrl, publicUrl } = await getPresignedUrl(file)
      await uploadToR2(uploadUrl, file)

      confirmedRef.current = [...confirmedRef.current, publicUrl]
      onChange(confirmedRef.current)

      setItems((prev) =>
        prev.map((item) =>
          item.id === tempId
            ? { ...item, status: 'done', publicUrl, previewUrl: publicUrl }
            : item
        ),
      )
      URL.revokeObjectURL(previewUrl)
    } catch (err) {
      const detail = err instanceof Error ? err.message : 'Unknown upload error'
      setItems((prev) =>
        prev.map((item) =>
          item.id === tempId
            ? { ...item, status: 'error', errorMessage: detail }
            : item
        ),
      )
      toast.error(`Failed to upload ${file.name}: ${detail}`)
    }
  }

  const handleFileChange = async (files: FileList | null) => {
    if (!files || files.length === 0) return

    const remaining = maxFiles - (value.length + activeUploads)
    if (remaining <= 0) {
      toast.error(`Maximum ${maxFiles} images allowed`)
      clearFileInput()
      return
    }

    const selected = Array.from(files)
    if (selected.length > remaining) {
      toast.error(`You selected ${selected.length} files, but only ${remaining} more can be added`)
    }

    const accepted = selected.slice(0, remaining)
    await Promise.all(accepted.map((file) => uploadSingleFile(file)))
    clearFileInput()
  }

  const handleDrop = async (event: React.DragEvent<HTMLDivElement>) => {
    event.preventDefault()
    setIsDragging(false)
    if (disabled || !canAddMore) return
    await handleFileChange(event.dataTransfer.files)
  }

  const removeItem = (id: string) => {
    setItems((prev) => {
      const target = prev.find((item) => item.id === id)
      if (target?.status === 'done' && target.publicUrl) {
        const next = confirmedRef.current.filter((url) => url !== target.publicUrl)
        confirmedRef.current = next
        onChange(next)
      }
      if (target?.status === 'error') {
        URL.revokeObjectURL(target.previewUrl)
      }
      return prev.filter((item) => item.id !== id)
    })
  }

  const uploadedItems = items.filter((item) => item.status !== 'error' || item.previewUrl)
  const doneItemsCount = items.filter((item) => item.status === 'done').length

  return (
    <div className="space-y-4">
      <input
        ref={inputRef}
        type="file"
        accept={ALLOWED_TYPES.join(',')}
        multiple
        className="hidden"
        onChange={(e) => void handleFileChange(e.target.files)}
      />

      <div
        role="button"
        tabIndex={disabled ? -1 : 0}
        onClick={openPicker}
        onDragEnter={(e) => {
          e.preventDefault()
          if (!disabled && canAddMore) setIsDragging(true)
        }}
        onDragOver={(e) => {
          e.preventDefault()
          if (!disabled && canAddMore) setIsDragging(true)
        }}
        onDragLeave={(e) => {
          e.preventDefault()
          setIsDragging(false)
        }}
        onDrop={handleDrop}
        onKeyDown={(e) => {
          if (disabled || !canAddMore) return
          if (e.key === 'Enter' || e.key === ' ') {
            e.preventDefault()
            openPicker()
          }
        }}
        className={[
          'w-full rounded-2xl border-2 border-dashed transition-all p-8 text-center',
          isDragging ? 'border-primary bg-primary/10' : 'border-primary/30 bg-primary/5 hover:bg-primary/10',
          disabled || !canAddMore ? 'cursor-not-allowed opacity-70' : 'cursor-pointer',
        ].join(' ')}
      >
        {isUploading ? (
          <Loader2 className="h-10 w-10 animate-spin text-muted-foreground mx-auto" />
        ) : (
          <Upload className="h-10 w-10 text-muted-foreground mx-auto" />
        )}

        <p className="text-base font-medium text-foreground mt-3">Drag & drop or choose images to upload</p>
        <p className="text-sm text-muted-foreground mt-1">Max {maxFiles} files · Allowed: JPEG, PNG, WebP, GIF</p>
      </div>

      {uploadedItems.length > 0 && (
        <div className="grid grid-cols-1 gap-3 md:grid-cols-2 xl:grid-cols-3">
          {uploadedItems.map((item) => {
            const isCover = item.status === 'done' && item.publicUrl === value[0]
            const canSelectCover = item.status === 'done' && doneItemsCount > 1

            return (
              <div key={item.id} className="group overflow-hidden rounded-2xl border bg-card shadow-sm">
                <div className="relative aspect-4/3 bg-muted">
                  <img
                    src={item.previewUrl}
                    alt={item.fileName}
                    className="h-full w-full object-cover"
                  />

                  {item.status === 'uploading' && (
                    <div className="absolute inset-0 bg-black/35 flex items-center justify-center">
                      <Loader2 className="h-8 w-8 animate-spin text-white" />
                    </div>
                  )}

                  {item.status === 'error' && (
                    <div className="absolute inset-0 bg-black/35 flex items-center justify-center">
                      <div className="rounded-full bg-red-500/90 px-3 py-1 text-xs font-medium text-white flex items-center gap-1.5">
                        <AlertCircle className="h-3.5 w-3.5" />
                        Upload failed
                      </div>
                    </div>
                  )}

                  <button
                    type="button"
                    onClick={() => removeItem(item.id)}
                    className="absolute top-2 right-2 inline-flex h-8 w-8 items-center justify-center rounded-full bg-black/60 text-white transition-colors hover:bg-black/80"
                    title="Remove image"
                  >
                    <X className="h-4 w-4" />
                  </button>

                  {canSelectCover && (
                    <button
                      type="button"
                      onClick={(e) => {
                        e.stopPropagation()
                        if (item.publicUrl) setCoverImage(item.publicUrl)
                      }}
                      className={[
                        'absolute top-2 left-2 inline-flex items-center gap-1.5 rounded-full px-3 py-1 text-xs font-medium transition-colors',
                        isCover
                          ? 'bg-primary text-primary-foreground'
                          : 'bg-background/90 text-foreground hover:bg-background',
                      ].join(' ')}
                      title={isCover ? 'Cover image' : 'Set as cover'}
                    >
                      <Star className="h-3.5 w-3.5" />
                      {isCover ? 'Cover' : 'Set cover'}
                    </button>
                  )}

                </div>

                <div className="space-y-1.5 p-3">
                  <div className="flex items-start justify-between gap-3">
                    <div className="min-w-0">
                      <p className="truncate text-sm font-medium">{item.fileName}</p>
                      <p className="text-xs text-muted-foreground">{item.sizeLabel}</p>
                    </div>
                    {item.status === 'done' && (
                      <CheckCircle2 className="mt-0.5 h-4 w-4 shrink-0 text-emerald-600" />
                    )}
                  </div>

                  {item.status === 'error' && item.errorMessage && (
                    <p className="flex items-start gap-1.5 text-xs text-red-500">
                      <AlertCircle className="mt-0.5 h-3.5 w-3.5 shrink-0" />
                      <span>{item.errorMessage}</span>
                    </p>
                  )}

                  <div className="h-1.5 w-full overflow-hidden rounded-full bg-muted">
                    <div
                      className={[
                        'h-full transition-all',
                        item.status === 'done' ? 'w-full bg-emerald-500' : '',
                        item.status === 'error' ? 'w-full bg-red-500' : '',
                        item.status === 'uploading' ? 'w-3/5 bg-primary animate-pulse' : '',
                      ].join(' ')}
                    />
                  </div>
                </div>
              </div>
            )
          })}
        </div>
      )}

      {value.length >= maxFiles && (
        <p className="text-xs text-muted-foreground">
          Maximum {maxFiles} photos reached
        </p>
      )}
    </div>
  )
}

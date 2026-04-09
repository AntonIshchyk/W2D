import { useState, useRef } from 'react'
import { ImagePlus, Loader2, X } from 'lucide-react'
import { toast } from 'sonner'
import { getPresignedUrl, uploadToR2 } from './PhotoUpload'
import { isValidImageUrl } from '../lib/utils/validation'
import { AvatarCropModal } from './AvatarCropModal'

interface AvatarUploadProps {
  value: string
  onChange: (url: string) => void
  disabled?: boolean
}

export function AvatarUpload({ value, onChange, disabled }: AvatarUploadProps) {
  const [isUploading, setIsUploading] = useState(false)
  const [cropImageSrc, setCropImageSrc] = useState<string | null>(null)
  const fileInputRef = useRef<HTMLInputElement>(null)

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0]
    if (!file) return

    if (!['image/jpeg', 'image/jpg', 'image/png', 'image/webp'].includes(file.type)) {
      toast.error('Only JPEG, PNG, or WebP images are allowed')
      return
    }

    if (file.size > 10 * 1024 * 1024) {
      toast.error('Image must be less than 10MB')
      return
    }

    const reader = new FileReader()
    reader.onload = () => {
      setCropImageSrc(reader.result as string)
    }
    reader.readAsDataURL(file)
    // Clear input so selecting the same file again works
    e.target.value = ''
  }

  const handleCropComplete = async (croppedFile: File) => {
    setCropImageSrc(null)
    setIsUploading(true)

    try {
      const { uploadUrl, publicUrl } = await getPresignedUrl(croppedFile)
      await uploadToR2(uploadUrl, croppedFile)
      onChange(publicUrl)
    } catch (error) {
      toast.error('Failed to upload profile photo')
    } finally {
      setIsUploading(false)
    }
  }

  if (value && isValidImageUrl(value)) {
    return (
      <div className="relative inline-block">
        <img
          src={value}
          alt="Profile photo"
          className="h-32 w-32 rounded-full object-cover border border-border"
        />
        {!disabled && (
          <button
            type="button"
            onClick={() => onChange('')}
            className="absolute -right-2 -top-2 flex h-8 w-8 items-center justify-center rounded-full bg-primary text-primary-foreground hover:opacity-90"
          >
            <X className="h-4 w-4" />
          </button>
        )}
      </div>
    )
  }

  return (
    <>
      <div
        onClick={() => !disabled && !isUploading && fileInputRef.current?.click()}
        className={`flex h-32 w-32 flex-col items-center justify-center rounded-full border-2 border-dashed border-input ${
          disabled || isUploading ? 'cursor-not-allowed opacity-50' : 'cursor-pointer hover:bg-muted/50'
        }`}
      >
        {isUploading ? (
          <Loader2 className="h-8 w-8 animate-spin text-muted-foreground" />
        ) : (
          <ImagePlus className="h-8 w-8 text-muted-foreground" />
        )}
      </div>

      <input
        type="file"
        ref={fileInputRef}
        onChange={handleFileChange}
        accept="image/jpeg,image/png,image/webp"
        className="hidden"
      />

      {cropImageSrc && (
        <AvatarCropModal
          imageSrc={cropImageSrc}
          onClose={() => setCropImageSrc(null)}
          onCropComplete={handleCropComplete}
        />
      )}
    </>
  )
}

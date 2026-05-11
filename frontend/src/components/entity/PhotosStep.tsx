import { PlaceImageUpload } from '../PlaceImageUpload'

interface PhotosStepProps {
  photoUrls: string[]
  onPhotoUrlsChange: (urls: string[]) => void
  maxFiles?: number
  disabled?: boolean
  photoLabel?: string
}

export function PhotosStep({
  photoUrls,
  onPhotoUrlsChange,
  maxFiles = 4,
  disabled = false,
  photoLabel = 'Photos',
}: PhotosStepProps) {
  return (
    <div className="space-y-8 animate-in fade-in slide-in-from-right-4 duration-300">
      <div className="space-y-2">
        <label className="text-lg font-semibold">
          {photoLabel}
        </label>
        <PlaceImageUpload
          value={photoUrls}
          onChange={onPhotoUrlsChange}
          maxFiles={maxFiles}
          disabled={disabled}
        />
      </div>
    </div>
  )
}

import { useState, useCallback } from 'react'
import Cropper from 'react-easy-crop'
import { X } from 'lucide-react'
import getCroppedImg from '../utils/cropImage'

interface AvatarCropModalProps {
  imageSrc: string
  onClose: () => void
  onCropComplete: (croppedFile: File) => void
}

type Area = {
  x: number
  y: number
  width: number
  height: number
}

export function AvatarCropModal({ imageSrc, onClose, onCropComplete }: AvatarCropModalProps) {
  const [crop, setCrop] = useState({ x: 0, y: 0 })
  const [zoom, setZoom] = useState(1)
  const [croppedAreaPixels, setCroppedAreaPixels] = useState<Area | null>(null)
  const [isProcessing, setIsProcessing] = useState(false)

  const onCropCompleteHandler = useCallback((_croppedArea: Area, nextCroppedAreaPixels: Area) => {
    setCroppedAreaPixels(nextCroppedAreaPixels)
  }, [])

  const handleSave = async () => {
    if (!croppedAreaPixels) return

    try {
      setIsProcessing(true)
      const croppedImage = await getCroppedImg(imageSrc, croppedAreaPixels)
      if (croppedImage) {
        onCropComplete(croppedImage)
      }
    } catch {
    } finally {
      setIsProcessing(false)
    }
  }

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/60 p-4 sm:p-8">
      <div className="relative w-full max-w-2xl rounded-3xl bg-background p-8 shadow-2xl">
        <button
          onClick={onClose}
          className="absolute right-6 top-6 rounded-full p-2 text-muted-foreground transition hover:bg-muted hover:text-foreground"
        >
          <X className="h-6 w-6" />
        </button>

        <h3 className="text-2xl font-black tracking-tight text-foreground">Crop your photo</h3>
        <p className="mt-2 text-base text-muted-foreground">Adjust the image to fit your profile.</p>

        <div className="relative mt-8 h-96 w-full overflow-hidden rounded-2xl bg-muted">
          <Cropper
            image={imageSrc}
            crop={crop}
            zoom={zoom}
            aspect={1}
            cropShape="round"
            showGrid={false}
            onCropChange={setCrop}
            onCropComplete={onCropCompleteHandler}
            onZoomChange={setZoom}
          />
        </div>

        <div className="mt-8 flex items-center justify-between gap-6 pb-2">
          <input
            type="range"
            value={zoom}
            min={1}
            max={3}
            step={0.1}
            aria-labelledby="Zoom"
            onChange={(e) => setZoom(Number(e.target.value))}
            className="w-full h-2 rounded-lg appearance-none bg-muted accent-primary cursor-pointer"
          />
          <button
            onClick={handleSave}
            disabled={isProcessing}
            className="shrink-0 rounded-xl bg-primary px-8 py-3 text-base font-semibold text-primary-foreground transition hover:opacity-90 disabled:opacity-50"
          >
            {isProcessing ? 'Saving...' : 'Apply'}
          </button>
        </div>
      </div>
    </div>
  )
}

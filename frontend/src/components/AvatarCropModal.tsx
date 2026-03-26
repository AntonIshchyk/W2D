import { useState, useCallback } from 'react'
import Cropper from 'react-easy-crop'
import { X } from 'lucide-react'
import getCroppedImg from '../utils/cropImage'

interface AvatarCropModalProps {
  imageSrc: string
  onClose: () => void
  onCropComplete: (croppedFile: File) => void
}

export function AvatarCropModal({ imageSrc, onClose, onCropComplete }: AvatarCropModalProps) {
  const [crop, setCrop] = useState({ x: 0, y: 0 })
  const [zoom, setZoom] = useState(1)
  const [croppedAreaPixels, setCroppedAreaPixels] = useState<any>(null)
  const [isProcessing, setIsProcessing] = useState(false)

  const onCropCompleteHandler = useCallback((croppedArea: any, croppedAreaPixels: any) => {
    setCroppedAreaPixels(croppedAreaPixels)
  }, [])

  const handleSave = async () => {
    try {
      setIsProcessing(true)
      const croppedImage = await getCroppedImg(imageSrc, croppedAreaPixels)
      if (croppedImage) {
        onCropComplete(croppedImage)
      }
    } catch (e) {
      console.error(e)
    } finally {
      setIsProcessing(false)
    }
  }

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/60 p-4">
      <div className="relative w-full max-w-md rounded-2xl bg-white p-6 shadow-xl">
        <button
          onClick={onClose}
          className="absolute right-4 top-4 rounded-full p-2 text-stone-500 hover:bg-stone-100"
        >
          <X className="h-5 w-5" />
        </button>

        <h3 className="text-lg font-bold text-stone-900">Crop your photo</h3>
        <p className="mt-1 text-sm text-stone-500">Adjust the image to fit your profile.</p>

        <div className="relative mt-6 h-64 w-full overflow-hidden rounded-xl bg-stone-900">
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

        <div className="mt-6 flex items-center justify-between gap-4">
          <input
            type="range"
            value={zoom}
            min={1}
            max={3}
            step={0.1}
            aria-labelledby="Zoom"
            onChange={(e) => setZoom(Number(e.target.value))}
            className="w-full accent-stone-900"
          />
          <button
            onClick={handleSave}
            disabled={isProcessing}
            className="shrink-0 rounded-xl bg-stone-900 px-6 py-2 text-sm font-semibold text-white transition hover:bg-stone-800 disabled:opacity-50"
          >
            {isProcessing ? 'Saving...' : 'Apply'}
          </button>
        </div>
      </div>
    </div>
  )
}

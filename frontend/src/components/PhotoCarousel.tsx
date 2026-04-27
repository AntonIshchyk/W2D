import { Dialog, DialogContent, DialogTrigger, DialogTitle } from './ui/dialog'
import { Carousel, CarouselContent, CarouselItem, CarouselNext, CarouselPrevious } from "./ui/carousel"
import { cn } from '../lib/utils'
import { isValidPhotoUrl } from '../lib/utils/validation'

interface PhotoCarouselProps {
  urls: string[]
  containerClassName?: string
  imageContainerClassName?: string
}

export function PhotoCarousel({ 
  urls, 
  containerClassName = "mt-4 mb-6 md:px-0",
  imageContainerClassName = "h-96"
}: PhotoCarouselProps) {
  const validUrls = urls.filter(isValidPhotoUrl)
  if (!validUrls || validUrls.length === 0) return null

  return (
    <div className={cn("mt-4 mb-6 md:px-0", containerClassName)} onClick={(e) => e.preventDefault()}>
      <Carousel className="w-full">
        <CarouselContent>
          {validUrls.map((url, i) => (
            <CarouselItem key={i}>
              <Dialog>
                <DialogTrigger asChild>
                  <div className={cn("relative w-full flex items-center justify-center bg-black/95 rounded-2xl overflow-hidden cursor-pointer hover:opacity-95 transition-opacity", imageContainerClassName)}>
                    <img 
                      src={url} 
                      alt={`Attachment ${i + 1}`} 
                      className="max-w-full max-h-full object-contain"
                    />
                    {validUrls.length > 1 && (
                      <div className="absolute top-3 right-3 bg-black/60 text-white text-xs font-medium px-2.5 py-1 rounded-full backdrop-blur-md">
                        {i + 1} / {validUrls.length}
                      </div>
                    )}
                  </div>
                </DialogTrigger>
                <DialogContent className="max-w-[95vw] sm:max-w-[90vw] md:max-w-[80vw] h-[90vh] p-0 border-0 bg-transparent flex flex-col justify-center shadow-none">
                  <DialogTitle className="sr-only">Image View</DialogTitle>
                  <div className="relative w-full h-full flex items-center justify-center">
                    <img src={url} className="max-w-full max-h-full object-contain" alt="Fullscreen view" />
                  </div>
                </DialogContent>
              </Dialog>
            </CarouselItem>
          ))}
        </CarouselContent>
        {validUrls.length > 1 && (
          <div className="absolute inset-y-0 left-2 right-2 flex items-center justify-between pointer-events-none">
            <CarouselPrevious className="relative inset-0 translate-x-0 translate-y-0 bg-black/50 text-white border-0 hover:bg-black/80 hover:text-white pointer-events-auto" />
            <CarouselNext className="relative inset-0 translate-x-0 translate-y-0 bg-black/50 text-white border-0 hover:bg-black/80 hover:text-white pointer-events-auto" />
          </div>
        )}
      </Carousel>
    </div>
  )
}

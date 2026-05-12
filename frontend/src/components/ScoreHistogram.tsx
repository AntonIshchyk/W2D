import { useCallback, useEffect, useRef, useState } from 'react'
import { Input } from './ui/input'

interface ScoreHistogramProps {
  scores: number[]
  min: number
  max: number
  low: number
  high: number
  onChange: (low: number, high: number) => void
}

const BIN_COUNT = 30

function buildBins(scores: number[], min: number, max: number, binCount: number): number[] {
  const bins = new Array(binCount).fill(0)
  if (max === min) return bins
  for (const s of scores) {
    const idx = Math.min(Math.floor(((s - min) / (max - min)) * binCount), binCount - 1)
    bins[idx]++
  }
  return bins
}

export function ScoreHistogram({ scores, min, max, low, high, onChange }: ScoreHistogramProps) {
  const wrapRef = useRef<HTMLDivElement>(null)
  const [width, setWidth] = useState(0)

  useEffect(() => {
    const el = wrapRef.current
    if (!el) return

    if (el.clientWidth > 0) setWidth(el.clientWidth)

    const ro = new ResizeObserver((entries) => {
      const w = entries[0].contentRect.width
      if (w > 0) setWidth(w)
    })
    ro.observe(el)
    return () => ro.disconnect()
  }, [])

  const bins = buildBins(scores, min, max, BIN_COUNT)
  const maxBin = Math.max(...bins, 1)

  const toFrac = useCallback((v: number) => (max === min ? 0 : (v - min) / (max - min)), [min, max])
  const toValue = useCallback((f: number) => Math.round(min + f * (max - min)), [min, max])

  const loFrac = toFrac(low)
  const hiFrac = toFrac(high)

  function handleHistoClick(e: React.MouseEvent<SVGSVGElement>) {
    const rect = (e.currentTarget as SVGSVGElement).getBoundingClientRect()
    const frac = Math.max(0, Math.min(1, (e.clientX - rect.left) / rect.width))
    const val = toValue(frac)
    const mid = (low + high) / 2
    if (val < mid) onChange(Math.min(val, high - 1), high)
    else onChange(low, Math.max(val, low + 1))
  }

  function makeDragHandler(isMin: boolean) {
    return (e: React.MouseEvent | React.TouchEvent) => {
      e.preventDefault()
      const startX = 'touches' in e ? e.touches[0].clientX : e.clientX
      const startFrac = isMin ? loFrac : hiFrac

      function onMove(ev: MouseEvent | TouchEvent) {
        const clientX = 'touches' in ev ? (ev as TouchEvent).touches[0].clientX : (ev as MouseEvent).clientX
        if (!wrapRef.current) return
        const frac = Math.max(0, Math.min(1, startFrac + (clientX - startX) / wrapRef.current.clientWidth))
        const val = toValue(frac)
        if (isMin) onChange(Math.min(val, high - 1), high)
        else onChange(low, Math.max(val, low + 1))
      }

      function onUp() {
        window.removeEventListener('mousemove', onMove)
        window.removeEventListener('mouseup', onUp)
        window.removeEventListener('touchmove', onMove)
        window.removeEventListener('touchend', onUp)
      }

      window.addEventListener('mousemove', onMove)
      window.addEventListener('mouseup', onUp)
      window.addEventListener('touchmove', onMove, { passive: false })
      window.addEventListener('touchend', onUp)
    }
  }

  const H = 48
  const gap = 2
  const barW = width > 0 ? Math.max(1, (width - gap * (BIN_COUNT - 1)) / BIN_COUNT) : 0

  return (
    <div ref={wrapRef} className="flex flex-col gap-1 select-none w-full">
      <svg
        width={width || '100%'}
        height={H}
        className="cursor-pointer w-full"
        onClick={handleHistoClick}
        aria-label="Score distribution histogram"
      >
        {width > 0 && bins.map((count, i) => {
          const barH = Math.max(2, (count / maxBin) * (H - 4))
          const x = i * (barW + gap)
          const binLoFrac = i / BIN_COUNT
          const binHiFrac = (i + 1) / BIN_COUNT
          const active = binHiFrac > loFrac && binLoFrac < hiFrac
          return (
            <rect
              key={i}
              x={x}
              y={H - barH}
              width={barW}
              height={barH}
              rx={2}
              className={active ? 'fill-primary' : 'fill-muted-foreground/25'}
              style={{ transition: 'fill 0.1s' }}
            />
          )
        })}
      </svg>

      <div className="relative h-5" style={{ marginTop: 2 }}>
        <div className="absolute inset-y-0 flex items-center w-full">
          <div className="w-full h-1 rounded-full bg-border" />
        </div>
        <div
          className="absolute inset-y-0 flex items-center pointer-events-none"
          style={{ left: `${loFrac * 100}%`, right: `${(1 - hiFrac) * 100}%` }}
        >
          <div className="w-full h-1 rounded-full bg-primary" />
        </div>

        <div
          className="absolute top-1/2 -translate-y-1/2 -translate-x-1/2 w-4 h-4 rounded-full bg-background border border-border shadow-sm cursor-grab active:cursor-grabbing z-10 hover:border-primary transition-colors"
          style={{ left: `${loFrac * 100}%` }}
          onMouseDown={makeDragHandler(true)}
          onTouchStart={makeDragHandler(true)}
          role="slider"
          tabIndex={0}
          aria-label="Minimum score"
          aria-valuenow={low}
          aria-valuemin={min}
          aria-valuemax={high - 1}
          onKeyDown={(e) => {
            if (e.key === 'ArrowLeft') onChange(Math.max(low - 1, min), high)
            if (e.key === 'ArrowRight') onChange(Math.min(low + 1, high - 1), high)
          }}
        />

        <div
          className="absolute top-1/2 -translate-y-1/2 -translate-x-1/2 w-4 h-4 rounded-full bg-background border border-border shadow-sm cursor-grab active:cursor-grabbing z-10 hover:border-primary transition-colors"
          style={{ left: `${hiFrac * 100}%` }}
          onMouseDown={makeDragHandler(false)}
          onTouchStart={makeDragHandler(false)}
          role="slider"
          tabIndex={0}
          aria-label="Maximum score"
          aria-valuenow={high}
          aria-valuemin={low + 1}
          aria-valuemax={max}
          onKeyDown={(e) => {
            if (e.key === 'ArrowLeft') onChange(low, Math.max(high - 1, low + 1))
            if (e.key === 'ArrowRight') onChange(low, Math.min(high + 1, max))
          }}
        />
      </div>

      <div className="flex items-center gap-2 mt-2">
        <div className="flex flex-col gap-1 flex-1">
          <label className="text-xs text-muted-foreground">Minimum</label>
          <Input
            type="number"
            value={low}
            min={min}
            max={high - 1}
            className="h-8 text-sm"
            onChange={(e) => {
              const v = parseInt(e.target.value, 10)
              if (!isNaN(v)) onChange(Math.max(min, Math.min(v, high - 1)), high)
            }}
          />
        </div>
        <div className="text-muted-foreground mt-5">–</div>
        <div className="flex flex-col gap-1 flex-1">
          <label className="text-xs text-muted-foreground">Maximum</label>
          <Input
            type="number"
            value={high}
            min={low + 1}
            max={max}
            className="h-8 text-sm"
            onChange={(e) => {
              const v = parseInt(e.target.value, 10)
              if (!isNaN(v)) onChange(low, Math.max(low + 1, Math.min(v, max)))
            }}
          />
        </div>
      </div>
    </div>
  )
}
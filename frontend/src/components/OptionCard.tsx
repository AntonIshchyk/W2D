import type { ElementType } from 'react'
import { cn } from '../lib/utils'

interface OptionCardProps {
  label: string
  Icon: ElementType
  selected: boolean
  onClick: () => void
}

export function OptionCard({ label, Icon, selected, onClick }: OptionCardProps) {
  return (
    <button
      type="button"
      onClick={onClick}
      className={cn(
        'flex flex-col items-center gap-2 rounded-2xl border p-4 text-center transition-all duration-150 cursor-pointer',
        'hover:bg-accent hover:border-border',
        selected
          ? 'border-primary bg-primary/5 ring-1 ring-primary'
          : 'border-border bg-card',
      )}
    >
      <Icon
        className={cn(
          'h-6 w-6 transition-colors',
          selected ? 'text-primary' : 'text-muted-foreground',
        )}
      />
      <div>
        <p className={cn('text-sm font-medium leading-tight', selected ? 'text-foreground' : 'text-foreground')}>
          {label}
        </p>
      </div>
    </button>
  )
}

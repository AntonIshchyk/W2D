import { ArrowBigDown, ArrowBigUp } from 'lucide-react'
import { cn } from '../lib/utils'

interface VoteButtonsProps {
  score: number
  currentUserVote?: number
  onVote: (value: number) => void
  disabled?: boolean
  className?: string
}

export function VoteButtons({ score, currentUserVote, onVote, disabled, className }: VoteButtonsProps) {
  return (
    <div className={cn("flex items-center gap-1 bg-muted/40 rounded-full p-1 border border-border/50", className)}>
      <button
        onClick={(e) => {
          e.preventDefault()
          e.stopPropagation()
          onVote(1)
        }}
        disabled={disabled}
        className={cn(
          "p-1.5 rounded-full transition-colors flex items-center justify-center",
          currentUserVote === 1 ? "bg-orange-100 text-orange-600 dark:bg-orange-900/30" : "hover:bg-muted text-muted-foreground",
          "disabled:opacity-40 disabled:cursor-not-allowed"
        )}
        aria-label="Upvote"
      >
        <ArrowBigUp className="w-5 h-5" fill={currentUserVote === 1 ? "currentColor" : "none"} />
      </button>

      <span
        className={cn(
          "text-sm font-bold min-w-[2ch] text-center",
          score > 0 ? "text-orange-600" : score < 0 ? "text-blue-600" : "text-foreground"
        )}
      >
        {score}
      </span>

      <button
        onClick={(e) => {
          e.preventDefault()
          e.stopPropagation()
          onVote(-1)
        }}
        disabled={disabled}
        className={cn(
          "p-1.5 rounded-full transition-colors flex items-center justify-center",
          currentUserVote === -1 ? "bg-blue-100 text-blue-600 dark:bg-blue-900/30" : "hover:bg-muted text-muted-foreground",
          "disabled:opacity-40 disabled:cursor-not-allowed"
        )}
        aria-label="Downvote"
      >
        <ArrowBigDown className="w-5 h-5" fill={currentUserVote === -1 ? "currentColor" : "none"} />
      </button>
    </div>
  )
}

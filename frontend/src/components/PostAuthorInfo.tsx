import { PostType } from '../types/posts'
import { POST_TYPE_LABELS, POST_TYPE_COLORS, POST_TYPE_ICONS } from '../api/posts'
import { cn } from '../lib/utils'

interface PostAuthorInfoProps {
  author?: {
    username?: string
  }
  type: PostType
}

export function PostAuthorInfo({ author, type }: PostAuthorInfoProps) {
  const typeStyle = POST_TYPE_COLORS[type]
  const TypeIcon = POST_TYPE_ICONS[type]

  return (
    <div className="flex items-center gap-3">
      <div>
        <p className="text-sm font-semibold text-foreground leading-tight">
          {author?.username || 'Anonymous'}
        </p>
        {typeStyle && (
          <div className={cn("flex items-center gap-1 mt-0.5 text-xs font-medium", typeStyle.text)}>
            {TypeIcon && <TypeIcon className="w-3.5 h-3.5" />}
            <span>{POST_TYPE_LABELS[type]}</span>
          </div>
        )}
      </div>
    </div>
  )
}

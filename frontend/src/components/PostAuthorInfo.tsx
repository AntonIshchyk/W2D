import { PostType } from '../types/posts'
import { POST_TYPE_LABELS, POST_TYPE_COLORS, POST_TYPE_ICONS } from '../features/posts/api'
import { UserAvatar } from './UserAvatar'
import { cn } from '../lib/utils'

interface PostAuthorInfoProps {
  author?: {
    username?: string
    profilePhotoUrl?: string | null
  }
  type: PostType
}

export function PostAuthorInfo({ author, type }: PostAuthorInfoProps) {
  const typeStyle = POST_TYPE_COLORS[type]
  const TypeIcon = POST_TYPE_ICONS[type]

  return (
    <div className="flex items-center gap-3">
      <UserAvatar url={author?.profilePhotoUrl} username={author?.username} />
      <div>
        <p className="text-sm font-semibold text-foreground/90 leading-tight">
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

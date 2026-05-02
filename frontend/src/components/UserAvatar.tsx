import { cn } from '../lib/utils'
import { isValidPhotoUrl } from '../lib/utils/validation'

interface UserAvatarProps {
  url?: string | null
  username?: string | null
  className?: string
}

export function UserAvatar({ url, username, className }: UserAvatarProps) {
  if (url && isValidPhotoUrl(url)) {
    return (
      <img
        src={url}
        alt={username || 'User'}
        className={cn("h-10 w-10 rounded-full object-cover border border-primary/20 shrink-0", className)}
      />
    )
  }

  return (
    <div
      className={cn(
        "h-10 w-10 rounded-full bg-linear-to-br from-primary/20 to-primary/10 flex items-center justify-center border border-primary/20 shrink-0",
        className
      )}
    >
      <span className="text-primary font-bold text-sm">
        {username ? username.substring(0, 1).toUpperCase() : 'AN'}
      </span>
    </div>
  )
}

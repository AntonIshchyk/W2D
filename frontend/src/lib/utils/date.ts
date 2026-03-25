export function formatDate(dateString: string): string {
  return new Date(dateString).toLocaleDateString('en-US', { 
    weekday: 'short', 
    month: 'short', 
    day: 'numeric' 
  })
}

export function formatRelativeTime(dateString: string): string {
  const normalizedDateString = dateString.endsWith('Z') ? dateString : `${dateString}Z`
  const date = new Date(normalizedDateString)
  const now = new Date()
  const diffMs = now.getTime() - date.getTime()
  
  const maxDiffMs = Math.max(0, diffMs)
  
  const diffMins = Math.floor(maxDiffMs / 60000)
  const diffHours = Math.floor(maxDiffMs / 3600000)
  const diffDays = Math.floor(maxDiffMs / 86400000)

  if (diffMins < 1) return 'now'
  if (diffMins < 60) return `${diffMins}min`
  if (diffHours < 24) return `${diffHours}h`
  return `${diffDays}d`
}

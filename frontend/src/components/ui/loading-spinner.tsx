interface LoadingSpinnerProps {
  text?: string
  size?: 'sm' | 'md' | 'lg'
}

export function LoadingSpinner({ text = 'Loading...', size = 'md' }: LoadingSpinnerProps) {
  const sizeClasses = {
    sm: 'h-3 w-3',
    md: 'h-4 w-4',
    lg: 'h-6 w-6'
  }

  return (
    <div className="flex items-center gap-2 text-sm text-muted-foreground">
      <div 
        className={`${sizeClasses[size]} border-2 border-primary border-t-transparent rounded-full animate-spin`} 
      />
      {text}
    </div>
  )
}

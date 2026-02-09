import type { LucideIcon } from 'lucide-react'
import { Card, CardContent } from './card'
import { Button } from './button'

interface EmptyStateProps {
  icon: LucideIcon
  title: string
  description?: string
  action?: {
    label: string
    onClick: () => void
  }
}

export function EmptyState({ icon: Icon, title, description, action }: EmptyStateProps) {
  return (
    <Card className="border-dashed">
      <CardContent className="py-24 text-center">
        <Icon className="h-12 w-12 mx-auto text-muted-foreground/50 mb-4" />
        <p className="text-lg font-medium text-muted-foreground mb-1">
          {title}
        </p>
        {description && (
          <p className="text-sm text-muted-foreground/70 mb-4">
            {description}
          </p>
        )}
        {action && (
          <Button onClick={action.onClick} className="gap-2">
            {action.label}
          </Button>
        )}
      </CardContent>
    </Card>
  )
}

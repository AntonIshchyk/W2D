import { cn } from '../../lib/utils'

export interface Step {
  id: number
  label: string
  icon: React.ComponentType<{ className?: string }>
}

interface EntityStepperProps {
  steps: Step[]
  currentStep: number
  onStepChange: (stepId: number) => void
}

export function EntityStepper({ steps, currentStep, onStepChange }: EntityStepperProps) {
  return (
    <div className="flex items-center gap-0">
      {steps.map((s, i) => {
        const Icon = s.icon
        const current = currentStep === s.id

        return (
          <div key={s.id} className="flex items-center">
            <button
              type="button"
              onClick={() => onStepChange(s.id)}
              className={cn(
                'flex items-center gap-2 px-4 py-2 rounded-full text-sm font-medium transition-all duration-300',
                current && 'bg-primary text-primary-foreground',
                !current && 'text-primary hover:bg-accent hover:text-accent-foreground cursor-pointer',
              )}
            >
              <Icon className="h-4 w-4" />
              {s.label}
            </button>
            {i < steps.length - 1 && (
              <div className={cn(
                'h-px w-8 mx-2 transition-colors duration-500',
                currentStep > s.id ? 'bg-primary' : 'bg-border',
              )} />
            )}
          </div>
        )
      })}
    </div>
  )
}

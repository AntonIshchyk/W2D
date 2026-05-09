import { ArrowLeft, ArrowRight, Loader2 } from 'lucide-react'
import { Button } from '../ui/button'
import { PageLayout } from '../Navbar'
import { EntityStepper, type Step } from './EntityStepper'

interface EntityFormShellProps {
  steps: Step[]
  currentStep: number
  onStepChange: (step: number) => void
  onCancel: () => void
  onSubmit: () => void
  isPending: boolean
  submitLabel: string
  pendingLabel: string
  preview: React.ReactNode
  children: React.ReactNode
}

export function EntityFormShell({
  steps,
  currentStep,
  onStepChange,
  onCancel,
  onSubmit,
  isPending,
  submitLabel,
  pendingLabel,
  preview,
  children,
}: EntityFormShellProps) {
  const isLastStep = currentStep === steps.length
  const isFirstStep = currentStep === 1

  return (
    <PageLayout>
      <div className="min-h-[calc(100vh-4rem)] bg-background text-foreground">
        <div className="mx-auto grid max-w-6xl grid-cols-1 gap-12 px-6 py-14 lg:grid-cols-[1fr_380px] lg:items-start">
          <div className="space-y-10">
            <EntityStepper steps={steps} currentStep={currentStep} onStepChange={onStepChange} />

            <div className="relative">{children}</div>

            <div className="flex items-center justify-between">
              <Button
                variant="ghost"
                onClick={() => (isFirstStep ? onCancel() : onStepChange(currentStep - 1))}
                className="gap-2 px-6 text-base hover:bg-accent hover:text-foreground h-12"
              >
                <ArrowLeft className="h-5 w-5" />
                {isFirstStep ? 'Cancel' : 'Back'}
              </Button>

              {isLastStep ? (
                <Button
                  onClick={onSubmit}
                  disabled={isPending}
                  className="gap-2 bg-primary px-8 text-base font-semibold text-primary-foreground hover:bg-primary/90 h-12 min-w-40 disabled:opacity-30"
                >
                  {isPending ? (
                    <>
                      <Loader2 className="h-5 w-5 animate-spin" /> {pendingLabel}
                    </>
                  ) : (
                    submitLabel
                  )}
                </Button>
              ) : (
                <Button
                  onClick={() => onStepChange(currentStep + 1)}
                  className="gap-2 bg-primary px-8 text-base font-semibold text-primary-foreground hover:bg-primary/90 h-12 disabled:opacity-30"
                >
                  Continue
                  <ArrowRight className="h-5 w-5" />
                </Button>
              )}
            </div>
          </div>

          <div className="sticky top-24 hidden lg:block">
            <p className="mb-4 text-sm font-semibold uppercase tracking-widest">Preview</p>
            {preview}
          </div>
        </div>
      </div>
    </PageLayout>
  )
}
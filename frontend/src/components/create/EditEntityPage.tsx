import { useNavigate,} from 'react-router-dom'
import { ArrowLeft, ArrowRight, Loader2 } from 'lucide-react'
import { Button } from '../ui/button'
import { PageLayout } from '../Navbar'
import { EntityStepper, type Step } from '../createEntity/EntityStepper'

interface EditEntityPageProps {
  steps: Step[]
  currentStep: number
  onStepChange: (step: number) => void
  onSubmit: () => void
  isPending: boolean
  isLoading: boolean
  entity: any
  submitLabel: string
  preview: React.ReactNode
  children: React.ReactNode
  backUrl: string
}

export function EditEntityPage({
  steps,
  currentStep,
  onStepChange,
  onSubmit,
  isPending,
  isLoading,
  entity,
  submitLabel,
  preview,
  children,
  backUrl,
}: EditEntityPageProps) {
  const navigate = useNavigate()

  if (isLoading) {
    return (
      <PageLayout>
        <div className="flex items-center justify-center py-20">
          <div className="flex items-center gap-2.5 text-muted-foreground">
            <Loader2 className="w-4 h-4 animate-spin" />
            <span className="text-sm">Loading…</span>
          </div>
        </div>
      </PageLayout>
    )
  }

  if (!entity) {
    return (
      <PageLayout>
        <div className="max-w-3xl mx-auto">
          <h2 className="text-xl font-semibold mb-2">Item not found</h2>
          <Button variant="ghost" onClick={() => navigate(backUrl)}>
            Back
          </Button>
        </div>
      </PageLayout>
    )
  }

  return (
    <PageLayout>
      <div className="min-h-[calc(100vh-4rem)] bg-background text-foreground">
        <div className="max-w-6xl mx-auto px-6 py-14 grid grid-cols-1 lg:grid-cols-[1fr_380px] gap-12 items-start">
          <div className="space-y-10">
            <EntityStepper steps={steps} currentStep={currentStep} onStepChange={onStepChange} />

            <div className="relative">
              {children}
            </div>

            <div className="flex items-center justify-between">
              <Button
                variant="ghost"
                onClick={() => (currentStep === 1 ? navigate(backUrl) : onStepChange(currentStep - 1))}
                className="hover:text-foreground hover:bg-accent gap-2 text-base h-12 px-6"
              >
                <ArrowLeft className="h-5 w-5" />
                {currentStep === 1 ? 'Cancel' : 'Back'}
              </Button>

              {currentStep < steps.length ? (
                <Button
                  onClick={() => onStepChange(currentStep + 1)}
                  className="bg-primary text-primary-foreground hover:bg-primary/90 font-semibold gap-2 text-base h-12 px-8 disabled:opacity-30"
                >
                  Continue
                  <ArrowRight className="h-5 w-5" />
                </Button>
              ) : (
                <Button
                  onClick={onSubmit}
                  disabled={isPending}
                  className="bg-primary text-primary-foreground hover:bg-primary/90 font-semibold gap-2 text-base h-12 px-8 min-w-40"
                >
                  {isPending
                    ? (
                      <>
                        <Loader2 className="h-5 w-5 animate-spin" /> Updating…
                      </>
                    ) : (
                      <>
                        {submitLabel}
                      </>
                    )
                  }
                </Button>
              )}
            </div>
          </div>

          <div className="hidden lg:block sticky top-24">
            <p className="text-sm font-semibold uppercase tracking-widest mb-4">Preview</p>
            {preview}
          </div>
        </div>
      </div>
    </PageLayout>
  )
}

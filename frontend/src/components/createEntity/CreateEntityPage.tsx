import { useNavigate } from 'react-router-dom'
import { ArrowLeft, ArrowRight, Loader2 } from 'lucide-react'
import { Button } from '../ui/button'
import { PageLayout } from '../Navbar'
import { EntityStepper, type Step } from './EntityStepper'


interface CreateEntityPageProps {
  steps: Step[]
  currentStep: number
  onStepChange: (step: number) => void
  onSubmit: () => void
  isPending: boolean
  submitLabel: string
  preview: React.ReactNode
  children: React.ReactNode
}

export function CreateEntityPage({
  steps,
  currentStep,
  onStepChange,
  onSubmit,
  isPending,
  submitLabel,
  preview,
  children,
}: CreateEntityPageProps) {
  const navigate = useNavigate()

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
                onClick={() => (currentStep === 1 ? navigate(-1) : onStepChange(currentStep - 1))}
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
                        <Loader2 className="h-5 w-5 animate-spin" /> Creating…
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

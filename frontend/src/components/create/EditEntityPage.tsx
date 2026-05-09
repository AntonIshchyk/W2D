import { useNavigate } from 'react-router-dom'
import { Loader2 } from 'lucide-react'
import { Button } from '../ui/button'
import { PageLayout } from '../Navbar'
import { type Step } from '../createEntity/EntityStepper'
import { EntityFormShell } from '../createEntity/EntityFormShell'

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
    <EntityFormShell
      steps={steps}
      currentStep={currentStep}
      onStepChange={onStepChange}
      onCancel={() => navigate(backUrl)}
      onSubmit={onSubmit}
      isPending={isPending}
      submitLabel={submitLabel}
      pendingLabel="Updating…"
      preview={preview}
    >
      {children}
    </EntityFormShell>
  )
}

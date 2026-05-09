import { useNavigate } from 'react-router-dom'
import { type Step } from './EntityStepper'
import { EntityFormShell } from './EntityFormShell'


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
    <EntityFormShell
      steps={steps}
      currentStep={currentStep}
      onStepChange={onStepChange}
      onCancel={() => navigate(-1)}
      onSubmit={onSubmit}
      isPending={isPending}
      submitLabel={submitLabel}
      pendingLabel="Creating…"
      preview={preview}
    >
      {children}
    </EntityFormShell>
  )
}

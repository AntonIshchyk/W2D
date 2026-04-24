interface FormFieldProps {
  label: string
  icon?: React.ReactNode
  children: React.ReactNode
}

export function FormField({
  label,
  icon,
  children
}: FormFieldProps) {
  return (
    <div className="space-y-2">
      <label className="flex items-center gap-2 text-sm font-medium text-muted-foreground">
        {icon}
        {label}
      </label>
      {children}
    </div>
  )
}

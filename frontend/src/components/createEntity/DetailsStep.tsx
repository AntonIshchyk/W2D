import { ChevronsUpDown, Check } from 'lucide-react'
import { Button } from '../ui/button'
import { Input } from '../ui/input'
import { Textarea } from '../ui/textarea'
import { Popover, PopoverContent, PopoverTrigger } from '../ui/popover'
import { Command, CommandEmpty, CommandGroup, CommandInput, CommandItem, CommandList } from '../ui/command'
import { cn } from '../../lib/utils'

interface Community {
  id: number
  name: string
}

interface DetailsStepProps {
  title: string
  onTitleChange: (value: string) => void
  description: string
  onDescriptionChange: (value: string) => void
  communities: Community[]
  selectedCommunityId: number | null
  onCommunitySelect: (id: number | null) => void
  communityOpen: boolean
  onCommunityOpenChange: (open: boolean) => void
  detailErrors: Record<string, string | undefined>
  onErrorClear: (field: string) => void
  extraFields?: React.ReactNode
}

export function DetailsStep({
  title,
  onTitleChange,
  description,
  onDescriptionChange,
  communities,
  selectedCommunityId,
  onCommunitySelect,
  communityOpen,
  onCommunityOpenChange,
  detailErrors,
  onErrorClear,
  extraFields,
}: DetailsStepProps) {
  const selectedCommunity = communities.find(c => c.id === selectedCommunityId)

  return (
    <div className="space-y-8 animate-in fade-in slide-in-from-right-4 duration-300">
      <div className="space-y-2">
        <label className="text-xs font-semibold uppercase tracking-widest">
          Title <span className="text-destructive">*</span>
        </label>
        <Input
          autoFocus
          value={title}
          onChange={e => {
            onTitleChange(e.target.value)
            if (detailErrors.title) {
              onErrorClear('title')
            }
          }}
          placeholder="Give a title"
          className={cn(
            'bg-card border-border text-foreground placeholder:text-muted-foreground h-12 text-base focus-visible:ring-primary focus-visible:border-primary',
            detailErrors.title && 'border-destructive focus-visible:ring-destructive focus-visible:border-destructive',
          )}
        />
        {detailErrors.title && <p className="text-xs text-destructive">{detailErrors.title}</p>}
      </div>

      {extraFields}

      <div className="space-y-2">
        <label className="text-xs font-semibold uppercase tracking-widest">
          Community
        </label>
        <Popover open={communityOpen} onOpenChange={onCommunityOpenChange}>
          <PopoverTrigger asChild>
            <Button
              variant="outline"
              role="combobox"
              className="w-full justify-between h-12 bg-card border-border text-foreground hover:bg-accent hover:text-accent-foreground font-normal text-sm"
            >
              {selectedCommunity ? selectedCommunity.name : 'Pick a community'}
              <ChevronsUpDown className="h-5 w-5 shrink-0 opacity-50" />
            </Button>
          </PopoverTrigger>
          <PopoverContent className="w-full p-0 bg-card border-border" align="start">
            <Command className="bg-transparent">
              <CommandInput
                placeholder="Find a community..."
                className="text-foreground placeholder:text-muted-foreground"
              />
              <CommandList>
                <CommandEmpty className="text-muted-foreground py-6 text-center text-sm">No community found.</CommandEmpty>
                <CommandGroup>
                  {communities.map(c => (
                    <CommandItem
                      key={c.id}
                      value={c.name}
                      onSelect={() => {
                        onCommunitySelect(c.id === selectedCommunityId ? null : c.id)
                        onCommunityOpenChange(false)
                      }}
                      className="text-foreground aria-selected:bg-accent"
                    >
                      <Check className={cn('mr-2 h-5 w-5 text-primary', selectedCommunityId === c.id ? 'opacity-100' : 'opacity-0')} />
                      {c.name}
                    </CommandItem>
                  ))}
                </CommandGroup>
              </CommandList>
            </Command>
          </PopoverContent>
        </Popover>
      </div>

      <div className="space-y-2">
        <label className="text-xs font-semibold uppercase tracking-widest">
          Description <span className="text-destructive">*</span>
        </label>
        <Textarea
          value={description}
          onChange={e => {
            onDescriptionChange(e.target.value)
            if (detailErrors.description) {
              onErrorClear('description')
            }
          }}
          placeholder="Share the details"
          rows={4}
          className={cn(
            'bg-card border-border text-foreground placeholder:text-muted-foreground text-sm resize-none focus-visible:ring-primary focus-visible:border-primary',
            detailErrors.description && 'border-destructive focus-visible:ring-destructive focus-visible:border-destructive',
          )}
        />
        {detailErrors.description && <p className="text-xs text-destructive">{detailErrors.description}</p>}
      </div>
    </div>
  )
}

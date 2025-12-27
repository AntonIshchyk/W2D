import { Button } from "./components/ui/button"

function App() {
  return (
    <div className="min-h-screen bg-gray-50 flex items-center justify-center">
      <div className="text-center">
        <h1 className="text-4xl font-bold text-gray-900 mb-4">
          W2D Application
        </h1>
        <p className="text-gray-600 mb-6">
          React + TypeScript + Tailwind CSS
        </p>
        <Button onClick={() => alert('shadcn button works!')}>
          Click Me
        </Button>
      </div>
    </div>
  )
}

export default App

import { useNavigate, Link, useLocation } from 'react-router-dom'
import { Button } from './ui/button'


export function Navbar() {
  const navigate = useNavigate()
  const location = useLocation()

  const handleLogout = () => {
    localStorage.removeItem('token')
    navigate('/login')
  }

  const isActive = (path: string) => location.pathname === path

  return (
    <nav className="bg-white shadow-sm border-b">
      <div className="max-w-6xl mx-auto px-4">
        <div className="flex items-center justify-between h-16">
          <div className="flex items-center gap-8">
            <Link to="/" className="text-xl font-bold text-gray-900 hover:text-gray-700">
              W2D
            </Link>
            <div className="flex gap-6">
              <Link 
                to="/activities" 
                className={`font-medium ${isActive('/activities') ? 'text-blue-600' : 'text-gray-700 hover:text-gray-900'}`}
              >
                Activities
              </Link>
              <Link 
                to="/profile" 
                className={`font-medium ${isActive('/profile') ? 'text-blue-600' : 'text-gray-700 hover:text-gray-900'}`}
              >
                Profile
              </Link>
            </div>
          </div>
          <div className="flex items-center gap-4">
            <Button onClick={handleLogout} variant="outline" size="sm">
              Logout
            </Button>
          </div>
        </div>
      </div>
    </nav>
  )
}

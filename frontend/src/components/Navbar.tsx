import { useNavigate, Link, useLocation } from 'react-router-dom'
import { Home, Map, MessageCircle, User, LogOut, Sparkles } from 'lucide-react'
import { clearAuthToken } from '../hooks/useAuthSync'
import { hasAuthToken } from '../lib/authToken'


export function Navbar() {
  const navigate = useNavigate()
  const location = useLocation()
  const isLoggedIn = hasAuthToken()

  const handleLogout = () => {
    clearAuthToken()
    navigate('/login')
  }

  const isActive = (path: string) => location.pathname === path
  const isPostsActive  = isActive('/posts') || location.pathname.startsWith('/posts/')
  const isPlacesActive = isActive('/places') || location.pathname.startsWith('/places/')

  const navItems = [
    {
      path: '/',
      label: 'Home',
      icon: <Home className="w-5 h-5" />,
      active: isActive('/')
    },
    {
      path: '/places',
      label: 'Map',
      icon: <Map className="w-5 h-5" />,
      active: isPlacesActive
    },
    {
      path: '/posts',
      label: 'Posts',
      icon: <MessageCircle className="w-5 h-5" />,
      active: isPostsActive
    },
    {
      path: '/suggestions',
      label: 'Suggest',
      icon: <Sparkles className="w-5 h-5" />,
      active: isActive('/suggestions')
    },
    {
      path: '/profile',
      label: 'Profile',
      icon: <User className="w-5 h-5" />,
      active: isActive('/profile')
    }
  ]

  return (
    <nav className="fixed left-0 top-0 bottom-0 w-18 bg-card flex flex-col items-center py-6 z-50 shadow-sm border-r border-border">
      <Link to="/" className="text-card-foreground font-black text-lg tracking-tighter mb-10 hover:opacity-80 transition-opacity">
        W2D
      </Link>

      <div className="flex flex-col items-center gap-1 flex-1">
        {navItems.map((item) => (
          <Link
            key={item.path}
            to={item.path}
            className={`group relative w-11 h-11 rounded-xl flex items-center justify-center transition-all duration-200 ${
              item.active
                ? 'bg-primary text-primary-foreground shadow-lg shadow-primary/10'
                : 'text-muted-foreground hover:text-foreground hover:bg-secondary'
            }`}
          >
            {item.icon}
            <span className="absolute left-full ml-3 px-2.5 py-1 bg-popover text-popover-foreground text-xs rounded-md whitespace-nowrap opacity-0 pointer-events-none group-hover:opacity-100 transition-opacity shadow-lg border border-border">
              {item.label}
            </span>
          </Link>
        ))}
      </div>

      {isLoggedIn && (
        <button
          onClick={handleLogout}
          className="group relative w-11 h-11 rounded-xl flex items-center justify-center text-muted-foreground hover:text-destructive hover:bg-secondary transition-all duration-200"
        >
          <LogOut className="w-5 h-5" />
          <span className="absolute left-full ml-3 px-2.5 py-1 bg-popover text-popover-foreground text-xs rounded-md whitespace-nowrap opacity-0 pointer-events-none group-hover:opacity-100 transition-opacity shadow-lg border border-border">
            Logout
          </span>
        </button>
      )}
    </nav>
  )
}

export function PageLayout({ children, fullWidth = false }: { children: React.ReactNode, fullWidth?: boolean }) {
  return (
    <div className="min-h-screen bg-background text-foreground pl-18">
      <Navbar />
      {fullWidth ? (
        <div className="h-screen w-full relative">
          {children}
        </div>
      ) : (
        <div className="p-6 lg:p-10">
          <div className="max-w-6xl mx-auto">
            {children}
          </div>
        </div>
      )}
    </div>
  )
}

import { useNavigate, Link, useLocation } from 'react-router-dom'
import { clearAuthToken } from '../hooks/useAuthSync'


export function Navbar() {
  const navigate = useNavigate()
  const location = useLocation()

  const handleLogout = () => {
    clearAuthToken()
    navigate('/login')
  }

  const isActive = (path: string) => location.pathname === path
  const isPostsActive  = isActive('/posts') || location.pathname.startsWith('/posts/')
  const isEventsActive = isActive('/events') || location.pathname.startsWith('/events/')

  const navItems = [
    {
      path: '/',
      label: 'Home',
      icon: (
        <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6" />
        </svg>
      ),
      active: isActive('/')
    },
    {
      path: '/events',
      label: 'Events',
      icon: (
        <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
        </svg>
      ),
      active: isEventsActive
    },
    {
      path: '/posts',
      label: 'Posts',
      icon: (
        <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M7 8h10M7 12h4m1 8l-4-4H5a2 2 0 01-2-2V6a2 2 0 012-2h14a2 2 0 012 2v8a2 2 0 01-2 2h-3l-4 4z" />
        </svg>
      ),
      active: isPostsActive
    },
    {
      path: '/profile',
      label: 'Profile',
      icon: (
        <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
        </svg>
      ),
      active: isActive('/profile')
    }
  ]

  return (
    <nav className="fixed left-0 top-0 bottom-0 w-18 bg-card flex flex-col items-center py-6 z-50 shadow-sm border-r border-border">
      {/* Logo */}
      <Link to="/" className="text-card-foreground font-black text-lg tracking-tighter mb-10 hover:opacity-80 transition-opacity">
        W2D
      </Link>

      {/* Nav items */}
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
            {/* Tooltip */}
            <span className="absolute left-full ml-3 px-2.5 py-1 bg-popover text-popover-foreground text-xs rounded-md whitespace-nowrap opacity-0 pointer-events-none group-hover:opacity-100 transition-opacity shadow-lg border border-border">
              {item.label}
            </span>
          </Link>
        ))}
      </div>

      {/* Logout at bottom */}
      <button
        onClick={handleLogout}
        className="group relative w-11 h-11 rounded-xl flex items-center justify-center text-muted-foreground hover:text-destructive hover:bg-secondary transition-all duration-200"
      >
        <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1" />
        </svg>
        <span className="absolute left-full ml-3 px-2.5 py-1 bg-popover text-popover-foreground text-xs rounded-md whitespace-nowrap opacity-0 pointer-events-none group-hover:opacity-100 transition-opacity shadow-lg border border-border">
          Logout
        </span>
      </button>
    </nav>
  )
}

/** Layout wrapper that accounts for the sidebar */
export function PageLayout({ children }: { children: React.ReactNode }) {
  return (
    <div className="min-h-screen bg-background text-foreground pl-18">
      <Navbar />
      <div className="p-6 lg:p-10">
        <div className="max-w-6xl mx-auto">
          {children}
        </div>
      </div>
    </div>
  )
}

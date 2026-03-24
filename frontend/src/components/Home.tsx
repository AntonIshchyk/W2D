import { useQuery } from '@tanstack/react-query'
import { Link } from 'react-router-dom'
import { PageLayout } from './Navbar'
import { fetchCurrentUser } from '../lib/auth'
import { useAuthErrorHandler } from '../hooks/useAuthErrorHandler'

export function Home() {
  const { data: user, isLoading, isError, error: userError } = useQuery({
    queryKey: ['currentUser'],
    queryFn: fetchCurrentUser,
    retry: false
  })

  useAuthErrorHandler(isError, userError)

  if (isLoading) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <p className="text-gray-400 text-sm tracking-wide uppercase">Loading...</p>
      </div>
    )
  }

  if (isError) {
    return null
  }

  return (
    <PageLayout>
      {/* Greeting - subtle, not a hero */}
      <div className="mb-10">
        <h1 className="text-2xl font-medium text-gray-400">
          Hey, <span className="text-gray-900 font-semibold">{user?.username}</span>
        </h1>
      </div>

      {/* Asymmetric grid */}
      <div className="grid grid-cols-1 lg:grid-cols-3 gap-5 auto-rows-fr">
        {/* Big CTA - takes 2 cols */}
        <Link 
          to="/communities" 
          className="lg:col-span-2 group relative bg-gray-900 rounded-2xl p-10 flex flex-col justify-between overflow-hidden transition-transform hover:scale-[1.01] duration-300"
        >
          <div className="relative z-10">
            <span className="inline-block text-xs font-medium uppercase tracking-widest text-gray-400 mb-4">
              Browse
            </span>
            <h2 className="text-4xl lg:text-5xl font-bold text-white leading-tight">
              What to do<br />today?
            </h2>
          </div>
          <div className="relative z-10 mt-8">
            <span className="inline-flex items-center gap-2 text-sm font-medium text-gray-400 group-hover:text-white transition-colors">
              Explore communities
              <svg className="w-4 h-4 group-hover:translate-x-1 transition-transform" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M17 8l4 4m0 0l-4 4m4-4H3" />
              </svg>
            </span>
          </div>
          {/* Abstract decoration */}
          <div className="absolute -right-10 -bottom-10 w-60 h-60 bg-gray-800 rounded-full opacity-50" />
          <div className="absolute right-20 -bottom-5 w-32 h-32 bg-gray-700 rounded-full opacity-30" />
        </Link>

        {/* Stacked right column */}
        <div className="flex flex-col gap-5">
          <Link 
            to="/posts" 
            className="group flex-1 bg-white border border-gray-200 rounded-2xl p-7 flex flex-col justify-between hover:border-gray-400 transition-colors"
          >
            <svg className="w-7 h-7 text-gray-300 mb-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M7 8h10M7 12h4m1 8l-4-4H5a2 2 0 01-2-2V6a2 2 0 012-2h14a2 2 0 012 2v8a2 2 0 01-2 2h-3l-4 4z" />
            </svg>
            <div>
              <h3 className="text-lg font-semibold text-gray-900 mb-1">Community</h3>
              <p className="text-sm text-gray-500">Experiences, guides, questions</p>
            </div>
          </Link>

          <Link 
            to="/profile" 
            className="group flex-1 bg-white border border-gray-200 rounded-2xl p-7 flex flex-col justify-between hover:border-gray-400 transition-colors"
          >
            <svg className="w-7 h-7 text-gray-300 mb-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-6 9l2 2 4-4" />
            </svg>
            <div>
              <h3 className="text-lg font-semibold text-gray-900 mb-1">Your Plans</h3>
              <p className="text-sm text-gray-500">Your profile</p>
            </div>
          </Link>
        </div>
      </div>
    </PageLayout>
  )
}

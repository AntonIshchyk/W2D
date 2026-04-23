import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'
import { Toaster } from 'sonner'
import { Login } from './components/Login'
import { ProfileSetup } from './components/ProfileSetup'
import { Home } from './components/Home'
import { Profile } from './components/Profile'
import { Events } from './components/Events'
import { CreateEvent } from './components/CreateEvent'
import { EventDetail } from './components/EventDetail'
import { Posts } from './components/Posts'
import { CreatePost } from './components/CreatePost'
import { PostDetail } from './components/PostDetail'
import { useAuthSync } from './hooks/useAuthSync'
import { ProtectedRoute } from './components/ProtectedRoute'
import { hasAuthToken } from './lib/authToken'

function App() {
  useAuthSync()
  const isLoggedIn = hasAuthToken()

  return (
    <BrowserRouter future={{ v7_startTransition: true, v7_relativeSplatPath: true }}>
      <Toaster position="top-center" richColors />
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/profile-setup" element={<ProtectedRoute><ProfileSetup /></ProtectedRoute>} />
        <Route path="/" element={<ProtectedRoute><Home /></ProtectedRoute>} />
        <Route path="/profile" element={<ProtectedRoute><Profile /></ProtectedRoute>} />
        <Route path="/events" element={<ProtectedRoute><Events /></ProtectedRoute>} />
        <Route path="/events/create" element={<ProtectedRoute><CreateEvent /></ProtectedRoute>} />
        <Route path="/events/:id" element={<ProtectedRoute><EventDetail /></ProtectedRoute>} />
        <Route path="/posts" element={<ProtectedRoute><Posts /></ProtectedRoute>} />
        <Route path="/posts/create" element={<ProtectedRoute><CreatePost /></ProtectedRoute>} />
        <Route path="/posts/:id" element={<ProtectedRoute><PostDetail /></ProtectedRoute>} />
        <Route path="*" element={<Navigate to={isLoggedIn ? '/' : '/login'} replace />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App

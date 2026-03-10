import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'
import { Toaster } from 'sonner'
import { Login } from './components/Login'
import { Home } from './components/Home'
import { Profile } from './components/Profile'
import { Activities } from './components/Activities'
import { Events } from './components/Events'
import { EventDetail } from './components/EventDetail'
import { Posts } from './components/Posts'
import { CreatePost } from './components/CreatePost'
import { PostDetail } from './components/PostDetail'
import { useAuthSync } from './hooks/useAuthSync'
import { ProtectedRoute } from './components/ProtectedRoute'

function App() {
  // Automatically clear cache when auth token changes
  useAuthSync()

  return (
    <BrowserRouter future={{ v7_startTransition: true, v7_relativeSplatPath: true }}>
      <Toaster position="top-center" richColors />
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/" element={<ProtectedRoute><Home /></ProtectedRoute>} />
        <Route path="/profile" element={<ProtectedRoute><Profile /></ProtectedRoute>} />
        <Route path="/activities" element={<ProtectedRoute><Activities /></ProtectedRoute>} />
        <Route path="/events" element={<ProtectedRoute><Events /></ProtectedRoute>} />
        <Route path="/events/:id" element={<ProtectedRoute><EventDetail /></ProtectedRoute>} />
        <Route path="/posts" element={<ProtectedRoute><Posts /></ProtectedRoute>} />
        <Route path="/posts/create" element={<ProtectedRoute><CreatePost /></ProtectedRoute>} />
        <Route path="/posts/:id" element={<ProtectedRoute><PostDetail /></ProtectedRoute>} />
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App

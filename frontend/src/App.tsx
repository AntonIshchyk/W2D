import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'
import { Toaster } from 'sonner'
import { Login } from './components/Login'
import { ProfileSetup } from './components/ProfileSetup'
import { Home } from './components/Home'
import { Profile } from './components/Profile'
import { EditProfile } from './components/EditProfile'
import { Places } from './components/Places'
import { CreatePlace } from './components/CreatePlace'
import { Posts } from './components/Posts'
import { CreatePost } from './components/CreatePost'
import { EditPost } from './components/EditPost'
import { EditPlace } from './components/EditPlace'
import { PostDetail } from './components/PostDetail'
import { PlaceDetail } from './components/PlaceDetail'
import { useAuthSync } from './hooks/useAuthSync'
import { ProtectedRoute } from './components/ProtectedRoute'

function App() {
  useAuthSync()

  return (
    <BrowserRouter future={{ v7_startTransition: true, v7_relativeSplatPath: true }}>
      <Toaster position="top-center" richColors />
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/profile-setup" element={<ProtectedRoute><ProfileSetup /></ProtectedRoute>} />
        <Route path="/" element={<ProtectedRoute><Home /></ProtectedRoute>} />
        <Route path="/profile" element={<ProtectedRoute><Profile /></ProtectedRoute>} />
        <Route path="/profile/edit" element={<ProtectedRoute><EditProfile /></ProtectedRoute>} />
        <Route path="/places" element={<ProtectedRoute><Places /></ProtectedRoute>} />
        <Route path="/places/create" element={<ProtectedRoute><CreatePlace /></ProtectedRoute>} />
        <Route path="/places/:id" element={<ProtectedRoute><PlaceDetail /></ProtectedRoute>} />
        <Route path="/places/:placeId/edit" element={<ProtectedRoute><EditPlace /></ProtectedRoute>} />
        <Route path="/posts" element={<ProtectedRoute><Posts /></ProtectedRoute>} />
        <Route path="/posts/create" element={<ProtectedRoute><CreatePost /></ProtectedRoute>} />
        <Route path="/posts/:id" element={<ProtectedRoute><PostDetail /></ProtectedRoute>} />
        <Route path="/posts/:postId/edit" element={<ProtectedRoute><EditPost /></ProtectedRoute>} />
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App

import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'
import { SignUp } from './components/SignUp'
import { Login } from './components/Login'
import { Home } from './components/Home'
import { Profile } from './components/Profile'
import { Activities } from './components/Activities'
import { Posts } from './components/Posts'
import { CreatePost } from './components/CreatePost'
import { PostDetail } from './components/PostDetail'
import { useAuthSync } from './hooks/useAuthSync'

function App() {
  // Automatically clear cache when auth token changes
  useAuthSync()

  return (
    <BrowserRouter future={{ v7_startTransition: true, v7_relativeSplatPath: true }}>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/activities" element={<Activities />} />
        <Route path="/posts" element={<Posts />} />
        <Route path="/posts/create" element={<CreatePost />} />
        <Route path="/posts/:id" element={<PostDetail />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<SignUp />} />
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App

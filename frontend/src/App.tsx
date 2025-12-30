import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'
import { SignUp } from './components/SignUp'
import { Login } from './components/Login'
import { Home } from './components/Home'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<SignUp />} />
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App

import { useMutation } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { GoogleLogin } from '@react-oauth/google'
import { toast } from 'sonner'
import { API_ENDPOINTS } from '../config/api'
import { setAuthToken } from '../hooks/useAuthSync'

const ACTIVITIES = [
  {
    id: 'football',
    label: 'Football',
    photo: 'https://images.unsplash.com/photo-1579952363873-27f3bade9f55?w=400&h=260&fit=crop&auto=format',
    accent: '#e85d3a',
    rot: '-5deg',
    style: { top: '5%', left: '1%' },
    delay: '0s',
  },
  {
    id: 'cycling',
    label: 'Cycling',
    photo: 'https://images.unsplash.com/photo-1541625602330-2277a4c46182?w=400&h=260&fit=crop&auto=format',
    accent: '#f0a500',
    rot: '4deg',
    style: { top: '5%', right: '2%' },
    delay: '1.4s',
  },
  {
    id: 'walk',
    label: 'Go for a walk',
    photo: 'https://images.unsplash.com/photo-1549057446-9f5c6ac91a04?q=80&w=1934&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
    accent: '#2eaa6e',
    rot: '-4deg',
    style: { top: '42%', left: '1%' },
    delay: '0.6s',
  },
  {
    id: 'pingpong',
    label: 'Ping pong',
    photo: 'https://images.unsplash.com/photo-1534158914592-062992fbe900?w=400&h=260&fit=crop&auto=format',
    accent: '#d63fac',
    rot: '5deg',
    style: { top: '38%', right: '1%' },
    delay: '0.7s',
  },
  {
    id: 'videogames',
    label: 'Video games',
    photo: 'https://images.unsplash.com/photo-1493711662062-fa541adb3fc8?w=400&h=260&fit=crop&auto=format',
    accent: '#9b4fe8',
    rot: '-3.5deg',
    style: { top: '75%', left: '1%' },
    delay: '1.8s',
  },
  {
    id: 'chess',
    label: 'Chess',
    photo: 'https://images.unsplash.com/photo-1529699211952-734e80c4d42b?w=400&h=260&fit=crop&auto=format',
    accent: '#a0c040',
    rot: '5deg',
    style: { top: '73%', right: '2%' },
    delay: '3s',
  },
]

const PINS = [
  // Football — top-left card (top:5%, left:1%, ~174px wide). Pin sits at right edge of card, vertically centered
  { color: '#e85d3a', size: 18, delay: '0s',   style: { top: '12%', left: '13%' } },
  // Cycling — top-right card (top:5%, right:2%). Pin sits at left edge of card
  { color: '#f0a500', size: 18, delay: '1.0s', style: { top: '12%', right: '13%' } },
  // Walk — mid-left card (top:42%, left:1%). Pin at right edge, vertically centered
  { color: '#2eaa6e', size: 16, delay: '2.1s', style: { top: '50%', left: '13%' } },
  // Ping pong — mid-right card (top:38%, right:1%). Pin at left edge
  { color: '#d63fac', size: 16, delay: '0.5s', style: { top: '47%', right: '13%' } },
  // Video games — bottom-left card (top:75%, left:1%). Pin at right edge
  { color: '#9b4fe8', size: 16, delay: '1.6s', style: { top: '82%', left: '13%' } },
  // Chess — bottom-right card (top:73%, right:2%). Pin at left edge
  { color: '#a0c040', size: 16, delay: '2.8s', style: { top: '80%', right: '13%' } },
]

export function Login() {
  const navigate = useNavigate()
  const googleMutation = useMutation({
    mutationFn: async (credential: string) => {
      const response = await fetch(API_ENDPOINTS.users.googleLogin, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ credential }),
      })
      if (!response.ok) {
        let errorMsg = 'Google login failed'
        try { const body = await response.json(); errorMsg = body.message || errorMsg } catch {}
        throw new Error(errorMsg)
      }
      return response.json()
    },
    onSuccess: (data) => {
      setAuthToken(data.token)
      toast.success('Signed in with Google!')
      navigate('/')
    },
    onError: (error: Error) => {
      toast.error(error.message)
    },
  })

  return (
    <>
      <style>{`
        *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

        .lr {
          min-height: 100vh;
          background: #0e0e0e;
          display: flex;
          position: relative;
          overflow: hidden;
          
        }

        .lr::before {
          content: '';
          position: fixed; inset: 0;
          background-image:
            linear-gradient(rgba(255,255,255,0.022) 1px, transparent 1px),
            linear-gradient(90deg, rgba(255,255,255,0.022) 1px, transparent 1px);
          background-size: 48px 48px;
          pointer-events: none;
          z-index: 0;
        }

        .glow {
          position: absolute;
          border-radius: 50%;
          filter: blur(100px);
          pointer-events: none;
          z-index: 0;
          opacity: 0.18;
        }
        .glow-a { width: 550px; height: 550px; background: #e85d3a; top: -120px; left: -120px; }
        .glow-b { width: 420px; height: 420px; background: #5b6ee8; bottom: -80px; right: 18%; }
        .glow-c { width: 380px; height: 380px; background: #2eaa6e; top: 38%; left: -90px; }
        .glow-d { width: 320px; height: 320px; background: #d63fac; top: 8%; right: -70px; }
        .glow-e { width: 280px; height: 280px; background: #f0a500; bottom: 5%; left: 30%; }

        .map-lines {
          position: absolute; inset: 0; z-index: 1; pointer-events: none;
        }

        /* ── Cards ── */
        .act-card {
          position: absolute;
          width: 174px;
          border-radius: 12px;
          overflow: hidden;
          z-index: 2;
          animation: floatCard 7s ease-in-out infinite;
          /* no box-shadow */
        }

        .act-photo-wrap {
          position: relative;
          width: 100%;
          height: 112px;
          overflow: hidden;
        }

        .act-photo {
          width: 100%;
          height: 100%;
          object-fit: cover;
          display: block;
        }

        .act-tint {
          position: absolute;
          inset: 0;
          mix-blend-mode: multiply;
        }

        .act-photo-wrap::after {
          content: '';
          position: absolute;
          bottom: 0; left: 0; right: 0;
          height: 36px;
          background: linear-gradient(to bottom, transparent, var(--card-accent));
        }

        .act-footer {
          padding: 8px 11px 10px;
          display: flex;
          align-items: center;
        }

        .act-label {
          
          font-size: 13px;
          font-weight: 600;
          color: #fff;
          line-height: 1.2;
          white-space: nowrap;
          overflow: hidden;
          text-overflow: ellipsis;
          letter-spacing: 0.01em;
        }

        @keyframes floatCard {
          0%, 100% { transform: translateY(0px)   rotate(var(--rot)); }
          50%       { transform: translateY(-10px) rotate(var(--rot)); }
        }

        /* ── Pins ── */
        .map-pin {
          position: absolute;
          z-index: 3;
          pointer-events: none;
          animation: pinFloat 4s ease-in-out infinite;
        }
        @keyframes pinFloat {
          0%, 100% { transform: translateY(0); }
          50%       { transform: translateY(-5px) scale(1.14); }
        }

        /* ── Form ── */
        .form-panel {
          position: relative;
          z-index: 10;
          flex: 1;
          display: flex;
          align-items: center;
          justify-content: center;
          padding: 24px;
          pointer-events: none;
        }
        .form-panel > * { pointer-events: all; }

        .form-card {
          background: rgba(16, 16, 16, 0.88);
          border-radius: 20px;
          border: 1px solid rgba(255,255,255,0.09);
          box-shadow:
            0 28px 90px rgba(0,0,0,0.7),
            0 0 0 1px rgba(255,255,255,0.04),
            inset 0 1px 0 rgba(255,255,255,0.07);
          padding: 48px 44px 44px;
          width: 100%;
          max-width: 390px;
          backdrop-filter: blur(28px);
          animation: cardIn 0.65s cubic-bezier(0.16, 1, 0.3, 1) both;
        }
        @keyframes cardIn {
          from { opacity: 0; transform: translateY(32px) scale(0.97); }
          to   { opacity: 1; transform: translateY(0) scale(1); }
        }

        .brand {
          
          font-size: 48px;
          font-weight: 800;
          color: #fff;
          line-height: 1;
          letter-spacing: -1px;
        }
        .brand-tagline {
          font-size: 11.5px;
          font-weight: 300;
          color: rgba(255,255,255,0.32);
          letter-spacing: 0.12em;
          text-transform: uppercase;
          margin-top: 6px;
          margin-bottom: 28px;
        }

        .communities-text {
          font-size: 13px;
          font-weight: 300;
          color: rgba(255,255,255,0.42);
          line-height: 1.7;
          margin-bottom: 4px;
        }

        .sep {
          width: 28px; height: 1.5px;
          background: linear-gradient(90deg, #e85d3a, #f0a500);
          border-radius: 2px;
          margin: 24px 0 20px;
        }

        .cta-text {
          font-size: 13px;
          font-weight: 400;
          color: rgba(255,255,255,0.6);
          margin-bottom: 20px;
          letter-spacing: 0.01em;
        }

        .google-wrap { display: flex; justify-content: center; }

        .fine-print {
          margin-top: 22px;
          font-size: 11px;
          color: rgba(255,255,255,0.18);
          text-align: center;
          font-weight: 300;
          line-height: 1.7;
          letter-spacing: 0.02em;
        }

        @media (max-width: 720px) {
          .act-card, .map-pin, .map-lines, .glow { display: none; }
          .form-card { padding: 36px 28px; }
        }
      `}</style>

      <div className="lr">
        <div className="glow glow-a" />
        <div className="glow glow-b" />
        <div className="glow glow-c" />
        <div className="glow glow-d" />
        <div className="glow glow-e" />

        {/*
          Map lines — each path is ONE continuous d attribute with no gaps.
          Left rail:   top-left → mid-left → bottom-left
          Right rail:  top-right → mid-right → bottom-right
          Top arc:     top-left → top-right
          Bottom arc:  bottom-left → bottom-right
          Mid cross:   mid-left → mid-right
        */}
        <svg className="map-lines" viewBox="0 0 1440 900" fill="none" preserveAspectRatio="none">
          <path
            d="M192 108 C191 250 189 380 191 450 C193 520 191 650 192 792"
            stroke="rgba(255,255,255,0.13)" strokeWidth="1.5" strokeLinecap="round"
          />
          <path
            d="M1248 108 C1108 250 1106 380 1108 450 C1110 520 1108 650 1248 792"
            stroke="rgba(255,255,255,0.13)" strokeWidth="1.5" strokeLinecap="round"
          />
          <path
            d="M192 108 C480 38 960 38 1248 108"
            stroke="rgba(255,255,255,0.08)" strokeWidth="1.5" strokeLinecap="round"
          />
          <path
            d="M192 792 C480 862 960 862 1248 792"
            stroke="rgba(255,255,255,0.08)" strokeWidth="1.5" strokeLinecap="round"
          />
          <path
            d="M191 450 C480 400 960 400 1108 450"
            stroke="rgba(255,255,255,0.055)" strokeWidth="1.5" strokeLinecap="round"
          />
        </svg>

        {/* Activity cards */}
        {ACTIVITIES.map((a) => (
          <div
            key={a.id}
            className="act-card"
            style={{
              ...a.style,
              animationDelay: a.delay,
              ['--rot' as string]: a.rot,
              ['--card-accent' as string]: a.accent,
            } as React.CSSProperties}
          >
            <div className="act-photo-wrap">
              <img className="act-photo" src={a.photo} alt={a.label} loading="lazy" />
              <div className="act-tint" style={{ background: `${a.accent}55` }} />
            </div>
            <div className="act-footer" style={{ background: a.accent }}>
              <span className="act-label">{a.label}</span>
            </div>
          </div>
        ))}

        {/* Map pins */}
        {PINS.map(({ color, size, delay, style }, i) => (
          <div
            key={i}
            className="map-pin"
            style={{ ...style, animationDelay: delay } as React.CSSProperties}
          >
            <svg width={size} height={Math.round(size * 1.38)} viewBox="0 0 18 24" fill="none">
              <path d="M9 0C4.03 0 0 4.03 0 9c0 6.75 9 15 9 15s9-8.25 9-15C18 4.03 13.97 0 9 0z" fill={color}/>
              <circle cx="9" cy="9" r="3.5" fill="white" opacity="0.95"/>
            </svg>
          </div>
        ))}

        {/* Form */}
        <div className="form-panel">
          <div className="form-card">
            <div className="brand">W2D</div>
            <div className="brand-tagline">What to do</div>

            <p className="communities-text">
              Communities for every kind of activity — find people who share your interests and make plans together.
            </p>

            <div className="sep" />
            <p className="cta-text">Join your people. Pick an activity.</p>

            <div className="google-wrap">
              <GoogleLogin
                onSuccess={(credentialResponse) => {
                  if (credentialResponse.credential) {
                    googleMutation.mutate(credentialResponse.credential)
                  }
                }}
                onError={() => console.error('Google Login Failed')}
                useOneTap
              />
            </div>

            <p className="fine-print">
              By signing in you agree to share good times and have fun!
            </p>
          </div>
        </div>
      </div>
    </>
  )
}

import { createRoot } from 'react-dom/client'
import React from 'react'
import { RouterProvider } from 'react-router-dom'
import router from './routes.tsx'

createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)

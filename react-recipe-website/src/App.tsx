import './assets/css/bootstrap.min.css'
import Navbar from './Navbar'
import { Outlet } from 'react-router-dom'

function App() {

  return (
    <>
      <div className="container">
        <div className="row">
          <div className="col">
            <Navbar />
          </div>
        </div>
        <div className="row">
          <div className="col">
            <Outlet />
          </div>
        </div>
      </div>
    </>
  )
}

export default App

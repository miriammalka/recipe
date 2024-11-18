import './assets/css/bootstrap.min.css'
import Navbar from './Navbar'
import Sidebar from './Sidebar'
import MainScreen from './MainScreen'
import { useState } from 'react'

function App() {
  const [selectedCuisineId, setSelectedCuisineId] = useState(0);
  const handleCuisineSelected = (cuisineId: number) => {
    setSelectedCuisineId(cuisineId);
  }
  return (
    <>
      <div className="container">
        <div className="row">
          <div className="col">
            <Navbar />
          </div>
        </div>
        <div className="row mt-4">
          <div className="col-3">
            <Sidebar onCuisineSelected={handleCuisineSelected}/>
          </div>
          <div className="col-9">
            <MainScreen cuisineId={selectedCuisineId} />
          </div>
        </div>
      </div>
    </>
  )
}

export default App

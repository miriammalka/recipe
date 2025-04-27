import Sidebar from './Sidebar'
import MainScreen from './MainScreen'
import { useState } from 'react'


export default function Recipes() {

    const [selectedCuisineId, setSelectedCuisineId] = useState(0);
  
    const handleCuisineSelected = (cuisineId: number) => {
        setSelectedCuisineId(cuisineId);
    }



    return (
        <>
            <div className="container">
                <div className="row mt-4">
                    <div className="col-3">
                        <Sidebar onCuisineSelected={handleCuisineSelected} />
                    </div>
                    <div className="col-9">
                        
                        <MainScreen cuisineId={selectedCuisineId} />
                    </div>
                </div>
            </div>
        </>
    )
}


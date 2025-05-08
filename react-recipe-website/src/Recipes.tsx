import Sidebar from './Sidebar'
import MainScreen from './MainScreen'
import { useEffect, useState } from 'react'
import { fetchCuisines } from './DataUtility';
import { ICuisine } from './DataInterfaces';


export default function Recipes() {
    const DEFAULT_CUISINE = 1021; // doesn't matter what number goes here, just for personal convenience
    const [selectedCuisineId, setSelectedCuisineId] = useState(DEFAULT_CUISINE);
    const [isCuisineSelectionShowing, setIsCuisineSelectionShowing] = useState(true);

    const [cuisineList, setCuisineList] = useState<ICuisine[]>([]);

    /*  on page load ... 
    fetch all cuisine names, 
    set the cuisine list for the sidebar, 
    set the selected cuisine default */
    useEffect(() => {
        const fetchData = async () => {
            const cuisineData = await fetchCuisines();
            setCuisineList(cuisineData);
            console.log('cuisines names retrieved', cuisineData);

            /*  use cuisineData var and not cuisineList because cuisineList doesn't get set until the end of useEffect */
            setSelectedCuisineId(cuisineData[0].cuisineId || 0);
        };
        fetchData();
    },
        []);

/*         useEffect(() => {
            // fetch ALL recipes from db
        }, [cuisineList]) */

    const onCuisineSelected = (cuisineId: number) => {
        setSelectedCuisineId(cuisineId);
        console.log("Selected cuisine ID:", cuisineId);
        setIsCuisineSelectionShowing(true);
    }



    return (
        <>
            <div className="container">
                <div className="row mt-4">
                    <div className="col-3">
                        <Sidebar
                            cuisineList={cuisineList}
                            onCuisineSelected={onCuisineSelected}
                            selectedCuisineId={selectedCuisineId}
                        />
                    </div>
                    <div className="col-9">
                        <MainScreen
                            cuisineId={selectedCuisineId}
                            isCuisineSelectionShowing={isCuisineSelectionShowing}
                            setIsCuisineSelectionShowing={setIsCuisineSelectionShowing}
                        />
                    </div>
                </div>
            </div>
        </>
    )
}


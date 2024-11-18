import { ICuisine } from "./DataInterfaces";
import CuisineButton from "./CuisineButton";
import { fetchCuisines } from "./DataUtility";
import { useEffect, useState } from "react";

interface Props{
    onCuisineSelected:(cuisineId:number)=> void
}


export default function Sidebar({onCuisineSelected}:Props) {
    const [cuisineList, setCuisineList] = useState<ICuisine[]>([]);
    const [selectedCuisineId, setSelectedCuisineId] = useState(0);


    useEffect(() => {
        const fetchData = async () => {
            const cuisineData = await fetchCuisines();
            setCuisineList(cuisineData);
            console.log(cuisineData);
            if(cuisineData.length >0){
                handleCuisineSelected(cuisineData[0].cuisineId)
            }
        };
        fetchData();
    },
        []);

    function handleCuisineSelected(cuisineId: number) {
        //grays out cuisine button
        setSelectedCuisineId(cuisineId);
        //communicates to main screen which recipes to show for the selected cuisine
        onCuisineSelected(cuisineId);
    }
    return (
        <>
            <div className="row">
                <div className="col">
                    {cuisineList.map(c => (
                        <CuisineButton key={c.cuisineId} cuisine={c} isSelected={c.cuisineId == selectedCuisineId} onSelected={handleCuisineSelected}/>
                    ))}
                </div>
            </div>
        </>
    )
}
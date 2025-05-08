import { ICuisine } from "./DataInterfaces";
import CuisineButton from "./CuisineButton";

interface Props {
    onCuisineSelected: (cuisineId: number) => void,
    cuisineList: ICuisine[],
    selectedCuisineId: number; 
}


export default function Sidebar({ onCuisineSelected, cuisineList, selectedCuisineId }: Props) {

    function handleCuisineSelected(cuisineId: number) {
        console.log('handleCuisineSelected', cuisineId, selectedCuisineId);
        if(cuisineId !== selectedCuisineId) {
        //grays out cuisine button
        // setSelectedCuisineId(cuisineId);
        //communicates to main screen which recipes to show for the selected cuisine
        onCuisineSelected(cuisineId);
    }
    else{
        onCuisineSelected(cuisineId);
    }
}
    return (
        <>
            <div className="row">
                <div className="col">
                    {cuisineList.map(c => (
                        <CuisineButton key={c.cuisineId} cuisine={c} isSelected={c.cuisineId === selectedCuisineId} onSelected={handleCuisineSelected} />
                    ))}
                </div>
            </div>
        </>
    )
}
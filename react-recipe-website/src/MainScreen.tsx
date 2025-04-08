import { useEffect, useState } from "react"
import { IRecipe } from "./DataInterfaces"
import { fetchRecipiesByCuisineId } from "./DataUtility";
import RecipeCard from "./RecipeCard";
import { RecipeEdit } from "./RecipeEdit"


interface Props {
    cuisineId: number,
    //onRecipeSelectedForEdit: (recipe: IRecipe) => void;

}
export default function MainScreen({ cuisineId, /*onRecipeSelectedForEdit */ }: Props) {
    const [recipeList, setRecipeList] = useState<IRecipe[]>([]);
    const [isLoading, setIsLoading] = useState(false);
    const [recipeid, setRecipeId] = useState(0);
    const [refreshTrigger, setRefreshTrigger] = useState(0);


    useEffect(
        () => {
            if (cuisineId > 0) {
                setIsLoading(true);
                const fetchData = async () => {
                    const data = await fetchRecipiesByCuisineId(cuisineId);
                    setRecipeList(data);
                    console.log(data);
                    setIsLoading(false);
                    setRecipeId(0);
                }
                fetchData();
            }
        },
        [cuisineId, refreshTrigger]
    )

    function handleRecipeEdit(recipeid: number) {
        setRecipeId(recipeid);
    }


    function handleRecipeDelete(deletedrecipeid: number) {
        setRecipeList(recipeList.filter(r => r.recipeId != deletedrecipeid));
    }

    function handleUpdateRecipe(updatedrecipe: IRecipe) {
        const recipeExists = recipeList.some(r => r.recipeId === updatedrecipe.recipeId);
        if (recipeExists) {
            setRecipeList(prevList =>
                prevList.map(r => r.recipeId === updatedrecipe.recipeId ? updatedrecipe : r)
            );            
        }
        else {
            setRecipeList([...recipeList, updatedrecipe]);   
            //setRecipeId(updatedrecipe.recipeId);          
        }
        //setRefreshTrigger(prev => prev + 1);
    }

    function handleRecipeClone(clonedRecipe: IRecipe) {

            setRecipeList([...recipeList, clonedRecipe]);   
            //setRecipeId(updatedrecipe.recipeId);          
      
        //setRefreshTrigger(prev => prev + 1);
    }

    return (
        <>
            <div className="row align-items-center mb-3">
                <div className="col-md-10">
                    <div className={isLoading ? "placeholder-glow" : ""}>
                        <h2 className="mt-2 bg-light">
                            <span className={isLoading ? "placeholder" : ""}>
                                {recipeid === 0 ? `${recipeList.length} Recipes` :
                                    recipeid === -1 ? "New Recipe" : "Edit Recipe"}
                            </span>
                        </h2>

                    </div>
                </div>
                <div className="col-md-2 text end">
                    {
                        recipeid == 0 ? (<>
                            <div className="d-flex gap-2 justify-content-end">
                                <button className="btn btn-secondary" onClick={() => setRecipeId(-1)}>New Recipe</button>
                                {/* <button className="btn btn-secondary ms-2" onClick={()=>handleRecipeClone}>Clone a Recipe</button> */}
                            </div>
                        </>)
                            :
                            <button className="btn btn-warning" onClick={() => setRecipeId(0)}>Back</button>
                    }
                </div>
            </div>
            <div className="row">
                {
                    recipeid === 0 ?

                        recipeList.map(r => <div key={r.recipeId} className="col-md-6 col-lg-3 mb-2">
                            <RecipeCard recipe={r} onRecipeEdit={handleRecipeEdit} />

                        </div>)
                        :
                        <RecipeEdit
                            recipe={recipeList.find(r => r.recipeId === recipeid)!}
                            onCancel={() => handleRecipeEdit(0)}
                            onRecipeDelete={handleRecipeDelete}
                            onRecipeUpdate={handleUpdateRecipe}
                            onRecipeClone={handleRecipeClone} />
                }
            </div>


        </>
    );
}



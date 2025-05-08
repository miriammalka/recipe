import { useEffect, useState } from "react"
import { IRecipe } from "./DataInterfaces"
import { fetchRecipiesByCuisineId } from "./DataUtility";
import RecipeCard from "./RecipeCard";
import { RecipeEdit } from "./RecipeEdit"


interface Props {
    cuisineId: number,
    isCuisineSelectionShowing: boolean
    setIsCuisineSelectionShowing: (value: boolean) => void

}
export default function MainScreen(
    {   cuisineId, 
        isCuisineSelectionShowing, 
        setIsCuisineSelectionShowing }
    : Props) {
    const [recipeList, setRecipeList] = useState<IRecipe[]>([]);
    const [isLoading, setIsLoading] = useState(false);
    const [recipeid, setRecipeId] = useState(0);
    const [isRecipeClone, setIsRecipeClone] = useState(false);
    const [areButtonsDisabled, setAreButtonsDisabled] = useState(false);

    useEffect(
        () => {
            if (cuisineId > 0) {
                setIsCuisineSelectionShowing(true);
                setIsLoading(true);
                setRecipeList([]);
                const fetchData = async () => {
                    const singleCuisineRecipesData = await fetchRecipiesByCuisineId(cuisineId);
                    setRecipeList(singleCuisineRecipesData);
                    console.log('fetched singleCuisineRecipesData', singleCuisineRecipesData);
                    setIsLoading(false);
                }
                fetchData();
            }
        },
        [cuisineId]
    )

    function handleRecipeEdit(recipeid: number) {
        setRecipeId(recipeid);
        setIsCuisineSelectionShowing(false)
        setIsRecipeClone(false);
        setAreButtonsDisabled(recipeid === -1);
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
            setRecipeId(updatedrecipe.recipeId);

        }

    }

    function handleRecipeClone(clonedRecipe: IRecipe) {

        setRecipeList([...recipeList, clonedRecipe]);
        setRecipeId(clonedRecipe.recipeId);
        setIsCuisineSelectionShowing(false);
        setIsRecipeClone(true);
    }

    return (
        <>
            <div className="row align-items-center mb-3">
                <div className="col-md-10">
                    <div className={isLoading ? "placeholder-glow" : ""}>
                        <h2 className="mt-2 bg-light">
                            <span className={isLoading ? "placeholder" : ""}>
                                {isCuisineSelectionShowing == true ? `${recipeList.length} Recipes` :
                                    recipeid === -1 ? "New Recipe" : "Edit Recipe"}
                            </span>
                        </h2>

                    </div>
                </div>
                <div className="col-md-2 text end">
                    {
                        isCuisineSelectionShowing ? (<>
                            <div className="d-flex gap-2 justify-content-end">
                                <button className="btn btn-secondary" onClick={() => { handleRecipeEdit(-1) }}>New Recipe</button>
                            </div>
                        </>)
                            :
                            <button className="btn btn-warning" onClick={() => setIsCuisineSelectionShowing(true)}>Back</button>
                    }
                </div>
            </div>
            <div className="row">
                {
                    isCuisineSelectionShowing ? //recipeid === 0 ? //isCuisineDisplayShowing === false or !isCuisineDisplayShowing

                        recipeList.map(r => <div key={r.recipeId} className="col-md-6 col-lg-3 mb-2">
                            <RecipeCard recipe={r} onRecipeEdit={handleRecipeEdit} />

                        </div>)
                        :
                        <RecipeEdit
                            recipe={recipeList.find(r => r.recipeId === recipeid)!}
                            onCancel={() => handleRecipeEdit(0)}
                            onRecipeDelete={handleRecipeDelete}
                            onRecipeUpdate={handleUpdateRecipe}
                            onRecipeClone={handleRecipeClone}
                            isClone={isRecipeClone}
                            ButtonsDisabled={areButtonsDisabled}
                            setButtonsDisabled={setAreButtonsDisabled} />
                }
            </div>


        </>
    );
}



import { useEffect, useState } from "react"
import { IRecipe } from "./DataInterfaces"
import { fetchRecipiesByCuisineId } from "./DataUtility";
import RecipeCard from "./RecipeCard";

interface Props {
    cuisineId: number
}
export default function MainScreen({ cuisineId }: Props) {
    const [recipeList, setRecipeList] = useState<IRecipe[]>([]);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(
        () => {
            if (cuisineId > 0) {
                setIsLoading(true);
                const fetchData = async () => {
                    const data = await fetchRecipiesByCuisineId(cuisineId);
                    setRecipeList(data);
                    console.log(data);
                    setIsLoading(false);
                }
                fetchData();
            }
        },
        [cuisineId]
    )

    return (
        <>
            <div className="row">
                <div className={isLoading ? "placeholder-glow" : ""}>
                    <h2 className="mt-2 bg-light">
                        <span className={ isLoading ? "placeholder" : ""}>{recipeList.length} Recipes</span>
                    </h2>
                </div>
            </div>
            <div className="row mt-4">
                {
                    recipeList.map(r =>
                        <div className="col-md-6 col-lg-3 mb-2">
                            <RecipeCard recipe={r} key={r.recipeId} />
                        </div>

                    )
                }
            </div>

        </>
    )
}
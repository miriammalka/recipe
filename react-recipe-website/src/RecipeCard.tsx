import { getUserStore } from "@miriammalka/reactutils";
import { IRecipe } from "./DataInterfaces"

interface Props {
    recipe: IRecipe
    onRecipeEdit: (recipeid : number) => void;
}
export default function RecipeCard({ recipe, onRecipeEdit}: Props) {
    const imgpath = "/images/recipe-images/recipe_";
    const apiurl = import.meta.env.VITE_API_URL;
    const useUserStore = getUserStore(apiurl);
    const isLoggedIn = useUserStore(state => state.isLoggedIn);


    return (
        <>
            <div className="card" style={{ display: 'flex', flexDirection: 'column', width: '100%' }}>
                <img src={`${imgpath}${recipe.recipeName.toLowerCase().replace(/ /g, "_")}.jpg`}
                    alt={`${recipe.recipeName.replace(/ /g, "_").toLowerCase()}.jpg`} className="card-img-top"
                    style={{ width: '100%', height: '200px', objectFit: 'cover' }}
                    onError={(event) => (event.currentTarget.src = `${imgpath}default.jpg`)} />
                <div className="card-body" style={{ padding: '1rem' }}>
                    <h5 className="card-title">{recipe.recipeName}</h5>
                </div>
                <div className="card-footer">
                    {
                        isLoggedIn ? (
                            <div>
                            <button className=" btn btn-primary" onClick={()=> onRecipeEdit(recipe.recipeId)}> Edit</button>
                            </div>
                        ) 
                        :null
                    }

                </div>
                
            </div>
        </>
    )
}

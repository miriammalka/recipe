import { IRecipe } from "./DataInterfaces"

interface Props {
    recipe: IRecipe
}
export default function RecipeCard({ recipe }: Props) {

    return (
        <>
            <div className="card" style={{ display: 'flex', flexDirection: 'column', width: '100%' }}>
                <img src={`/images/recipe-images/recipe_${recipe.recipeName.toLowerCase().replace(/ /g, "_")}.jpg`}
                    alt={`recipe_${recipe.recipeName.replace(/ /g, "_").toLowerCase()}.jpg`} className="card-img-top"
                    style={{ width: '100%', height: '200px', objectFit: 'cover' }} />
                <div className="card-body" style={{ padding: '1rem' }}>
                    <h5 className="card-title">{recipe.recipeName}</h5>
                </div>
            </div>
        </>
    )
}

//style={{ width: 200, height: 200, objectFit: "cover" }}
import Sidebar from './Sidebar'
import MainScreen from './MainScreen'
import { useState } from 'react'
import { RecipeEdit } from './RecipeEdit'
import { blankRecipe } from './DataUtility'
import { IRecipe } from './DataInterfaces'

export default function Recipes() {
  const [selectedCuisineId, setSelectedCuisineId] = useState(0);
  const [isRecipeEdit, setIsRecipeEdit] = useState(false);
  const [recipeForEdit, setRecipeForEdit] = useState(blankRecipe);

  const handleCuisineSelected = (cuisineId: number) => {
    setSelectedCuisineId(cuisineId);
    setIsRecipeEdit(false);
  }

  const handleRecipeSelectedForEdit = (recipe: IRecipe) => {
    setRecipeForEdit(recipe);
    setIsRecipeEdit(true);
    console.log(recipe);
  }
  return (
    <>
      <div className="container">
        <div className="row mt-4">
          <div className="col-3">
            <Sidebar onCuisineSelected={handleCuisineSelected} />
          </div>
          <div className="col-9">
            <button onClick={() => handleRecipeSelectedForEdit(blankRecipe)} className="btn btn-outline-primary mb-4" style={{ alignContent: "center" }}>New Recipe</button>
            {isRecipeEdit ? <RecipeEdit recipe={recipeForEdit} /> : <MainScreen cuisineId={selectedCuisineId} onRecipeSelectedForEdit={handleRecipeSelectedForEdit} />}
          </div>
        </div>
      </div>
    </>
  )
}

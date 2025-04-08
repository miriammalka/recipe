import { useEffect, useState } from "react"
import { FieldValues, useForm } from "react-hook-form";
import { ICuisine, IInstruction, IRecipe, IRecipeIngredient, IUsers } from "./DataInterfaces";
import { blankRecipe, cloneRecipe, deleteRecipe, fetchCuisines, fetchUsers, postRecipe } from "./DataUtility";
import { getUserStore } from "@miriammalka/reactutils";
import { RecipeIngredientGrid } from "./RecipeIngredientGrid";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { InstructionGrid } from "./InstructionGrid";

interface Props {
    recipe: IRecipe
    onCancel: () => void;
    onRecipeUpdate: (recipe: IRecipe) => void;
    onRecipeDelete: (deletedrecipeid: number) => void;
    onRecipeClone: (recipe: IRecipe) => void;
}
export function RecipeEdit({ recipe, onCancel, onRecipeDelete, onRecipeUpdate, onRecipeClone }: Props) {
    const { register, handleSubmit, reset } = useForm({ defaultValues: recipe });
    const [cuisines, setCuisines] = useState<ICuisine[]>([]);
    const [errorMessage, setErrorMessage] = useState("");
    const [users, setUsers] = useState<IUsers[]>([]);

    const apiurl = import.meta.env.VITE_API_URL;
    const useUserStore = getUserStore(apiurl);
    const rolerank = useUserStore((state) => state.roleRank);


    useEffect(() => {
        const fetchCuisineData = async () => {
            const cuisinedata = await fetchCuisines();
            setCuisines(cuisinedata);
            reset(recipe);
        };
        fetchCuisineData();
    }
        , []);


    useEffect(() => {
        const fetchUsersData = async () => {
            const usersdata = await fetchUsers();
            setUsers(usersdata);
            reset(recipe);
        };
        fetchUsersData();
    }
        , []);

    //I'm not sure what this function does
    useEffect(() => {
        reset(recipe);
    },
        [recipe, reset]);

    const submitForm = async (data: FieldValues) => {
        const transformedData = {
            ...data,
            datePublished: data.datePublished === "" ? null : data.datePublished,
            dateArchived: data.dateArchived === "" ? null : data.dateArchived,
            vegan: !!data.vegan
        };
        try {
            setErrorMessage("");
            const response = await postRecipe(transformedData);
            setErrorMessage(response.errorMessage);
            if (!response.errorMessage) {
                onRecipeUpdate(response);
                toast.success("Recipe saved successfully!");
            }
            reset(response);
        }
        catch (error: unknown) {
            if (error instanceof Error) {
                setErrorMessage(error.message);
            }
            else {
                setErrorMessage("error occured");
            }
        }
    };

    const handleDelete = async () => {
        try {
            setErrorMessage("");
            const response = await deleteRecipe(recipe.recipeId);
            setErrorMessage(response.errorMessage);
            if (response.errorMessage === "") {
                onRecipeDelete(recipe.recipeId);
                reset(blankRecipe);
                toast.success("Recipe deleted successfully!");
                console.log(recipe, "deleted");
            }
        }
        catch (error: unknown) {
            if (error instanceof Error) {
                setErrorMessage(error.message);
            }
            else {
                setErrorMessage("Error Occured")
            }
        }

    }


    const handleCloneRecipe = async () => {
        console.log("clone recipe clicked");
        const transformedData = {
            ...recipe,
            recipeid: undefined,
            datePublished: recipe.datePublished === "" ? null : recipe.datePublished,
            dateArchived: recipe.dateArchived === "" ? null : recipe.dateArchived,
            vegan: !!recipe.vegan
        };
        try {
            setErrorMessage("");
            const response = await cloneRecipe(transformedData);
            setErrorMessage(response.errorMessage);

            if (!response.errorMessage) {
                console.log("cloned recipe name", response.recipeName)

                //const clonedRecipe = { ...response, recipeName: response.recipeName + " - Clone"};
                onRecipeClone(response);
                //setValue("recipeName", clonedRecipe.recipeName); // Explicitly set recipe name

                toast.success("Recipe cloned successfully!");
            }
            else {
                console.error("Clone Error:", response.errorMessage);
                setErrorMessage(response.errorMessage);
            }
            reset(response);
        }
        catch (error: unknown) {
            console.error("Clone Recipe API Error:", error);
            setErrorMessage(error instanceof Error ? error.message : "An error occurred");
        }
    }



    const handleRecipeIngredientChange = (value: IRecipeIngredient, fordelete: boolean) => {
        const updatedIngredients = fordelete
            ? recipe.recipeIngredientList.filter(ingredient => ingredient.recipeIngredientId !== value.recipeIngredientId)
            : recipe.recipeIngredientList.map(ingredient => ingredient.recipeIngredientId === value.recipeIngredientId ? value : ingredient);

        const updatedRecipe = {
            ...recipe,
            recipeIngredientList: updatedIngredients
        };
        onRecipeUpdate(updatedRecipe);
    };

    const handleInstructionChange = (value: IInstruction, fordelete: boolean) => {
        const updatedInstruction = fordelete ?
            recipe.instructionList.filter(instruction => instruction.instructionId !== value.instructionId) :
            recipe.instructionList.map(instruction => instruction.instructionId === value.instructionId ? value : instruction);

        const updatedRecipe = {
            ...recipe,
            instructionList: updatedInstruction
        };
        onRecipeUpdate(updatedRecipe)
    }


    return (
        <>
            <div className="bg-light mt-4 p-4">
                <ToastContainer />
                <div className="row">
                    <div className="col-12">
                        <h2 id="hmsg">{errorMessage}</h2>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12">
                        <form className="needs-validation" onSubmit={handleSubmit(submitForm)}>


                            <div className="mb-3">
                                <label htmlFor="recipeName" className="form-label">Recipe Name:</label>
                                <input type="text" id="recipeName" {...register("recipeName")} className="form-control" required />
                            </div>

                            <div className="mb-3">
                                <label htmlFor="cuisineId" className="form-label">Cuisine ID:</label>
                                <select id="cuisineId" {...register("cuisineId")} className="form-select">
                                    {cuisines.map(c => <option key={c.cuisineId} value={c.cuisineId}>{c.cuisineName}</option>)}
                                </select>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="usersId" className="form-label">Users ID:</label>
                                <select id="usersId" {...register("usersId")} className="form-select">
                                    {users.map(u => <option key={u.usersId} value={u.usersId}>{u.userName}</option>)}
                                </select>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="calories" className="form-label">Calories:</label>
                                <input type="number" id="calories" {...register("calories")} className="form-control" required />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="dateCreated" className="col-form-label">Date Created:</label>
                                <input type="date" {...register("dateCreated")} className="form-control" required />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="datePublished" className="form-label">Date Published:</label>
                                <input type="date" {...register("datePublished")} className="form-control" />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="dateArchived" className="form-label">Date Archived:</label>
                                <input type="date" {...register("dateArchived")} className="form-control" />
                            </div>

                            <div className="mb-3">
                                <label htmlFor="vegan" className="form-label">Vegan:</label>
                                <input type="checkbox" id="vegan" {...register("vegan")} className="form-check-input" />
                            </div>

                            <button type="submit" className="btn btn-primary m-2">Submit</button>
                            {rolerank >= 3 ? <button onClick={handleDelete} disabled={rolerank >= 3 ? false : true} type="button" id="btndelete" className="btn btn-danger m-2">Delete</button> : null}
                            <button onClick={onCancel} type="button" id="btncancel" className="btn btn-warning">Cancel</button>
                            <button onClick={handleCloneRecipe} className="btn btn-success m-2">Clone recipe</button>
                        </form>
                    </div>
                </div>
                <hr />
                <ul className="nav nav-tabs" id="myTab" role="tablist">
                    <li className="nav-item" role="presentation">
                        <button className="nav-link active" id="recipe-ingredients-tab" data-bs-toggle="tab"
                            data-bs-target="#recipe-ingredients" aria-selected="true">Recipe Ingredients</button>
                    </li>
                    <li className="nav-item" role="presentation">
                        <button className="nav-link" id="instruction-tab" data-bs-toggle="tab" data-bs-target="#instruction"
                            aria-selected="true">Instructions</button>
                    </li>
                </ul>
                <div className="tab-content" id="myTabContent">
                    <div className="tab-pane fade show active" id="recipe-ingredients" role="tabpanel" aria-labelledby="recipe-ingredients-tab">
                        <div className="row">
                            <RecipeIngredientGrid recipe={recipe} onChanged={handleRecipeIngredientChange} />
                        </div>
                    </div>
                    <div className="tab-pane fade" id="instruction" role="tabpanel" aria-labelledby="instruction-tab">
                        <div className="row">
                            <InstructionGrid recipe={recipe} onChanged={handleInstructionChange} />
                        </div>
                    </div>
                </div>
            </div>
        </>
    )

}



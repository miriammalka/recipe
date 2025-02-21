import { useEffect, useState } from "react"
import { FieldValues, useForm } from "react-hook-form";
import { ICuisine, IRecipe, IUsers } from "./DataInterfaces";
import { blankRecipe, deleteRecipe, fetchCuisines, fetchUsers, postRecipe } from "./DataUtility";
import { getUserStore } from "@miriammalka/reactutils";

interface Props {
    recipe: IRecipe
}
export function RecipeEdit({ recipe }: Props) {
    const [errorMessage, setErrorMessage] = useState("");
    const { register, handleSubmit, reset } = useForm({ defaultValues: recipe });
    const [cuisines, setCuisines] = useState<ICuisine[]>([]);
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
        try {
            const response = await postRecipe(data);
            setErrorMessage(response.errorMessage);
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
    }


    const handleDelete = async () => {
        try {
            const response = await deleteRecipe(recipe.recipeId);
            setErrorMessage(response.errorMessage);
            if (response.errorMessage == "") {
                reset(blankRecipe);
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
    //need to work on binding the date
    return (
        <>
            <div className="bg-light mt-4 p-4">
                <div className="row">
                    <div className="col-12">
                        <h2 id="hmsg">{errorMessage}</h2>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12">
                        <form className="needs-validation" onSubmit={handleSubmit(submitForm)}>
                            <div className="mb-3">
                                <label htmlFor="recipeId" className="form-label" style={{ display: "none" }}>Recipe ID:</label>
                                <input type="number" id="recipeId" {...register("recipeId")} className="form-control" style={{ display: "none" }} required />
                            </div>

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
                                <select className="form-select" id="vegan" {...register("vegan")}>
                                    <option value="true">true</option>
                                    <option value="false">false</option>
                                </select>
                            </div>
                            <button type="submit" className="btn btn-primary">Submit</button>
                            {rolerank >= 3 ? <button onClick={handleDelete} disabled={rolerank >= 3 ? false : true} type="button" id="btndelete" className="btn btn-danger">Delete</button> : null}

                        </form>
                    </div>
                </div>
            </div>
        </>
    )

}

// const convertToISODate = (dateParam: any) => {
//     const date = new Date(dateParam);
//     const formattedDate = date.toISOString().split('T')[0];
//     return formattedDate;

// }

// const formattedDateCreated = recipe.dateCreated ? convertToISODate(recipe.dateCreated) : "";
// const formattedDatePublished = recipe.datePublished ? convertToISODate(recipe.datePublished) : "";
// const formattedDateArchived = recipe.dateArchived ? convertToISODate(recipe.dateArchived) : "";

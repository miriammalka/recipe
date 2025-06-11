import { useEffect, useState } from "react"
import { FieldValues, useForm } from "react-hook-form";
import { ICookbook, ICookbookRecipe, IUsers } from "./DataInterfaces";
import { postCookbook, deleteCookbook, fetchUsers, blankCookbook } from "./DataUtility";
import { getUserStore } from "@miriammalka/reactutils";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { CookbookRecipeGrid } from "./CookbookRecipeGrid";




interface Props {
    cookbook: ICookbook;
    onCancel: () => void;
    onCookbookUpdate: (cookbook: ICookbook) => void;
    onCookbookDelete: (deletedcookbookid: number) => void;
    ButtonsDisabled: boolean;
    setButtonsDisabled: (value: boolean) => void;
}

export default function CookbookEdit({ cookbook, onCancel, onCookbookDelete, onCookbookUpdate, ButtonsDisabled, setButtonsDisabled }: Props) {
    const { register, handleSubmit, reset } = useForm<ICookbook>({ defaultValues: cookbook });
    const [users, setUsers] = useState<IUsers[]>([]);
    const [errorMessage, setErrorMessage] = useState("");


    const apiurl = import.meta.env.VITE_API_URL;
    const useUserStore = getUserStore(apiurl);
    const rolerank = useUserStore((state) => state.roleRank);




    useEffect(() => {
        const fetchUsersData = async () => {
            const usersdata = await fetchUsers();
            setUsers(usersdata);
            reset(cookbook);
        };
        fetchUsersData();
    }
        , []);

    //I'm not sure what this function does
    useEffect(() => {
        reset(cookbook);
    },
        [cookbook, reset]);

    const submitForm = async (data: FieldValues) => {
        const transformedData = {
            ...data,
            dateCreated: data.dateCreated === "" ? null : data.dateCreated,
        };
        try {
            setErrorMessage("");
            const response = await postCookbook(transformedData);
            if (response.errorMessage.includes("out of range")) {
                setErrorMessage("Price must be less than or equal to $99.99")
            }
            else {
                setErrorMessage(response.errorMessage);
            }

            if (!response.errorMessage) {
                onCookbookUpdate(response);
                setButtonsDisabled(false);
                toast.success("Cookbook saved successfully!");

            }
            reset(response);
        }
        catch (error: unknown) {
            if (error instanceof Error) {
                setErrorMessage(error.message);
            }
        }
    };

    const handleDelete = async () => {
        try {
            setErrorMessage("");
            const response = await deleteCookbook(cookbook.cookbookId);
            setErrorMessage(response.errorMessage);
            if (response.errorMessage === "") {
                onCookbookDelete(cookbook.cookbookId);
                reset(blankCookbook);
                toast.success("Cookbook deleted successfully!");
                console.log(cookbook, "deleted");
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

    const handleCookbookRecipeChange = (value: ICookbookRecipe, fordelete: boolean) => {
        const updatedCookbookRecipe = fordelete
            ? cookbook.cookbookRecipeList.filter(recipe => recipe.cookbookRecipeId !== value.cookbookRecipeId)
            : cookbook.cookbookRecipeList.map(recipe => recipe.cookbookRecipeId === value.cookbookRecipeId ? value : recipe);

        const updatedCookbook = {
            ...cookbook,
            cookbookRecipeList: updatedCookbookRecipe
        };
        onCookbookUpdate(updatedCookbook);
    };




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
                                <label htmlFor="cookbookName" className="form-label">Cookbook Name:</label>
                                <input type="text" id="cookbookName" {...register("cookbookName")} className="form-control" required />
                            </div>

                            <div className="mb-3">
                                <label htmlFor="usersId" className="form-label">User Name:</label>
                                <select id="usersId" {...register("usersId")} className="form-select">
                                    <option value=""></option>
                                    {users.map(u => <option key={u.usersId} value={u.usersId}>{u.userName}</option>)}
                                </select>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="dateCreated" className="col-form-label">Date Created:</label>
                                <input type="date" {...register("dateCreated")} className="form-control" />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="price" className="form-label" >Price:</label>
                                <input type="number" step="0.01" id="price" {...register("price")} className="form-control" required />
                            </div>

                            <div className="mb-3">
                                <label htmlFor="active" className="form-label">Active:</label>
                                <input type="checkbox" id="active" {...register("active")} className="form-check-input" />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="skillLevel" className="form-label">Skill Level:</label>
                                <select id="skillLevel" {...register("skillLevel")} className="form-select">
                                    <option value=""></option>
                                    <option value={1}>Beginner</option>
                                    <option value={2}>Intermediate</option>
                                    <option value={3}>Advanced</option>
                                </select>
                            </div>

                            <button type="submit" className="btn btn-primary m-2">Submit</button>
                            {rolerank >= 3 ? <button onClick={handleDelete} disabled={ButtonsDisabled} type="button" id="btndelete" className="btn btn-danger m-2">Delete</button> : null}
                            <button onClick={onCancel} type="button" id="btncancel" className="btn btn-warning">Cancel</button>
                        </form>
                    </div>
                </div>
                <hr />
                <ul className="nav nav-tabs" id="myTab" role="tablist">
                    <li className="nav-item" role="presentation">
                        <button className="nav-link active" id="cookbook-recipe-tab" data-bs-toggle="tab"
                            data-bs-target="#cookbook-recipe" aria-selected="true">Cookbook Recipes</button>
                    </li>

                </ul>
                <div className="tab-content" id="myTabContent">
                    <div className="tab-pane fade show active" id="cookbook-recipe" role="tabpanel" aria-labelledby="cookbook-recipe-tab">
                        <div className="row">
                            <CookbookRecipeGrid
                                cookbook={cookbook}
                                onChanged={handleCookbookRecipeChange}
                                ButtonsDisabled={ButtonsDisabled} />
                        </div>
                    </div>

                </div>
            </div>
        </>
    )

}



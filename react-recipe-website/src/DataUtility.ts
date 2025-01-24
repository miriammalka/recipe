import { FieldValues } from "react-hook-form";
import { IRecipe, ICuisine, IUsers } from "./DataInterfaces"
import { createAPI, getUserStore } from "@miriammalka/reactutils";

let baseurl = import.meta.env.VITE_API_URL;

function api(){
    const sessionkey = getUserStore(baseurl).getState().sessionKey;
    return createAPI(baseurl, sessionkey);
}


export async function fetchCuisines() {
    return await api().fetchData<ICuisine[]>("Cuisine");
}

export async function fetchRecipiesByCuisineId(cuisineId: number) {
    return await api().fetchData<IRecipe[]>(`Recipe/getbycuisineId/${cuisineId}`)
}

export async function fetchUsers() {
    return await api().fetchData<IUsers[]>("Recipe/users");
}

export async function postRecipe(form: FieldValues) {
    return api().postData<IRecipe>("recipe", form);
}

export async function deleteRecipe(recipeid: number) {
    return api().deleteData<IRecipe>(`Recipe?id=${recipeid}`);
}

export const blankRecipe: IRecipe = {
    recipeId: 0,
    cuisineName: "",
    cuisineId: 0,
    userName: "",
    usersId: 0,
    recipeName: "",
    calories: 0,
    dateCreated: (() => {
        const currentDate = new Date();
        currentDate.setHours(0, 0, 0, 0); // Set to midnight
        return currentDate;
    })(),
    datePublished: null,
    dateArchived: null,
    vegan: true,
    errorMessage: ""
}
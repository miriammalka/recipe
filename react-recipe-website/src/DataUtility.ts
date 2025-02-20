import { FieldValues } from "react-hook-form";
import { IRecipe, ICuisine, IUsers, IDashboard } from "./DataInterfaces"
import { createAPI, getUserStore } from "@miriammalka/reactutils";

let baseurl = import.meta.env.VITE_API_URL;

function api() {
    const sessionkey = getUserStore(baseurl).getState().sessionKey;
    return createAPI(baseurl, sessionkey);
}

function formatRecipeDates(recipe: IRecipe): IRecipe{
    return{
        ...recipe,
        dateCreated: formatDate(recipe.dateCreated),
        datePublished: formatDate(recipe.datePublished),
        dateArchived: formatDate(recipe.dateArchived)
    }
}

function formatDate(date: Date | string | null): string {
    if (!date) return "";
    const d = new Date(date);
    const month = ("0" + (d.getMonth() + 1)).slice(-2);
    const day = ("0" + d.getDate()).slice(-2);
    return `${d.getFullYear()}-${month}-${day}`;
}

export async function fetchDashboard() {
    return await api().fetchData<IDashboard[]>("App");
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
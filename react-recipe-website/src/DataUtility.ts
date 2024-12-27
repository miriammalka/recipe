import { FieldValues } from "react-hook-form";
import { IRecipe, ICuisine, IUsers } from "./DataInterfaces"

let baseurl = import.meta.env.VITE_API_URL;
//https://localhost:7070/api/
//https://recipeapimme.azurewebsites.net/api/

async function fetchData<T>(url: string): Promise<T> {
    url = baseurl + url;
    const response = await fetch(url);
    const data = await response.json();
    console.log(response);
    console.log(data);
    return data;
}

export async function fetchCuisines() {
    return await fetchData<ICuisine[]>("Cuisine");
}

export async function fetchRecipiesByCuisineId(cuisineId: number) {
    return await fetchData<IRecipe[]>(`Recipe/getbycuisineId/${cuisineId}`)
}

export async function fetchUsers() {
    return await fetchData<IUsers[]>("Recipe/users");
}

async function postData<T>(url: string, form: FieldValues): Promise<T> {
    url = baseurl + url;
    const response = await fetch(url, {
        method: "POST",
        body: JSON.stringify(form),
        headers: {
            "Content-Type": "application/json"
        }
    });
    const data = await response.json();
    return data;
}

async function deleteData<T>(url: string): Promise<T> {
    url = baseurl + url;
    const response = await fetch(url, {
        method: "DELETE"
    });
    console.log(response);
    const data = await response.json();
    console.log(data);
    return (data);
}

export async function postRecipe(form: FieldValues) {
    return postData<IRecipe>("recipe", form);
}

export async function deleteRecipe(recipeid: number) {
    return deleteData<IRecipe>(`Recipe?id=${recipeid}`);
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
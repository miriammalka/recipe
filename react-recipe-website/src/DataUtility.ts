import { IRecipe, ICuisine } from "./DataInterfaces"

const baseurl = "https://recipeapimme.azurewebsites.net/api/"
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

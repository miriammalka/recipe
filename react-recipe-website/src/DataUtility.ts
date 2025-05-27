import { FieldValues } from "react-hook-form";
import { IRecipe, ICuisine, IUsers, IDashboard, IIngredient, IRecipeIngredient, IMeal, ICookbook, IInstruction, ICookbookRecipe, ICourse, IMeasurementType } from "./DataInterfaces"
import { createAPI, getUserStore } from "@miriammalka/reactutils";

let baseurl = import.meta.env.VITE_API_URL;

function api() {
    const sessionkey = getUserStore(baseurl).getState().sessionKey;
    return createAPI(baseurl, sessionkey);
}

function formatRecipeDates(recipe: IRecipe): IRecipe {
    return {
        ...recipe,
        dateCreated: formatDate(recipe.dateCreated),
        datePublished: formatDate(recipe.datePublished),
        dateArchived: formatDate(recipe.dateArchived)
    };
}

function formatCookbookDates(cookbook: ICookbook): ICookbook {
    return {
        ...cookbook,
        dateCreated: formatDate(cookbook.dateCreated),

    };
}



export function formatDate(date: Date | string | null): string {
    // console.log('date received', date);
    if (!date) return "";
    const d = new Date(date);
    const month = ("0" + (d.getMonth() + 1)).slice(-2);
    const day = ("0" + d.getDate()).slice(-2);
    const returnValue = `${d.getFullYear()}-${month}-${day}`
    // console.log('formatted data', returnValue)
    return returnValue;
}



export async function fetchDashboard() {
    return await api().fetchData<IDashboard[]>("App");
}


export async function fetchCuisines() {
    return await api().fetchData<ICuisine[]>("Cuisine");
}

export async function postCuisine(form: FieldValues) {
    return await api().postData<ICuisine[]>("Cuisine", form);
}

export async function deleteCuisine(cuisine: ICuisine) {
    return api().deleteData(`Cuisine?id=${cuisine.cuisineId}`)
}

export async function fetchRecipiesByCuisineId(cuisineId: number) {
    const recipes = await api().fetchData<IRecipe[]>(`Recipe/getbycuisineId/${cuisineId}`)
    return recipes.map(formatRecipeDates);
}

export async function fetchRecipes() {
    const recipes = await api().fetchData<IRecipe[]>("CookbookRecipe/Recipes")
    return recipes.map(formatRecipeDates);
}

export async function postRecipe(form: FieldValues) {
    const recipe = await api().postData<IRecipe>("recipe", form);
    return formatRecipeDates(recipe);
}

export async function cloneRecipe(recipe: IRecipe) {
    const clonedRecipe =  await api().postData<IRecipe>("Recipe/Clone", recipe);
    return formatRecipeDates(clonedRecipe);
}

export async function deleteRecipe(recipeid: number) {
    const recipe = await api().deleteData<IRecipe>(`Recipe?id=${recipeid}`);
    return formatRecipeDates(recipe);
}

export async function fetchUsers() {
    return await api().fetchData<IUsers[]>("users");
}

export async function postUsers(form: FieldValues) {
    return await api().postData<IUsers[]>("Users", form);
}

export async function deleteUsers(user: IUsers) {
    return api().deleteData(`Users?id=${user.usersId}`)
}

export async function fetchIngredients() {
    return await api().fetchData<IIngredient[]>("recipeingredient/ingredients")
}

export async function deleteIngredient(ingredient: IIngredient) {
    return api().deleteData(`Ingredient?id=${ingredient.ingredientId}`)
}

export async function postIngredient(form: FieldValues) {
    return api().postData<IIngredient>("ingredient", form);
}


export async function postRecipeIngredient(form: FieldValues) {
    return api().postData<IRecipeIngredient>("recipeingredient", form);
}

export async function deleteRecipeIngredient(recipeingredient: IRecipeIngredient) {
    return api().deleteData(`recipeingredient?id=${recipeingredient.recipeIngredientId}`)
}

export async function postInstruction(form: FieldValues) {
    return api().postData<IInstruction>("instruction", form);
}

export async function deleteInstruction(instruction: IInstruction) {
    return api().deleteData(`instruction?id=${instruction.instructionId}`)
}

export async function fetchMeals() {
    return await api().fetchData<IMeal[]>("Meal");
}

export async function fetchCookbooks() {
    const cookbook = await api().fetchData<ICookbook[]>("Cookbook");
    return cookbook.map(formatCookbookDates);
}


export async function postCookbook(form: FieldValues) {
    const cookbook = await api().postData<ICookbook>("cookbook", form);
    return formatCookbookDates(cookbook);
}

export async function deleteCookbook(cookbookid: number) {
    const cookbook = await api().deleteData<ICookbook>(`cookbook?id=${cookbookid}`)
    return formatCookbookDates(cookbook);
}

export async function autoCreateCookbook(user: IUsers) {
    return await api().postData<ICookbook>("Cookbook/AutoCreateCookbook", user);
    // return formatCookbookDates(autoCreateCookbook);
}

export async function fetchRecipesByCookbookName(cookbookName: string) {
    return await api().fetchData<ICookbookRecipe[]>(`cookbookrecipe/getrecipesbycookbookname/${cookbookName}`)
    //return cookbookrecipes.map(formatCookbookRecipeDates);
}

export async function postCookbookRecipe(form: FieldValues) {
    return api().postData<ICookbookRecipe>("cookbookrecipe", form);
}

export async function deleteCookbookRecipe(cookbookrecipe: ICookbookRecipe) {
    return api().deleteData(`CookbookRecipe?id=${cookbookrecipe.cookbookRecipeId}`)
}

export async function fetchCourse() {
    return await api().fetchData<ICourse[]>("course");
}

export async function deleteCourse(course: ICourse) {
    return api().deleteData(`course?id=${course.courseId}`)
}

export async function postCourse(form: FieldValues) {
    return api().postData("course", form)
}

export async function fetchMeasureMentType() {
    return await api().fetchData<IMeasurementType[]>("MeasurementType");
}

export async function deleteMeasurementType(measurementType: IMeasurementType) {
    return api().deleteData(`MeasurementType?id=${measurementType.measurementTypeId}`)
}

export async function postMeasurementType(form: FieldValues) {
    return api().postData("measurementtype", form)
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
    errorMessage: "",
    recipeIngredientList: [] as IRecipeIngredient[],
    instructionList: [] as IInstruction[]
}

export const blankRecipeIngredient: IRecipeIngredient = {
    recipeIngredientId: 0,
    recipeId: 0,
    ingredientId: 0,
    measurementTypeId: 0,
    amount: 0,
    sequenceOrder: 0,
    errorMessage: ""
}

export const blankInstruction: IInstruction = {
    instructionId: 0,
    recipeId: 0,
    instruction: "",
    sequenceOrder: 0,
    errorMessage: ""
}

export const blankCookbook: ICookbook = {
    cookbookId: 0,
    cookbookName: "",
    price: 0,
    active: false,
    usersId: 0,
    skillLevel: 0,
    skillLevelString: "",
    dateCreated: formatDate(new Date()),

    errorMessage: "",
    cookbookRecipeList: [] as ICookbookRecipe[]
}

export const blankCookbookRecipe: ICookbookRecipe = {
    cookbookRecipeId: 0,
    cookbookId: 0,
    recipeId: 0,
    sequence: 0,
    errorMessage: ""
}

export const blankCourse: ICourse = {
    courseId: 0,
    courseName: "",
    sequenceOrder: 0,
    errorMessage: ""
}

export const blankMeasurementType: IMeasurementType = {
    measurementTypeId: 0,
    measurementType: "",
    errorMessage: ""
}

export const blankIngredient: IIngredient = {
    ingredientId: 0,
    ingredientName: "",
    errorMessage: ""
}

export const blankCuisine: ICuisine = {
    cuisineId: 0,
    cuisineName: "",
    errorMessage: ""
}

export const blankUsers: IUsers = {
    usersId: 0,
    firstName: "",
    lastName: "",
    userName: "",
    errorMessage: ""
}



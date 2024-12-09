export interface IRecipe {
    recipeId: number,
    cuisineName: string,
    cuisineId: number,
    userName: string,
    usersId: number,
    recipeName: string,
    calories: number,
    dateCreated: Date,
    datePublished: Date | null,
    dateArchived: Date | null,
    vegan: boolean,
    errorMessage: string
}

export interface ICuisine {
    cuisineId: number,
    cuisineName: string
}

export interface IUsers{
    usersId: number,
    firstName: string,
    lastName: string,
    userName: string
}
export interface IRecipe {
    recipeId: number,
    cuisineName: string,
    cuisineId: number,
    userName: string,
    usersId: number,
    recipeName: string,
    calories: number,
    dateCreated: Date | string,
    datePublished: Date | null | string,
    dateArchived: Date | null | string,
    vegan: boolean,
    errorMessage: string
}

export interface ICuisine {
    cuisineId: number,
    cuisineName: string
}

export interface IUsers {
    usersId: number,
    firstName: string,
    lastName: string,
    userName: string
}

export interface IDashboard {
    order: number,
    type: string,
    number: number
}
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
    vegan: boolean
}

export interface ICuisine {
    cuisineId: number,
    cuisineName: string
}
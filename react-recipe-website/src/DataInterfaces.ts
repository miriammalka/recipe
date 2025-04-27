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
    errorMessage: string,
    recipeIngredientList: IRecipeIngredient[],
    instructionList: IInstruction[]

}

export interface ICuisine {
    cuisineId: number,
    cuisineName: string,
    errorMessage: string
}

export interface IUsers {
    usersId: number,
    firstName: string,
    lastName: string,
    userName: string,
    errorMessage: string

}

export interface IDashboard {
    order: number,
    type: string,
    number: number
}

export interface IRecipeIngredient {
    recipeIngredientId: number,
    recipeId: number,
    ingredientId: number,
    measurementTypeId: number,
    amount: number,
    sequenceOrder: number,
    errorMessage: string
}

export interface IIngredient {
    ingredientId: number,
    ingredientName: string,
    errorMessage: string
}

export interface IInstruction {
    instructionId: number,
    recipeId: number,
    instruction: string,
    sequenceOrder: number,
    errorMessage: string
}

export interface IMeal {
    mealId: number,
    mealName: string,
    userName: string,
    dateCreated: Date,
    numCalories: number,
    numCourses: number,
    numRecipes: number,
    mealDescription: string,
    active: boolean
}

export interface ICookbook {
    cookbookId: number,
    cookbookName: string,
    usersId: number,
    price: number,
    dateCreated: Date | string,
    active: boolean,
    skillLevel: number,
    skillLevelDesc: string,
    cookbookRecipeList: ICookbookRecipe[],
    errorMessage: string
}

export interface ICookbookRecipe {
    cookbookRecipeId: number,
    cookbookId: number,
    recipeId: number,
    sequence: number,
    errorMessage: string
}

export interface ICourse {
    courseId: number,
    courseName: string,
    sequenceOrder: number,
    errorMessage: string
}

export interface IMeasurementType {
    measurementTypeId: number,
    measurementType: string,
    errorMessage: string
}


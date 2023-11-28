use RecipeDB
go 
--select concat('grant execute on ', r.Routine_Name, ' to reciperole')
--from INFORMATION_SCHEMA.ROUTINES r

grant execute on ShowTotalCaloriesPerMeal to reciperole
grant execute on FormatRecipe to reciperole
grant execute on UsersUpdate to reciperole
grant execute on UsersGet to reciperole
grant execute on UsersDelete to reciperole
grant execute on RecipeUpdate to reciperole
grant execute on RecipeIngredientUpdate to reciperole
grant execute on RecipeIngredientGet to reciperole
grant execute on RecipeIngredientDelete to reciperole
grant execute on RecipeGet to reciperole
grant execute on RecipeDelete to reciperole
grant execute on MeasurementTypeUpdate to reciperole
grant execute on MeasurementTypeGet to reciperole
grant execute on MeasurementTypeDelete to reciperole
grant execute on MealGet to reciperole
grant execute on InstructionUpdate to reciperole
grant execute on InstructionGet to reciperole
grant execute on InstructionDelete to reciperole
grant execute on IngredientUpdate to reciperole
grant execute on IngredientGet to reciperole
grant execute on IngredientDelete to reciperole
grant execute on CuisineUpdate to reciperole
grant execute on CuisineGet to reciperole
grant execute on CuisineDelete to reciperole
grant execute on CourseUpdate to reciperole
grant execute on CourseGet to reciperole
grant execute on CourseDelete to reciperole
grant execute on CookbookUpdate to reciperole
grant execute on CookbookRecipeUpdate to reciperole
grant execute on CookbookRecipeGet to reciperole
grant execute on CookbookRecipeDelete to reciperole
grant execute on CookbookGet to reciperole
grant execute on CookbookDelete to reciperole
grant execute on CloneRecipe to reciperole
grant execute on AutoCreateCookbook to reciperole
grant execute on DashboardGet to reciperole
--AF Amazing job!
use RecipeDB
go

create or alter function dbo.ShowTotalCaloriesPerMeal(@MealId int)
returns int
as
begin
	declare @value int = 0;

	select @value = sum(r.Calories)
	from meal m
	join mealcourse mc
	on m.MealId = mc.MealId
	join MealCourseRecipe mcr
	on mc.MealCourseId = mcr.MealCourseId
	join recipe r
	on mcr.RecipeId = r.RecipeId
	where m.MealId = @MealId

	return @value
end
go

select TotalCaloriesPerMeal = dbo.ShowTotalCaloriesPerMeal(m.MealId) ,*
from meal m
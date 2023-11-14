use RecipeDB
go

create or alter proc dbo.MealGet(
@MealId int = 0,
@All bit = 0,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @All = isnull(@All,0), @MealId = isnull(@MealId,0)

	select m.MealName, u.UserName, NumCalories = sum(r.Calories), NumCourses = count(distinct mc.CourseId), NumRecipes = count(distinct r.RecipeId)
	from meal m
	join users u
	on m.UsersId = u.UsersId
	join mealcourse mc
	on mc.MealId = m.MealId
	join mealcourserecipe mcr
	on mcr.mealcourseId = mc.MealCourseId
	--AF No need to join to recipe, you can get the count of distinct MealCourseRecipeId
	--MM I need to join it anyways to get the sum of calories in a meal
	--AF I see that you have a function for that already, so I would assume you would use it.  You don't need to to if you don't want, and then you can leave this as is
	join recipe r 
	on r.RecipeId = mcr.RecipeId
	where m.MealId = @MealId
	or @All = 1
	group by m.MealName, u.UserName
	order by m.MealName

	return @return
end
go

exec MealGet @All = 1
use RecipeDB
go

create or alter proc dbo.MealGet(
@MealId int = 0,
@All bit = 0,
@IncludeBlank bit = 0,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @All = isnull(@All,0), @MealId = isnull(@MealId,0)

	select m.MealId, m.MealName, u.UserName, u.UsersId, m.DateCreated, NumCalories = dbo.ShowTotalCaloriesPerMeal(m.MealId), NumCourses = count(distinct mc.CourseId), NumRecipes = count(distinct mcr.MealCourseRecipeId), m.MealDesc, m.Active
	from meal m
	join users u
	on m.UsersId = u.UsersId
	join mealcourse mc
	on mc.MealId = m.MealId
	join mealcourserecipe mcr
	on mcr.mealcourseId = mc.MealCourseId
	where m.MealId = @MealId
	or @All = 1
	group by m.MealName, u.UserName, m.MealId, m.DateCreated, m.MealDesc, m.Active, u.UsersId
	union select 0,'', '',0,'', 0,0,0, '',0
	where @IncludeBlank = 1
	order by m.MealName

	return @return
end
go

exec MealGet @All = 1

exec MealGet @MealId = 13
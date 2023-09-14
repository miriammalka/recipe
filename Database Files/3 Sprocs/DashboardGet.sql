create or alter proc dbo.DashboardGet(
@Message varchar(500) = '' output
)
as 
begin

	declare @return int = 0

	select 'order' = 0, 'Type' = 'Recipes', Number = count(r.RecipeId) from recipe r 
	union select 1, 'Meals', count(m.MealId) from Meal m
	union select 2, 'Cookbooks', count(c.CookbookId) from Cookbook c
	order by 'order'

	return @return

end
go

exec DashboardGet
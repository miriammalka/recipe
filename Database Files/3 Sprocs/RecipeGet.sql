create or alter procedure dbo.RecipeGet(@RecipeId int = 0, @All bit = 0, @RecipeName varchar(100) = '')
as
begin
	select @RecipeName = nullif(@RecipeName, '')
	select r.RecipeId, r.CuisineId, r.UserId, r.RecipeName, r.Calories, R.DateCreated, R.DatePublished, R.DateArchived, RecipeInSpecifiedFormat = dbo.ShowRecipeInSpecifiedFormat(r.RecipeId)
	from recipe r
	where r.RecipeId = @RecipeId
	or @All = 1
	or r.RecipeName like '%' + @RecipeName + '%'
end


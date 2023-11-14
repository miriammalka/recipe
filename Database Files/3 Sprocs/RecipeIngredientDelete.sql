use RecipeDB
go

create or alter procedure dbo.RecipeIngredientDelete(
@RecipeIngredientId int = 0,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0
	
	select @RecipeIngredientId = isnull(@RecipeIngredientId, 0)

--AF ONe delete statement should not be in  a SQL transaction

	delete recipeingredient where RecipeIngredientId = @RecipeIngredientId

	return @return
end
go

use RecipeDB
go

create or alter procedure dbo.CookbookRecipeDelete(
@CookbookRecipeId int = 0,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0
	
	select @CookbookRecipeId = isnull(@CookbookRecipeId,0)

--AF It's only useful to use a SQL transaction when running more than one SQL statement, a regular delete should be used here
--MM ok

	delete CookbookRecipe where CookbookRecipeId = @CookbookRecipeId

	return @return
end
go

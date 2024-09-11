use RecipeDB
go

create or alter proc dbo.CookbookRecipeGet(
@CookbookRecipeId int = 0,
@CookbookId int = 0, 
@CookbookName varchar(500) = '',
@All bit = 0,
@Message varchar(500) = '' output
)
as
begin
	
	declare @return int = 0

	select @All = isnull(@All,0), @CookbookRecipeId = isnull(@CookbookRecipeId,0), @CookbookId = isnull(@CookbookId,0), @CookbookName = isnull(@CookbookName, '')

	select cr.CookbookRecipeId, cr.CookbookId, cb.CookbookName, cr.RecipeId, cr.SequenceOrder, r.RecipeName, c.CuisineName, u.UserName, r.Calories, r.DateCreated, r.DatePublished, r.DateArchived, r.Vegan
	from cookbookrecipe cr
	join Cookbook cb
	on cb.CookbookId = cr.CookbookId
	join recipe r
	on r.RecipeId = cr.RecipeId
	join cuisine c
	on r.CuisineId = c.CuisineId
	join users u
	on u.UsersId = r.UsersId
	where @All = 1
	or cr.CookbookRecipeId = @CookbookRecipeId
	or cb.CookbookName = @CookbookName
	order by cr.Cookbookid, cr.SequenceOrder

	return @return
end
go

exec CookbookRecipeGet @All = 1
exec CookbookRecipeGet @CookbookName = 'Treats for Two'


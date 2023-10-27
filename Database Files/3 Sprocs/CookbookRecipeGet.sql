create or alter proc dbo.CookbookRecipeGet(
@CookbookRecipeId int = 0,
@CookbookId int = 0, 
@All bit = 0,
@Message varchar(500) = '' output
)
as
begin
	
	declare @return int = 0

	select @All = isnull(@All,0), @CookbookRecipeId = isnull(@CookbookRecipeId,0), @CookbookId = isnull(@CookbookId,0)

	select cr.CookbookRecipeId, cr.CookbookId, cr.RecipeId, cr.SequenceOrder
	from cookbook c
	join cookbookrecipe cr
	on c.CookbookId = cr.CookbookId
	join recipe r
	on r.RecipeId = cr.RecipeId
	where @All = 1
	or cr.CookbookId = @CookbookId
	order by c.Cookbookid, cr.SequenceOrder

	return @return
end
go

exec CookbookRecipeGet @All = 1


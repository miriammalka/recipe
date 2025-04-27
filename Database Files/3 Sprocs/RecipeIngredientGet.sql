use RecipeDB
go

create or alter procedure dbo.RecipeIngredientGet(
	@RecipeIngredientId int = 0,
	@RecipeId int = 0,
	@All bit = 0,
	@IncludeBlank bit = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @All = isnull(@All,0), @RecipeIngredientId = isnull(@RecipeIngredientId,0), @RecipeId = isnull(@RecipeId,0)

	select ri.RecipeIngredientId, ri.RecipeId, ri.IngredientId, ri.MeasurementTypeId, ri.Amount, ri.SequenceOrder
	from RecipeIngredient ri
	where ri.RecipeIngredientId = @RecipeIngredientId
	or @All = 1
	or ri.RecipeId = @RecipeId
	union select 0, 0,0,0,0,0
	where @IncludeBlank = 1
	order by ri.SequenceOrder

	return @return
end
go

exec RecipeIngredientGet @All = 1


--select *from recipe r
--join recipeingredient ri
--on r.recipeid = ri.recipeid
--join ingredient i
--on i.ingredientid = ri.ingredientid
--join instruction s
--on s.recipeid = r.recipeid
select * from ingredient
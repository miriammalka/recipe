use RecipeDB
go

create or alter proc dbo.IngredientGet(
@IngredientId int = 0,
@All bit = 0,
@IngredientName varchar(100) = '',
@IncludeBlank bit = 0,
@Message varchar(500) = '' output
)

as
begin

	declare @return int = 0

	select @All = isnull(@All,0), @IngredientId = isnull(@IngredientId, 0), @IncludeBlank = isnull(@IncludeBlank,0)
	
	select i.IngredientId, i.IngredientName
	from Ingredient i
	where i.IngredientId = @IngredientId
	or @All = 1
	or i.IngredientName like '%' + @IngredientName + '%'
	union select 0, ' '
	where @IncludeBlank = 1
	order by i.IngredientId

	return @return
end
go

exec IngredientGet @All = 1, @IncludeBlank = 1
exec IngredientGet @IngredientName = 's'


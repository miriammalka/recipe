use RecipeDB
go

create or alter procedure dbo.CuisineGet(
@CuisineId int = 0, 
@All bit = 0,
@IncludeBlank bit = 0,
@Message varchar(500) = ''  output
)
as
begin

	select @All = isnull(@All,0), @CuisineId = isnull(@CuisineId,0), @IncludeBlank = isnull(@IncludeBlank,0)

	select c.CuisineId, c.CuisineName
	from Cuisine c
	where c.CuisineId = @CuisineId
	or @All = 1
	union select 0,' '
	where @IncludeBlank = 1
	order by c.CuisineId
end
go

exec CuisineGet @All = 1, @IncludeBlank = 1
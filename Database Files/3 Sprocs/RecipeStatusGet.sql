create or alter proc dbo.RecipeStatusGet(
@RecipeId int,
@DateCreated date = '' output,
@DatePublished date = '' output,
@DateArchived date = '' output,
@Message varchar(500) = ''
)
as
begin
	declare @return int = 1

	select @DateCreated = nullif(@DateCreated, '')
	select @DateCreated = nullif(@DatePublished, '')
	select @DateCreated = nullif(@DateArchived, '')

	select r.DateCreated, r.DatePublished, r.DateArchived
	from recipe r
	where r.RecipeId = @RecipeId

	return @return
end
go

exec RecipeStatusGet @RecipeId = 319
exec RecipeStatusGet @RecipeId = 320
exec RecipeStatusGet @RecipeId = 321

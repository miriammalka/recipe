use RecipeDB
go

create or alter procedure dbo.RecipeGet(
@RecipeId int = 0, 
@RecipeName varchar(500) = '',
@All bit = 0, 
@IncludeBlank bit = 0,
@Message varchar(500) = '' output
)
as
begin

	select @All = isnull(@All,0), @RecipeId = isnull(@RecipeId,0), @IncludeBlank = isnull(@IncludeBlank,0)

	select r.RecipeId, r.CuisineId, r.UsersId, r.RecipeName, r.RecipeStatus, 'User' = concat(u.FirstName, ' ', u.LastName),r.Calories, 
	'Num Ingredients' = count(ri.RecipeIngredientId), r.Picture,	
	r.DateCreated, r.DatePublished, r.DateArchived , isequence = case r.recipestatus
		 
		when 'published' then 1
		when  'draft' then 2
		when  'archived' then 3
		end
	from recipe r
	join users u
	on u.UsersId = r.UsersId
	left join recipeingredient ri
	on ri.RecipeId = r.RecipeId
	where r.RecipeId = @RecipeId
	or @All = 1
	or r.RecipeName like '%' + @RecipeName + '%'
	group by r.RecipeId, r.CuisineId, r.UsersId, r.RecipeName, r.RecipeStatus, concat(u.FirstName, ' ', u.LastName), r.Calories, r.DateCreated, 
	r.DatePublished, r.DateArchived, r.Picture
	union select 0, 0, 0, ' ', ' ', ' ', 0, 0, ' ' ,' ', ' ', ' ', 0
	where @IncludeBlank = 1
	order by isequence
end
go
exec RecipeGet @All = 1, @IncludeBlank = 1
exec RecipeGet @RecipeName = 'c'


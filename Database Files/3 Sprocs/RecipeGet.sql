--how do I program the @IncludeBlank?
create or alter procedure dbo.RecipeGet(
@RecipeId int = 0, 
@All bit = 0, 
@IncludeBlank bit = 0,
@Message varchar(500) = '' output
)
as
begin
	select r.RecipeId, r.CuisineId, r.UsersId, r.RecipeName, r.RecipeStatus, 'User' = concat(u.FirstName, ' ', u.LastName),r.Calories, 
	'Num Ingredients' = count(ri.RecipeIngredientId),	
	r.DateCreated, r.DatePublished, r.DateArchived 
	from recipe r
	join users u
	on u.UsersId = r.UsersId
	left join recipeingredient ri
	on ri.RecipeId = r.RecipeId
	where r.RecipeId = @RecipeId
	or @All = 1
	--union select 0, 0, 0, '', '', '', 0, 0, '', '', ''
	--where @IncludeBlank = 1
	group by r.RecipeId, r.CuisineId, r.UsersId, r.RecipeName, r.RecipeStatus, concat(u.FirstName, ' ', u.LastName), r.Calories, r.DateCreated, 
	r.DatePublished, r.DateArchived
	order by r.RecipeStatus desc
end
go
exec RecipeGet @All = 1



select * from RecipeIngredient where recipeid = 22
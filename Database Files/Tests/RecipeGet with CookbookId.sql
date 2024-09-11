--this file does not need to be used
--I just saved it because I did not want to lose the code for now
use RecipeDB
go
/*
create or alter procedure dbo.RecipeGet(
@RecipeId int = 0, 
@RecipeName varchar(500) = '',
@CookbookId int = 0,
@All bit = 0, 
@IncludeBlank bit = 0,
@Message varchar(500) = '' output
)
as
begin

	select @All = isnull(@All,0), @RecipeId = isnull(@RecipeId,0), @CookbookId = isnull(@CookbookId,0), @IncludeBlank = isnull(@IncludeBlank,0)

	select r.RecipeId, r.CuisineId,c.CuisineName, r.UsersId, r.RecipeName, r.RecipeStatus, u.UserName, 'User' = concat(u.FirstName, ' ', u.LastName), r.Calories, 
	'Num Ingredients' = count(ri.RecipeIngredientId), r.Picture,	
	r.DateCreated, 
	r. DatePublished,  
	r. DateArchived, 
	isequence = case r.recipestatus
		when 'published' then 1
		when  'draft' then 2
		when  'archived' then 3
		end,

		r.Vegan,
		cr.CookbookId
	from recipe r
	join users u
	on u.UsersId = r.UsersId
	join cuisine c
	on c.CuisineId = r.CuisineId
	left join CookbookRecipe cr
	on r.RecipeId = cr.RecipeId
	left join recipeingredient ri
	on ri.RecipeId = r.RecipeId
	where r.RecipeId = @RecipeId
	or @All = 1
	or (r.RecipeName like '%' + @RecipeName + '%' and @RecipeName != '')
	or cr.CookbookId = @CookbookId
	group by r.RecipeId, r.CuisineId, c.CuisineName, r.UsersId, r.RecipeName, r.RecipeStatus, u.UserName, concat(u.FirstName, ' ', u.LastName), r.Calories, r.DateCreated, 
	r.DatePublished, r.DateArchived, r.Picture, r.Vegan, cr.CookbookId
	union select 0, 0, '', 0, ' ', ' ','', ' ', 0, 0, ' ' ,' ', ' ', ' ', 0,0,0
	where @IncludeBlank = 1
	order by isequence
end
go
exec RecipeGet @All = 1, @IncludeBlank = 1
exec RecipeGet @RecipeName = 'c'
exec RecipeGet @CookbookId = 23
*/

select * from recipe r
join cookbookrecipe cr
on cr.RecipeId = r.RecipeId
where cr.CookbookId = 13
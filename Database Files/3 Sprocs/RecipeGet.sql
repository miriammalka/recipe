use RecipeDB
go
--this is without cookbookid

create or alter procedure dbo.RecipeGet(
@RecipeId int = 0, 
@RecipeName varchar(500) = '',
--@CookbookId int = 0,
@CuisineId int = 0,
@All bit = 0, 
@IncludeBlank bit = 0,
@Message varchar(500) = '' output
)
as
begin

	select @All = isnull(@All,0), @RecipeId = isnull(@RecipeId,0), @CuisineId = isnull(@CuisineId,0), @IncludeBlank = isnull(@IncludeBlank,0)

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

		r.Vegan 
	from recipe r
	join users u
	on u.UsersId = r.UsersId
	join cuisine c
	on c.CuisineId = r.CuisineId
	left join recipeingredient ri
	on ri.RecipeId = r.RecipeId
	where r.RecipeId = @RecipeId
	or r.CuisineId = @CuisineId
	or @All = 1
	or (r.RecipeName like '%' + @RecipeName + '%' and @RecipeName  != '')
	group by r.RecipeId, r.CuisineId, c.CuisineName, r.UsersId, r.RecipeName, r.RecipeStatus, u.UserName, concat(u.FirstName, ' ', u.LastName), r.Calories, r.DateCreated, 
	r.DatePublished, r.DateArchived, r.Picture, r.Vegan
	union select 0, 0, '', 0, ' ', ' ','', ' ', 0, 0, ' ' ,' ', ' ', ' ', 0,0
	where @IncludeBlank = 1
	order by isequence
end
go


exec RecipeGet @All = 1, @IncludeBlank = 1
exec RecipeGet @RecipeName = 'c'


select * from recipe r
join cookbookrecipe cr
on cr.RecipeId = r.RecipeId
where cr.CookbookId = 23

exec RecipeGet @CuisineId = 16
exec RecipeGet @All = 1



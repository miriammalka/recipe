create or alter proc dbo.CookbookGet(
@CookbookId int = 0,
@All bit = 0,
@Message varchar(500) = '' output
)
as
begin

	declare @return int = 0

	select c.Cookbookid, c.UsersId, c.CookbookName, Author = Concat(u.FirstName, ' ', u.LastName), NumRecipes = count(distinct cr.CookbookRecipeId), c.Price, c.DateCreated, c.Active
	from cookbook c
	left join cookbookrecipe cr
	on c.cookbookId = cr.cookbookId
	join users u
	on u.usersId = c.usersId
	where c.CookbookId = @CookbookId 
	or @All = 1
	group by c.CookbookId, c.CookbookName, Concat(u.FirstName, ' ', u.LastName), c.Price, c.DateCreated, c.UsersId, c.Active
	order by c.CookbookName 

	return @return
end
go

exec CookbookGet @All = 1
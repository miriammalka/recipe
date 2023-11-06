create or alter procedure dbo.AutoCreateCookbook(
@CookbookId int = null output,
@UsersId int,
@Message varchar(500) = '' output
)
as
begin
	
	declare @return int = 0, @Username varchar(100) = '', @NumRecipes int = 0

	select @Username = concat(u.FirstName, ' ', u.LastName) from Users u where @UsersId = u.UsersId 
	select @NumRecipes = count(r.RecipeId) from Recipe r where r.UsersId = @UsersId
		
	insert Cookbook(UsersId, CookbookName, Price, DateCreated, Active)
	select @UsersId, concat('Recipes by', ' ', @Username), @NumRecipes * 1.33, GetDate(), 1
	
	select @CookbookId = SCOPE_IDENTITY()

	insert CookbookRecipe(CookbookId, RecipeId, SequenceOrder )
	select @CookbookId, r.RecipeId, SequenceOrder = ROW_NUMBER() over (order by RecipeName)
	from recipe r
	where r.UsersId = @UsersId
	order by r.RecipeName

	return @return

end
go

declare @UsersId int

select top 1 @UsersId = u.UsersId from Users u
exec AutoCreateCookbook @UsersId = @UsersId

select c.CookbookId, u.UsersId, u.Username, c.cookbookname, c.price, r.recipename, cr.sequenceorder
from cookbook c
left join cookbookrecipe cr
on c.cookbookid = cr.cookbookid
left join recipe r
on r.recipeid = cr.recipeid
left join users u
on u.usersid = c.usersid
where c.UsersId = @usersid

select * from users u
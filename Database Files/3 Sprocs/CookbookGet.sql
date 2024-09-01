use RecipeDB
go

create or alter proc dbo.CookbookGet(
@CookbookId int = 0,
@All bit = 0,
@IncludeBlank bit = 0,
@Message varchar(500) = '' output
)
as
begin

	declare @return int = 0

	select @All = isnull(@All,0), @CookbookId = isnull(@CookbookId,0)

	select c.Cookbookid, c.UsersId, u.Username, c.CookbookName, Author = Concat(u.FirstName, ' ', u.LastName), NumRecipes = count(distinct cr.CookbookRecipeId), c.Price, c.DateCreated, c.Active, c.SkillLevel, c.SkillLevelDesc
	from users u
	join cookbook c
	on c.usersid = u.usersid
	left join cookbookrecipe cr
	on c.cookbookId = cr.cookbookId
	--AF It doesn't seem necessary to have a left join here, as all cookbooks must have a foreign key for userid, so the tables should always connect
	--MM I thought once you do a left join in the table, all subsequent joins need to be left joins.
	/* Af That is correct, but you can have a join and then a left join.  You can join to Users and then left join to CookbookRecipe.  It seems to me like switching the order
	will be fine, is there a reson you need to join to Users only after CookbookREcipe? */
	--MM No, I just joined to cookbook first because this is a CookbookGet sproc, but I can switch the order
	--AF You can still select from Cookbook first, I was just saying that you can join to Users before left joining to CookbookRecipe
	where c.CookbookId = @CookbookId 
	or @All = 1
	group by c.CookbookId, c.CookbookName, u.Username, Concat(u.FirstName, ' ', u.LastName), c.Price, c.DateCreated, c.UsersId, c.Active, c.SkillLevel, c.SkillLevelDesc
	union select 0, 0,'', '', '', 0, 0, '',0, 0, ''
	where @IncludeBlank = 1
	order by c.CookbookName 

	return @return
end
go

exec CookbookGet @All = 1, @IncludeBlank = 1
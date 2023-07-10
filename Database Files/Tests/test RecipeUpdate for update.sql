declare @Message varchar(500) = '', @return int, @CuisineId int, @UserId int, @RecipeId int,
@RecipeName varchar (100),
@Calories int,
@DateCreated datetime 

select top 1 
	@RecipeId = r.RecipeId,
	@CuisineId = r.CuisineId, 
	@UserId = r.UserId, 
	@RecipeName = RecipeName, 
	@Calories = Calories, 
	@DateCreated = DateCreated 
from recipe r

select @RecipeName = REVERSE(@RecipeName)

exec @return = RecipeUpdate
	@RecipeId = @RecipeId output,
	@CuisineId = @CuisineId, 
	@UserId = @UserId, 
	@RecipeName = @RecipeName, 
	@Calories = @Calories, 
	@DateCreated = @DateCreated, 
	@Message = @Message output

select @return, @Message, @RecipeId

select * from recipe r where r.RecipeId = @RecipeId
	
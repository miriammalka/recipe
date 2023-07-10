declare @Message varchar(500) = '', @return int, @CuisineId int, @UserId int, @RecipeId int, @DateCreated datetime

select top 1 @CuisineId = CuisineId from Cuisine
select top 1 @UserId = UserId from users
select @DateCreated = GETDATE()

exec @return = RecipeUpdate
	@RecipeId = @RecipeId output,
	@CuisineId = @CuisineId, 
	@UserId = @UserId, 
	@RecipeName = 'Pumpkin Pie', 
	@Calories = 200, 
	@DateCreated = @DateCreated,
	@Message = @Message output

select @return, @Message, @RecipeId, @DateCreated

select * from recipe where recipeid = @recipeid

delete recipe where recipeid = @RecipeId

select top 1 * from recipe order by 1 desc
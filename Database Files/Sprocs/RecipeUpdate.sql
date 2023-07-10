create or alter procedure dbo.RecipeUpdate(
@RecipeId int output,
@CuisineId int,
@UserId int,
@RecipeName varchar (100),
@Calories int,
@DateCreated datetime,
--@DatePublished datetime,
--@DateArchived datetime,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @RecipeId = isnull(@RecipeId, 0)
	if exists (select * from recipe r where r.RecipeName = @RecipeName)
		begin
			select @return = 1, @Message = 'Recipe name must be unique'
			goto finished
		end

	if @RecipeId = 0
		begin
			insert Recipe(CuisineId, UserId, RecipeName, Calories, DateCreated)
			values (@CuisineId, @UserId, @RecipeName, @Calories, @DateCreated) 
	
			select @RecipeId = SCOPE_IDENTITY()
		end

	else
	begin
		update Recipe
		set
		CuisineId = @CuisineId, 
		UserId = @UserId, 
		RecipeName = @RecipeName, 
		Calories = @Calories, 
		DateCreated = @DateCreated
  where RecipeId = @RecipeId
	end

	finished:
	return @return
end
go
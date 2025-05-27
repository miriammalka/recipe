use RecipeDB
go

create or alter procedure dbo.RecipeUpdate(
@RecipeId int = 0 output,
@CuisineId int = 0,
@UsersId int = 0,
@RecipeName varchar (100) = '',
@Calories int,
@DateCreated datetime output,
@DatePublished datetime,
@DateArchived datetime,
@Vegan bit = 0,
--@RecipeStatus varchar(25) output,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @RecipeId = isnull(@RecipeId, 0), @DateCreated = nullif(@DateCreated, ''),
	@DatePublished = nullif(@DatePublished,''), @DateArchived = nullif(@DateArchived, '')
	
	if exists (select * from recipe r where r.RecipeName = @RecipeName and @RecipeId = 0)
	begin
		select @return = 1, @Message = 'Recipe name must be unique'
		goto finished
	end

	if @RecipeId = 0
	begin
		select @DateCreated = isnull(@DateCreated,GetDate())--, @RecipeStatus = 'Draft'
	
		insert Recipe(CuisineId, UsersId, RecipeName, Calories, DateCreated, DatePublished, DateArchived, Vegan)
		values (@CuisineId, @UsersId, @RecipeName, @Calories, @DateCreated, @DatePublished, @DateArchived, @Vegan) 
	
		select @RecipeId = SCOPE_IDENTITY()
	end

	else
	begin
		update Recipe
		set
		CuisineId = @CuisineId, 
		UsersId = @UsersId, 
		RecipeName = @RecipeName, 
		Calories = @Calories, 
		DateCreated = @DateCreated,
		DatePublished = @DatePublished,
		DateArchived = @DateArchived,
		Vegan = @Vegan
	    where RecipeId = @RecipeId
	end

	finished:
	return @return
end
go

--test
--exec RecipeUpdate @UsersId = 1021, @CuisineId = 1021, @RecipeName = 'rainbow salad', @Calories = 100, @DateCreated = '', @DatePublished = '', @DateArchived = '', @Vegan = 0

--select * from users
--select * from cuisine
--select * from recipe
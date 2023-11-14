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
@RecipeStatus varchar(25) output,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @RecipeId = isnull(@RecipeId, 0), @CuisineId = isnull(@CuisineId, 0), @UsersId = isnull(@UsersId, 0), @DateCreated = isnull(@DateCreated, ''),
	@DatePublished = nullif(@DatePublished, ''), @DateArchived = nullif(@DateArchived, '')
	
	--AF If you are matching on @RecipeId = 0, you should give @RecipeId a default value of 0 just in case it doesn't come in at all
	if exists (select * from recipe r where r.RecipeName = @RecipeName and @RecipeId = 0)
	begin
		select @return = 1, @Message = 'Recipe name must be unique'
		goto finished
	end

	if @RecipeId = 0
	begin

		--AF It's more concise for this to be set in isnull()
		select @DateCreated = GETDATE(), @RecipeStatus = 'Draft'
		
		insert Recipe(CuisineId, UsersId, RecipeName, Calories, DateCreated, DatePublished, DateArchived)
		values (@CuisineId, @UsersId, @RecipeName, @Calories, @DateCreated, @DatePublished, @DateArchived) 
	
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
		DateArchived = @DateArchived
	    where RecipeId = @RecipeId
	end

	finished:
	return @return
end
go



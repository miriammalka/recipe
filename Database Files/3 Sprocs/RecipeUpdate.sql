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

	select @RecipeId = isnull(@RecipeId, 0), @CuisineId = isnull(@CuisineId, 0), @UsersId = isnull(@UsersId, 0), @DateCreated = nullif(@DateCreated, ''),
	@DatePublished = nullif(@DatePublished, ''), @DateArchived = nullif(@DateArchived, '')
	
	if exists (select * from recipe r where r.RecipeName = @RecipeName and @RecipeId = 0)
	begin
		select @return = 1, @Message = 'Recipe name must be unique'
		goto finished
	end

	if @CuisineId = 0
	begin
		select @return = 1, @Message = 'A recipe record must have a Cuisine.'
		goto finished
	end

	if @UsersId = 0
	begin
		select @return = 1, @Message = 'A recipe record must have a User.'
		goto finished
	end

	if @RecipeId = 0
	begin

		/*AF I see that you only want DateCreated to be set to getdate() for an insert, not an update.  When I commented here to move the code up and use isnull(),
		 I meant that you would just default DateCreated to getdate() if it's null.  Since you are not doing that, and it seems you want to keep the DateCreated null
		 for an update if a different value is not supplied, I wouldn't use isnull() above.  YOu can do nullif if @DateCreated is blank, like you have for the other dates
		  and then here set DateCreated to getdate() here if it's null*/

		select @DateCreated = isnull(@DateCreated,GetDate()), @RecipeStatus = 'Draft'
	
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



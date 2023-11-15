use RecipeDB
go

--Af It would be good to add  a default value for the below parameters
--MM can you explain why?
--Af Sorry, this comment was put here mistakenly
--MM can I leave the default values though?
create or alter proc dbo.CookbookRecipeUpdate(
@CookbookRecipeId int = 0 output,
@CookbookId int = 0,
@RecipeId int = 0,
@SequenceOrder int = 0,
@Message varchar(500) = '' output
)
as
begin
	
	declare @return int = 0

	select @CookbookRecipeId = isnull(@CookbookRecipeId, 0), @CookbookId = isnull(@CookbookId, 0), @RecipeId = isnull(@RecipeId,0), 
	@SequenceOrder = isnull(@SequenceOrder,0)

	if @CookbookRecipeId = 0
	begin
		insert CookbookRecipe (CookbookId, RecipeId, SequenceOrder)
		values(@CookbookId, @RecipeId, @SequenceOrder)

		select @CookbookRecipeId = SCOPE_IDENTITY()
	end
	else
	begin
		update CookbookRecipe
		set
			CookbookId = @CookbookId,
			RecipeId = @RecipeId,
			SequenceOrder = @SequenceOrder
		where CookbookRecipeId = @CookbookRecipeId
	end

	return @return

end
go

select * from cookbookrecipe

exec CookbookRecipeUpdate @CookbookId= 2,
@RecipeId = 12

select * from Recipe
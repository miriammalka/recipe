--Af It would be good to add  a default value for the below parameters
create or alter proc dbo.CookbookRecipeUpdate(
@CookbookRecipeId int  output,
@CookbookId int ,
@RecipeId int ,
@SequenceOrder int ,
@Message varchar(500) = '' output
)
as
begin
	
	declare @return int = 0

	--AF You are missing isnull() for @SequenceOrder
	select @CookbookRecipeId = isnull(@CookbookRecipeId, 0), @CookbookId = isnull(@CookbookId, 0), @RecipeId = isnull(@RecipeId,0)

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
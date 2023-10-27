create or alter proc dbo.IngredientDelete(
@IngredientId int,
@All bit = 0,
@Message varchar(500) = '' output
)
as
begin

	declare @return int = 0
	
	begin try
	begin tran

	--delete cbr
	--from cookbookrecipe cbr
	--join recipe r
	--on r.RecipeId = cbr.RecipeId
	--join RecipeIngredient ri
	--on ri.RecipeId = r.RecipeId
	--join Ingredient i
	--on i.IngredientId = ri.IngredientId
	--where i.IngredientId = @IngredientId

	--delete mcr
	--from MealCourseRecipe mcr
	--join Recipe r
	--on r.RecipeId = mcr.RecipeId
	--join RecipeIngredient ri
	--on ri.RecipeId = r.RecipeId
	--join Ingredient i
	--on i.IngredientId = ri.IngredientId
	--where i.IngredientId = @IngredientId

	delete ri
	from RecipeIngredient ri
	join Ingredient i
	on ri.IngredientId = i.IngredientId
	where i.IngredientId = @IngredientId

	--delete r
	--from recipe r
	--join RecipeIngredient ri
	--on ri.RecipeId = r.RecipeId
	--join Ingredient i
	--on i.IngredientId = ri.IngredientId
	--where i.IngredientId = @IngredientId

	delete i
	from Ingredient i
	where i.IngredientId = @IngredientId

	commit
	end try
	begin catch
		rollback;
		throw
	end catch
	
	return @return

end
go

--exec IngredientDelete @IngredientId = 991

--select * from Ingredient
create or alter proc dbo.CuisineDelete(
@CuisineId int = 0,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @CuisineId = isnull(@CuisineId, 0)

	begin try
	begin tran

		delete cr 
		from CookbookRecipe cr 
		join Recipe r 
		on r.RecipeId = cr.RecipeId 
		--AF You don't need to join to cuisine, Recipe has CuisineId
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where c.CuisineId = @CuisineId

		delete mcr 
		from MealcourseRecipe mcr 
		join Recipe r 
		on r.RecipeId = mcr.RecipeId 
		--AF You don't need to join to cuisine, Recipe has CuisineId
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where c.CuisineId = @CuisineId

		--AF Instructions are not dependent on cuisines, they should not be deleted
		delete s
		from Instruction s 
		join Recipe r 
		on r.RecipeId = s.RecipeId
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where c.CuisineId = @CuisineId

		--AF RecipeIngredients are not dependent on cuisines, they should not be deleted
		delete ri
		from RecipeIngredient ri 
		join recipe r 
		on r.RecipeId = ri.RecipeId
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where c.CuisineId = @CuisineId

		delete r
		from recipe r 
		--AF You don't need to join to cuisine, Recipe has CuisineId
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where c.CuisineId = @CuisineId
		
		delete c
		from Cuisine c
		where c.CuisineId = @CuisineId
		
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

	return @return
end
go

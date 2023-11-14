use RecipeDB
go

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
		where r.CuisineId = @CuisineId

		delete mcr 
		from MealcourseRecipe mcr 
		join Recipe r 
		on r.RecipeId = mcr.RecipeId 
		where r.CuisineId = @CuisineId

		--AF Instructions are not dependent on cuisines, they should not be deleted
		--MM I have to delete it because if I am deleting all the recipes that are related to the cuisine, recipeid is a foreign key in the instruction table, 
		--so the cuisine will not delete
		--AF You're right, you can keep this and the one below as is
		delete s
		from Instruction s 
		join Recipe r 
		on r.RecipeId = s.RecipeId
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where c.CuisineId = @CuisineId

		delete ri
		from RecipeIngredient ri 
		join recipe r 
		on r.RecipeId = ri.RecipeId
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where c.CuisineId = @CuisineId

		delete r
		from recipe r 
		where r.CuisineId = @CuisineId
		
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


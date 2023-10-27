--check if I'm doing this delete correctly
create or alter proc dbo.CuisineDelete(
@CuisineId int,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	begin try
	begin tran

		delete cr 
		from CookbookRecipe cr 
		join Recipe r 
		on r.RecipeId = cr.RecipeId 
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where r.CuisineId = @CuisineId

		delete mcr 
		from MealcourseRecipe mcr 
		join Recipe r 
		on r.RecipeId = mcr.RecipeId 
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where r.CuisineId = @CuisineId

		delete s
		from Instruction s 
		join Recipe r 
		on r.RecipeId = s.RecipeId
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where r.CuisineId = @CuisineId


		delete ri
		from RecipeIngredient ri 
		join recipe r 
		on r.RecipeId = ri.RecipeId
		join Cuisine c
		on c.CuisineId = r.CuisineId
		where r.CuisineId = @CuisineId

		delete r
		from recipe r 
		join Cuisine c
		on c.CuisineId = r.CuisineId
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

--tests

--exec CuisineDelete @CuisineId = 111
--select * from cuisine
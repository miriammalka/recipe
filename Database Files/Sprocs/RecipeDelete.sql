create or alter procedure dbo.RecipeDelete(@RecipeId int)
as
begin
	begin try
	--AF Formatting tip - it's good to indent all the code in the 'try' block, so that it's clear what is part of the 'try' block
	begin tran
		delete recipeingredient where RecipeId = @RecipeId
		delete instruction where RecipeId = @RecipeId
		delete recipe where RecipeId = @RecipeId
	commit
	end try
	begin catch
		rollback;
		throw
	end catch
end
go
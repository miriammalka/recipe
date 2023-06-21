create or alter procedure dbo.RecipeDelete(@RecipeId int)
as
begin
	begin try
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
create or alter procedure dbo.RecipeIngredientDelete(
@RecipeIngredientId int,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0
	

	begin try
		begin tran
		delete recipeingredient where RecipeIngredientId = @RecipeIngredientId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch


	return @return
end
go

exec RecipeIngredientDelete @RecipeIngredientId = 1085
select * from recipeingredient
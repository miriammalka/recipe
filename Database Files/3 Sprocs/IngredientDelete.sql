use RecipeDB
go

create or alter proc dbo.IngredientDelete(
@IngredientId int = 0,
@Message varchar(500) = '' output
)
as
begin

	declare @return int = 0

	select @IngredientId = isnull(@IngredientId,0)
	
	begin try
		begin tran

		delete ri
		from RecipeIngredient ri
		where ri.IngredientId = @IngredientId

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

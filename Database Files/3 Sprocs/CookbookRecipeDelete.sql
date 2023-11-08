create or alter procedure dbo.CookbookRecipeDelete(
@CookbookRecipeId int = 0,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0
	
	select @CookbookRecipeId = isnull(@CookbookRecipeId,0)

--AF It's only useful to use a SQL transaction when running more than one SQL statement, a regular delete should be used here
	begin try
		begin tran
		delete CookbookRecipe where CookbookRecipeId = @CookbookRecipeId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

	return @return
end
go

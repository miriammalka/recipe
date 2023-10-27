create or alter procedure dbo.CookbookRecipeDelete(
@CookbookRecipeId int,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0
	

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

exec CookbookRecipeDelete @CookbookRecipeId = 16
select * from CookbookRecipe
create or alter procedure dbo.CookbookDelete(
@CookbookId int,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	begin try
		begin tran
		delete cookbookrecipe where CookbookId = @CookbookId
		delete cookbook where CookbookId = @CookbookId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

	finished:
	return @return
end
go

exec CookbookDelete @CookbookId = 2

select * from cookbook
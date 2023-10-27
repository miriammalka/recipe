create or alter procedure dbo.CookbookUpdate(
@CookbookId int output,
@UsersId int,
@CookbookName varchar(500),
@Price int,
@DateCreated datetime output,
@Active bit,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @CookbookId = isnull(@CookbookId, 0)
		
	if exists (select * from Cookbook c where @Active = 0 and @Price > 0)
	begin
		select @return = 1, @Message = 'An inactive cookbook has to have a price of $0.'
		goto finished
	end

	if @CookbookId = 0
	begin
		
		if @DateCreated is null
		begin
			select @DateCreated = GETDATE()
		end

		insert Cookbook(UsersId, CookbookName, Price, DateCreated, Active)
		values (@UsersId, @CookbookName, @Price, @DateCreated, @Active) 
	
		select @CookbookId = SCOPE_IDENTITY()
	end

	else
	begin
		update Cookbook
		set
		UsersId = @UsersId,
		CookbookName = @CookbookName,
		Price = @Price,
		DateCreated = @DateCreated,
		Active = @Active
  where CookbookId = @CookbookId
	end

	finished:
	return @return
end
go

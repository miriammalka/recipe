--Af It would be good to add  a default value for the below parameters
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

--AF Add isnull() for the other parameters
	select @CookbookId = isnull(@CookbookId, 0), @UsersId = isnull(@UsersId,0)

	/*AF This is not checking the status of a specific cookbook and its price, it's checking if there are any cookbooks in the table that are inactive and have a price greater 
	than 0.  I'm not sure exactly what this is meant to do, but it seems it needs to be fixed, because whenever this case exists, this if statement will stop the update from 
	happening and go straight to 'finished', even if the user is trying to update or insert a cookbook that is active	*/
	if exists (select * from Cookbook c where @Active = 0 and @Price > 0)
	begin
		select @return = 1, @Message = 'An inactive cookbook has to have a price of $0.'
		goto finished
	end

	if @CookbookId = 0
	begin
		
		--AF It would be more concise to just use isnull() on the top of the page for this, instead of an if statement
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

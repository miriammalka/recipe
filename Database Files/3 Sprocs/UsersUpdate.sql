use RecipeDB
go

create or alter procedure dbo.UsersUpdate(
		@UsersId int  output,
		@FirstName varchar(100),
		@LastName varchar(100),
		@UserName varchar (100),
		@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @UsersId = isnull(@UsersId,0)
	
	if @UsersId = 0
	begin
		insert Users(FirstName, LastName, UserName)
		values(@FirstName, @LastName, @UserName)

		select @UsersId= scope_identity()
	end
	else
	begin
		update Users
		set	
			FirstName = @FirstName,
			LastName = @LastName,
			UserName = @UserName
		where UsersId = @UsersId
	end
	
	return @return
end
go
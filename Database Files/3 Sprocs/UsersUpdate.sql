use RecipeDB
go

create or alter procedure dbo.UsersUpdate(
		@UsersId int = 0 output,
		@FirstName varchar(100),
		@LastName varchar(100),
		@UserName varchar (100),
		@Password varchar(100) = '',
		@RoleId int = 0,
		@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @UsersId = isnull(@UsersId,0), @Password = isnull(@Password, 'password')
	if @RoleId is null or @RoleId = 0
	begin
		select top 1 @RoleId = RoleId
		from roles
		order by RoleId
	end
	
	if @UsersId <= 0
	begin
		insert Users(FirstName, LastName, UserName, Password, RoleId)
		values(@FirstName, @LastName, @UserName, @Password, @RoleId)

		select @UsersId= scope_identity()
	end
	else
	begin
		update Users
		set	
			FirstName = @FirstName,
			LastName = @LastName,
			UserName = @UserName,
			Password = @Password,
			RoleId = @RoleId
		where UsersId = @UsersId
	end
	
	return @return
end
go

--test
--exec UsersUpdate @FirstName = 'bbb', @LastName = 'nnn', @UserName = 'test123', @Password = 'password', @RoleId = 1
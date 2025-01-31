create or alter procedure dbo.UsersLogin(
	@username varchar(100),
	@password varchar(20),
	@message varchar(500) = '' output
)
as
begin
	declare @return int = 0, @usersId int
	select @message = ''
	select @usersId = u.usersId from users u where u.Username = @username and u.password = @password

	if isnull(@usersId, 0) > 0
	begin
		update Users
		set sessionkey = NEWID(), sessionkeyDate = GETDATE()
		where UsersId = @usersId

		select u.UsersId, u.RoleId, u.username, u.sessionkey, r.rolename, r.rolerank
		from users u
		join roles r
		on r.roleId = u.roleId
		where u.UsersId = @usersId
	end
	else
	begin
		select @return = 1, @message = 'invalid login'
	end

	return @return
end
go
grant execute on UsersLogin to reciperole

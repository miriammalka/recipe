create or alter procedure dbo.UsersLogout(
	@username varchar(100),
	@message varchar(500) = '' output
)
as
begin
	declare @return int = 0, @usersId int
	select @message = ''
	update Users
	set sessionkey = '', sessionkeyDate = null
	where username = @username

	return @return
end
go
grant execute on UsersLogout to reciperole
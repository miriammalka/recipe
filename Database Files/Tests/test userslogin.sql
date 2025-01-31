declare @message varchar(500), @return int
exec @return = UsersLogin @username = '', @password = '', @message = @message output 

select @return, @message

exec @return = UsersLogin @username = 'MGross123', @password = 'password', @message = @message output

select @return, @message
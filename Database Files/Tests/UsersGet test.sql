--unit tests on old version of UsersGet
exec UsersGet

exec UsersGet @All = 1

declare @Id int
select top 1 @Id = u.UsersId from Users u
exec UsersGet @UsersId = @Id

--tests on updated version of UsersGet
declare @message varchar(500), @return int, @sessionkey varchar(255)
select top 1 @sessionkey = sessionkey from users u where sessionkey != ''

exec @return = UsersGet @usersId = 0, @sessionkey = @sessionkey, @message = @message output

select @return, @message
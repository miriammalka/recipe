--unit tests
exec UsersGet

exec UsersGet @All = 1

exec UsersGet @UserName = ''
exec UsersGet @UserName = 'a'

declare @Id int
select top 1 @Id = u.UserId from Users u
exec UsersGet @UserId = @Id
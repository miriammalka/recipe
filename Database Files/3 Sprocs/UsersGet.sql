create or alter procedure dbo.UsersGet(
@UsersId int = 0, 
@All bit = 0,
@Message varchar(500) = ''  output
)
as 
begin
	select u.UsersId, u.FirstName, u.LastName, u.Username, Users = concat(u.FirstName, ' ', u.LastName)
	from Users u
	where u.UsersId = @UsersId
	or @All = 1
end
go

exec UsersGet @All = 1



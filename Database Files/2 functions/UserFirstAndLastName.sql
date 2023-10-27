create or alter function  dbo.UserFirstAndLastName(@UsersId int)
returns varchar(250)
as 
begin
	declare @value varchar(250) = ''

	select @value = concat(u.FirstName, ' ', u.LastName)
	from users u
	join Recipe r
	on r.UserId = u.UserId
	where u.UserId = @UsersId

	return @value
end
go

select UserFirstAndLastName = dbo.UserFirstAndLastName(u.UserId), u.* 
from Users u
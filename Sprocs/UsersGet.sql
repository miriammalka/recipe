create or alter procedure dbo.UsersGet(@UserId int = 0, @All bit = 0, @UserName varchar(100) = '')
as 
begin
	select @UserName = nullif(@UserName, '')
	select u.UserId, u.FirstName, u.LastName, u.Username
	from Users u
	where u.UserId = @UserId
	or @All = 1
	or u.Username like '%' + @UserName + '%'
end


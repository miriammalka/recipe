create or alter procedure dbo.UsersGet(
@UsersId int = 0, 
@All bit = 0,
@IncludeBlank bit = 0,
@Message varchar(500) = ''  output
)
as 
begin
	
	select @All = isnull(@All, 0), @UsersId = isnull(@UsersId,0), @IncludeBlank = isnull(@IncludeBlank,0)

	select u.UsersId, u.FirstName, u.LastName, u.Username, Users = concat(u.FirstName, ' ', u.LastName)
	from Users u
	where u.UsersId = @UsersId
	or @All = 1
	union select 0,'','','',''
	where @IncludeBlank = 1
	order by u.UsersId
end
go

exec UsersGet @All = 1, @IncludeBlank = 1



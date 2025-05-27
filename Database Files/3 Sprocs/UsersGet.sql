use RecipeDB
go

create or alter procedure dbo.UsersGet(
@UsersId int = 0, 
@sessionkey varchar(255) = '',
@All bit = 0,
@IncludeBlank bit = 0,
@Message varchar(500) = ''  output
)
as 
begin
	
	declare @return int = 0, @maxseconds int = 1200

	select @All = isnull(@All, 0), @UsersId = isnull(@UsersId,0), @IncludeBlank = isnull(@IncludeBlank,0)

	if isnull(@sessionkey, '') != ''
	begin
		select @UsersId = usersId from users u where u.sessionkey = @sessionkey

		if isnull(@usersId, 0) = 0
		begin
			goto exit_proc
		end


		if(select top 1 datediff(second, u.sessionkeyDate, Getdate()) from users u where u.usersId = @UsersId) > @maxseconds
		begin 
			update u set u.sessionkey = '', u.sessionkeyDate = null
			from users u where u.UsersId = @UsersId
		end

		else
		begin
		update u set u.sessionkeyDate = GETDATE()
		from users u where u.usersId = @UsersId
		end
	end

	exit_proc:

	select u.UsersId, r.roleId, u.FirstName, u.LastName, u.Username, Users = concat(u.FirstName, ' ', u.LastName), u.sessionkey, r.rolename, r.rolerank
	from Users u
	join roles r
	on r.roleId = u.roleId
	where u.UsersId = @UsersId
	or @All = 1
	or (u.sessionkey = @sessionkey and @sessionkey != '')
	union select 0, 0,' ',' ',' ',' ', ' ', ' ', 0
	where @IncludeBlank = 1
	order by u.UsersId

	return @return
end
go

grant execute on UsersGet to reciperole



exec UsersGet @All = 1, @IncludeBlank = 1

select * from users

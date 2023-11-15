use RecipeDB
go

create or alter procedure dbo.CookbookUpdate(
@CookbookId int = 0 output,
@UsersId int = 0,
@CookbookName varchar(500) = '',
@Price int = 0,
@DateCreated datetime = 0 output,
@Active bit = 0,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @CookbookId = isnull(@CookbookId, 0),  @CookbookName = isnull(@CookbookName, ''), @Price = isnull(@Price,0), 
	@DateCreated = nullif(@DateCreated,''), @Active = isnull(@Active,0)

		if @UsersId = 0
		begin
			select @return = 1, @Message = 'A Cookbook record must have a User.'
			goto finished
		end
	--MM I added this line of code below because the table had a constraint for this but it was not a user friendly message. I just updated the table so that not
	--the front end shows a user friendly message and I was able remove the "if exists" line of code
	--AF Great! I just had a question on the constraint, see in table file
	if @CookbookId = 0
	begin
		  --MM I switched @DateCreated above to be blank if it's null, but I did not do that for the other dates. Did you mean the same way I did it the RecipeUpdate sproc?
		--AF What you did is good, what you are doing above is setting @DateCreated to null if it comes in as blank.  That's good so that in the line below, if it came in as null
		-- or blank, it will now be set to getdate()
		begin
			select @DateCreated = isnull(@DateCreated, GETDATE())
		end

		insert Cookbook(UsersId, CookbookName, Price, DateCreated, Active)
		values (@UsersId, @CookbookName, @Price, @DateCreated, @Active) 
	
		select @CookbookId = SCOPE_IDENTITY()
	end

	else
	begin
		update Cookbook
		set
		UsersId = @UsersId,
		CookbookName = @CookbookName,
		Price = @Price,
		DateCreated = @DateCreated,
		Active = @Active
  		where CookbookId = @CookbookId
	end

	finished:
	return @return
end
go

--declare @Message varchar(100) 
--exec CookbookUpdate 
--@UsersId = 1,
--@CookbookName = 'my new cookbook',
--@Price = 2,
--@Active = 1,
--@Message = @Message output
--select @Message

select * from cookbook
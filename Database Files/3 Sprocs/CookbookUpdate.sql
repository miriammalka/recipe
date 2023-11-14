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

	select @CookbookId = isnull(@CookbookId, 0), @UsersId = isnull(@UsersId,0), @CookbookName = isnull(@CookbookName, ''), @Price = isnull(@Price,0), 
	@DateCreated = isnull(@DateCreated,0), @Active = isnull(@Active,0)

	--MM There is a rule that a cookbook that is active has to hae a price greater than 0. I just tried editing an existing cookbook that was active and did not run into a problem. 
	--Can you show me the problem you ran into?
	/*AF It's not that I actually ran into issues, I just saw this sql statement selecting all from cookbook.  I misread it, since you are selecting from cookbook, I looked
	at it and assumed you were matching up on columns in the table, my oversight.  Regardless, this if statement is not foolproof, because if there are no cookbooks in the table,
	even if @ACtive = 0 and @Price = 0, it won't go into this select statment.  Is there are a reason that you are selecting from cookbook?  To me, it seems like this if statement
	should just be if @Active = 0 and @Price > 0 */
	if exists (select * from Cookbook c where @Active = 0 and @Price > 0)
	begin
		select @return = 1, @Message = 'An inactive cookbook has to have a price of $0.'
		goto finished
	end

	if @CookbookId = 0
	begin
		
		/*AF I see that you only want DateCreated to be set to getdate() for an insert, not an update.  When I commented here to move the code up and use isnull(),
		 I meant that you would just default DateCreated to getdate() if it's null.  Since you are not doing that, and it seems you want to keep the DateCreated null
		 for an update if a different value is not supplied, I wouldn't use isnull() above.  YOu can do nullif if @DateCreated is blank, like you have for the other dates
		  and then here set DateCreated to getdate() here if it's null*/

		begin
			select @DateCreated = GETDATE()
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

declare @Message varchar(100) 
exec CookbookUpdate 
@UsersId = 1,
@CookbookName = 'my new cookbook',
@Price = 2,
@Active = 0,
@Message = @Message output
select @Message

select * from cookbook
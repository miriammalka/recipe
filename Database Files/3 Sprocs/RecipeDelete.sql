create or alter procedure dbo.RecipeDelete(
@RecipeId int = 0,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @RecipeId = isnull(@RecipeId, 0)

	if exists(select * from recipe r where r.RecipeId = @RecipeId and (r.RecipeStatus = 'published' or DATEDIFF(Day, r.DateArchived, getdate()) <= 30))
	begin
		select @return = 1, @Message = 'Cannot delete recipe that is published or is archived less than 30 days.'
		goto finished
	end

	begin try
		begin tran
		delete mealcourserecipe where RecipeId = @RecipeId
		delete recipeingredient where RecipeId = @RecipeId
		delete instruction where RecipeId = @RecipeId
		delete recipe where RecipeId = @RecipeId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

	finished:
	return @return
end
go

exec RecipeDelete @RecipeId = 1
select * from recipe
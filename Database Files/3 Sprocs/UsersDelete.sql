use RecipeDB
go

create or alter proc dbo.UsersDelete(
	@UsersId int = 0,
	@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @UsersId = isnull(@UsersId,0)

	begin try
		begin tran

		delete cr 
		from CookbookRecipe cr 
		join Cookbook cb 
		on cb.CookbookId = cr.CookbookId 
		join Recipe r 
		on r.RecipeId = cr.RecipeId 
		join Users u 
		on  u.UsersId = r.UsersId 
		or cb.UsersId = u.UsersId
		where u.UsersId = @UsersId

		delete cb 
		from Cookbook cb 
		where cb.UsersId = @UsersId

		delete mcr 
		from MealcourseRecipe mcr 
		join MealCourse mc 
		on mc.mealcourseid = mcr.MealCourseId 
		join Meal m 
		on m.MealId = mc.MealId 
		join Recipe r 
		on r.RecipeId = mcr.RecipeId 
		join Users u 
		on u.UsersId = m.UsersId 
		or u.UsersId = r.UsersId
		where u.UsersId = @UsersId 

		delete  mc 
		from MealCourse mc 
		join meal m 
		on m.MealId = mc.mealId
		--AF Meal has a column UserId, it's not necessary to join to Users, comment remains
		join Users u 
		on u.UsersId = m.UsersId
		where u.UsersId = @UsersId

		delete m
		from meal m 
		where m.UsersId = @UsersId

		delete s
		from Instruction s 
		join Recipe r 
		on r.RecipeId = s.RecipeId
		join Users u 
		on u.UsersId = r.UsersId
		where u.UsersId = @UsersId

		delete ri
		from RecipeIngredient ri 
		join recipe r 
		on r.RecipeId = ri.RecipeId
		where r.UsersId = @UsersId

		delete r
		from recipe r 
		where r.UsersId = @UsersId

		delete u
		from Users u 
		where u.UsersId = @UsersId
		
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

	return @return
end
go


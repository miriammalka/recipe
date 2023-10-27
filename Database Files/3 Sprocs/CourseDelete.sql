create or alter proc dbo.CourseDelete(
@CourseId int,
@All bit = 0,
@Message varchar(500) = '' output
)
as
begin

	declare @return int = 0
	
	begin try
	begin tran

	--delete cbr
	--from CookbookRecipe cbr
	--join recipe r
	--on cbr.RecipeId = r.RecipeId
	--join MealCourseRecipe mcr
	--on cbr.RecipeId = mcr.RecipeId
	--join MealCourse mc
	--on mc.MealCourseId = mcr.MealCourseId
	--join Course c 
	--on c.CourseId = mc.CourseId
	--where c.CourseId = @CourseId

	delete mcr
	from MealCourseRecipe mcr
	join MealCourse mc 
	on mc.MealCourseId = mcr.MealcourseId
	join Course c
	on c.CourseId = mc.CourseId
	where c.CourseId = @CourseId

	delete mc
	from MealCourse mc
	join Course c
	on c.CourseId = mc.CourseId
	where c.CourseId = @CourseId

	delete c
	from Course c
	where c.CourseId = @CourseId

	commit
	end try
	begin catch
		rollback;
		throw
	end catch
	
	return @return

end
go

--exec CourseDelete @CourseId = 89

--select * from Course
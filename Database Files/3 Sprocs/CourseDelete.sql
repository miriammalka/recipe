create or alter proc dbo.CourseDelete(
@CourseId int = 0,
@All bit = 0,
@Message varchar(500) = '' output
)
as
begin

	declare @return int = 0

	select @CourseId = isnull(@CourseId, 0)
	
	begin try
		begin tran

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

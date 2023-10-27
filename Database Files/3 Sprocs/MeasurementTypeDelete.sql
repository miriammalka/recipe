create or alter proc dbo.MeasurementTypeDelete(
@MeasurementTypeId int,
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
	--on r.RecipeId = cbr.CookbookRecipeId
	--join RecipeIngredient ri
	--on ri.RecipeId = r.RecipeId
	--join MeasurementType mt
	--on mt.MeasurementTypeId = ri.MeasurementTypeId
	--where mt.MeasurementTypeId = @MeasurementTypeId

	--delete mcr
	--from MealCourseRecipe mcr
	--join recipe r
	--on r.RecipeId = mcr.RecipeId
	--join RecipeIngredient ri
	--on ri.RecipeId = r.RecipeId
	--join MeasurementType mt
	--on mt.MeasurementTypeId = ri.MeasurementTypeId
	--where mt.MeasurementTypeId = @MeasurementTypeId

	delete ri
	from RecipeIngredient ri
	join MeasurementType mt
	on mt.MeasurementTypeId = ri.MeasurementTypeId
	where mt.MeasurementTypeId = @MeasurementTypeId

	--delete r
	--from recipe r
	--join RecipeIngredient ri
	--on r.RecipeId = ri.RecipeId
	--join MeasurementType mt
	--on mt.MeasurementTypeId = ri.MeasurementTypeId
	--where mt.MeasurementTypeId = @MeasurementTypeId

	delete mt
	from MeasurementType mt
	where mt.MeasurementTypeId = @MeasurementTypeId

	commit
	end try
	begin catch
		rollback;
		throw
	end catch
	
	return @return

end
go

--exec MeasurementTypeDelete @MeasurementTypeId = 200
--select * from MeasurementType

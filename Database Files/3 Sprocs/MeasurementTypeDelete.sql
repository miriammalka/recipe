use RecipeDB
go

create or alter proc dbo.MeasurementTypeDelete(
@MeasurementTypeId int = 0,
@All bit = 0,
@Message varchar(500) = '' output
)
as
begin

	declare @return int = 0

	select @All = isnull(@All,0), @MeasurementTypeId = isnull(@MeasurementTypeId,0)
	
	begin try
		begin tran

		delete ri
		from RecipeIngredient ri
		join MeasurementType mt
		on mt.MeasurementTypeId = ri.MeasurementTypeId
		where mt.MeasurementTypeId = @MeasurementTypeId

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


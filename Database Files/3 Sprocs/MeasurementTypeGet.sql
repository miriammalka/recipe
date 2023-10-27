create or alter proc dbo.MeasurementTypeGet(
@MeasurementTypeId int = 0,
@All bit = 0,
@Message varchar(500) = '' output
)

as
begin

	declare @return int = 0

	select @All = isnull(@All,0), @MeasurementTypeId = isnull(@MeasurementTypeId, 0)
	select i.MeasurementTypeId, i.MeasurementType
	from MeasurementType i
	where i.MeasurementTypeId = @MeasurementTypeId
	or @All = 1
	return @return
end
go

exec MeasurementTypeGet @All = 1

select * from MeasurementType

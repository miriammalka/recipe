--create or alter procedure dbo.CuisineGet(@CuisineId int = 0, @All bit = 0, @CuisineName varchar(50) = '')
--as
--begin
--	select @CuisineName = nullif(@CuisineName, '')
--	select c.CuisineId, c.CuisineName
--	from Cuisine c
--	where c.CuisineId = @CuisineId
--	or @All = 1
--	or c.CuisineName like '%' + @CuisineName + '%'
--end

create or alter procedure dbo.CuisineGet(
@CuisineId int = 0, 
@All bit = 0,
@Message varchar(500) = ''  output
)
as
begin
	select c.CuisineId, c.CuisineName
	from Cuisine c
	where c.CuisineId = @CuisineId
	or @All = 1
end
go
exec CuisineGet @All = 1
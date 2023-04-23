create or alter procedure dbo.CuisineGet(@CuisineId int = 0, @All bit = 0, @CuisineName varchar(50) = '')
as
begin
	select @CuisineName = nullif(@CuisineName, '')
	select c.CuisineId, c.CuisineName
	from Cuisine c
	where c.CuisineId = @CuisineId
	or @All = 1
	or c.CuisineName like '%' + @CuisineName + '%'
end



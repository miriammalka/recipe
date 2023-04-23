--unit tests
exec CuisineGet

exec CuisineGet @All = 1

exec CuisineGet @CuisineName = ''
exec CuisineGet @CuisineName = 'a'

declare @Id int
select top 1 @Id = c.CuisineId from Cuisine c
exec CuisineGet @CuisineId = @Id
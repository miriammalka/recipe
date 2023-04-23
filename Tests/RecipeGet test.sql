--unit tests
exec RecipeGet

exec RecipeGet @All = 1

exec RecipeGet @RecipeName = ''
exec RecipeGet @RecipeName = 'm'

declare @Id int
select top 1 @Id = r.RecipeId from recipe r
exec RecipeGet @RecipeId = @Id
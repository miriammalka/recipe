create or alter function dbo.ShowRecipeInSpecifiedFormat(@RecipeId int)
returns varchar(150)
as
begin
	declare @value varchar(150) = ''

	select @value = concat(r.RecipeName, ' ', '(', c.CuisineName, ') ', 'has ', count(distinct ri.RecipeIngredientId), ' ingredients and ', count(distinct i.InstructionId), ' steps.')
	from recipe r
	join cuisine c
	on r.CuisineId = c.CuisineId
	left join recipeingredient ri 
	on ri.RecipeId = r.RecipeId
	left join instruction i
	on i.RecipeId = r.RecipeId
	where r.RecipeId = @RecipeId
	group by r.RecipeName, c.CuisineName

	return @value
end
go

select RecipeInSpecifiedFormat = dbo.ShowRecipeInSpecifiedFormat(r.RecipeId) ,*
from recipe r
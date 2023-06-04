declare @RecipeId int

Select top 1 @RecipeId = r.RecipeId
from recipe r
join recipeingredient ri
on ri.recipeid = r.recipeid


exec RecipeDelete @RecipeId = @RecipeId

Select top 1 @RecipeId = r.RecipeId
from recipe r
join recipeingredient ri
on ri.recipeid = r.recipeid

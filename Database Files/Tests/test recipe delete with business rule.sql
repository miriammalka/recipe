use RecipeDB
go
declare @RecipeId int

select top 1 @RecipeId = r.RecipeId 
from recipe r
left join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
left join Instruction i
on r.RecipeId = i.RecipeId
left join MealCourseRecipe mcr
on r.RecipeId = mcr.RecipeId
left join CookbookRecipe cr
on r.RecipeId = cr.RecipeId
where mcr.MealCourseRecipeId is null
and cr.CookbookRecipeId is null
and (r.RecipeStatus = 'published' 
or DATEDIFF(Day, r.DateArchived, getdate()) <= 30)

select 'recipe', r.RecipeId, r.RecipeName from recipe r where r.RecipeId = @RecipeId
union select 'ingredient', ri.recipeingredientid, i.IngredientName from RecipeIngredient ri join Ingredient i on i.IngredientId = ri.IngredientId where ri.RecipeId = @RecipeId
union select 'instruction', s.Instructionid, s.Instruction from Instruction s where s.RecipeId = @RecipeId

declare @return int, @message varchar(500)
exec @return = RecipeDelete @RecipeId = @RecipeId, @message = @message output
select @return, @message

select 'recipe', r.RecipeId, r.RecipeName from recipe r where r.RecipeId = @RecipeId
union select 'ingredient', ri.recipeingredientid, i.IngredientName from RecipeIngredient ri join Ingredient i on i.IngredientId = ri.IngredientId where ri.RecipeId = @RecipeId
union select 'instruction', s.Instructionid, s.Instruction from Instruction s where s.RecipeId = @RecipeId

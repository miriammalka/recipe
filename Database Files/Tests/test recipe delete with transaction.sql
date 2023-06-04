declare @RecipeId int

select top 1 @RecipeId = r.RecipeId 
from recipe r
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join Instruction i
on r.RecipeId = i.RecipeId
left join MealCourseRecipe mcr
on r.RecipeId = mcr.RecipeId
left join CookbookRecipe cr
on r.RecipeId = cr.RecipeId
where mcr.MealCourseRecipeId is null
and cr.CookbookRecipeId is null

select 'recipe', r.RecipeId, r.RecipeName from recipe r where r.RecipeId = @RecipeId
union select 'ingredient', ri.recipeingredientid, i.IngredientName from RecipeIngredient ri join Ingredient i on i.IngredientId = ri.IngredientId where ri.RecipeId = @RecipeId
union select 'instruction', s.Instructionid, s.Instruction from Instruction s where s.RecipeId = @RecipeId

begin try
	begin tran
		delete RecipeIngredient where RecipeId = @RecipeId
		delete Instruction where RecipeId = @RecipeId
		delete Recipe where RecipeId = @RecipeId
	commit
end try
begin catch
	rollback;

select 'recipe', r.RecipeId, r.RecipeName from recipe r where r.RecipeId = @RecipeId
union select 'ingredient', ri.recipeingredientid, i.IngredientName from RecipeIngredient ri join Ingredient i on i.IngredientId = ri.IngredientId where ri.RecipeId = @RecipeId
union select 'instruction', s.Instructionid, s.Instruction from Instruction s where s.RecipeId = @RecipeId
;
	throw
end catch
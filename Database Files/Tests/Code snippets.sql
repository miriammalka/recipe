select r.RecipeName , ri.SequenceOrder, ri.Amount,  i.IngredientName
from recipeingredient ri
join recipe r
on r.recipeId = ri.recipeId
join ingredient i
on i.ingredientid = ri.ingredientid
for json auto

SELECT 
    (SELECT
        r.RecipeName , ri.SequenceOrder, ri.Amount,  i.IngredientName

    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
FROM
   recipeingredient ri
join recipe r
on r.recipeId = ri.recipeId
join ingredient i
on i.ingredientid = ri.ingredientid


SELECT

    r.RecipeName,

    ingredients = (
        SELECT
            i.IngredientName
            
        FROM ingredient i 
		join RecipeIngredient ri
		on ri.IngredientId = i.IngredientId
		where ri.Recipeid = r.recipeid
        FOR JSON PATH
    )
FROM recipe r
FOR JSON PATH, WITHOUT_ARRAY_WRAPPER

select r.recipename, i.instruction, i.sequenceorder
from recipe r
join Instruction i
on i.RecipeId = r.RecipeId
order by r.recipeid, i.instructionid
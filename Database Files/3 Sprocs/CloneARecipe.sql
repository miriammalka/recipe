create or alter proc dbo.CloneARecipe(
@RecipeId int = null output,
@BaseRecipeId int,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	insert Recipe(CuisineId, UsersId, RecipeName, Calories, DateCreated)
	select r.cuisineid, r.usersid, concat(r.RecipeName, ' - ', 'Clone'), r.Calories, GetDate() from recipe r where r.recipeid = @baserecipeid

	select @RecipeId = SCOPE_IDENTITY();

	insert RecipeIngredient(RecipeId, IngredientId, MeasurementTypeId, SequenceOrder, Amount)
	select @RecipeId, ri.IngredientId, ri.MeasurementTypeId, ri.SequenceOrder, ri.Amount
	from RecipeIngredient ri
	where ri.RecipeId = @BaseRecipeId

	--review this code
	insert Instruction(RecipeId, SequenceOrder, Instruction)
	select @RecipeId, i.SequenceOrder, i.Instruction
	from Instruction i
	where i.RecipeId = @BaseRecipeId

	return @return
end
go

declare
@RecipeId int = null,
@BaseRecipeId int,
@i int,
@m varchar(500)

select top 1 @BaseRecipeId = r.RecipeId from Recipe r order by r.RecipeId desc

exec @i = CloneARecipe
	@RecipeId = @RecipeId output,
	@BaseRecipeId = @BaseRecipeId,
	@Message = @m output

select @i, @m

select r.RecipeId, r.RecipeName, NumRecipeIngredientId = count(distinct ri.RecipeIngredientId), NumInstructionId = count( i.InstructionId)
from recipe r
left join RecipeIngredient ri
on r.RecipeId = ri.RecipeId
left join Instruction i
on i.RecipeId = r.RecipeId
where r.RecipeId in (@RecipeId, @BaseRecipeId)
group by r.RecipeId, r.RecipeName

use RecipeDB
go
select * from recipe
--select * from recipeingredient
--select * from instruction


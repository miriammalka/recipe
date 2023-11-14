use RecipeDB
go

create or alter procedure dbo.InstructionGet(
	@InstructionId int = 0,
	@RecipeId int = 0,
	@All bit = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @All = isnull(@All,0), @InstructionId = isnull(@InstructionId,0), @RecipeId = isnull(@RecipeId,0)

	select i.InstructionId, i.RecipeId, i.Instruction, i.SequenceOrder
	from Instruction i
	where i.InstructionId = @InstructionId
	or i.RecipeId = @RecipeId
	or @All = 1
	order by i.RecipeId, i.SequenceOrder

	return @return
end
go

exec InstructionGet @All = 1

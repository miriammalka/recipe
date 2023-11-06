create or alter proc dbo.InstructionUpdate(
@InstructionId int  output,
@RecipeId int ,
@Instruction varchar(500) = '',
@SequenceOrder int ,
@Message varchar(500) = '' output
)
as
begin
	
	declare @return int = 0

	select @InstructionId = isnull(@InstructionId, 0), @RecipeId = isnull(@RecipeId,0)

	if @InstructionId = 0
	begin
		insert Instruction (RecipeId, Instruction, SequenceOrder)
		values(@RecipeId, @Instruction, @SequenceOrder)

		select @InstructionId = SCOPE_IDENTITY()
	end
	else
	begin
		update Instruction
		set
			RecipeId = @RecipeId,
			Instruction = @Instruction,
			SequenceOrder = @SequenceOrder
		where InstructionId = @InstructionId
	end

	return @return

end
go
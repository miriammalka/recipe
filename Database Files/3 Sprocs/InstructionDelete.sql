use RecipeDB
go

create or alter procedure dbo.InstructionDelete(
@InstructionId int = 0,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @InstructionId = isnull(@InstructionId,0)

--Af SQL transactions are used when you are executing more than one SQL statement, this should just be a simple delete statement

	delete Instruction where InstructionId = @InstructionId

	return @return
end
go

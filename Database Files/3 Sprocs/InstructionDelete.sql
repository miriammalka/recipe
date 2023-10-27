create or alter procedure dbo.InstructionDelete(
@InstructionId int,
@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	begin try
		begin tran
		delete Instruction where InstructionId = @InstructionId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch


	return @return
end
go

exec InstructionDelete @InstructionId = 970
select * from Instruction
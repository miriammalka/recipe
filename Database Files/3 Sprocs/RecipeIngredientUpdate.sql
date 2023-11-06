create or alter proc dbo.RecipeIngredientUpdate(
@RecipeIngredientId int  output,
@RecipeId int ,
@IngredientId int ,
@MeasurementTypeId int ,
@Amount int ,
@SequenceOrder int ,
@Message varchar(500) = '' output
)
as
begin
	
	declare @return int = 0

	select @RecipeIngredientId = isnull(@RecipeIngredientId, 0), @RecipeId = isnull(@RecipeId, 0), @IngredientId = isnull(@IngredientId, 0)

	if @RecipeIngredientId = 0
	begin
		insert RecipeIngredient (RecipeId, IngredientId, MeasurementTypeId, Amount, SequenceOrder)
		values(@RecipeId, @IngredientId, @MeasurementTypeId, @Amount, @SequenceOrder)

		select @RecipeIngredientId = SCOPE_IDENTITY()
	end
	else
	begin
		update RecipeIngredient
		set
			RecipeId = @RecipeId,
			IngredientId = @IngredientId,
			MeasurementTypeId = @MeasurementTypeId,
			Amount = @Amount,
			SequenceOrder = @SequenceOrder
		where RecipeIngredientId = @RecipeIngredientId
	end

	return @return

end
go
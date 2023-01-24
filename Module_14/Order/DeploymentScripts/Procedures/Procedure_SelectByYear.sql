CREATE PROCEDURE [dbo].[SelectByYear]
	@year INT
AS
	SELECT [order_id]
			,[status]
			,[created_date]
			,[updated_date]
			,[product_id]
	FROM [dbo].[Orders]
	WHERE Year(created_date) = @year
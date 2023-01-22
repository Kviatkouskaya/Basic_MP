CREATE PROCEDURE [dbo].[SelectByMonth]
	@month INT
AS
	SELECT [order_id]
			,[status]
			,[created_date]
			,[updated_date]
			,[product_id]
	FROM [dbo].[Orders]
	WHERE MONTH(created_date) = @month
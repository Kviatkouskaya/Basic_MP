CREATE PROCEDURE [dbo].[SelectByMonth]
	@month INT
AS
	SELECT [order_id] AS OrderId
			,[status]
			,[created_date]
			,[updated_date]
			,[product_id] AS ProductId
	FROM [dbo].[Orders]
	WHERE MONTH(created_date) = @month
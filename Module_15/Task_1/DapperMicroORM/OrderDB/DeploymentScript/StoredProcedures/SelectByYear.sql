CREATE PROCEDURE [dbo].[SelectByYear]
	@year INT
AS
	SELECT [order_id] AS OrderId
			,[status]
			,[created_date]
			,[updated_date]
			,[product_id] AS ProductId
	FROM [dbo].[Orders]
	WHERE Year(created_date) = @year
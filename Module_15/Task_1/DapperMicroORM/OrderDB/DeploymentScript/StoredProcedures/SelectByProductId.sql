CREATE PROCEDURE [dbo].[SelectByProductId]
	@product_id INT
AS
	SELECT [order_id] AS OrderId
			,[status]
			,[created_date]
			,[updated_date]
			,[product_id] AS ProductId
	FROM [dbo].[Orders]
	WHERE product_id = @product_id
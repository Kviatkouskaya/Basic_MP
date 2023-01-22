CREATE PROCEDURE [dbo].[SelectByProductId]
	@product_id INT
AS
	SELECT [order_id]
			,[status]
			,[created_date]
			,[updated_date]
			,[product_id]
	FROM [dbo].[Orders]
	WHERE product_id = @product_id
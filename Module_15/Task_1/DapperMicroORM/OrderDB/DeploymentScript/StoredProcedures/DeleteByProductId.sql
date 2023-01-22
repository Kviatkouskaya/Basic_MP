CREATE PROCEDURE [dbo].[DeleteByProductId]
	@product_id INT
AS
	DELETE FROM [dbo].[Orders]
	WHERE product_id = @product_id
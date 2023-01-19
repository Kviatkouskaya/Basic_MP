CREATE PROCEDURE [dbo].[SelectByStatus]
	@status INT
AS
	SELECT [order_id]
			,[status]
			,[created_date]
			,[updated_date]
			,[product_id]
	FROM [dbo].[Orders]
	WHERE status = @status

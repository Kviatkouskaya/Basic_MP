CREATE PROCEDURE [dbo].[DeleteByMonth]
	@month INT
AS
	DELETE FROM [dbo].[Orders]
	WHERE MONTH(created_date) = @month
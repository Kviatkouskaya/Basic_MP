CREATE PROCEDURE [dbo].[DeleteByYear]
	@year INT
AS
	DELETE FROM [dbo].[Orders]
	WHERE Year(created_date) = @year
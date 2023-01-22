CREATE PROCEDURE [dbo].[DeleteByStatus]
	@status INT
AS
	DELETE FROM [dbo].[Orders]
	WHERE status = @status
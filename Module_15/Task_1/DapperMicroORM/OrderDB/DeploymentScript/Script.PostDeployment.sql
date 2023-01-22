/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO
:r .\Insert_Data.sql

GO
:r .\StoredProcedures\SelectByStatus.sql

GO
:r .\StoredProcedures\SelectByProductId.sql

GO
:r .\StoredProcedures\SelectByMonth.sql

GO
:r .\StoredProcedures\SelectByYear.sql

GO
:r .\StoredProcedures\DeleteByStatus.sql

GO
:r .\StoredProcedures\DeleteByProductId.sql

GO
:r .\StoredProcedures\DeleteByMonth.sql

GO
:r .\StoredProcedures\DeleteByYear.sql

GO
Footer
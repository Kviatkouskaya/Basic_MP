﻿/*
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
:r .\Procedures\Procedure_SelectByStatus.sql

GO
:r .\Procedures\Procedure_SelectByProductId.sql

GO
:r .\Procedures\Procedure_SelectByMonth.sql

GO
:r .\Procedures\Procedure_SelectByYear.sql

GO
:r .\Procedures\Procedure_DeleteByStatus.sql

GO
:r .\Procedures\Procedure_DeleteByProductId.sql

GO
:r .\Procedures\Procedure_DeleteByMonth.sql

GO
:r .\Procedures\Procedure_DeleteByYear.sql

GO

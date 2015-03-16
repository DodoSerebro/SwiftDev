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
MERGE INTO Methodology AS Target 
USING (VALUES 
        (1, 'DAD'), 
        (2, 'XP'), 
        (3, 'SCRUM'),
		(4, 'RUP')
) 
AS Source (MethodologyId, MethodologyName) 
ON Target.MethodologyId = Source.MethodologyId 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (MethodologyName) 
VALUES (MethodologyName);
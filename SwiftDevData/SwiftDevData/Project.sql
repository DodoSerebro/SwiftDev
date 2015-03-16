CREATE TABLE [dbo].[Project]
(
	[ProjectId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProjectName] NCHAR(20) NOT NULL,
	[ProjectDescription] Text NOT NULL, 
    [Company] NCHAR(20) NOT NULL, 
    [Methodology] NCHAR(10) NOT NULL, 
    [ProjectStart] DATE NOT NULL, 
    [ProjectEnd] DATE NULL,


)

	CREATE TABLE [dbo].[Methodology]
(
	[MethodologyId] INT IDENTITY(1,1) NOT NULL  PRIMARY KEY,
	[MethodologyName] NCHAR(10) NOT NULL UNIQUE
)

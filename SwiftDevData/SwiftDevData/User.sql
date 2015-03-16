CREATE TABLE [dbo].[User]
(
	[UserId] INT  IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[Username] NCHAR(30) NOT NULL UNIQUE,
	[Password] NCHAR(20) NOT NULL,
    [FirstName] NCHAR(20) NOT NULL, 
    [LastName] NCHAR(20) NOT NULL, 
    [Role] NCHAR(20) NOT NULL, 
    [CurrentProject] INT NULL
)

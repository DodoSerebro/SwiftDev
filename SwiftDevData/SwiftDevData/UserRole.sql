﻿CREATE TABLE [dbo].[UserRole]
(
	[RoleId] INT  IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserRole] NCHAR(25) NOT NULL
)
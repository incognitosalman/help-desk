﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Email] NVARCHAR(150) NOT NULL, 
    [PasswordHash] VARBINARY(MAX) NOT NULL, 
    [FirstName] NVARCHAR(150) NULL, 
    [LastName] NVARCHAR(150) NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY (Id)
)

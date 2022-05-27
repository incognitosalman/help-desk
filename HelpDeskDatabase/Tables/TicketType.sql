CREATE TABLE [dbo].[TicketType]
(
	[Id] INT NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_TicketType] PRIMARY KEY (Id),
)

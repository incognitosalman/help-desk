CREATE TABLE [dbo].[TicketState]
(
	[Id] INT NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL,
    CONSTRAINT [FK_TicketState] PRIMARY KEY (Id)

)

CREATE TABLE [dbo].[TicketTag]
(
	[Id] INT NOT NULL, 
    [TicketId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_TicketTag] PRIMARY KEY (Id),
    CONSTRAINT [FK_TicketTag_Ticket] FOREIGN KEY (TicketId) REFERENCES Ticket(Id)
)

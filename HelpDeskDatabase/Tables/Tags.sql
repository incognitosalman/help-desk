CREATE TABLE [dbo].[Tags]
(
	[Id] INT NOT NULL, 
    [TicketId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY (Id),
    CONSTRAINT [FK_Tags_Tickets] FOREIGN KEY (TicketId) REFERENCES Tickets(Id)
)

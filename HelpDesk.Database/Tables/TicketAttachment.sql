CREATE TABLE [dbo].[TicketAttachment]
(
	[Id] INT NOT NULL,
    [TicketId] INT NOT NULL, 
    [FilePath] NVARCHAR(500) NOT NULL, 
    [FileName] NVARCHAR(250) NOT NULL, 
    [FileExtension] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [PK_TicketAttachment] PRIMARY KEY (Id),
    CONSTRAINT [FK_TicketAttachment_Ticket] FOREIGN KEY (TicketId) REFERENCES Ticket(Id)
)

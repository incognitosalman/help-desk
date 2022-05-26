CREATE TABLE [dbo].[Attachments]
(
	[Id] INT NOT NULL,
    [TicketId] INT NOT NULL, 
    [FilePath] NVARCHAR(500) NOT NULL, 
    [FileName] NVARCHAR(250) NOT NULL, 
    [FileExtension] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [PK_Attachments] PRIMARY KEY (Id),
    CONSTRAINT [FK_Attachment_Tickets] FOREIGN KEY (TicketId) REFERENCES Tickets(Id)
)

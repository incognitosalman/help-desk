-- =============================================
-- Author:		Taj
-- Create date: 2022-05-31
-- Description:	Delete an existing ticket
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteTicket] 
	-- Add the parameters for the stored procedure here
	@Id	INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Ticket
	WHERE Id = @Id;
END
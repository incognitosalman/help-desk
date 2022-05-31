-- =============================================
-- Author:		Taj
-- Create date: 2022-05-31
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAllTicketGroups] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Name
	FROM TicketGroup 
	ORDER BY [Name];
END
-- =============================================
-- Author:		Taj
-- Create date: 2022-05-31
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetTicketById]
	@Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Description, AgentId
		, StateId, SourceId
		, Subject, T.Email, T.Id, TypeId
		, GroupId, TG.Name AS [Group]
		, PriorityId, TP.Name AS [Priority]
		, U.Email AS AgentEmail, U.FirstName AS AgentFirstName, U.LastName AS AgentLastName
	FROM  Ticket AS T
	LEFT OUTER JOIN Users AS U
		ON T.AgentId = U.Id
	INNER JOIN TicketGroup AS TG
		ON T.GroupId = TG.Id
	INNER JOIN TicketPriority AS TP
		ON T.PriorityId = TP.Id
	WHERE T.Id = @Id;
END

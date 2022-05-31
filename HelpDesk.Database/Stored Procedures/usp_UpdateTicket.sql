-- =============================================
-- Author:		Taj
-- Create date: 2022-05-31
-- Description:	Update a new ticket
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateTicket] 
	-- Add the parameters for the stored procedure here
	@Id	INT,
	@Email NVARCHAR(250), 
	@Subject NVARCHAR(100), 
	@GroupId int, 
	@TypeId int,
	@SourceId int,
	@StateId int,
	@AgentId int = NULL,
	@PriorityId int,
	@Description NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Ticket
	SET          
		[Description] = @Description
		, PriorityId = @PriorityId
		, AgentId = @AgentId
		, StateId = @StateId
		, SourceId = @SourceId
		, TypeId = @TypeId
		, GroupId = @GroupId
		, [Subject] = @Subject
	WHERE Id = @Id;
END
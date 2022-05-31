﻿-- =============================================
-- Author:		Taj
-- Create date: 2022-05-31
-- Description:	Create a new ticket
-- =============================================
CREATE PROCEDURE [dbo].[usp_CreateTicket] 
	-- Add the parameters for the stored procedure here
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
	INSERT INTO Ticket (
			Email, Subject, GroupId, SourceId
			, TypeId, StateId, AgentId, PriorityId, Description
	)
	VALUES (
		@Email,@Subject,@GroupId,@SourceId
		,@TypeId,@StateId,@AgentId,@PriorityId
		,@Description
	)
END

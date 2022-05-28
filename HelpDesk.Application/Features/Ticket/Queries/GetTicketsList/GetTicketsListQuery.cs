using HelpDesk.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Application.Features.Ticket.Queries.GetTicketsList
{
    public class GetTicketsListQuery : IRequest<List<TicketResponse>>
    {
        public GetTicketsListQuery()
        {
        }

        public GetTicketsListQuery(int groupId, int typeId, int sourceId, int stateId, int agentId, int priorityId)
        {
            GroupId = groupId;
            TypeId = typeId;
            SourceId = sourceId;
            StateId = stateId;
            AgentId = agentId;
            PriorityId = priorityId;
        }

        public int GroupId { get; set; }
        public int TypeId { get; set; }
        public int SourceId { get; set; }
        public int StateId { get; set; }
        public int AgentId { get; set; }
        public int PriorityId { get; set; }

    }
}

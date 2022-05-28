using HelpDesk.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Application.Features.Ticket.Queries.GetTicket
{
    public class GetTicketQuery : IRequest<TicketResponse>
    {
        public GetTicketQuery(int ticketId)
        {
            TicketId = ticketId;
        }

        public int TicketId { get; set; }

    }
}

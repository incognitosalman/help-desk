using AutoMapper;
using HelpDesk.Application.Contracts.Persistence;
using HelpDesk.Domain.Responses;
using MediatR;

namespace HelpDesk.Application.Features.Ticket.Queries.GetTicket
{
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, TicketResponse>
    {
        private readonly ITicketsRepository _ticketsRepository;
        private readonly IMapper _mapper;

        public GetTicketQueryHandler(
            ITicketsRepository ticketsRepository, 
            IMapper mapper)
        {
            _ticketsRepository = ticketsRepository;
            _mapper = mapper;
        }

        public async Task<TicketResponse> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var record = await _ticketsRepository.GetByIdAsync(request.TicketId);
            return _mapper.Map<TicketResponse>(record);
        }
    }
}

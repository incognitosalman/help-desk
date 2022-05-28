using AutoMapper;
using HelpDesk.Application.Contracts.Persistence;
using HelpDesk.Domain.Responses;
using MediatR;

namespace HelpDesk.Application.Features.Ticket.Queries.GetTicketsList
{
    public class GetTicketsListQueryHandler : IRequestHandler<GetTicketsListQuery, List<TicketResponse>>
    {
        private readonly ITicketsRepository _ticketsRepository;
        private readonly IMapper _mapper;

        public GetTicketsListQueryHandler(
            ITicketsRepository ticketsRepository, 
            IMapper mapper)
        {
            _ticketsRepository = ticketsRepository;
            _mapper = mapper;
        }

        public async Task<List<TicketResponse>> Handle(GetTicketsListQuery request, CancellationToken cancellationToken)
        {
            var list = await _ticketsRepository.GetAsync(
                predicate: null,
                orderBy: null,
                includeString: "Agent",
                disableTracking: true);
            return _mapper.Map<List<TicketResponse>>(list);
        }
    }
}

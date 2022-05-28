using HelpDesk.Application.Contracts.Persistence;
using HelpDesk.Domain.Entities;

namespace HelpDesk.Application.Contracts.Persistence
{
    public interface ITicketsRepository : IAsyncRepository<Ticket>
    {
    }
}

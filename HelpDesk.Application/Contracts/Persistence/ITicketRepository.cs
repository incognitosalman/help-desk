using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Responses;

namespace HelpDesk.Application.Contracts.Persistence
{
    public interface ITicketRepository 
    {
        Task<List<TicketResponse>> GetAsync();
        Task<TicketResponse> GetByIdAsync(int id);
        Task<int> CreateAsync(Ticket entity);
        Task<int> UpdateAsync(Ticket entity);
        Task<int> DeleteAsync(Ticket entity);
    }
}

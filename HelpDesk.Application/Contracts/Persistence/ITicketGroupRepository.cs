using HelpDesk.Domain.Entities;

namespace HelpDesk.Application.Contracts.Persistence
{
    public interface ITicketGroupRepository 
    {
        Task<List<TicketGroup>> GetAsync();
        Task<TicketGroup> GetByIdAsync(int id);
        Task<int> CreateAsync(TicketGroup entity);
        Task<int> UpdateAsync(TicketGroup entity);
        Task<int> DeleteAsync(TicketGroup entity);
    }
}

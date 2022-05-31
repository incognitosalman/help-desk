using System.Data;
using Dapper;
using HelpDesk.Application.Contracts.Persistence;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Responses;
using Microsoft.Extensions.Configuration;

namespace HelpDesk.Infrastructure.Repositories
{
    public class TicketRepository : BaseRepository, ITicketRepository
    {
        public TicketRepository(IConfiguration configuration)
            : base(configuration)
        { }
         
        public async Task<List<TicketResponse>> GetAsync()
        {
            try
            {
                var query = "usp_GetAllTickets";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<TicketResponse>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TicketResponse> GetByIdAsync(int id)
        {
            try
            {
                var query = "usp_GetTicketById @Id";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<TicketResponse>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(Ticket entity)
        {
            try
            {
                var query = "usp_CreateTicket @Email, @Subject, @GroupId, @TypeId, @SourceId, @StateId, @AgentId, @PriorityId, @Description";

                var parameters = new DynamicParameters();
                parameters.Add("@Email", entity.Email, DbType.String);
                parameters.Add("@Subject", entity.Subject, DbType.String);
                parameters.Add("@GroupId", entity.GroupId, DbType.Int32);
                parameters.Add("@TypeId", entity.AgentId, DbType.Int32);
                parameters.Add("@SourceId", entity.SourceId, DbType.Int32);
                parameters.Add("@StateId", entity.StateId, DbType.Int32);
                parameters.Add("@AgentId", entity.AgentId, DbType.Int32);
                parameters.Add("@PriorityId", entity.PriorityId, DbType.Int32);
                parameters.Add("@Description", entity.Description, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Ticket entity)
        {
            try
            {
                var query = "usp_UpdateTicket @Id, @Email, @Subject, @GroupId, @TypeId, @SourceId, @StateId, @AgentId, @PriorityId, @Description";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id, DbType.Int64);
                parameters.Add("@Email", entity.Email, DbType.String);
                parameters.Add("@Subject", entity.Subject, DbType.String);
                parameters.Add("@GroupId", entity.GroupId, DbType.Int32);
                parameters.Add("@TypeId", entity.AgentId, DbType.Int32);
                parameters.Add("@SourceId", entity.SourceId, DbType.Int32);
                parameters.Add("@StateId", entity.StateId, DbType.Int32);
                parameters.Add("@AgentId", entity.AgentId, DbType.Int32);
                parameters.Add("@PriorityId", entity.PriorityId, DbType.Int32);
                parameters.Add("@Description", entity.Description, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Ticket entity)
        {
            try
            {
                var query = "usp_DeleteTicket @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

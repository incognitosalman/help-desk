using System.Data;
using Dapper;
using HelpDesk.Application.Contracts.Persistence;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Responses;
using Microsoft.Extensions.Configuration;

namespace HelpDesk.Infrastructure.Repositories
{
    public class TicketGroupRepository : BaseRepository, ITicketGroupRepository
    {
        public TicketGroupRepository(IConfiguration configuration)
            : base(configuration)
        { }
         
        public async Task<List<TicketGroup>> GetAsync()
        {
            try
            {
                var query = "usp_GetAllTicketGroups";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<TicketGroup>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TicketGroup> GetByIdAsync(int id)
        {
            try
            {
                var query = "usp_GetTicketGroupById @Id";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<TicketGroup>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(TicketGroup entity)
        {
            try
            {
                var query = "usp_CreateTicketGroup @Name";

                var parameters = new DynamicParameters();
                parameters.Add("@Name", entity.Name, DbType.String);

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

        public async Task<int> UpdateAsync(TicketGroup entity)
        {
            try
            {
                var query = "usp_UpdateTicketGroup @Id, @Name";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id, DbType.Int64);
                parameters.Add("@Name", entity.Name, DbType.String);

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

        public async Task<int> DeleteAsync(TicketGroup entity)
        {
            try
            {
                var query = "usp_DeleteTicketGroup @Id";

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

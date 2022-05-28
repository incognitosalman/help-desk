using HelpDesk.Application.Contracts.Persistence;
using HelpDesk.Domain.Entities;
using HelpDesk.Infrastructure.Data;
using HelpDesk.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Infrastructure.Repositories
{
    public class TicketsRepository : RepositoryBase<Ticket>, ITicketsRepository
    {
        public TicketsRepository(HelpDeskContext context) : base(context)
        {
        }
    }
}

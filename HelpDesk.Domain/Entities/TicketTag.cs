using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Entities
{
    public partial class TicketTag : EntityBase
    {
        public int TicketId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Ticket Ticket { get; set; } = null!;
    }
}

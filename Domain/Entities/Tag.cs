using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Tag
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Ticket Ticket { get; set; } = null!;
    }
}

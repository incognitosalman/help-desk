﻿using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Entities
{
    public partial class TicketState : EntityBase
    {
        public TicketState()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

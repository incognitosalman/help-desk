using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Group
    {
        public Group()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

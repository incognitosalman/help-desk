using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Source
    {
        public Source()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

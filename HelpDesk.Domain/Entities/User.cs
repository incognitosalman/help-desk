using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Entities
{
    public partial class User : EntityBase
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

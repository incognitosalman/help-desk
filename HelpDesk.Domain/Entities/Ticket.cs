using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Entities
{
    public partial class Ticket : EntityBase
    {
        public Ticket()
        {
            TicketAttachments = new HashSet<TicketAttachment>();
            TicketTags = new HashSet<TicketTag>();
        }

        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public int? GroupId { get; set; }
        public int? TypeId { get; set; }
        public int? SourceId { get; set; }
        public int StateId { get; set; }
        public int? AgentId { get; set; }
        public int PriorityId { get; set; }
        public string? Description { get; set; }

        public virtual User? Agent { get; set; }
        public virtual TicketGroup? Group { get; set; }
        public virtual TicketPriority Priority { get; set; } = null!;
        public virtual TicketSource? Source { get; set; }
        public virtual TicketState State { get; set; } = null!;
        public virtual TicketType? Type { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<TicketTag> TicketTags { get; set; }
    }
}

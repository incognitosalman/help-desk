using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Ticket
    {
        public Ticket()
        {
            Attachments = new HashSet<Attachment>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
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
        public virtual Group? Group { get; set; }
        public virtual Priority Priority { get; set; } = null!;
        public virtual Source? Source { get; set; }
        public virtual State State { get; set; } = null!;
        public virtual Type? Type { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}

using HelpDesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Responses
{
    public class TicketResponse
    {
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
        public string AgentEmail { get; set; } = null!;
        public string AgentFirstName { get; set; } = null!;
        public string AgentLastName { get; set; } = null!;
        public string Group { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpDesk.Domain.Resuests
{
    public class TicketCreateRequest
    {
        public string Email { get; set; }
        public string Subject { get; set; } 
        public int? GroupId { get; set; }
        public int? TypeId { get; set; }
        public int? SourceId { get; set; }
        public int StateId { get; set; }
        public int? AgentId { get; set; }
        public int PriorityId { get; set; }
        public string? Description { get; set; }

        public IEnumerable<SelectListItem> Groups { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Sources { get; set; }
        public IEnumerable<SelectListItem> States{ get; set; }
        public IEnumerable<SelectListItem> Priorities{ get; set; }

    }
}

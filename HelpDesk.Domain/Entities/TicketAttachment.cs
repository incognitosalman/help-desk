﻿using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Entities
{
    public partial class TicketAttachment : EntityBase
    {
        public int TicketId { get; set; }
        public string FilePath { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FileExtension { get; set; } = null!;

        public virtual Ticket Ticket { get; set; } = null!;
    }
}

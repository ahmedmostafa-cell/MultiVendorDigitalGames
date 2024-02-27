﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbTicketDiscussion
    {
        public Guid? TicketDiscussionId { get; set; }
        public Guid? TicketId { get; set; }
        public string TicketText { get; set; }
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbTicket Ticket { get; set; }
    }
}

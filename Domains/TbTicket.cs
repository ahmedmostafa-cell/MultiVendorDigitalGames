using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbTicket
    {
        public TbTicket()
        {
            TbTicketDiscussions = new HashSet<TbTicketDiscussion>();
        }

        public Guid? TicketId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل تفاصيل التيكيت         ")]
        public string TicketText { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل فئة التيكيت         ")]
        public Guid? TicketCategoryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbTicketCategory TicketCategory { get; set; }
        public virtual ICollection<TbTicketDiscussion> TbTicketDiscussions { get; set; }
    }
}

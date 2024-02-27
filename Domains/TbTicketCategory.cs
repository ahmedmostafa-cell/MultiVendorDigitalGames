using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbTicketCategory
    {
        public TbTicketCategory()
        {
            TbTickets = new HashSet<TbTicket>();
        }

        public Guid? TicketCategoryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم فئة التيكيت         ")]
        public string TicketCategoryName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم فئة التيكيت الانجليزي         ")]
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbTicket> TbTickets { get; set; }
    }
}

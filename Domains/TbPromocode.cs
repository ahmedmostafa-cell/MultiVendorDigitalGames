using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbPromocode
    {
        public Guid? PromocodeId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل  البروموكود  ")]
        public string PromocodeTitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل نسبة خصم البروموكود  ")]
        public string PromocodeDiscountPercent { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

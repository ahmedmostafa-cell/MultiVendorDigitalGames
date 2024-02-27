using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbSellerSubscribe
    {
        public Guid? SellerSubscribeId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم التاجر  ")]
        public Guid? SellerId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل تكلفة لاشتراك   ")]
        public string SubscribeFees { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل هامش ربح الموقع   ")]
        public string WebsiteProfitMargin { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل تايخ البداية   ")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل تاريخ النهاية   ")]
        public string EndDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbSeller Seller { get; set; }
    }
}

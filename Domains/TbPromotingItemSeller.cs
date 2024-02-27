using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbPromotingItemSeller
    {
        public Guid? PromotingItemSellerId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل  اسم التاجر  ")]
        public Guid? SellerId { get; set; }
        public string SellerName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل  اسم المنتج  ")]
        public Guid? ItemId { get; set; }
        public string ItemName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل  قيمة البرومو  ")]
        public string PromotioValue { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

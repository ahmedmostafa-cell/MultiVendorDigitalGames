using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public partial class TbOrder
    {
        [Key]
        public Guid? OrderId { get; set; }

        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string? SellerId { get; set; }
        public string? SellerName { get; set; }
        public string? SellerNameEn { get; set; }

        public string? OrderPriceBeforePromocode { get; set; }

        public Guid? PromocodeId { get; set; }

        public string? PromocodeTitle { get; set; }

        public string? PromocodeDiscountPercent { get; set; }


        public string? OrderPriceAfterPromocode { get; set; }

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Notes { get; set; }
        public int? CurrentState { get; set; }

        public string? TransactionStatus { get; set; }
    }
}

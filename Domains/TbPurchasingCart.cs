using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbPurchasingCart
    {
        public Guid? PurchasingCartId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Guid? ItemId { get; set; }
        public string ItemName { get; set; }
        public Guid? SellerId { get; set; }
        public string SellerName { get; set; }
        public Guid? ItemSellerId { get; set; }
        public string ItemImagePath { get; set; }
        public string ItemSalePrice { get; set; }
        public string Region { get; set; }
        public string SellerItemEvaluationStarts { get; set; }
        public string SellerItemEvaluationNumbers { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public int? Quantity { get; set; }
    }
}

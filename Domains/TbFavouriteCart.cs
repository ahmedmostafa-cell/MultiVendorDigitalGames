using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domains
{
    public partial class TbFavouriteCart
    {
        public Guid? FavouriteCartId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserNameEn { get; set; }
        public Guid? ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemNameEn { get; set; }
        public Guid? SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerNameEn { get; set; }
        public Guid? ItemSellerId { get; set; }
        public string ItemImagePath { get; set; }
        public string ItemSalePrice { get; set; }
        public string Region { get; set; }
        public string RegionEn { get; set; }
        public string SellerItemEvaluationStarts { get; set; }
        public string SellerItemEvaluationNumbers { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
        [NotMapped]
        public int? NumberOfAddFavourite { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public partial class TbItemSellerImages
    {
        [Key]
        public Guid? ItemSellerImageId { get; set; }
       
        public Guid? ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemNameEn { get; set; }
        
        public Guid? SellerId { get; set; }
        public string? SellerName { get; set; }
        public string? SellerNameEn { get; set; }
        public string? ItemImagePath { get; set; }
       
        public string? ItemSalePrice { get; set; }
       
        public Guid? RegionId { get; set; }
        public string? Region { get; set; }
        public string? RegionEn { get; set; }
        public string? SellerItemEvaluationStarts { get; set; }
        public string? SellerItemEvaluationNumbers { get; set; }
        public string? EvaluatersNumbers { get; set; }
        public string? Promoted { get; set; }
        public string? WebsiteProfitMargin { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Notes { get; set; }
        public int? CurrentState { get; set; }

        public int? NumberOfAddFavourite { get; set; }


        public string? NumberOfSalesTransaction { get; set; }


        public string? UpComingGames { get; set; }

        public bool BestSellingEGiftCard { get; set; }

        public Guid? ItemSellerId { get; set; }
        public bool BestSellingGiftCard { get; set; }

        public string? RegionName { get; set; }
        public virtual TbItem? Item { get; set; }
        public virtual TbRegion? RegionNavigation { get; set; }
        public virtual TbSeller? Seller { get; set; }
    }
}

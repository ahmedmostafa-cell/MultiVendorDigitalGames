using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbBlogItemSeller
    {
        public Guid? BlogItemSellerId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم  المدونة  ")]
        public Guid? BlogId { get; set; }
       

      
        public string BlogTitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم  المنتج  ")]
        public Guid? ItemSellerId { get; set; }
        public string BlogTitleEn { get; set; }


        [Required(ErrorMessage = "من فضلك ادخل وصف  المنتج الانجليزي  ")]
        public string ShortDescroptionEn { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل وصف  المنتج  ")]
        public string ShortDescroption { get; set; }



        public Guid? ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemNameEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم  التاجر  ")]
        public Guid? SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerNameEn { get; set; }

        public string ItemPrice { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbBlog Blog { get; set; }
    }
}

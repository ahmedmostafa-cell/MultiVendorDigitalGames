using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbBlog
    {
        public TbBlog()
        {
            TbBlogComments = new HashSet<TbBlogComment>();
            TbBlogImages = new HashSet<TbBlogImage>();
            TbBlogItemSellers = new HashSet<TbBlogItemSeller>();
        }

        public Guid? BlogId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل عنوان المدونة")]
        public string BlogTitle { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل عنوان المدونة الانجليزي")]
        public string BlogTitleEn { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل وصف مختصر  للمدونة")]
        public string BlogShortDescription { get; set; }

        [Required(ErrorMessage = " من فضلك ادخل وصف مختصر  للمدونة انجليزي")]
        public string BlogShortDescriptionEn { get; set; }
       
        public Guid? ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemNameEn { get; set; }


      


        public Guid? SellerId { get; set; }
        public string SellerName { get; set; }

        public string SellerNameEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل ترتيب ظهور المدونة   ")]
        public int? OrderNo { get; set; }
        //[Required(ErrorMessage = "من فضلك ادخل اسم قسم التي تنتمي له المدونة   ")]
        public Guid? BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }

        public string BlogCategoryNameEn { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم الوضوع التي تنتمي له المدونة   ")]
        public Guid? BlogTopicId { get; set; }
        public string BlogTopicName { get; set; }
        public string BlogTopicNameEn { get; set; }
        public string CreatedBy { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل فئة المدونة")]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbBlogCategory BlogCategory { get; set; }
        public virtual TbBlogTopic BlogTopic { get; set; }
        public virtual ICollection<TbBlogComment> TbBlogComments { get; set; }
        public virtual ICollection<TbBlogImage> TbBlogImages { get; set; }
        public virtual ICollection<TbBlogItemSeller> TbBlogItemSellers { get; set; }
    }
}

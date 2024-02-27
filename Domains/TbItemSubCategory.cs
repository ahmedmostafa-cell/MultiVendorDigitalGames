using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbItemSubCategory
    {
        public Guid? ItemSubCategoryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المنتج  ")]
        public Guid? ItemId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الفئة الفرعية  ")]
        public Guid? SubCategoryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }


        public bool EGiftCard { get; set; }

        public bool GiftCard { get; set; }

        public virtual TbItem Item { get; set; }
        public virtual TbSubCategory SubCategory { get; set; }
    }
}

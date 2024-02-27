using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbMainCategory
    {
        public TbMainCategory()
        {
            TbSubCategories = new HashSet<TbSubCategory>();
        }

        public Guid? MainCategoryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الفئة الرئيسية  ")]
        public string MainCategoryTitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الفئة الرئيسية الانجليزي  ")]
        public string MainCategoryTitleEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف الفئة الرئيسية  ")]
        public string MainCategoryDescription { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف الفئة الرئيسية الانجليزي  ")]
        public string MainCategoryDescriptionEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل النوع     ")]
        public Guid? TypeId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbType Type { get; set; }
        public virtual ICollection<TbSubCategory> TbSubCategories { get; set; }
    }
}

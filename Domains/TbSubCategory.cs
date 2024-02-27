using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbSubCategory
    {
        public TbSubCategory()
        {
            TbItemSubCategories = new HashSet<TbItemSubCategory>();
        }

        public Guid? SubCategoryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل عنوان الفئة الفرعية الانجليزي      ")]
        public string SubCategoryTitle { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل عنوان الفئة الفرعية الانجليزي      ")]
        public string SubCategoryTitleEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف الفئة الفرعية       ")]
        public string SubCategoryDescription { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل وصف الفئة الفرعية الانجليزي      ")]
        public string SubCategoryDescriptionEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الفئة الرئيسية       ")]
        public Guid? MainCategoryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbMainCategory MainCategory { get; set; }
        public virtual ICollection<TbItemSubCategory> TbItemSubCategories { get; set; }
    }
}

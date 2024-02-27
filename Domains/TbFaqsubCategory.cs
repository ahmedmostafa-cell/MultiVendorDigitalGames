using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbFaqsubCategory
    {
        public TbFaqsubCategory()
        {
            TbFaqs = new HashSet<TbFaq>();
        }

        public Guid? FaqsubCategoryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الفئة الفرعية للسؤال   ")]
        public string FaqsubCategoryName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الفئة الفرعية للسؤال الانجليزي  ")]
        public string FaqsubCategoryNameEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل فئة السؤال   ")]
        public Guid? FaqcategoryId { get; set; }
        public string FaqcategoryName { get; set; }
        public string FaqcategoryNameEn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbFaqcategory Faqcategory { get; set; }
        public virtual ICollection<TbFaq> TbFaqs { get; set; }
    }
}

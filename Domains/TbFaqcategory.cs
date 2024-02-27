using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbFaqcategory
    {
        public TbFaqcategory()
        {
            TbFaqsubCategories = new HashSet<TbFaqsubCategory>();
        }

        public Guid? FaqcategoryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل فئة السؤال   ")]
        public string FaqcategoryName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل فئة السؤال الانجليزي  ")]
        public string FaqcategoryNameEn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbFaqsubCategory> TbFaqsubCategories { get; set; }
    }
}

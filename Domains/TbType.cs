using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbType
    {
        public TbType()
        {
            TbMainCategories = new HashSet<TbMainCategory>();
        }

        public Guid? TypeId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم النوع         ")]
        public string TypeTitle { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم النوع الانجليزي         ")]
        public string TypeTitleEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف النوع          ")]
        public string TypeDescription { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل وصف النوع الانجليزي         ")]
        public string TypeDescriptionEn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbMainCategory> TbMainCategories { get; set; }
    }
}

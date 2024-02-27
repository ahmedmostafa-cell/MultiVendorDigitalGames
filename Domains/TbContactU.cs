using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbContactU
    {
        public Guid? ContactUsId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل الايميل الرسمي  ")]
        public string BusinessDevelopementEmail { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل ايميل الشؤون القانونية  ")]
        public string LegalDepartmentEmail { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل ايميل التوظيف  ")]
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

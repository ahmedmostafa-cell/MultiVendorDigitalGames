using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public partial class TbCompanyType
    {
        [Key]
        public Guid? CompanyTypeId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل عنوان نوع الشركة الاول")]
        public string? CompanyTypeTitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل عنوان نوع الشركة الانجليزي")]
        public string? CompanyTypeEn { get; set; }
       
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
      
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

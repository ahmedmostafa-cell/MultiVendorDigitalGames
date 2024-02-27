using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public partial class TbOperatingSystem
    {
        public Guid? OperatingSystemId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم نظام التشغيل ")]
        public string? OperatingSystemName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم نظام التشغيل الانجليزي ")]
        public string? OperatingSystemNameEn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Notes { get; set; }
        public int? CurrentState { get; set; }

    }
}

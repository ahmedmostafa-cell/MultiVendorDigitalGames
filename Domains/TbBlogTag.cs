using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public partial class TbBlogTag
    {
        [Key]
        public Guid? BlogTagId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم تاج المدونة ")]
        public string? BlogTaName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم تاج المدونة الانجليزي ")]
        public string? BlogTaNameEn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

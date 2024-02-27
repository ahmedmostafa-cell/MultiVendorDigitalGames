using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbCurrency
    {
        public Guid? CurrencyId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم العملة  ")]
        public string CurrencyName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم العملة الانجليزي  ")]
        public string CurrencyNameEn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

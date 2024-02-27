using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbCountry
    {
        public Guid? CountryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الدولة  ")]
        public string CountryName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الدولة الانجليزي  ")]
        public string CountryNameEn { get; set; }
        public string CountryImagePath { get; set; }
        public Guid? RegionId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

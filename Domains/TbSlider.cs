using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbSlider
    {
        public Guid? SliderId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل  عنوان السليدر      ")]
        public string SliderTitle { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل   عنوان السليدر الانجليزي     ")]
        public string SliderTitleEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف السليدر      ")]
        public string SliderDescription { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف السليدر الانجليزي      ")]
        public string SliderDescriptionEn { get; set; }
      
        public string SliderImagePath { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل مكان السليدر       ")]
        public string Location { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل ترتيب ظهور السليدر       ")]
        public string SliderOrderNo { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

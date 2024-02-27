using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbFaq
    {
        public Guid? Faqid { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم السؤال  ")]
        public string Faqquestion { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم السؤال الانجليزي  ")]
        public string FaqquestionEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اجابة السؤال   ")]
        public string Faqanswer { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اجابة السؤال الانجليزي  ")]
        public string FaqanswerEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل فئة السؤال ")]
        public Guid? FaqsubCategoryId { get; set; }
        public string FaqsubCategoryName { get; set; }
        public string FaqsubCategoryNameEn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbFaqsubCategory FaqsubCategory { get; set; }
    }
}

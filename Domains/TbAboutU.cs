using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbAboutU
    {
        public Guid? AboutUsId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل العنوان الاول")]
        public string FirstTitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل العنوان الاول الانجليزي")]
        public string FirstTitleEn1 { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل العنوان الثاني ")]
        public string SecondTitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل العنوان الثاني الانجليزي")]
        public string SecondTitleEn1 { get; set; }
        [Required(ErrorMessage = " من فضلك ادخل شرح العنوان الاول ")]
        public string FirstText { get; set; }
        [Required(ErrorMessage = " من فضلك ادخل شرح العنوان الاول الانجليزي")]
        public string FirstTextEn1 { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل العنوان الثالث ")]
        public string ThirdTtitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل العنوان الثالث الانجليزي")]
        public string ThirdTtitleEn1 { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل شرح  الجزا الاول من العنوان الثالث ")]
        public string SecondText { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل شرح  الجزا الاول من العنوان الثالث الانجليزي")]
        public string SecondTextEn1 { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل شرح  الجزا الثاني من العنوان الثالث ")]
        public string CreatedBy { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل شرح  الجزا الثاني من العنوان الثالث الانجليزي")]

        public string CreatedByEn1 { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل شرح  الجزا الثالث من العنوان الثالث ")]
        public string UpdatedBy { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل شرح  الجزا الثالث من العنوان الثالث الانجليزي")]
        public string UpdatedByEn { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbBlogImage
    {
        public Guid? BlogImageId { get; set; }
        public string BlogImagePath { get; set; }
        public Guid? BlogId { get; set; }
        public int? OrderNo { get; set; }
        public string BlogImageMain { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم عنوان الصورة  ")]
        public string BlogImageTitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم عنوان الصورة الانجليزي ")]
        public string BlogImageTitleEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف الصورة  ")]
        public string BlogImageText { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل وصف الصورة الانجليزي ")]
        public string BlogImageTextEn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbBlog Blog { get; set; }
    }
}

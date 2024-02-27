using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbBlogCategory
    {
        public TbBlogCategory()
        {
            TbBlogs = new HashSet<TbBlog>();
        }

        public Guid? BlogCategoryId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم قسم المدونة ")]
        public string BlogCategoryName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم قسم المدونة الانجليزي ")]
        public string BlogCategoryNameEn { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbBlog> TbBlogs { get; set; }
    }
}

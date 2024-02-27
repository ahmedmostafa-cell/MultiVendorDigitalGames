using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbBlogTopic
    {
        public TbBlogTopic()
        {
            TbBlogs = new HashSet<TbBlog>();
        }

        public Guid? BlogTopicId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم موشوع المدونة ")]
        public string BlogTopicName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم موشوع المدونة الانجليزي ")]
        public string BlogTopicNameEn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbBlog> TbBlogs { get; set; }
    }
}

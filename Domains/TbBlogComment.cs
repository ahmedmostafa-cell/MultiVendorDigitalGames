using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbBlogComment
    {
        public TbBlogComment()
        {
            TbBlogCommentLikes = new HashSet<TbBlogCommentLike>();
        }

        public Guid? BlogCommentId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم  صاحب التعليق  ")]
        public string CommenterId { get; set; }
        public string CommenterName { get; set; }
      
        public string CommenterEmail { get; set; }
        public string CommentSyntax { get; set; }
        public Guid? BlogId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbBlog Blog { get; set; }
        public virtual ICollection<TbBlogCommentLike> TbBlogCommentLikes { get; set; }
    }
}

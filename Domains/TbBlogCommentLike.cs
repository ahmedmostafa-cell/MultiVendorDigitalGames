using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbBlogCommentLike
    {
        public Guid? BlogCommentLikeId { get; set; }
        public Guid? BlogCommentId { get; set; }
        public string ActionPersonId { get; set; }
        public string ActionPersonName { get; set; }

        public string ActionPersonNameEn { get; set; }

        public string ActionPersonEmail { get; set; }
        public string LikeAction { get; set; }
        public string DislikeAction { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbBlogComment BlogComment { get; set; }
    }
}

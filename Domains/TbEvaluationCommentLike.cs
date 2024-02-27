using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbEvaluationCommentLike
    {
        public Guid? EvaluationCommentLikeId { get; set; }
        public Guid? EvaluationId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserNameEn { get; set; }
        public string UserEmail { get; set; }
        public string LikeAction { get; set; }
        public string DislikeAction { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbEvaluation Evaluation { get; set; }
    }
}

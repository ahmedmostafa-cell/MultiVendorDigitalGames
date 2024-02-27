using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbEvaluation
    {
        public TbEvaluation()
        {
            TbEvaluationCommentLikes = new HashSet<TbEvaluationCommentLike>();
        }

        public Guid? EvaluationId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserNameEn { get; set; }
        public Guid? ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemNameEn { get; set; }
        public Guid? SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerNameEn { get; set; }
        public string ParameterOneStarts { get; set; }
        public string ParameterOneNumer { get; set; }
        public string ParameterwoStarts { get; set; }
        public string ParameterTwoNumber { get; set; }
        public string ParameterThreeStarts { get; set; }
        public string ParamterThreeNumber { get; set; }
        public string ParameterFourStarts { get; set; }
        public string ParameterFourNumber { get; set; }
        public string EvaluationText { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public Guid? ItemSellerId { get; set; }
        public virtual ICollection<TbEvaluationCommentLike> TbEvaluationCommentLikes { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbEnebaReview
    {
        public Guid? EnebaReviewId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
        public string StarsNo { get; set; }
        public string ReplyBack { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbCompetitionRecord
    {
        public Guid? CompetitionRecordId { get; set; }
        public Guid? CompetitionId { get; set; }
        public string UserId { get; set; }
        public Guid? CompetitionRulesId { get; set; }
        public string NoOfPoints { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbCompetition Competition { get; set; }
    }
}

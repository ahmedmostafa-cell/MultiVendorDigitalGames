using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbCompetition
    {
        public TbCompetition()
        {
            TbCompetitionRecords = new HashSet<TbCompetitionRecord>();
            TbCompetitionRules = new HashSet<TbCompetitionRule>();
        }

        public Guid? CompetitionId { get; set; }
        public string CompetitonImagePath { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل عنوان المنافسة   ")]
        public string CompetitionTitle { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل عنوان المنافسة الانجليزي   ")]
        public string CompetitionTitleEn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbCompetitionRecord> TbCompetitionRecords { get; set; }
        public virtual ICollection<TbCompetitionRule> TbCompetitionRules { get; set; }
    }
}

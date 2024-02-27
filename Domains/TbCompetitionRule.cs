using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbCompetitionRule
    {
        public Guid? CompetitionRulesId { get; set; }
        public Guid? CompetitionId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم قانون المنافسة    ")]
        public string RuleName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم قانون المنافسة الانجليزي    ")]
        public string RuleNameEn { get; set; }
        public string NoOfPoints { get; set; }
        public string Link { get; set; }
        public string Action { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbCompetition Competition { get; set; }
    }
}

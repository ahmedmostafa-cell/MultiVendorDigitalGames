using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbRegion
    {
        public TbRegion()
        {
            TbItemSellers = new HashSet<TbItemSeller>();
            TbItems = new HashSet<TbItem>();
        }

        public Guid? RegionId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل  اسم المنطقة  ")]
        public string RegionName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل  اسم المنطقة الانجليزي  ")]
        public string RegionNameEn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbItemSeller> TbItemSellers { get; set; }
        public virtual ICollection<TbItem> TbItems { get; set; }
    }
}

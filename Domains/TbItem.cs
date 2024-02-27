using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbItem
    {
        public TbItem()
        {
            TbItemSellers = new HashSet<TbItemSeller>();
            TbItemSubCategories = new HashSet<TbItemSubCategory>();
        }

        public Guid? ItemId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المنتج ")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المنتج الانجليزي ")]
        public string ItemNameEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المنطقة ")]
        public Guid? RegionId { get; set; }
        public string Region { get; set; }
        public string RegionEn { get; set; }
        public string WorksOn { get; set; }
        public string WorksOnEn { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم نظام التشغيل ")]
        public Guid? OperatingSystemId { get; set; }
        public string? OperatingSystemName { get; set; }

        public string? OperatingSystemNameEn { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل  المفتاح الالكتروني ")]
        public string DigitalKey { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل  هل اللعبة حديثة ستزل قريبا ")]
        public string UpComingGames { get; set; }
       
      
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbRegion RegionNavigation { get; set; }
        public virtual ICollection<TbItemSeller> TbItemSellers { get; set; }
        public virtual ICollection<TbItemSubCategory> TbItemSubCategories { get; set; }
    }
}

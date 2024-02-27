using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public partial class  TbBlogBlogTag
    {
        [Key]
        public Guid? BlogBlogTagId { get; set; }



        [Required(ErrorMessage = "من فضلك ادخل اسم  المدونة  ")]
        public Guid? BlogId { get; set; }



        public string? BlogTitle { get; set; }
      
        public string? BlogTitleEn { get; set; }



        [Required(ErrorMessage = "من فضلك ادخل اسم  التاج  ")]
        public Guid? BlogTagId { get; set; }


      


        public string? BlogTaName { get; set; }


        public string? BlogTaNameEn { get; set; }



     
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Notes { get; set; }
        public int? CurrentState { get; set; }



       

        
    }
}

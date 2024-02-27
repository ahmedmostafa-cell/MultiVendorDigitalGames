using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbSeller
    {
        public TbSeller()
        {
            TbItemSellers = new HashSet<TbItemSeller>();
            TbSellerSubscribes = new HashSet<TbSellerSubscribe>();
        }

        public Guid? SellerId { get; set; }
      
        public string SellerFullName { get; set; }


        public string SupplierName { get; set; }


        public string SellerFullNamen { get; set; }


        public Guid? CompanyTypeId { get; set; }

        public string CompanyType { get; set; }


        public string CompanyTypeEn { get; set; }

        public string CompanyName { get; set; }


        public string CompanyNumber { get; set; }

        public string DocumentA { get; set; }
 
        public string DocumentB { get; set; }
     
        public string DocumentC { get; set; }
   
        public string DocumentD { get; set; }
    
        public string DocumentE { get; set; }
       
        public string DocumentF { get; set; }
      
        public string NoOfSkus { get; set; }
       
        public string QtyAvailabeToSell { get; set; }
        public string ApiServices { get; set; }
       
        public Guid? CountryId { get; set; }
        public string CountryName { get; set; }
       
        public string Address { get; set; }
      
        public Guid? CityId { get; set; }

        public string CityName { get; set; }
       
        public string ZipCode { get; set; }
       
        public string TypesOfItems { get; set; }
      
        public string DateOfBirth { get; set; }
       
        public string SellerEmail { get; set; }
      
        public string SellerPhoneNumber { get; set; }
        
        public string BusinessCountry { get; set; }
       
        public string BusinessAddress { get; set; }
       
        public Guid? BusinessCirtyId { get; set; }
        public string BusinessCityName { get; set; }
        
        public string BusinessZipCode { get; set; }
      
        public string BusinessTradeName { get; set; }
        
        public string BusinessWebsite { get; set; }
       
        public string TaxIdentificationNo { get; set; }
      
        public string WbesiteProfitMargin { get; set; }
       
        public string RefrenceId { get; set; }
       
        public string VatNumber { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }

        public virtual ICollection<TbItemSeller> TbItemSellers { get; set; }
        public virtual ICollection<TbSellerSubscribe> TbSellerSubscribes { get; set; }
    }
}

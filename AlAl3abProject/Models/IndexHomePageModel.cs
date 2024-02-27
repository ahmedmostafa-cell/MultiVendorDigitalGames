using Domains;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AlAl3abProject.Models
{
    public class IndexHomePageModel
    {
        #region Declaration
        public IEnumerable<TbType> lstTypes { get; set; }


        public TbBlogImage BlogImage { get; set; }


        public IEnumerable<TbBlogImage> lstBlogImages { get; set; }


        public IEnumerable<TbBlogItemSeller> lstBlogItemSellers { get; set; }

        public IEnumerable<TbBlogTopic> lstBlogTopics { get; set; }


        public IEnumerable<TbBlog> lstBlogs { get; set; }


        public TbItemSeller itemSeller { get; set; }

        public TbContactU elelmentContactUs { get; set; }

        public TbAboutU elelmentAboutUs { get; set; }

        public IEnumerable<TbFavouriteCart> lstFavouriteCart { get; set; }

        public IEnumerable<TbFaqcategory> lstFaqcategories { get; set; }

        public IEnumerable<TbFaqsubCategory> lstFaqFaqsubCategories { get; set; }

        public IEnumerable<TbFaq> lstFaqs { get; set; }

        public IEnumerable<TbItem> lstItems { get; set; }

        public IEnumerable<TbMainCategory> lstMainCategories { get; set; }

        public IEnumerable<TbMainCategory> lstMainCategoriesFilters { get; set; }


        public List<SelectListItem> lstgtypes { get; set; }

        public IEnumerable<TbMainCategory> lstMainCategoriesBestSellingGiftCards { get; set; }

        public IEnumerable<TbOrderDetails> lstOrderDetails { get; set; }

        public IEnumerable<TbCompanyType> lstCompanyTypes { get; set; }

        public TbOrder Order { get; set; }


        public TbFaq faq { get; set; }


        public TbSeller seller { get; set; }


        public TbBlog blog { get; set; }


        public IEnumerable<TbMainCategory> lstMainCategoriesBestSellingEGiftCards { get; set; }

        public IEnumerable<TbSubCategory> lstSubCategories { get; set; }

        public IEnumerable<TbSubCategory> lstSubCategoriesFilters { get; set; }

        public IEnumerable<TbSubCategory> lstSubCategoriesFinal { get; set; }

        public IEnumerable<TbSubCategory> lstSubCategoriesBestSellingEGiftCards { get; set; }

        public IEnumerable<TbSubCategory> lstSubCategoriesBestSellingGiftCards { get; set; }

        public IEnumerable<TbSlider> lstSliders { get; set; }

        public IEnumerable<TbPurchasingCart> lstPurchasingCart { get; set; }


        public IEnumerable<TbItemSeller> lstItemSellers { get; set; }


        public IEnumerable<TbItemSeller> lstItemSellersFinal { get; set; }


        public IEnumerable<TbItemSeller> lstGameTop { get; set; }

        public IEnumerable<TbItemSeller> lstRecommendedForYou { get; set; }


        public IEnumerable<TbItemSeller> lstUpComingGames { get; set; }


        public IEnumerable<TbItemSeller> lstBestSellingGiftCards { get; set; }

        public IEnumerable<TbItemSeller> lstRelatedProducts { get; set; }

        public IEnumerable<TbItemSeller> lstRelated2Products { get; set; }

        public IEnumerable<TbItemSeller> lstBestSellingEGiftCards { get; set; }

        public IEnumerable<TbItemSellerImages> lstItemSellerImages { get; set; }

        public IEnumerable<TbItemSubCategory> lstItemSubCategoryBestSellingGiftCards { get; set; }

        public IEnumerable<TbItemSubCategory> lstItemSubCategoryBestSellingEGiftCards { get; set; }


        public IEnumerable<TbItemSubCategory> lstItemSubCategory { get; set; }


        public IEnumerable<TbItemSubCategory> lstItemSubCategoryFinal { get; set; }


        public IEnumerable<TbItemSubCategory> lstUpdatedItemSubCategory { get; set; }

        public IEnumerable<TbItemSubCategory> lstUpdated2ItemSubCategory { get; set; }
        public IEnumerable<VwItemSellerFavouriteCount> lstVwItemSellerFavouriteCount { get; set; }

        

        public IEnumerable<VwItemSellerEvalauationParameters> lstVwItemSellerEvalauationParameters { get; set; }

        public VwItemSellerEvalauationParameters VwItemSellerEvalauationParameters { get; set; }

        public IEnumerable<VwHighestSalesIteSeller> lstVwHighestSalesIteSeller { get; set; }


        public IEnumerable<TbRegion> lstRegions { get; set; }


        public IEnumerable<TbCountry> LstCountries { get; set; }


        public IEnumerable<TbOperatingSystem> lstOperatingSystems { get; set; }


        public IEnumerable<TbBlogBlogTag> lstBlogBlogTag { get; set; }


        public IEnumerable<TbBlogTag> lstBlogTag { get; set; }



        public IEnumerable<TbBlogCategory> lstBlogCategories { get; set; }

        #endregion
    }
}

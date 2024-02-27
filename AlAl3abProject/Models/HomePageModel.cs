using BL;
using Domains;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlAl3abProject.Models
{
    public class HomePageModel
    {
        #region Declaration


        public IEnumerable<ApplicationUser> UserData { get; set; }

        public string ImageProfile { get; set; }

        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

      

        public ApplicationUser OneUser { get; set; }


        public IEnumerable<ApplicationUser> lstUsers { get; set; }

        public IEnumerable<TbAboutU> lstAboutU { get; set; }

        public IEnumerable<TbBlog> lstBlogs { get; set; }

        public IEnumerable<TbBlogCategory> lstBlogCategories { get; set; }

        public IEnumerable<TbBlogComment> lstBlogComments { get; set; }

        public IEnumerable<TbBlogImage> lstBlogImages { get; set; }

        public IEnumerable<TbBlogCommentLike> lstBlogCommentLikes { get; set; }

        public IEnumerable<TbBlogItemSeller> lstBlogItemSellers { get; set; }


        public IEnumerable<TbCompanyType> lstCompanyTypes { get; set; }

        public IEnumerable<TbBlogTopic> lstBlogTopics { get; set; }

        public IEnumerable<TbCity> lstCities { get; set; }

        public IEnumerable<TbCompetition> lstCompetitions { get; set; }

        public IEnumerable<TbCompetitionRecord> lstCompetitionRecords { get; set; }

        public IEnumerable<TbCompetitionRule> lstCompetitionRules { get; set; }

        public IEnumerable<TbContactU> lstContactUs { get; set; }

        public IEnumerable<TbCountry> lstCountries { get; set; }

        public IEnumerable<TbCurrency> lstCurrencies { get; set; }

        public IEnumerable<TbEnebaReview> lstEnebaReviews { get; set; }

        public IEnumerable<TbEvaluation> lstEvaluations { get; set; }

        public IEnumerable<TbEvaluationCommentLike> lstEvaluationCommentLikes { get; set; }

        public IEnumerable<TbFaq> lstFaqs { get; set; }

        public IEnumerable<TbFaqcategory> lstFaqcategories { get; set; }

        public IEnumerable<TbFaqsubCategory> lstFaqsubCategories { get; set; }

        public IEnumerable<TbFavouriteCart> lstFavouriteCarts { get; set; }

        public IEnumerable<TbItem> lstItems { get; set; }

        public IEnumerable<TbItemSeller> lstItemSellers { get; set; }

        public IEnumerable<TbItemSubCategory> lstItemSubCategories { get; set; }

        public IEnumerable<TbMainCategory> lstMainCategories { get; set; }

        public IEnumerable<TbPolicyAndPrivacy> lstPolicyAndPrivacies { get; set; }

        public IEnumerable<TbProductSeller> lstProductSellers { get; set; }

        public IEnumerable<TbPromocode> lstPromocodes { get; set; }

        public IEnumerable<TbPromotingItemSeller> lstPromotingItemSellers { get; set; }

        public IEnumerable<TbPurchasingCart> lstPurchasingCarts { get; set; }

        public IEnumerable<TbRegion> lstRegions { get; set; }

        public IEnumerable<TbSeller> lstSellers { get; set; }

        public IEnumerable<TbSellerSubscribe> lstSellerSubscribes { get; set; }

        public IEnumerable<TbSetting> lstSettings { get; set; }

        public IEnumerable<TbOrder> lstOrders { get; set; }


        public IEnumerable<TbOrderDetails> lstOrderDetails { get; set; }

        public IEnumerable<TbSlider> lstSliders { get; set; }

        public IEnumerable<TbSubCategory> lstSubCategories { get; set; }

        public IEnumerable<TbTicket> lstTickets { get; set; }

        public IEnumerable<TbTicketCategory> lstTicketCategories { get; set; }

        public IEnumerable<TbTicketDiscussion> lstTicketDiscussions { get; set; }

        public IEnumerable<TbType> lstTypes { get; set; }

        public IEnumerable<TbWallet> lstWallets { get; set; }



        public IEnumerable<IdentityUserRole<string>> lstUserRole { get; set; }


        public IEnumerable<TbOperatingSystem> lstOperatingSystem { get; set; }



        public IEnumerable<TbItemSellerImages> lstItemSellerImages { get; set; }



        public IEnumerable<TbBlogTag> lstBlogTags { get; set; }


        public IEnumerable<TbBlogBlogTag> lstBlogBlogTags { get; set; }



















        #endregion
    }
}

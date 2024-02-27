using System;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BL
{
    public partial class AlAl3abDbContext : IdentityDbContext<ApplicationUser>
    {
        public AlAl3abDbContext()
        {
        }

        public AlAl3abDbContext(DbContextOptions<AlAl3abDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAboutU> TbAboutUs { get; set; }
        public virtual DbSet<TbBlog> TbBlogs { get; set; }
        public virtual DbSet<TbBlogCategory> TbBlogCategories { get; set; }
        public virtual DbSet<TbBlogComment> TbBlogComments { get; set; }
        public virtual DbSet<TbBlogCommentLike> TbBlogCommentLikes { get; set; }
        public virtual DbSet<TbBlogImage> TbBlogImages { get; set; }
        public virtual DbSet<TbBlogItemSeller> TbBlogItemSellers { get; set; }
        public virtual DbSet<TbBlogTopic> TbBlogTopics { get; set; }
        public virtual DbSet<TbCity> TbCities { get; set; }
        public virtual DbSet<TbCompetition> TbCompetitions { get; set; }
        public virtual DbSet<TbCompetitionRecord> TbCompetitionRecords { get; set; }
        public virtual DbSet<TbCompetitionRule> TbCompetitionRules { get; set; }
        public virtual DbSet<TbContactU> TbContactUs { get; set; }
        public virtual DbSet<TbCountry> TbCountries { get; set; }
        public virtual DbSet<TbCurrency> TbCurrencies { get; set; }
        public virtual DbSet<TbEnebaReview> TbEnebaReviews { get; set; }
        public virtual DbSet<TbEvaluation> TbEvaluations { get; set; }
        public virtual DbSet<TbEvaluationCommentLike> TbEvaluationCommentLikes { get; set; }
        public virtual DbSet<TbFaq> TbFaqs { get; set; }
        public virtual DbSet<TbFaqcategory> TbFaqcategories { get; set; }
        public virtual DbSet<TbFaqsubCategory> TbFaqsubCategories { get; set; }
        public virtual DbSet<TbFavouriteCart> TbFavouriteCarts { get; set; }
        public virtual DbSet<TbItem> TbItems { get; set; }
        public virtual DbSet<TbItemSeller> TbItemSellers { get; set; }
        public virtual DbSet<TbItemSubCategory> TbItemSubCategories { get; set; }
        public virtual DbSet<TbMainCategory> TbMainCategories { get; set; }
        public virtual DbSet<TbPolicyAndPrivacy> TbPolicyAndPrivacies { get; set; }
        public virtual DbSet<TbProductSeller> TbProductSellers { get; set; }
        public virtual DbSet<TbPromocode> TbPromocodes { get; set; }
        public virtual DbSet<TbPromotingItemSeller> TbPromotingItemSellers { get; set; }
        public virtual DbSet<TbPurchasingCart> TbPurchasingCarts { get; set; }
        public virtual DbSet<TbRegion> TbRegions { get; set; }
        public virtual DbSet<TbSeller> TbSellers { get; set; }
        public virtual DbSet<TbSellerSubscribe> TbSellerSubscribes { get; set; }
        public virtual DbSet<TbSetting> TbSettings { get; set; }
        public virtual DbSet<TbSlider> TbSliders { get; set; }
        public virtual DbSet<TbSubCategory> TbSubCategories { get; set; }
        public virtual DbSet<TbTicket> TbTickets { get; set; }
        public virtual DbSet<TbTicketCategory> TbTicketCategories { get; set; }
        public virtual DbSet<TbTicketDiscussion> TbTicketDiscussions { get; set; }
        public virtual DbSet<TbType> TbTypes { get; set; }
        public virtual DbSet<TbWallet> TbWallets { get; set; }

        public virtual DbSet<TbTransaction> TbTransactions { get; set; }

        public virtual DbSet<TbOperatingSystem> TbOperatingSystems { get; set; }


        public virtual DbSet<TbItemSellerImages> TbItemSellerImagess { get; set; }

        public virtual DbSet<TbOrder> TbOrders { get; set; }


        public virtual DbSet<TbOrderDetails> TbOrderDetailss { get; set; }


        public virtual DbSet<TbCompanyType> TbCompanyTypies { get; set; }

        public virtual DbSet<VwItemSellerEvalauationParameters> VwItemSellerEvalauationParameterss { get; set; }

        public virtual DbSet<VwItemSellerFavouriteCount> VwItemSellerFavouriteCounts { get; set; }

        public virtual DbSet<VwHighestSalesIteSeller> VwHighestSalesIteSellers { get; set; }


        public virtual DbSet<TbBlogTag> TbBlogTags { get; set; }


        public virtual DbSet<TbBlogBlogTag> TbBlogBlogTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAboutU>(entity =>
            {
                entity.HasKey(e => e.AboutUsId);

                entity.Property(e => e.AboutUsId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasColumnType("nvarchar(max)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.FirstText).HasColumnType("nvarchar(max)");

                entity.Property(e => e.FirstTitle).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.SecondText).HasColumnType("nvarchar(max)");

                entity.Property(e => e.SecondTitle).HasMaxLength(200);

                entity.Property(e => e.ThirdTtitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasColumnType("nvarchar(max)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbBlog>(entity =>
            {
                entity.HasKey(e => e.BlogId);

                entity.ToTable("TbBlog");

                entity.Property(e => e.BlogId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BlogCategoryName).HasMaxLength(200);

                entity.Property(e => e.BlogShortDescription).HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.BlogTitle).HasMaxLength(200);

                entity.Property(e => e.BlogTopicName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.SellerName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.BlogCategory)
                    .WithMany(p => p.TbBlogs)
                    .HasForeignKey(d => d.BlogCategoryId)
                    .HasConstraintName("FK_TbBlog_TbBlogCategory");

                entity.HasOne(d => d.BlogTopic)
                    .WithMany(p => p.TbBlogs)
                    .HasForeignKey(d => d.BlogTopicId)
                    .HasConstraintName("FK_TbBlog_TbBlogTopic");
            });

            modelBuilder.Entity<TbBlogCategory>(entity =>
            {
                entity.HasKey(e => e.BlogCategoryId);

                entity.ToTable("TbBlogCategory");

                entity.Property(e => e.BlogCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BlogCategoryName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbBlogComment>(entity =>
            {
                entity.HasKey(e => e.BlogCommentId);

                entity.ToTable("TbBlogComment");

                entity.Property(e => e.BlogCommentId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CommentSyntax).HasMaxLength(200);

                entity.Property(e => e.CommenterEmail).HasMaxLength(200);

                entity.Property(e => e.CommenterId).HasMaxLength(200);

                entity.Property(e => e.CommenterName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.TbBlogComments)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_TbBlogComment_TbBlog");
            });

            modelBuilder.Entity<TbBlogCommentLike>(entity =>
            {
                entity.HasKey(e => e.BlogCommentLikeId);

                entity.ToTable("TbBlogCommentLike");

                entity.Property(e => e.BlogCommentLikeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActionPersonEmail).HasMaxLength(200);

                entity.Property(e => e.ActionPersonId).HasMaxLength(200);

                entity.Property(e => e.ActionPersonName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DislikeAction).HasMaxLength(200);

                entity.Property(e => e.LikeAction).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.BlogComment)
                    .WithMany(p => p.TbBlogCommentLikes)
                    .HasForeignKey(d => d.BlogCommentId)
                    .HasConstraintName("FK_TbBlogCommentLike_TbBlogComment");
            });

            modelBuilder.Entity<TbBlogImage>(entity =>
            {
                entity.HasKey(e => e.BlogImageId);

                entity.ToTable("TbBlogImage");

                entity.Property(e => e.BlogImageId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BlogImageMain).HasMaxLength(200);

                entity.Property(e => e.BlogImagePath).HasMaxLength(200);

                entity.Property(e => e.BlogImageText).HasMaxLength(200);

                entity.Property(e => e.BlogImageTitle).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.TbBlogImages)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_TbBlogImage_TbBlog");
            });

            modelBuilder.Entity<TbBlogItemSeller>(entity =>
            {
                entity.HasKey(e => e.BlogItemSellerId);

                entity.ToTable("TbBlogItemSeller");

                entity.Property(e => e.BlogItemSellerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.ItemPrice).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.SellerName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.TbBlogItemSellers)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_TbBlogItemSeller_TbBlog");
            });

            modelBuilder.Entity<TbBlogTopic>(entity =>
            {
                entity.HasKey(e => e.BlogTopicId);

                entity.ToTable("TbBlogTopic");

                entity.Property(e => e.BlogTopicId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BlogTopicName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbOperatingSystem>(entity =>
            {
                entity.HasKey(e => e.OperatingSystemId);

                entity.ToTable("TbOperatingSystem");

                entity.Property(e => e.OperatingSystemId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OperatingSystemName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("TbCity");

                entity.Property(e => e.CityId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCompetition>(entity =>
            {
                entity.HasKey(e => e.CompetitionId);

                entity.ToTable("TbCompetition");

                entity.Property(e => e.CompetitionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompetitionTitle).HasMaxLength(200);

                entity.Property(e => e.CompetitonImagePath).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCompetitionRecord>(entity =>
            {
                entity.HasKey(e => e.CompetitionRecordId);

                entity.ToTable("TbCompetitionRecord");

                entity.Property(e => e.CompetitionRecordId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.NoOfPoints).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.TbCompetitionRecords)
                    .HasForeignKey(d => d.CompetitionId)
                    .HasConstraintName("FK_TbCompetitionRecord_TbCompetition");
            });

            modelBuilder.Entity<TbCompetitionRule>(entity =>
            {
                entity.HasKey(e => e.CompetitionRulesId);

                entity.ToTable("TbCompetitionRule");

                entity.Property(e => e.CompetitionRulesId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Action).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Link).HasMaxLength(200);

                entity.Property(e => e.NoOfPoints).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.RuleName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.TbCompetitionRules)
                    .HasForeignKey(d => d.CompetitionId)
                    .HasConstraintName("FK_TbCompetitionRule_TbCompetition");
            });

            modelBuilder.Entity<TbContactU>(entity =>
            {
                entity.HasKey(e => e.ContactUsId);

                entity.Property(e => e.ContactUsId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BusinessDevelopementEmail).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.LegalDepartmentEmail).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("TbCountry");

                entity.Property(e => e.CountryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CountryImagePath).HasMaxLength(200);

                entity.Property(e => e.CountryName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.ToTable("TbCurrency");

                entity.Property(e => e.CurrencyId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrencyName).HasMaxLength(200);

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbEnebaReview>(entity =>
            {
                entity.HasKey(e => e.EnebaReviewId);

                entity.ToTable("TbEnebaReview");

                entity.Property(e => e.EnebaReviewId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ReplyBack).HasMaxLength(200);

                entity.Property(e => e.ReviewText).HasMaxLength(200);

                entity.Property(e => e.ReviewTitle).HasMaxLength(200);

                entity.Property(e => e.StarsNo).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<TbEvaluation>(entity =>
            {
                entity.HasKey(e => e.EvaluationId);

                entity.ToTable("TbEvaluation");

                entity.Property(e => e.EvaluationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EvaluationText).HasMaxLength(200);

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ParameterFourNumber).HasMaxLength(200);

                entity.Property(e => e.ParameterFourStarts).HasMaxLength(200);

                entity.Property(e => e.ParameterOneNumer).HasMaxLength(200);

                entity.Property(e => e.ParameterOneStarts).HasMaxLength(200);

                entity.Property(e => e.ParameterThreeStarts).HasMaxLength(200);

                entity.Property(e => e.ParameterTwoNumber).HasMaxLength(200);

                entity.Property(e => e.ParameterwoStarts).HasMaxLength(200);

                entity.Property(e => e.ParamterThreeNumber).HasMaxLength(200);

                entity.Property(e => e.SellerName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<TbEvaluationCommentLike>(entity =>
            {
                entity.HasKey(e => e.EvaluationCommentLikeId);

                entity.ToTable("TbEvaluationCommentLike");

                entity.Property(e => e.EvaluationCommentLikeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DislikeAction).HasMaxLength(200);

                entity.Property(e => e.LikeAction).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserEmail).HasMaxLength(200);

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);

                entity.HasOne(d => d.Evaluation)
                    .WithMany(p => p.TbEvaluationCommentLikes)
                    .HasForeignKey(d => d.EvaluationId)
                    .HasConstraintName("FK_TbEvaluationCommentLike_TbEvaluation");
            });

            modelBuilder.Entity<TbFaq>(entity =>
            {
                entity.HasKey(e => e.Faqid);

                entity.ToTable("TbFAQ");

                entity.Property(e => e.Faqid)
                    .HasColumnName("FAQId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Faqanswer)
                    .HasColumnType("nvarchar(MAX)")
                    .HasColumnName("FAQAnswer");

                entity.Property(e => e.Faqquestion)
                    .HasMaxLength(200)
                    .HasColumnName("FAQQuestion");

                entity.Property(e => e.FaqsubCategoryId).HasColumnName("FAQSubCategoryId");

                entity.Property(e => e.FaqsubCategoryName)
                    .HasMaxLength(200)
                    .HasColumnName("FAQSubCategoryName");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FaqsubCategory)
                    .WithMany(p => p.TbFaqs)
                    .HasForeignKey(d => d.FaqsubCategoryId)
                    .HasConstraintName("FK_TbFAQ_TbFAQSubCategory");
            });

            modelBuilder.Entity<TbFaqcategory>(entity =>
            {
                entity.HasKey(e => e.FaqcategoryId);

                entity.ToTable("TbFAQCategory");

                entity.Property(e => e.FaqcategoryId)
                    .HasColumnName("FAQCategoryId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.FaqcategoryName)
                    .HasMaxLength(200)
                    .HasColumnName("FAQCategoryName");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFaqsubCategory>(entity =>
            {
                entity.HasKey(e => e.FaqsubCategoryId);

                entity.ToTable("TbFAQSubCategory");

                entity.Property(e => e.FaqsubCategoryId)
                    .HasColumnName("FAQSubCategoryId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.FaqcategoryId).HasColumnName("FAQCategoryId");

                entity.Property(e => e.FaqcategoryName)
                    .HasMaxLength(200)
                    .HasColumnName("FAQCategoryName");

                entity.Property(e => e.FaqsubCategoryName)
                    .HasMaxLength(200)
                    .HasColumnName("FAQSubCategoryName");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Faqcategory)
                    .WithMany(p => p.TbFaqsubCategories)
                    .HasForeignKey(d => d.FaqcategoryId)
                    .HasConstraintName("FK_TbFAQSubCategory_TbFAQCategory");
            });

            modelBuilder.Entity<TbFavouriteCart>(entity =>
            {
                entity.HasKey(e => e.FavouriteCartId);

                entity.ToTable("TbFavouriteCart");

                entity.Property(e => e.FavouriteCartId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemImagePath).HasMaxLength(200);

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.ItemSalePrice).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.Region).HasMaxLength(200);

                entity.Property(e => e.SellerItemEvaluationNumbers).HasMaxLength(200);

                entity.Property(e => e.SellerItemEvaluationStarts).HasMaxLength(200);

                entity.Property(e => e.SellerName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<TbItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("TbItem");

                entity.Property(e => e.ItemId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DigitalKey).HasMaxLength(200);

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.OperatingSystemId).HasColumnType("uniqueidentifier");

                entity.Property(e => e.Region).HasMaxLength(200);

                entity.Property(e => e.UpComingGames).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorksOn).HasMaxLength(200);

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.TbItems)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_TbItem_TbRegion");
            });

            modelBuilder.Entity<TbItemSeller>(entity =>
            {
                entity.HasKey(e => e.ItemSellerId);

                entity.ToTable("TbItemSeller");

                entity.Property(e => e.ItemSellerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EvaluatersNumbers).HasMaxLength(200);

                entity.Property(e => e.ItemImagePath).HasMaxLength(200);

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.ItemSalePrice).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.Promoted).HasMaxLength(200);

                entity.Property(e => e.Region).HasMaxLength(200);

                entity.Property(e => e.SellerItemEvaluationNumbers).HasMaxLength(200);

                entity.Property(e => e.SellerItemEvaluationStarts).HasMaxLength(200);

                entity.Property(e => e.SellerName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WebsiteProfitMargin).HasMaxLength(200);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbItemSellers)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_TbItemSeller_TbItem");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.TbItemSellers)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_TbItemSeller_TbRegion");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.TbItemSellers)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK_TbItemSeller_TbSeller");
            });

            modelBuilder.Entity<TbItemSubCategory>(entity =>
            {
                entity.HasKey(e => e.ItemSubCategoryId);

                entity.ToTable("TbItemSubCategory");

                entity.Property(e => e.ItemSubCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbItemSubCategories)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_TbItemSubCategory_TbItem");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TbItemSubCategories)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_TbItemSubCategory_TbSubCategory");
            });

            modelBuilder.Entity<TbMainCategory>(entity =>
            {
                entity.HasKey(e => e.MainCategoryId);

                entity.ToTable("TbMainCategory");

                entity.Property(e => e.MainCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.MainCategoryDescription).HasMaxLength(200);

                entity.Property(e => e.MainCategoryTitle).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TbMainCategories)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_TbMainCategory_TbType");
            });

            modelBuilder.Entity<TbPolicyAndPrivacy>(entity =>
            {
                entity.HasKey(e => e.PoliciesAndPrivacyId);

                entity.ToTable("TbPolicyAndPrivacy");

                entity.Property(e => e.PoliciesAndPrivacyId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PoliciesAndPrivacyDescription).HasMaxLength(200);

                entity.Property(e => e.PoliciesAndPrivacyForWhom).HasMaxLength(200);

                entity.Property(e => e.PoliciesAndPrivacyTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbProductSeller>(entity =>
            {
                entity.HasKey(e => e.SellerProductId);

                entity.ToTable("TbProductSeller");

                entity.Property(e => e.SellerProductId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.SellerName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPromocode>(entity =>
            {
                entity.HasKey(e => e.PromocodeId);

                entity.ToTable("TbPromocode");

                entity.Property(e => e.PromocodeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PromocodeDiscountPercent).HasMaxLength(200);

                entity.Property(e => e.PromocodeTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPromotingItemSeller>(entity =>
            {
                entity.HasKey(e => e.PromotingItemSellerId);

                entity.ToTable("TbPromotingItemSeller");

                entity.Property(e => e.PromotingItemSellerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PromotioValue).HasMaxLength(200);

                entity.Property(e => e.SellerName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPurchasingCart>(entity =>
            {
                entity.HasKey(e => e.PurchasingCartId);

                entity.ToTable("TbPurchasingCart");

                entity.Property(e => e.PurchasingCartId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemImagePath).HasMaxLength(200);

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.ItemSalePrice).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.Region).HasMaxLength(200);

                entity.Property(e => e.SellerItemEvaluationNumbers).HasMaxLength(200);

                entity.Property(e => e.SellerItemEvaluationStarts).HasMaxLength(200);

                entity.Property(e => e.SellerName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<TbRegion>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.ToTable("TbRegion");

                entity.Property(e => e.RegionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.RegionName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSeller>(entity =>
            {
                entity.HasKey(e => e.SellerId);

                entity.ToTable("TbSeller");

                entity.Property(e => e.SellerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.ApiServices).HasMaxLength(200);

                entity.Property(e => e.BusinessAddress).HasMaxLength(200);

                entity.Property(e => e.BusinessCityName).HasMaxLength(200);

                entity.Property(e => e.BusinessCountry).HasMaxLength(200);

                entity.Property(e => e.BusinessTradeName).HasMaxLength(200);

                entity.Property(e => e.BusinessWebsite).HasMaxLength(200);

                entity.Property(e => e.BusinessZipCode).HasMaxLength(200);

                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.Property(e => e.CompanyName).HasMaxLength(200);

                entity.Property(e => e.CompanyType)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CountryName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DateOfBirth).HasMaxLength(200);

                entity.Property(e => e.DocumentA).HasMaxLength(200);

                entity.Property(e => e.DocumentB).HasMaxLength(200);

                entity.Property(e => e.DocumentC).HasMaxLength(200);

                entity.Property(e => e.DocumentD).HasMaxLength(200);

                entity.Property(e => e.DocumentE).HasMaxLength(200);

                entity.Property(e => e.DocumentF).HasMaxLength(200);

                entity.Property(e => e.NoOfSkus)
                    .HasMaxLength(200)
                    .HasColumnName("NoOfSKUs");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.QtyAvailabeToSell).HasMaxLength(200);

                entity.Property(e => e.RefrenceId).HasMaxLength(200);

                entity.Property(e => e.SellerEmail).HasMaxLength(200);

                entity.Property(e => e.SellerFullName).HasMaxLength(200);

                entity.Property(e => e.SellerPhoneNumber).HasMaxLength(200);

                entity.Property(e => e.TaxIdentificationNo).HasMaxLength(200);

                entity.Property(e => e.TypesOfItems).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VatNumber).HasMaxLength(200);

                entity.Property(e => e.WbesiteProfitMargin).HasMaxLength(200);

                entity.Property(e => e.ZipCode).HasMaxLength(200);
            });

            modelBuilder.Entity<TbSellerSubscribe>(entity =>
            {
                entity.HasKey(e => e.SellerSubscribeId);

                entity.ToTable("TbSellerSubscribe");

                entity.Property(e => e.SellerSubscribeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasMaxLength(200);

                entity.Property(e => e.SubscribeFees).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WebsiteProfitMargin).HasMaxLength(200);

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.TbSellerSubscribes)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK_TbSellerSubscribe_TbSeller");
            });

            modelBuilder.Entity<TbSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("TbSetting");

                entity.Property(e => e.SettingId).HasDefaultValueSql("(newid())");

               

                entity.Property(e => e.AppProfitPercent)
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.OffersValidityDays)
                   .HasMaxLength(200);
                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueAddedTax)
                   .HasMaxLength(200);
            });

            modelBuilder.Entity<TbSlider>(entity =>
            {
                entity.HasKey(e => e.SliderId);

                entity.ToTable("TbSlider");

                entity.Property(e => e.SliderId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Location).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.SliderDescription).HasMaxLength(200);

                entity.Property(e => e.SliderImagePath).HasMaxLength(200);

                entity.Property(e => e.SliderOrderNo).HasMaxLength(200);

                entity.Property(e => e.SliderTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("TbSubCategory");

                entity.Property(e => e.SubCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.SubCategoryDescription).HasMaxLength(200);

                entity.Property(e => e.SubCategoryTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.MainCategory)
                    .WithMany(p => p.TbSubCategories)
                    .HasForeignKey(d => d.MainCategoryId)
                    .HasConstraintName("FK_TbSubCategory_TbMainCategory");
            });

            modelBuilder.Entity<TbTicket>(entity =>
            {
                entity.HasKey(e => e.TicketId);

                entity.ToTable("TbTicket");

                entity.Property(e => e.TicketId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                     .HasColumnType("datetime")
                     .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.TicketText).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);

                entity.HasOne(d => d.TicketCategory)
                    .WithMany(p => p.TbTickets)
                    .HasForeignKey(d => d.TicketCategoryId)
                    .HasConstraintName("FK_TbTicket_TbTicketCategory");
            });

            modelBuilder.Entity<TbTicketCategory>(entity =>
            {
                entity.HasKey(e => e.TicketCategoryId);

                entity.ToTable("TbTicketCategory");

                entity.Property(e => e.TicketCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.TicketCategoryName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTicketDiscussion>(entity =>
            {
                entity.HasKey(e => e.TicketDiscussionId);

                entity.ToTable("TbTicketDiscussion");

                entity.Property(e => e.TicketDiscussionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.RecieverId).HasMaxLength(200);

                entity.Property(e => e.SenderId).HasMaxLength(200);

                entity.Property(e => e.TicketText).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TbTicketDiscussions)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_TbTicketDiscussion_TbTicket");
            });

            modelBuilder.Entity<TbType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("TbType");

                entity.Property(e => e.TypeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.TypeDescription).HasMaxLength(200);

                entity.Property(e => e.TypeTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbWallet>(entity =>
            {
                entity.HasKey(e => e.WalletId);

                entity.ToTable("TbWallet");

                entity.Property(e => e.WalletId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.TransactionType).HasMaxLength(200);

                entity.Property(e => e.TransactionValue).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<VwItemSellerEvalauationParameters>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwItemSellerEvalauationParameters");


            });

            modelBuilder.Entity<VwItemSellerFavouriteCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwItemSellerFavouriteCount");


            });

            modelBuilder.Entity<VwHighestSalesIteSeller>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwHighestSalesIteSeller");


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

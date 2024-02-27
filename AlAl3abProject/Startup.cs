using AlAl3abProject.Helpers;
using AlAl3abProject.Models;
using AlAl3abProject.Resources;
using AlAl3abProject.Services;
using BL;
using Domains.Resources;
using EmailService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AlAl3abProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfig = Configuration
     .GetSection("EmailConfiguration")
     .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = "975214719409-pp37jcmifi7bg33254ve18ku83telt9r.apps.googleusercontent.com";
                options.ClientSecret = "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";


            });



            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "1387677424973135";
                options.AppSecret = "de6fc7e479121219c97a2e079eee1b3e";
            });
            services.AddScoped<AbousUsService, ClsAboutU>();
            services.AddScoped<BlogService, ClsBlog>();
            services.AddScoped<BlogCategoryService, ClsBlogCategory>();
            services.AddScoped<BlogCommentService, ClsBlogComment>();
            services.AddScoped<BlogCommentLikeService, ClsBlogCommentLike>();
            services.AddScoped<BlogImageService, ClsBlogImage>();
            services.AddScoped<BlogItemSellerService, ClsBlogItemSeller>();
            services.AddScoped<BlogTopicService, ClsBlogTopic>();
            services.AddScoped<CityService, ClsCity>();
            services.AddScoped<CompetitionService, ClsCompetition>();
            services.AddScoped<CompeitionRecordService, ClsCompetitionRecord>();
            services.AddScoped<CompeitionRuleService, ClsCompetitionRule>();
            services.AddScoped<ContactUService, ClsContactU>();
            services.AddScoped<CountryService, ClsCountry>();
            services.AddScoped<CurrencyService, ClsCurrency>();
            services.AddScoped<EnebaReviewService, ClsEnebaReview>();
            services.AddScoped<EvaluationService, ClsEvaluation>();
            services.AddScoped<EvaluationCommentLikeService, ClsEvaluationCommentLike>();
            services.AddScoped<FaqService, ClsFaq>();
            services.AddScoped<FaqcategoryService, ClsFaqcategory>();
            services.AddScoped<FaqsubCategoryService, ClsFaqsubCategory>();
            services.AddScoped<FaqsubCategoryService, ClsFaqsubCategory>();
            services.AddScoped<FavouriteCartService, ClsFavouriteCart>();
            services.AddScoped<ItemService, ClsItem>();
            services.AddScoped<ItemSellerService, ClsItemSeller>();
            services.AddScoped<ItemSubCategoryService, ClsItemSubCategory>();
            services.AddScoped<MainCategoryService, ClsMainCategory>();
            services.AddScoped<PolicyAndPrivacyService, ClsPolicyAndPrivacy>();
            services.AddScoped<ProductSellerService, ClsProductSeller>();
            services.AddScoped<PromocodeService, ClsPromocode>();
            services.AddScoped<PromotingItemSellerService, ClsPromotingItemSeller>();
            services.AddScoped<PurchasingCartService, ClsPurchasingCart>();
            services.AddScoped<RegionService, ClsRegion>();
            services.AddScoped<SellerService, ClsSeller>();
            services.AddScoped<SellerSubscribeService, ClsSellerSubscribe>();
            services.AddScoped<SettingService, ClsSetting>();
            services.AddScoped<SliderService, ClsSlider>();
            services.AddScoped<SubCategoryService, ClsSubCategory>();
            services.AddScoped<TicketService, ClsTicket>();
            services.AddScoped<TicketCategoryService, ClsTicketCategory>();
            services.AddScoped<TicketDiscussionService, ClsTicketDiscussion>();
            services.AddScoped<TypeService, ClsType>();
            services.AddScoped<WalletService, ClsWallet>();
            services.AddScoped<OperatingSystemService, ClsOperatingSystem>();
            services.AddScoped<ItemSellerImageService, ClsItemSellerImage>();
            services.AddScoped<OrderDetailsService, ClsOrderDetails>();
            services.AddScoped<OrderService, ClsOrder>();
            services.AddScoped<BlogTagService, ClsBlogTag>();
            services.AddScoped<BlogBlogTagService, ClsBlogBlogTag>();
            services.AddScoped<CompanyTybeService, ClsCompanyType>();
            services.Configure<TwilioSettings>(Configuration.GetSection("Twilio"));
            services.AddTransient<ISMSService, SMSService>();
            services.AddControllersWithViews();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddDbContext<AlAl3abDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            ResWebsite.Culture = ResDomains.Culture = new CultureInfo("en");
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.AllowedUserNameCharacters = "";
                options.Password.RequireDigit = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.User.AllowedUserNameCharacters = string.Empty;

            }).AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<AlAl3abDbContext>().AddDefaultTokenProviders();    ///.AddDefaultUI();


            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Home/login");
                opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Accessdenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var supportedCultures = new[] { "en-US", "ar-EG", "fr" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
        public static bool ChangeLanguage()
        {
            if (ResWebsite.Culture.Name == "en")
                ResWebsite.Culture = new CultureInfo("ar");
            else
                ResWebsite.Culture = new CultureInfo("en");

            return true;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AlAl3abProject.Models;
using BL;
using System.Globalization;
using AlAl3abProject.Resources;
using Domains.Resources;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AlAl3abProject.Services;
using EmailService;
using System.Text.Encodings.Web;
using MimeKit.Encodings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlAl3abProject.Controllers
{
   
    public class HomeController : Controller
    {
       
        private readonly ItemSubCategoryService itemSubCategoryService;
        private readonly ItemService itemService;
        private readonly TypeService typeService;
        private readonly ItemSellerService itemSellerService;
        private readonly MainCategoryService mainCategoryService;
        private readonly SubCategoryService subCategoryService;
        private readonly SliderService sliderService;
        private readonly ILogger<HomeController> _logger;
        private readonly AlAl3abDbContext _alAl3abDbContext;
        private readonly ISMSService _smsService;
       private readonly PurchasingCartService _purchasingCartService;
        private readonly UserManager<ApplicationUser> _userManager;
        //one
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IEmailSender _emailSender;
        private readonly UrlEncoder _urlEncoder;
        private readonly IEmailSender _emailSender;
        public HomeController( ItemSubCategoryService ItemSubCategoryService, ItemService ItemService, TypeService TypeService, ItemSellerService ItemSellerService, MainCategoryService MainCategoryService, SubCategoryService SubCategoryService, SliderService SliderService, ILogger<HomeController> logger, AlAl3abDbContext alAl3abDbContext,
            ISMSService smsService, IEmailSender emailSender, AlAl3abDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            UrlEncoder urlEncoder, RoleManager<IdentityRole> roleManager
, PurchasingCartService purchasingCartService


            )
        {
            _logger = logger;
            _alAl3abDbContext = alAl3abDbContext;
            typeService = TypeService;
            itemSellerService = ItemSellerService;
            mainCategoryService = MainCategoryService;
            subCategoryService = SubCategoryService;
            sliderService = SliderService;
            itemService = ItemService;
            itemSubCategoryService = ItemSubCategoryService;
            _userManager = userManager;

            _signInManager = signInManager;
            _urlEncoder = urlEncoder;
            _roleManager = roleManager;
            _emailSender = emailSender;

            _smsService = smsService;
            _purchasingCartService = purchasingCartService;
          
          
           
        }

        public async Task<IActionResult> IndexAsync()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstItems = itemService.getAll().Where(A=> A.UpComingGames =="نعم");
            oIndexHomePageModel.lstItemSubCategoryBestSellingEGiftCards = itemSubCategoryService.getAll();
            oIndexHomePageModel.lstItemSubCategoryBestSellingGiftCards = itemSubCategoryService.getAll();
            oIndexHomePageModel.lstGameTop = itemSellerService.getAll();
            oIndexHomePageModel.lstRecommendedForYou = itemSellerService.getAll();
            oIndexHomePageModel.lstUpComingGames = itemSellerService.getAll();
            oIndexHomePageModel.lstBestSellingGiftCards = itemSellerService.getAll();
            oIndexHomePageModel.lstBestSellingEGiftCards = itemSellerService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            if (User.Identity.IsAuthenticated) 
            {
                int? subtotal = 0;
                var user = await _userManager
                    .GetUserAsync(User);
                oIndexHomePageModel.lstPurchasingCart = _purchasingCartService.getAll().Where(a => a.UserId == user.Id);
                foreach (var item in oIndexHomePageModel.lstPurchasingCart)
                {
                    subtotal += int.Parse(item.ItemSalePrice) * item.Quantity;
                }
                ViewBag.totalCart = subtotal.ToString();

            }
           
            //oIndexHomePageModel.lstMainCategoriesBestSellingEGiftCards = mainCategoryService.getAll().Where(a=> a.MainCategoryId == Guid.Parse("70558737-c4dd-4c46-acd0-6c25e58b238f")).ToList();
            //oIndexHomePageModel.lstMainCategoriesBestSellingGiftCards = mainCategoryService.getAll().Where(a => a.MainCategoryId == Guid.Parse("d4c45a7b-2f73-4a16-a044-f55ddd1f5a87")).ToList();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategoriesBestSellingEGiftCards = _alAl3abDbContext.TbSubCategories
     .Include(a => a.MainCategory)
     .Where(a => a.MainCategory != null && a.MainCategory.MainCategoryId == Guid.Parse("70558737-c4dd-4c46-acd0-6c25e58b238f"))
     .ToList();

            oIndexHomePageModel.lstSubCategoriesBestSellingGiftCards = _alAl3abDbContext.TbSubCategories
     .Include(a => a.MainCategory)
     .Where(a => a.MainCategory != null && a.MainCategory.MainCategoryId == Guid.Parse("d4c45a7b-2f73-4a16-a044-f55ddd1f5a87"))
     .ToList();


            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            //oIndexHomePageModel.lstSubCategories = _alAl3abDbContext.TbSubCategories.Include(a => a.MainCategory.MainCategoryId == Guid.Parse("70558737-c4dd-4c46-acd0-6c25e58b238f")).ToList();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
            oIndexHomePageModel.lstVwItemSellerEvalauationParameters = _alAl3abDbContext.VwItemSellerEvalauationParameterss.ToList();
            oIndexHomePageModel.lstVwItemSellerFavouriteCount = _alAl3abDbContext.VwItemSellerFavouriteCounts.ToList();
            oIndexHomePageModel.lstVwHighestSalesIteSeller = _alAl3abDbContext.VwHighestSalesIteSellers.ToList();
            foreach (var i in oIndexHomePageModel.lstGameTop) 
            {
                foreach(var e in oIndexHomePageModel.lstVwItemSellerEvalauationParameters) 
                {
                   if(i.ItemSellerId == e.ItemSellerId) 
                    {
                        i.SellerItemEvaluationNumbers = (e.ParameterOneStarts + e.ParameterwoStarts + e.ParameterThreeStarts + e.ParameterFourStarts).ToString();
                    }
                   
                }

            }
            foreach (var i in oIndexHomePageModel.lstGameTop)
            {
                foreach (var e in oIndexHomePageModel.lstVwItemSellerFavouriteCount)
                {
                    if (i.ItemSellerId == e.ItemSellerId)
                    {
                        i.NumberOfAddFavourite = e.NumberOfAdd;
                    }
                   
                }

            }

            foreach (var i in oIndexHomePageModel.lstRecommendedForYou)
            {
                foreach (var e in oIndexHomePageModel.lstVwHighestSalesIteSeller)
                {
                    if (i.ItemSellerId == e.ItemSellerId)
                    {
                        i.NumberOfSalesTransaction = (e.NumberOfSalesTransaction).ToString();
                    }
                    
                }

            }
            foreach (var i in oIndexHomePageModel.lstRecommendedForYou)
            {
                foreach (var e in oIndexHomePageModel.lstVwItemSellerFavouriteCount)
                {
                    if (i.ItemSellerId == e.ItemSellerId)
                    {
                        i.NumberOfAddFavourite = e.NumberOfAdd;
                    }
                   

                }

            }



            foreach (var i in oIndexHomePageModel.lstUpComingGames)
            {
                foreach (var e in oIndexHomePageModel.lstItems)
                {
                    if (i.ItemId == e.ItemId && e.UpComingGames =="نعم")
                    {
                        i.UpComingGames = e.UpComingGames;
                    }
                    
                }

            }
            foreach (var i in oIndexHomePageModel.lstUpComingGames)
            {
                foreach (var e in oIndexHomePageModel.lstVwItemSellerFavouriteCount)
                {
                    if (i.ItemSellerId == e.ItemSellerId)
                    {
                        i.NumberOfAddFavourite = e.NumberOfAdd;
                    }
                  

                }

            }

            foreach(var i in oIndexHomePageModel.lstItemSubCategoryBestSellingEGiftCards) 
            {
                foreach(var e in oIndexHomePageModel.lstSubCategoriesBestSellingEGiftCards) 
                {
                    if(i.SubCategoryId == e.SubCategoryId) 
                    {
                        i.EGiftCard = true;
                    }
                    else 
                    {
                        i.EGiftCard = false;
                    }
                }
            }


            foreach (var i in oIndexHomePageModel.lstBestSellingEGiftCards)

            {
                foreach (var e in oIndexHomePageModel.lstItemSubCategoryBestSellingEGiftCards.Where(a=> a.EGiftCard == true))
                {
                    if (i.ItemId == e.ItemId )
                    {
                        i.BestSellingEGiftCard =true;
                    }
                    else
                    {
                        i.BestSellingEGiftCard = false;
                    }
                }

            }
           
            foreach (var i in oIndexHomePageModel.lstBestSellingEGiftCards)
            {
                foreach (var e in oIndexHomePageModel.lstVwItemSellerFavouriteCount)
                {
                    if (i.ItemSellerId == e.ItemSellerId)
                    {
                        i.NumberOfAddFavourite = e.NumberOfAdd;
                    }
                   

                }

            }
            foreach (var i in oIndexHomePageModel.lstBestSellingEGiftCards)
            {
                foreach (var e in oIndexHomePageModel.lstVwItemSellerFavouriteCount)
                {
                    if (i.ItemSellerId == e.ItemSellerId)
                    {
                        i.NumberOfAddFavourite = e.NumberOfAdd;
                    }
                  

                }

            }



            foreach (var i in oIndexHomePageModel.lstItemSubCategoryBestSellingGiftCards)
            {
                foreach (var e in oIndexHomePageModel.lstSubCategoriesBestSellingGiftCards)
                {
                    if (i.SubCategoryId == e.SubCategoryId)
                    {
                        i.GiftCard = true;
                    }
                    else
                    {
                        i.GiftCard = false;
                    }
                }
            }


            foreach (var i in oIndexHomePageModel.lstBestSellingGiftCards)

            {
                foreach (var e in oIndexHomePageModel.lstItemSubCategoryBestSellingGiftCards.Where(a => a.GiftCard == true))
                {
                    if (i.ItemId == e.ItemId && e.GiftCard ==true)
                    {
                        i.BestSellingGiftCard = true;
                    }
                    else
                    {
                        i.BestSellingGiftCard = false;
                    }
                }

            }

            foreach (var i in oIndexHomePageModel.lstBestSellingGiftCards)
            {
                foreach (var e in oIndexHomePageModel.lstVwItemSellerFavouriteCount)
                {
                    if (i.ItemSellerId == e.ItemSellerId)
                    {
                        i.NumberOfAddFavourite = e.NumberOfAdd;
                    }
                   

                }

            }
            foreach (var i in oIndexHomePageModel.lstBestSellingGiftCards)
            {
                foreach (var e in oIndexHomePageModel.lstVwItemSellerFavouriteCount)
                {
                    if (i.ItemSellerId == e.ItemSellerId)
                    {
                        i.NumberOfAddFavourite = e.NumberOfAdd;
                    }
                  

                }

            }


            oIndexHomePageModel.lstGameTop=oIndexHomePageModel.lstGameTop.OrderByDescending(a => int.Parse(a.SellerItemEvaluationNumbers)).ToList();
            oIndexHomePageModel.lstRecommendedForYou = oIndexHomePageModel.lstRecommendedForYou.OrderByDescending(a => int.Parse(a.NumberOfSalesTransaction)).ToList();
            oIndexHomePageModel.lstUpComingGames = oIndexHomePageModel.lstUpComingGames.Where(a => a.UpComingGames == "نعم").ToList();
            oIndexHomePageModel.lstBestSellingEGiftCards = oIndexHomePageModel.lstBestSellingEGiftCards.OrderByDescending(a => int.Parse(a.NumberOfSalesTransaction)).Where(a=> a.BestSellingEGiftCard == true).ToList();
            oIndexHomePageModel.lstBestSellingGiftCards = oIndexHomePageModel.lstBestSellingGiftCards.OrderByDescending(a => int.Parse(a.NumberOfSalesTransaction)).Where(a => a.BestSellingGiftCard == true).ToList();
            return View(oIndexHomePageModel);
        }
        public IActionResult ChangeLanguage(string lang, string url , string typeid , string subcategoryid)
        {
            if (lang == "en")
            {
                ResWebsite.Culture = ResDomains.Culture = new CultureInfo("en");
            }
            else
            {
                ResWebsite.Culture = ResDomains.Culture = new CultureInfo("ar");
            }
            if(typeid !=null) 
            {
                url = url + "&typeid=" + typeid;
            }
            if (typeid != null && subcategoryid!=null)
            {
                url = url + "&typeid=" + typeid + "&subcategoryid=" + subcategoryid;
            }
            return Redirect(url);
        }
        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string returnurl = null)
        {
            //two
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                //create roles
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
            //three
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Value = "Admin",
                Text = "Admin"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "User",
                Text = "User"
            });



            ViewData["ReturnUrl"] = returnurl;
            //four    five registerview model //six register view
            RegisterViewModel registerViewModel = new RegisterViewModel()
            {
                RoleList = listItems
            };
            return View(registerViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(FormFileCollection files, RegisterViewModel model, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.Name, };
                //SendSMSDto dto = new SendSMSDto();
                //dto.MobileNumber = user.PhoneNumber;

                //var codeS = await _userManager.GenerateTwoFactorTokenAsync(user, "Phone");

                //user.OTP = codeS;



                //var message = "Your security code is: " + codeS;
                //dto.Body = message;
                //String messag = HttpUtility.UrlEncode("test test agin ");
                //String sender = HttpUtility.UrlEncode("Meam");

                //var resultt = _smsService.Send("31b01279bf48a7bc3d40b497adcfa409466eb30a", "966544140910", "966591351435", messag, sender);
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //seven
                    if (model.RoleSelected != null && model.RoleSelected.Length > 0 && model.RoleSelected == "Admin")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackurl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    var userEmail = user.Email;

                    var messages = new Message(new string[] { user.Email }, "Email From Customer " + "His name is " + user.UserName + "\n" + " His Email Is " + user.Email + "\n", "This is the content from our async email. i am happy", files, user.Id);

                    await _emailSender.SendEmaillConfirmAsync(messages, code, user.Id, user.Email);


                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    return View("EmailConfirmation");
                }
                AddErrors(result);
            }
            //eight
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Value = "Admin",
                Text = "Admin"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "User",
                Text = "User"
            });
            model.RoleList = listItems;
            return View(model);
        }

        public IActionResult forgotpassword()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult login(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(LoginViewModel model, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {


                    ApplicationUser use = _userManager.Users.Where(a => a.Email == model.Email).FirstOrDefault();
                    var claim = await _userManager.GetClaimsAsync(use);
                    if (claim.Count > 0)
                    {
                        try
                        {
                            await _userManager.RemoveClaimAsync(use, claim.FirstOrDefault(u => u.Type == "Name"));
                        }
                        catch (Exception)
                        {

                        }
                    }
                    await _userManager.AddClaimAsync(use, new System.Security.Claims.Claim("Name", use.Email));
                    return LocalRedirect(returnurl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(VerifyAuthenticatorCode), new { returnurl, model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }


            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnurl = null)
        {
            //request a redirect to the external login provider
            var redirecturl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnurl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirecturl);
            return Challenge(properties, provider);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnurl = null, string remoteError = null)
        {
            returnurl = returnurl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View(nameof(login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(login));
            }

            //Sign in the user with this external login provider, if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {


                //update any authentication tokens
                await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(VerifyAuthenticatorCode), new { returnurl, RememberMe = true });
                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    return LocalRedirect(returnurl);

                }

            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("VerifyAuthenticatorCode", new { returnurl = returnurl });
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            // If there is no record in AspNetUserLogins table, the user may not have
            // a local account
            else
            {
                // Get the email claim value
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    // Create a new user without password if we do not have a user already
                    var user = await _userManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                            FirstName = info.Principal.FindFirstValue(ClaimTypes.Email),


                            Image = "312287690_202877398916203_6801447073936034210_n.jpg"
                        };

                        await _userManager.CreateAsync(user);

                    }

                    // Add a login (i.e insert a row for the user in AspNetUserLogins table)
                    await _userManager.AddLoginAsync(user, info);
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToAction(nameof(VerifyAuthenticatorCode), new { returnurl, RememberMe = true });
                    }
                    if (result.IsLockedOut)
                    {
                        return View("Lockout");
                    }
                    else
                    {
                        return LocalRedirect(returnurl);

                    }

                }

                // If we cannot find the user email we cannot continue

            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("VerifyAuthenticatorCode", new { returnurl = returnurl });
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }

            else
            {
                //If the user does not have account, then we will ask the user to create an account.
                ViewData["ReturnUrl"] = returnurl;
                ViewData["ProviderDisplayName"] = info.ProviderDisplayName;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var name = info.Principal.FindFirstValue(ClaimTypes.Name);
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = email, Name = name });

            }
            ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
            ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";

            return View("Error");
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnurl = null)
        {
            returnurl = returnurl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                //get the info about the user from external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("Error");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.Name, Image = "312287690_202877398916203_6801447073936034210_n.jpg" };
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    //nine ten index
                    await _userManager.AddToRoleAsync(user, "User");
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                        return LocalRedirect(returnurl);
                    }
                }
                AddErrors(result);
            }
            ViewData["ReturnUrl"] = returnurl;
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyAuthenticatorCode(bool rememberMe, string returnUrl = null)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(new VerifyAuthenticatorViewModel { ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyAuthenticatorCode(VerifyAuthenticatorViewModel model)
        {
            model.ReturnUrl = model.ReturnUrl ?? Url.Content("~/");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(model.Code, model.RememberMe, rememberClient: false);

            if (result.Succeeded)
            {
                return LocalRedirect(model.ReturnUrl);
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Code.");
                return View(model);
            }

        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model, IFormFileCollection files)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return RedirectToAction("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackurl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

                var messages = new Message(new string[] { user.Email }, "Email From Customer " + "His name is " + user.UserName + "\n" + " His Email Is " + user.Email + "\n", "This is the content from our async email. i am happy", files, user.Id);

                await _emailSender.SendEmailAsync(messages, code, user.Id, user.Email);


                return RedirectToAction("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string UserId, string Code)
        {
            ResetPasswordViewModel resetPasswordModel = new ResetPasswordViewModel
            {
                Code = Code,
                UserId = UserId
            };
            return View(resetPasswordModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }
                model.Code = model.Code.Replace(' ', '+');
                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }
                AddErrors(result);
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }



    }
}

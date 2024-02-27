using AlAl3abProject.Models;
using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlAl3abProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogCategoryService _blogCategoryService;
        private readonly BlogTagService _blogTagService;
        private readonly BlogBlogTagService _blogBlogTagService;
        private readonly ItemSellerService _itemSellerService;
        private readonly BlogItemSellerService _blogItemSellerService;
        private readonly BlogTopicService _blogTopicService;
        private readonly BlogImageService _blogImageService;
        private readonly BlogService blogService;
        private readonly TypeService typeService;
        private readonly MainCategoryService mainCategoryService;
        private readonly SubCategoryService subCategoryService;
        private readonly SliderService sliderService;
        private readonly ILogger<HomeController> _logger;
        private readonly AlAl3abDbContext _alAl3abDbContext;
        public BlogController(BlogCategoryService blogCategoryService,BlogBlogTagService blogBlogTagService,BlogTagService blogTagService,ItemSellerService itemSellerService,BlogItemSellerService blogItemSellerService,BlogTopicService blogTopicService,BlogImageService blogImageService,BlogService BlogService,TypeService TypeService, MainCategoryService MainCategoryService, SubCategoryService SubCategoryService, SliderService SliderService, ILogger<HomeController> logger, AlAl3abDbContext alAl3abDbContext)
        {
            _blogCategoryService = blogCategoryService;
            _blogBlogTagService = blogBlogTagService;
            _blogTagService = blogTagService;
            _itemSellerService = itemSellerService;
            _blogItemSellerService = blogItemSellerService;
            _blogTopicService = blogTopicService;
            _blogImageService = blogImageService;
            blogService = BlogService;
            _logger = logger;
            _alAl3abDbContext = alAl3abDbContext;
            typeService = TypeService;
            mainCategoryService = MainCategoryService;
            subCategoryService = SubCategoryService;
            sliderService = SliderService;


        }
        public IActionResult Index()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
            oIndexHomePageModel.lstBlogTopics = _blogTopicService.getAll();
            oIndexHomePageModel.blog = blogService.getAll().Where(a => a.OrderNo == 1).FirstOrDefault();
            oIndexHomePageModel.BlogImage = _blogImageService.getAll().Where(a=> a.BlogId == oIndexHomePageModel.blog.BlogId).Where(a=> a.BlogImageMain == "نعم").FirstOrDefault();
            oIndexHomePageModel.lstBlogImages = _blogImageService.getAll().Where(a => a.BlogImageMain == "نعم").ToList();
            oIndexHomePageModel.lstBlogs = blogService.getAll();
            oIndexHomePageModel.lstBlogCategories = _blogCategoryService.getAll();
            return View(oIndexHomePageModel);
        }

        public IActionResult News(string id , string tag)
        {
            if(tag == null) 
            {
                IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
                oIndexHomePageModel.lstTypes = typeService.getAll();
                oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
                oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
                oIndexHomePageModel.lstSliders = sliderService.getAll();
                oIndexHomePageModel.lstBlogTopics = _blogTopicService.getAll();
                oIndexHomePageModel.lstBlogs = blogService.getAll().Where(a => a.BlogTopicId == Guid.Parse(id)).ToList();
                oIndexHomePageModel.lstBlogImages = _blogImageService.getAll().Where(a => a.BlogImageMain == "نعم").ToList();
                ViewBag.BlogTopicName = _blogTopicService.getAll().Where(a => a.BlogTopicId == Guid.Parse(id)).FirstOrDefault().BlogTopicName;
                ViewBag.BlogTopicNameEn = _blogTopicService.getAll().Where(a => a.BlogTopicId == Guid.Parse(id)).FirstOrDefault().BlogTopicNameEn;
                return View(oIndexHomePageModel);

            }
            else 
            {
                IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
                oIndexHomePageModel.lstTypes = typeService.getAll();
                oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
                oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
                oIndexHomePageModel.lstSliders = sliderService.getAll();
                oIndexHomePageModel.lstBlogTopics = _blogTopicService.getAll();
                oIndexHomePageModel.lstBlogBlogTag = _blogBlogTagService.getAll().Where(a => a.BlogTagId == Guid.Parse(tag));
                List<TbBlog> lstblogs = new List<TbBlog>();
                List<TbBlog> lstblogss = blogService.getAll();
                foreach (var item in oIndexHomePageModel.lstBlogBlogTag) 
                {
                    TbBlog oTbBlog = new TbBlog();
                    oTbBlog = lstblogss.Where(a => a.BlogId == item.BlogId).FirstOrDefault();
                    if(lstblogs.Any(item => item.BlogId == item.BlogId))
                    {
                        

                    }
                    else 
                    {
                        lstblogs.Add(oTbBlog);
                    }
                   

                }
                oIndexHomePageModel.lstBlogs = lstblogs;
                oIndexHomePageModel.lstBlogImages = _blogImageService.getAll().Where(a => a.BlogImageMain == "نعم").ToList();
                return View(oIndexHomePageModel);
            }
           
            
        }



        public IActionResult Features()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
            return View(oIndexHomePageModel);
        }




        public IActionResult Esports()
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
            return View(oIndexHomePageModel);
        }




        public IActionResult BlogDetails(string id)
        {
            IndexHomePageModel oIndexHomePageModel = new IndexHomePageModel();
            oIndexHomePageModel.lstTypes = typeService.getAll();
            oIndexHomePageModel.lstBlogTopics = _blogTopicService.getAll();
            oIndexHomePageModel.lstMainCategories = mainCategoryService.getAll();
            oIndexHomePageModel.lstSubCategories = subCategoryService.getAll();
            oIndexHomePageModel.lstSliders = sliderService.getAll();
            oIndexHomePageModel.lstBlogItemSellers = _blogItemSellerService.getAll().Where(a=> a.BlogId == Guid.Parse(id)).ToList();
            oIndexHomePageModel.blog = blogService.getAll().Where(a => a.BlogId == Guid.Parse(id)).FirstOrDefault();
            oIndexHomePageModel.lstItemSellers = _itemSellerService.getAll();
            oIndexHomePageModel.lstBlogBlogTag = _blogBlogTagService.getAll().Where(a=> a.BlogId == Guid.Parse(id));
            string input = oIndexHomePageModel.blog.CreatedBy;
            string[] parts = input.Split('=');

            if (parts.Length > 1)
            {
                string afterEquals = parts[1];
                ViewBag.LINK = afterEquals;
            }
            oIndexHomePageModel.lstBlogImages = _blogImageService.getAll().Where(a => a.BlogId == Guid.Parse(id)).ToList();
            oIndexHomePageModel.BlogImage = _blogImageService.getAll().Where(a => a.BlogId == oIndexHomePageModel.blog.BlogId).Where(a => a.BlogImageMain == "نعم").FirstOrDefault();
            return View(oIndexHomePageModel);
        }
    }
}

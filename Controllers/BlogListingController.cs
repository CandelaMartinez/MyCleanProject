using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using MyCleanProject.Site.Interfaces;
using MyCleanProject.Site.ViewModels.custom;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace MyCleanProject.Site.Controllers
{
    public class BlogListingController : RenderController
    {
        //dependency injection de IBlogService para obtener la lista de blogs convertida a BlogItemViewModel
        private IPublishedValueFallback _publishedValueFallback;
        private IBlogService _blogService;
        

        public BlogListingController(
              ILogger<BlogListingController> logger,
              ICompositeViewEngine compositeViewEngine,
              IUmbracoContextAccessor umbracoContextAccessor,
              IPublishedValueFallback publishedValueFallback,
              IBlogService blogService
             
           )
          : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _publishedValueFallback = publishedValueFallback;
            _blogService = blogService;
            
        }

                //create an instance of BlogListingViewModel 
        //with my service, I can get into my instance the published content  in a list of BlogItemViewModel
        public override IActionResult Index()
        {

            var blogListingVM = new BlogListingViewModel();
            blogListingVM.Blogs = _blogService.GetBlogs(); 
           

            return View("~/Views/BlogListing/index.cshtml",blogListingVM);
        }

  
    }
}

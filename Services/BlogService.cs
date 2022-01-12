using MyCleanProject.Site.Interfaces;
using MyCleanProject.Site.ViewModels.custom;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;
//as the project is named .Site, I am using an alias to the model generated Site
using SiteModel = Umbraco.Cms.Web.Common.PublishedModels.Site;

namespace MyCleanProject.Site.Services
{
    public class BlogService : IBlogService
    {
        private IUmbracoContextAccessor _context;

        public BlogService(IUmbracoContextAccessor context)
        {
            _context = context;
        }

        public IEnumerable<BlogItemViewModel> GetBlogs()
        {
            //get the context
            IUmbracoContext cache = _context.GetRequiredUmbracoContext();

            //get to Root and from Roote get the first descendant (or default if its null) of the type Site with the alias SiteModel 
            SiteModel site = cache.Content.GetAtRoot().DescendantsOrSelf<SiteModel>().FirstOrDefault();

            //get the first descendant of Site called BlogListing (or default if its null)
            BlogListing listing = site.DescendantsOrSelf<BlogListing>().FirstOrDefault();
            
            //get the list of descendants of BlogListing type model
            //Select them and get them listed to convert to BlogItemViewModel, my own type 
            IEnumerable<BlogItemViewModel> blogItemList = listing.Descendants<BlogItem>().Select(ConvertToBlogItemViewModel);

            return blogItemList;
        }

        private BlogItemViewModel ConvertToBlogItemViewModel(BlogItem blog)//, int arg2)
        {
            return new BlogItemViewModel
            {
                Title = blog.Title,
                ImageUrl = blog.Image.Url(),
                LinkUrl = blog.Url(),
                Content = blog.Content
            };
        }

    }
}

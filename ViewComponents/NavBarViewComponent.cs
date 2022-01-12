using Microsoft.AspNetCore.Mvc;
using MyCleanProject.Site.ViewModels.custom;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace MyCleanProject.Site.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        private IUmbracoContextAccessor _context;

        public NavBarViewComponent(IUmbracoContextAccessor context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int contentNodeId)
        {
            var contentNode = _context.GetRequiredUmbracoContext().Content.GetById(contentNodeId);
            var site = contentNode.Root() as Umbraco.Cms.Web.Common.PublishedModels.Site;

            var navBarVM = new NavBarViewModel();
            navBarVM.ListaNavBar = site.NavBar;
            navBarVM.SiteTitle = site.SiteTitle;

            return View(navBarVM);
        }

    }
}

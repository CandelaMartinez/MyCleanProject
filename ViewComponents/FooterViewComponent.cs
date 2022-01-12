using Microsoft.AspNetCore.Mvc;
using MyCleanProject.Site.ViewModels.custom;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace MyCleanProject.Site.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private IUmbracoContextAccessor _context;

        public FooterViewComponent(IUmbracoContextAccessor context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int contentNodeId)
        {
            var contentNode = _context.GetRequiredUmbracoContext().Content.GetById(contentNodeId);
            var site = contentNode.Root() as Umbraco.Cms.Web.Common.PublishedModels.Site;

            var footerVM = new FooterViewModel();
            footerVM.ListaFooterItems = site.Footer;

            return View(footerVM);
        }
    }
}

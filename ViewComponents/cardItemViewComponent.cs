using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCleanProject.Site.ViewComponents
{
    public class cardItemViewComponent : ViewComponent
    {
        private IPublishedValueFallback _publishedValueFallback;

        public cardItemViewComponent(
                IPublishedValueFallback publishedValueFallback)
        {
            _publishedValueFallback = publishedValueFallback;
        }

        public async Task<IViewComponentResult> InvokeAsync(IPublishedElement model)
        {
            var banner = new CardItem(model, _publishedValueFallback);
            return View(banner);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCleanProject.Site.ViewComponents
{
    public class cardContainerViewComponent : ViewComponent
    {
        private IPublishedValueFallback _publishedValueFallback;

        public cardContainerViewComponent(
                IPublishedValueFallback publishedValueFallback)
        {
            _publishedValueFallback = publishedValueFallback;
        }

        public async Task<IViewComponentResult> InvokeAsync(IPublishedElement model)
        {
            var banner = new CardContainer(model, _publishedValueFallback);
            return View(banner);
        }
    }
}

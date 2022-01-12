using Microsoft.Extensions.DependencyInjection;
using MyCleanProject.Site.Interfaces;
using MyCleanProject.Site.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace MyCleanProject.Site.Composers
{
    public class RegisterDependencies : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddTransient<IBlogService, BlogService>();
          
        }
    }
}

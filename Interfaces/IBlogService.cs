using MyCleanProject.Site.ViewModels.custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCleanProject.Site.Interfaces
{
    public interface IBlogService
    {
        IEnumerable<BlogItemViewModel> GetBlogs();

    }
}

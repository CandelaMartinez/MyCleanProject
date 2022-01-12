using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCleanProject.Site.ViewModels.custom
{
    public class NavBarViewModel
    {
        public IEnumerable<NavBarItem> ListaNavBar { get; set; }
        public String SiteTitle { get; set; }
    }
}

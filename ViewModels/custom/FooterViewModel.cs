using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCleanProject.Site.ViewModels.custom
{
    public class FooterViewModel
    {
        public IEnumerable<FooterItem> ListaFooterItems { get; set; }
    }
}

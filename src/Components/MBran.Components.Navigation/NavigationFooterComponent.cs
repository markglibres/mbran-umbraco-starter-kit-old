using MBran.Core;
using MBran.Core.Components;
using MBran.Models;

namespace MBran.Components.Navigation
{
    public class NavigationFooterComponent : Component
    {
        private readonly ISiteService _siteService;

        public NavigationFooterComponent(IContentHelper contentHelper, 
            ISiteService siteService)
            : base(contentHelper)
        {
            _siteService = siteService;
        }

        public override object GetViewModel()
        {
            var siteNav = _siteService.GetSite().As<NavigationFooter>();
            var listNav = siteNav?.NavigationListFooter?.ConvertTo<NavigationListNested>();

            return listNav;
        }
    }
}

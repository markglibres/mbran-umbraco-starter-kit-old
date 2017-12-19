using MBran.Core;
using MBran.Core.Components;
using MBran.Models;

namespace MBran.Components.Navigation
{
    public class NavigationHeaderComponent : Component
    {
        private readonly ISiteService _siteService;

        public NavigationHeaderComponent(IContentHelper contentHelper, 
            ISiteService siteService)
            : base(contentHelper)
        {
            _siteService = siteService;
        }

        public override object GetViewModel()
        {
            var siteHeaderNav = _siteService.GetSite().As<NavigationHeader>();
            var headerNav = siteHeaderNav.NavigationListHeader.ConvertTo<NavigationListNested>();

            return headerNav;
        }
    }
}

using MBran.Core;
using MBran.Core.Components;
using MBran.Models;

namespace MBran.Components.Navigation
{
    public class NavigationFooterUtilityComponent : Component
    {
        private readonly ISiteService _siteService;

        public NavigationFooterUtilityComponent(IContentHelper contentHelper, 
            ISiteService siteService)
            : base(contentHelper)
        {
            _siteService = siteService;
        }

        public override object GetViewModel()
        {
            var siteNav = _siteService.GetSite().As<NavigationFooterUtility>();
            var listNav = siteNav?.NavigationListFooterUtility?.ConvertTo<NavigationListNested>();

            return listNav;
        }
    }
}

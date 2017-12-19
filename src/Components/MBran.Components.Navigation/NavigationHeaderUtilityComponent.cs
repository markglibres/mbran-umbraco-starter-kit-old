using MBran.Core;
using MBran.Core.Components;
using MBran.Models;

namespace MBran.Components.Navigation
{
    public class NavigationHeaderUtilityComponent : Component
    {
        private readonly ISiteService _siteService;

        public NavigationHeaderUtilityComponent(IContentHelper contentHelper, 
            ISiteService siteService)
            : base(contentHelper)
        {
            _siteService = siteService;
        }

        public override object GetViewModel()
        {
            var siteNav = _siteService.GetSite().As<NavigationHeaderUtility>();
            var listNav = siteNav?.NavigationListHeaderUtility?.ConvertTo<NavigationListNested>();

            return listNav;
        }
    }
}

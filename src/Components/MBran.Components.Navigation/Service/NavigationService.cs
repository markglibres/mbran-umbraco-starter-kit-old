using MBran.Core;
using MBran.Models;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace MBran.Components.Navigation.Service
{
    public class NavigationService : INavigationService
    {
        private readonly SiteConfig _siteConfig;

        public NavigationService(ISiteService siteService)
        {
            _siteConfig = siteService.GetSite();
        }
        public IEnumerable<NavigationListNested> GetFooter()
        {
            var siteNav = _siteConfig.As<NavigationFooter>();
            return ParseNavigation(siteNav?.NavigationListFooter);
        }

        public IEnumerable<NavigationListNested> GetFooterUtility()
        {
            var siteNav = _siteConfig.As<NavigationFooterUtility>();
            return ParseNavigation(siteNav?.NavigationListFooterUtility);
        }

        public IEnumerable<NavigationListNested> GetHeader()
        {
            var siteNav = _siteConfig.As<NavigationHeader>();
            return ParseNavigation(siteNav?.NavigationListHeader);
        }

        public IEnumerable<NavigationListNested> GetHeaderUtility()
        {
            var siteNav = _siteConfig.As<NavigationHeaderUtility>();
            return ParseNavigation(siteNav?.NavigationListHeaderUtility);
        }

        private IEnumerable<NavigationListNested> ParseNavigation(IEnumerable<IPublishedContent> listing)
        {
            if(listing == null)
            {
                return new List<NavigationListNested>();
            }
            return listing.ConvertTo<NavigationListNested>();
        }
    }
}

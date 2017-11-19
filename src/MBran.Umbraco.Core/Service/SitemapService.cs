using MBran.Umbraco.Models;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;

namespace MBran.Umbraco.Core
{
    public class SiteMapService : ISitemapService
    {
        private readonly ISiteService _siteService;
        private readonly IXmlSerializerService _xmlSerializer;
        private readonly IContentHelper _contentHelper;
        private readonly int _startId;
        public SiteMapService(ISiteService siteService,
            IContentHelper contentHelper,
            IXmlSerializerService xmlSerializer)
        {
            _siteService = siteService;
            _xmlSerializer = xmlSerializer;
            _contentHelper = contentHelper;
            _startId = _siteService.GetHome().Id;
        }

        public SitemapXml GetSiteMap()
        {
            IEnumerable<SiteMapXmlItem> pages = GetSiteMapPages()
                .Select(page => new SiteMapXmlItem
                {
                    Location = page.UrlAbsolute(),
                    ChangeFrequency = page.GetChangeFrequency(),
                    Priority = page.SitemapPriority,
                    LastModified = page.UpdateDate
                });

            var siteMap = new SitemapXml
            {
                Items = pages.ToList()
            };

            return siteMap;
        }

        public string GetSiteMapAsXml()
        {
            SitemapXml siteMap = GetSiteMap();
            return _xmlSerializer.ToXmlString(siteMap);
        }

        public IEnumerable<ISitemapSettings> GetSiteMapPages()
        {
            IEnumerable<ISitemapSettings> pages = _contentHelper
                .GetDescendantsOrSelf<ISitemapSettings>(_startId)
                .Where(page => !page.UmbracoNaviHide);

            return pages;
        }
    }
}

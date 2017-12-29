using System.Collections.Generic;
using System.Linq;
using MBran.Components.Sitemap.Extensions;
using MBran.Components.Sitemap.Models;
using MBran.Core;
using MBran.Models;
using Umbraco.Web;

namespace MBran.Components.Sitemap.Service
{
    public class SiteMapService : ISitemapService
    {
        private readonly IXmlSerializerService _xmlSerializer;
        private readonly IContentHelper _contentHelper;
        private readonly int _startId;
        public SiteMapService(ISiteService siteService,
            IContentHelper contentHelper,
            IXmlSerializerService xmlSerializer)
        {
            _xmlSerializer = xmlSerializer;
            _contentHelper = contentHelper;
            _startId = siteService.GetHome().Id;
        }

        public SitemapXml GetSiteMap()
        {
            var pages = GetSiteMapPages()
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
            var siteMap = GetSiteMap();
            return _xmlSerializer.ToXmlString(siteMap);
        }

        public IEnumerable<ISitemapSettings> GetSiteMapPages()
        {
            var pages = _contentHelper
                .GetDescendantsOrSelf<ISitemapSettings>(_startId)
                .Where(page => !page.UmbracoNaviHide);

            return pages;
        }
    }
}

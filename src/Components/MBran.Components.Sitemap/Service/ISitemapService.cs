using System.Collections.Generic;
using MBran.Components.Sitemap.Models;
using MBran.Models;

namespace MBran.Components.Sitemap.Service
{
    public interface ISitemapService
    {
        SitemapXml GetSiteMap();
        IEnumerable<ISitemapSettings> GetSiteMapPages();
        string GetSiteMapAsXml();
    }
}

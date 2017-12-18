using MBran.Models;
using System.Collections.Generic;

namespace MBran.Components.Sitemap
{
    public interface ISitemapService
    {
        SitemapXml GetSiteMap();
        IEnumerable<ISitemapSettings> GetSiteMapPages();
        string GetSiteMapAsXml();
    }
}

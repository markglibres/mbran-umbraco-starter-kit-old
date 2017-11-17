using System.Collections.Generic;
using Umbraco.Core.Models;

namespace MBran.Umbraco.Core
{
    public interface ISitemapService
    {
        SitemapXml GetSiteMap();
        IEnumerable<ISitemapSettings> GetSiteMapPages();
        string GetSiteMapAsXml();
    }
}

using MBran.Core.Models;
using System.Collections.Generic;

namespace MBran.Core
{
    public interface ISitemapService
    {
        SitemapXml GetSiteMap();
        IEnumerable<ISitemapSettings> GetSiteMapPages();
        string GetSiteMapAsXml();
    }
}

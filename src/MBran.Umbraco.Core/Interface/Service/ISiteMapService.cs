﻿using MBran.Umbraco.Models;
using System.Collections.Generic;

namespace MBran.Umbraco.Core
{
    public interface ISitemapService
    {
        SitemapXml GetSiteMap();
        IEnumerable<ISitemapSettings> GetSiteMapPages();
        string GetSiteMapAsXml();
    }
}

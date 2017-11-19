﻿using MBran.Umbraco.Models;

namespace MBran.Umbraco.Core
{
    public interface ISiteService
    {
        SiteConfig GetSite();
        Home GetHome();
        Error404 GetErrorPage();
        int GetDomainNodeId();
        string GetDomain();
    }
}

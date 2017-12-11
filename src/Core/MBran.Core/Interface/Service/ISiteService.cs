using MBran.Core.Models;

namespace MBran.Core
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

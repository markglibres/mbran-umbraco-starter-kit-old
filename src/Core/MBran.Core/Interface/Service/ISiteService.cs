using MBran.Models;

namespace MBran.Core
{
    public interface ISiteService
    {
        SiteConfig GetSite();
        Home GetHome();
        int GetDomainNodeId();
        string GetDomain();
    }
}

using MBran.Models;

namespace MBran.Core
{
    public interface ISiteService
    {
        SiteConfig GetSite();
        Home GetHome();
        Error404 GetErrorPage();
        
    }
}

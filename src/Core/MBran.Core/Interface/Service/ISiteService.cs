using Umbraco.Core.Models;

namespace MBran.Core
{
    public interface ISiteService<T>
        where T: class, IPublishedContent
    {
        T GetSite();
        
    }
}

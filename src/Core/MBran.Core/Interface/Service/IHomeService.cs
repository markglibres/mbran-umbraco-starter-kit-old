using Umbraco.Core.Models;

namespace MBran.Core
{
    public interface IHomeService<T>
        where T: class, IPublishedContent
    {
        T GetHome();
        int GetDomainNodeId();
        string GetDomain();
    }
}

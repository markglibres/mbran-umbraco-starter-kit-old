using Umbraco.Core.Models;

namespace MBran.Core
{
    public interface IPageHelper
    {
        int CurrentPageId();
        IPublishedContent CurrentPage();
        T CurrentPage<T>() where T: class;
    }
}

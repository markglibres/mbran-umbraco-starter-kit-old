using Umbraco.Core.Models;

namespace MBran.Core
{
    public interface IErrorService<T>
        where T: class, IPublishedContent
    {
        T GetErrorPage();
    }
}

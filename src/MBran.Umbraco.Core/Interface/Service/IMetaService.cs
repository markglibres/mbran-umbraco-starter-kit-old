using MBran.Umbraco.Models;
using Umbraco.Core.Models;

namespace MBran.Umbraco.Core
{
    public interface IMetaService
    {
        MetaTitle GetHeader(IPublishedContent node = null);
        Image GetImage(IPublishedContent node = null);
    }
}

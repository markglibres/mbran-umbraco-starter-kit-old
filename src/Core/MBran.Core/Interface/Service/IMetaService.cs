using MBran.Core.Models;
using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Core
{
    public interface IMetaService
    {
        MetaTitle GetHeader(IPublishedContent node = null);
        Image GetImage(IPublishedContent node = null);
    }
}

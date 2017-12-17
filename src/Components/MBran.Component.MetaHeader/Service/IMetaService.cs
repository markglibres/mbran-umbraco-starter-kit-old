using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Components.MetaHeader
{
    public interface IMetaService
    {
        MetaTitle GetHeader(IPublishedContent node = null);
        Image GetImage(IPublishedContent node = null);
    }
}

using MBran.Components.MetaHeader.Models;
using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Components.MetaHeader.Service
{
    public interface IMetaService
    {
        MetaTitle GetHeader(IPublishedContent node = null);
        Image GetImage(IPublishedContent node = null);
    }
}

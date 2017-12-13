using MBran.Component.Favicon.Models;
using Umbraco.Core.Models;

namespace MBran.Component.Favicon.Service
{
    public interface IFaviconService
    {
        FaviconViewModel GetFavicon(IPublishedContent page = null);
    }
}

using MBran.Components.Favicon.Models;
using Umbraco.Core.Models;

namespace MBran.Components.Favicon.Service
{
    public interface IFaviconService
    {
        FaviconViewModel GetFavicon(IPublishedContent page = null);
    }
}

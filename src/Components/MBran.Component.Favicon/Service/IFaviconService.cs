using Umbraco.Core.Models;

namespace MBran.Components.Favicon
{
    public interface IFaviconService
    {
        FaviconViewModel GetFavicon(IPublishedContent page = null);
    }
}

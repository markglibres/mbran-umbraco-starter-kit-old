using MBran.Umbraco.Models;
using Umbraco.Core.Models;

namespace MBran.Umbraco.Core
{
    public interface IMediaService
    {
        Image GetLogo(IPublishedContent node = null);
        Image GetFavicon(IPublishedContent node = null);
    }
}

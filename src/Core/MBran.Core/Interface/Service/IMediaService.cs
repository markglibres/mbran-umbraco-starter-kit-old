using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Core
{
    public interface IMediaService
    {
        Image GetLogo(IPublishedContent node = null);
    }
}

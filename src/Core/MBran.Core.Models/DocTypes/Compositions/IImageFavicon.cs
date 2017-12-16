using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial interface IImageFavicon
    {
        IPublishedContent Favicon { get; set; }
    }
}

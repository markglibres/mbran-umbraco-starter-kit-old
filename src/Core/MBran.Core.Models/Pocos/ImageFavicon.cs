using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class ImageFavicon : IImageFavicon
    {
        public IPublishedContent Favicon { get; set; }
    }
}

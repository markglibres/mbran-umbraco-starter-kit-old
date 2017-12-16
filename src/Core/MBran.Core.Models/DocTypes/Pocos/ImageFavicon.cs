using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class ImageFavicon : BasePoco, IImageFavicon
    {
        public virtual IPublishedContent Favicon { get; set; }
    }
}

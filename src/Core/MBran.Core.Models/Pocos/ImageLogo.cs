using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class ImageLogo: IImageLogo
    {
        public IPublishedContent Logo { get; set; }
    }
}

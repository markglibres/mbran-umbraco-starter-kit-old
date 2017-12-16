using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class ImageLogo : BasePoco, IImageLogo
    {
        public virtual IPublishedContent Logo { get; set; }
    }
}

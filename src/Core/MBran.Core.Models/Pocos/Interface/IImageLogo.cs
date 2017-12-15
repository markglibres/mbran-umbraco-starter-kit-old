using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial interface IImageLogo
    {
        IPublishedContent Logo { get; set;  }
    }
}

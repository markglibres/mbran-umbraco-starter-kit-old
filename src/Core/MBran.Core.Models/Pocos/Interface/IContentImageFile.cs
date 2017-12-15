using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial interface IContentImageFile
    {
        IPublishedContent ContentImage { get; set;  }
    }
}

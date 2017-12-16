using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial interface IMetaTagImage
    {
        IPublishedContent MetaImage { get; set;  }
    }
}

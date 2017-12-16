using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class MetaTagImage : BasePoco, IMetaTagImage
    {
        public virtual IPublishedContent MetaImage { get; set; }
    }
}

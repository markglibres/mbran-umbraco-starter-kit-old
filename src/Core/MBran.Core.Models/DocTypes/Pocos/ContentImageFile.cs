using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class ContentImageFile : BasePoco, IContentImageFile
    {
        public virtual IPublishedContent ContentImage { get; set; }
    }
}

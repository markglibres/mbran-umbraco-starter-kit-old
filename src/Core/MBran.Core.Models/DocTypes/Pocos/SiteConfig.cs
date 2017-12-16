using System.Collections.Generic;
using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class SiteConfig : BasePoco, ISiteConfig, IBusinessAddress, IBusinessTimingsNested, IImageFavicon, IImageLogo
    {
        public virtual string BusinessAddress1 { get; set; }
        public virtual string BusinessAddress2 { get; set; }
        public virtual string BusinessAddressCity { get; set; }
        public virtual string BusinessAddressCountry { get; set; }
        public virtual string BusinessAddressState { get; set; }
        public virtual string BusinessAddressZip { get; set; }
        public virtual IEnumerable<IPublishedContent> BusinessTimings { get; set; }
        public virtual IPublishedContent Favicon { get; set; }
        public virtual IPublishedContent Logo { get; set; }
    }
}

using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class Home : BasePoco, IHome
    {
        public virtual string ContentSummary { get; set; }
        public virtual string ContentTitle { get; set; }
        public virtual IPublishedContent ContentImage { get; set; }
        public virtual string MetaDescription { get; set; }
        public virtual string MetaTitle { get; set; }
        public virtual IPublishedContent MetaImage { get; set; }
        public virtual decimal SitemapChangeFrequency { get; set; }
        public virtual decimal SitemapPriority { get; set; }
        public virtual bool UmbracoNaviHide { get; set; }
    }
}

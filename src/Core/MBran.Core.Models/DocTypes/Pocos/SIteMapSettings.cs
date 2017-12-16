namespace MBran.Core.Models
{
    public partial class SIteMapSettings : BasePoco, ISitemapSettings
    {
        public virtual decimal SitemapChangeFrequency { get; set; }
        public virtual decimal SitemapPriority { get; set; }
        public virtual bool UmbracoNaviHide { get; set; }
    }
}

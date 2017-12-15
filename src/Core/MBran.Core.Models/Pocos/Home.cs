using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class Home : IHome
    {
        public string ContentSummary { get; set; }
        public string ContentTitle { get; set; }
        public IPublishedContent ContentImage { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public IPublishedContent MetaImage { get; set; }
        public decimal SitemapChangeFrequency { get; set; }
        public decimal SitemapPriority { get; set; }
        public bool UmbracoNaviHide { get; set; }
    }
}

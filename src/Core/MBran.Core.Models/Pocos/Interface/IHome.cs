using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial interface IHome
    {
        string ContentSummary { get; set; }
        string ContentTitle { get; set; }
        IPublishedContent ContentImage { get; set; }
        string MetaDescription { get; set; }
        string MetaTitle { get; set; }
        IPublishedContent MetaImage { get; set; }
        decimal SitemapChangeFrequency { get; set; }
        decimal SitemapPriority { get; set; }
        bool UmbracoNaviHide { get; set; }
    }
}

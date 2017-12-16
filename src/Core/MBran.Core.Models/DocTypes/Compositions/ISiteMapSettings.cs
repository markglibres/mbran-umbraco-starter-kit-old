namespace MBran.Core.Models
{
    public partial interface ISitemapSettings
    {
        decimal SitemapChangeFrequency { get; set; }
        decimal SitemapPriority { get; set; }
        bool UmbracoNaviHide { get; set; }
    }
}

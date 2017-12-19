using MBran.Components.Sitemap.Enums;
using MBran.Models;

namespace MBran.Components.Sitemap.Extensions
{
    public static class SitemapExtensions
    {
        public static SitemapChangeFrequency GetChangeFrequency(this ISitemapSettings sitemapSettings)
        {
            var intValue = decimal.ToInt32(sitemapSettings.SitemapChangeFrequency);
            return (SitemapChangeFrequency)intValue;
        }
    }
}

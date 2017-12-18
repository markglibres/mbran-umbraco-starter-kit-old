using MBran.Models;
using System;

namespace MBran.Components.Sitemap
{
    public static class SitemapExtensions
    {
        public static SitemapChangeFrequency GetChangeFrequency(this ISitemapSettings sitemapSettings)
        {
            int intValue = Decimal.ToInt32(sitemapSettings.SitemapChangeFrequency);
            return (SitemapChangeFrequency)intValue;
        }
    }
}

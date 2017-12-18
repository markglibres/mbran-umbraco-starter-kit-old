using System;

namespace MBran.Components.Sitemap
{
    public static class SitemapChangeFrequencyExtensions
    {
        public static string GetName(this SitemapChangeFrequency frequency)
        {
            return Enum.GetName(typeof(SitemapChangeFrequency), frequency).ToLower();
        }
        
    }
}

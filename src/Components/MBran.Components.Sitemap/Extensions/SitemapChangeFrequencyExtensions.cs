using System;
using MBran.Components.Sitemap.Enums;

namespace MBran.Components.Sitemap.Extensions
{
    public static class SitemapChangeFrequencyExtensions
    {
        public static string GetName(this SitemapChangeFrequency frequency)
        {
            return Enum.GetName(typeof(SitemapChangeFrequency), frequency)?.ToLower();
        }
        
    }
}

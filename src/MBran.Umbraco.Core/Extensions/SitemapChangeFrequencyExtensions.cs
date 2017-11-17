using System;

namespace MBran.Umbraco.Core
{
    public static class SitemapChangeFrequencyExtensions
    {
        public static string GetName(this SitemapChangeFrequency frequency)
        {
            return Enum.GetName(typeof(SitemapChangeFrequency), frequency).ToLower();
        }
        
    }
}

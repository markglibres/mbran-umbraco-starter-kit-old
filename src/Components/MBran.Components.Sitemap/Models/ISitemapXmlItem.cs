using System;

namespace MBran.Components.Sitemap
{
    public interface ISitemapXmlItem
    {
        string Location { get; set; }
        DateTime LastModified { get; set; }
        SitemapChangeFrequency ChangeFrequency { get; set; }
        decimal Priority { get; set; }
    }
}

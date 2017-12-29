using System;
using MBran.Components.Sitemap.Enums;

namespace MBran.Components.Sitemap.Models
{
    public interface ISitemapXmlItem
    {
        string Location { get; set; }
        DateTime LastModified { get; set; }
        SitemapChangeFrequency ChangeFrequency { get; set; }
        decimal Priority { get; set; }
    }
}

using System.Collections.Generic;

namespace MBran.Components.Sitemap.Models
{
    public interface ISitemapXml<T>
        where T : ISitemapXmlItem
    {
        List<T> Items { get; set; }
    }
}

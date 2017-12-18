using System.Collections.Generic;

namespace MBran.Components.Sitemap
{
    public interface ISitemapXml<T>
        where T : ISitemapXmlItem
    {
        List<T> Items { get; set; }
    }
}

using System.Collections.Generic;

namespace MBran.Umbraco.Core
{
    public interface ISitemapXml<T>
        where T : ISitemapXmlItem
    {
        List<T> Items { get; set; }
    }
}

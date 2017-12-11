using System.Collections.Generic;

namespace MBran.Core
{
    public interface ISitemapXml<T>
        where T : ISitemapXmlItem
    {
        List<T> Items { get; set; }
    }
}

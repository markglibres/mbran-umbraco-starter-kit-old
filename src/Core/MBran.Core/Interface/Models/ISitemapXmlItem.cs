using System;

namespace MBran.Core
{
    public interface ISitemapXmlItem
    {
        string Location { get; set; }
        DateTime LastModified { get; set; }
        SitemapChangeFrequency ChangeFrequency { get; set; }
        decimal Priority { get; set; }
    }
}

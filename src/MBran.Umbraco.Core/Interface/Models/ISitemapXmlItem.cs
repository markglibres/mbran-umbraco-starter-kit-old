using System;

namespace MBran.Umbraco.Core
{
    public interface ISitemapXmlItem
    {
        string Location { get; set; }
        DateTime LastModified { get; set; }
        SitemapChangeFrequency ChangeFrequency { get; set; }
        double Priority { get; set; }
    }
}

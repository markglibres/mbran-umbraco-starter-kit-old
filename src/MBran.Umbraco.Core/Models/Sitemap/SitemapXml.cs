using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace MBran.Umbraco.Core
{
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class SitemapXml : ISitemapXml<SiteMapXmlItem>
    {
        [XmlElement("url")]
        public List<SiteMapXmlItem> Items { get; set; }
    }
}

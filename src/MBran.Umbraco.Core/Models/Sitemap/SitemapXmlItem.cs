using System;
using System.Xml.Serialization;

namespace MBran.Umbraco.Core
{
    public class SiteMapXmlItem : ISitemapXmlItem
    {
        [XmlElement("loc")]
        public string Location { get; set; }
        [XmlElement("lastmod")]
        public DateTime LastModified { get; set; }
        [XmlElement("changefreq")]
        public SitemapChangeFrequency ChangeFrequency { get; set; }
        [XmlElement("priority")]
        public double Priority { get; set; }
    }
}

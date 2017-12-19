using System;
using System.Xml.Serialization;
using MBran.Components.Sitemap.Enums;

namespace MBran.Components.Sitemap.Models
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
        public decimal Priority { get; set; }
    }
}

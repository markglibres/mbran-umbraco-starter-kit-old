using Umbraco.Web.Models;

namespace MBran.Core.Models
{
    public partial class Image : IImage
    {
        public string UmbracoBytes { get; set; }
        public string UmbracoExtension { get; set; }
        public ImageCropDataSet UmbracoFile { get; set; }
        public string UmbracoHeight { get; set; }
        public string UmbracoWidth { get; set; }
    }
}

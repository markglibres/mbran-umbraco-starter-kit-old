using Umbraco.Web.Models;

namespace MBran.Core.Models
{
    public partial class Image : BasePoco, IImage
    {
        public virtual string UmbracoBytes { get; set; }
        public virtual string UmbracoExtension { get; set; }
        public virtual ImageCropDataSet UmbracoFile { get; set; }
        public virtual string UmbracoHeight { get; set; }
        public virtual string UmbracoWidth { get; set; }
    }
}

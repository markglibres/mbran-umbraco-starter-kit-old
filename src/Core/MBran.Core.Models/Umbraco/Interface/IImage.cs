using Umbraco.Web.Models;

namespace MBran.Core.Models
{
    public partial interface IImage
    {
        string UmbracoBytes { get; set; }
        string UmbracoExtension { get; set; }
        ImageCropDataSet UmbracoFile { get; set; }
        string UmbracoHeight { get; set; }
        string UmbracoWidth { get; set; }
    }
}

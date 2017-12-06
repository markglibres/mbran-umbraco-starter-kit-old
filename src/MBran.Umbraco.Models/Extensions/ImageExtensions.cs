using System.Web;

namespace MBran.Umbraco.Models
{
    public static class ImageExtensions
    {
        public static string GetMimeType(this Image image)
        {
            return MimeMapping.GetMimeMapping(image.Path);
        }
    }
}

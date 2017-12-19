using MBran.Models;
using System.Web;

namespace MBran.Core.Models
{
    public static class ImageExtensions
    {
        public static string GetMimeType(this Image image)
        {
            if(image == null)
            {
                return string.Empty;
            }
            return MimeMapping.GetMimeMapping(image.Path);
        }
    }
}

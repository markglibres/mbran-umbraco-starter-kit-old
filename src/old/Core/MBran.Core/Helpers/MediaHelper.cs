using MBran.Models;
using Umbraco.Web;

namespace MBran.Core
{
    public class MediaHelper : IMediaHelper
    {
        private readonly UmbracoHelper _umbracoHelper;
        public MediaHelper(UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;
        }
        public Image GetMedia(int nodeId)
        {
            var media = _umbracoHelper.TypedMedia(nodeId);
            var image = new Image(media);
            return image;
        }
    }
}

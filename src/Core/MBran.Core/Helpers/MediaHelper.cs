using MBran.Core.Models;
using Umbraco.Core.Models;
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
            IPublishedContent media = _umbracoHelper.TypedMedia(nodeId);
            Image image = new Image(media);
            return image;
        }
    }
}

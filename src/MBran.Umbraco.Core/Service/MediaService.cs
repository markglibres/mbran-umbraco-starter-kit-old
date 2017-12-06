using MBran.Umbraco.Models;
using Umbraco.Core.Models;

namespace MBran.Umbraco.Core
{
    public class MediaService : IMediaService
    {
        private readonly IMediaHelper _mediaHelper;
        private readonly IPageHelper _pageHelper;
        public MediaService(IMediaHelper mediaHelper, IPageHelper pageHelper)
        {
            _mediaHelper = mediaHelper;
            _pageHelper = pageHelper;
        }
        public Image GetFavicon(IPublishedContent node = null)
        {
            if(node == null)
            {
                node = _pageHelper.CurrentPage();
            }

            ImageFavicon favicon = node.As<ImageFavicon>();
            if(favicon.Favicon == null)
            {
                return null;
            }

            return _mediaHelper.GetMedia(favicon.Favicon.Id);
        }

        public Image GetLogo(IPublishedContent node = null)
        {
            if (node == null)
            {
                node = _pageHelper.CurrentPage();
            }

            ImageLogo logo = node.As<ImageLogo>();
            if (logo.Logo == null)
            {
                return null;
            }

            return _mediaHelper.GetMedia(logo.Logo.Id);
        }
    }
}

using MBran.Core.Models;
using Umbraco.Core.Models;

namespace MBran.Core
{
    public class MediaService : IMediaService
    {
        private readonly IMediaHelper _mediaHelper;
        private readonly ISiteService _siteService;
        public MediaService(IMediaHelper mediaHelper, ISiteService siteService)
        {
            _mediaHelper = mediaHelper;
            _siteService = siteService;
        }
        public Image GetFavicon(IPublishedContent node = null)
        {
            if(node == null)
            {
                node = _siteService.GetSite();
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
                node = _siteService.GetSite();
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

using MBran.Core.Models;
using MBran.Models;
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
        
        public Image GetLogo(IPublishedContent node = null)
        {
            if (node == null)
            {
                node = _siteService.GetSite();
            }

            var logo = node.As<ImageLogo>();
            return logo.Logo == null ? null : _mediaHelper.GetMedia(logo.Logo.Id);
        }
    }
}

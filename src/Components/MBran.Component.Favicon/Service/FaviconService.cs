using MBran.Core;
using MBran.Core.Models;
using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Components.Favicon
{
    public class FaviconService : IFaviconService
    {
        private readonly ISiteService _siteService;
        private readonly IMediaHelper _mediaHelper;
        public FaviconService(ISiteService siteService,
            IMediaHelper mediaHelper)
        {
            _siteService = siteService;
            _mediaHelper = mediaHelper;
        }
        public FaviconViewModel GetFavicon(IPublishedContent model = null)
        {
            if (model == null)
            {
                model = _siteService.GetSite();
            }

            Image favicon = this.GetFaviconImage(model);
            FaviconViewModel viewModel = new FaviconViewModel();

            if (favicon != null)
            {
                viewModel.MimeType = favicon.GetMimeType();
                viewModel.Url = favicon.Url;
            }
            
            return viewModel;
        }

        private Image GetFaviconImage(IPublishedContent node)
        {
            ImageFavicon favicon = node.As<ImageFavicon>();
            if (favicon.Favicon == null)
            {
                return null;
            }

            return _mediaHelper.GetMedia(favicon.Favicon.Id);
        }
    }
}

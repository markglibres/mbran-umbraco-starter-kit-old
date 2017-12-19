using MBran.Components.Favicon.Models;
using MBran.Core;
using MBran.Core.Models;
using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Components.Favicon.Service
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

            var favicon = GetFaviconImage(model);
            var viewModel = new FaviconViewModel();

            if (favicon == null) return viewModel;

            viewModel.MimeType = favicon.GetMimeType();
            viewModel.Url = favicon.Url;

            return viewModel;
        }

        private Image GetFaviconImage(IPublishedContent node)
        {
            var favicon = node.As<ImageFavicon>();
            return favicon.Favicon == null ? null : _mediaHelper.GetMedia(favicon.Favicon.Id);
        }
    }
}

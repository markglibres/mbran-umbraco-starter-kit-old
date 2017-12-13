using MBran.Component.Favicon.Models;
using MBran.Core;
using MBran.Core.Models;
using Umbraco.Core.Models;

namespace MBran.Component.Favicon.Service
{
    public class FaviconService : IFaviconService
    {
        private readonly IMediaService _mediaService;
        public FaviconService(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }
        public FaviconViewModel GetFavicon(IPublishedContent model = null)
        {
            Image favicon = _mediaService.GetFavicon(model);
            FaviconViewModel viewModel = new FaviconViewModel();

            if (favicon != null)
            {
                viewModel.MimeType = favicon.GetMimeType();
                viewModel.Url = favicon.Url;
            }
            
            return viewModel;
        }
    }
}

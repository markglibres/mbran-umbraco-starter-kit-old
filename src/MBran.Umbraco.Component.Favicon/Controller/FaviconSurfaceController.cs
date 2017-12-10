using MBran.Umbraco.Core;
using MBran.Umbraco.Models;
using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Umbraco.Components
{
    public class FaviconSurfaceController : ComponentSurfaceController
    {
        private readonly IMediaService _mediaService;
        public FaviconSurfaceController(IPageHelper pageHelper, IMediaService mediaService)
            : base(pageHelper)
        {
            _mediaService = mediaService;
        }

        [ChildActionOnly]
        public override PartialViewResult RenderModel(IPublishedContent model = null)
        {
            Image favicon = _mediaService.GetFavicon(model);
            return ComponentView(favicon);
        }
    }
}

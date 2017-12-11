using MBran.Core;
using MBran.Core.Models;
using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Core.Components
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

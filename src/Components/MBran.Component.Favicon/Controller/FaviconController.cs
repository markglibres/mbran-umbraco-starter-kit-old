using MBran.Component.Favicon.Service;
using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public class FaviconController : ComponentSurfaceController
    {
        private readonly IFaviconService _faviconService;
        public FaviconController(IPageHelper pageHelper, 
            IFaviconService faviconService) 
            : base(pageHelper)
        {
            _faviconService = faviconService;
        }

        [ChildActionOnly]
        public override PartialViewResult RenderModel(IPublishedContent model = null)
        {
            var viewModel = _faviconService.GetFavicon(model);
            return ComponentView(viewModel);
        }
    }
}

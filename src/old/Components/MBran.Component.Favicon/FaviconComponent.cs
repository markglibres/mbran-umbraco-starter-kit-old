using MBran.Components.Favicon.Service;
using MBran.Core;
using MBran.Core.Components;

namespace MBran.Components.Favicon
{
    public class FaviconComponent : Component
    {
        private readonly IFaviconService _faviconService;
        public FaviconComponent(IContentHelper contentHelper, IFaviconService faviconService) :
            base(contentHelper)
        {
            _faviconService = faviconService;
        }
        public override object GetModel()
        {
            var viewModel = _faviconService.GetFavicon();
            return viewModel;
        }
    }
}

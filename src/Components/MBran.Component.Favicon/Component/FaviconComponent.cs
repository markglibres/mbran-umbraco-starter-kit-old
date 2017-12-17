using MBran.Core;
using MBran.Core.Components;

namespace MBran.Components.Favicon
{
    public class FaviconComponent : Component
    {
        private readonly IFaviconService _faviconService;
        public FaviconComponent(IPageHelper pageHelper, IFaviconService faviconService) :
            base(pageHelper)
        {
            _faviconService = faviconService;
        }
        public override object GetViewModel()
        {
            var viewModel = _faviconService.GetFavicon();
            return viewModel;
        }
    }
}

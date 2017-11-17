using MBran.Umbraco.Core;
using System.Web.Mvc;

namespace MBran.Umbraco.Components
{
    public class MetaTagHeaderSurfaceController : ViewComponentSurfaceController
    {
        private readonly IMetaService _metaService;
        public MetaTagHeaderSurfaceController(IPageHelper pageHelper,
            IMetaService metaService) 
            : base(pageHelper)
        {
            _metaService = metaService;
        }

        [ChildActionOnly]
        public ActionResult MetaTagHeader()
        {
            var viewModel = new MetaTagHeaderViewModel {
                Title = _metaService.Title,
                Description = _metaService.Description
            };
            return ComponentView(viewModel);
        }
    }
}

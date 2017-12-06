using MBran.Umbraco.Core;
using MBran.Umbraco.Models;
using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Umbraco.Components
{
    public class MetaTagHeaderSurfaceController : ComponentSurfaceController
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
            return RenderModel();
        }

        [ChildActionOnly]
        public override PartialViewResult RenderModel(IPublishedContent model = null)
        {
            MetaTitle dataModel = _metaService.GetHeader(model);
            MetaTitleViewModel viewModel = dataModel.Map<MetaTitleViewModel>();

            return ComponentView(viewModel);
        }
    }
}

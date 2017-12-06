using MBran.Umbraco.Core;
using MBran.Umbraco.Models;
using System;
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
        public PartialViewResult RenderTitle(IPublishedContent model = null)
        {
            MetaTitle dataModel = _metaService.GetHeader(model);
            MetaTitleViewModel viewModel = dataModel.Map<MetaTitleViewModel>();

            return ComponentView(viewModel);
        }

        [ChildActionOnly]
        public override PartialViewResult RenderModel(IPublishedContent model = null)
        {
            throw new NotImplementedException();
        }
    }
}

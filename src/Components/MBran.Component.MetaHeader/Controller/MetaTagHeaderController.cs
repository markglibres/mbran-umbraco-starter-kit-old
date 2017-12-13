using MBran.Core;
using MBran.Core.Components;
using MBran.Core.Models;
using System;
using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Component.MetaHeader
{
    public class MetaTagHeaderController : ComponentSurfaceController
    {
        private readonly IMetaService _metaService;

        public MetaTagHeaderController(IPageHelper pageHelper,
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

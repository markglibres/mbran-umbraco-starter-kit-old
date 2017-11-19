using AutoMapper;
using MBran.Umbraco.Core;
using MBran.Umbraco.Models;
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
            MetaTagHeaderComponentModel model = _metaService.Header;
            MetaTagHeaderViewModel viewModel = Mapper.Map<MetaTagHeaderViewModel>(model);

            return ComponentView(viewModel);
        }
    }
}

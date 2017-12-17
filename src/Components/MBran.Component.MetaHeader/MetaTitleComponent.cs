using MBran.Core;
using MBran.Core.Components;
using MBran.Core.Models;

namespace MBran.Components.MetaHeader
{
    public class MetaTitleComponent : Component
    {
        private readonly IMetaService _metaService;
        
        public MetaTitleComponent(IPageHelper pageHelper,
            IMetaService metaService) 
            : base(pageHelper)
        {
            _metaService = metaService;
        }

        public override object GetModel()
        {
            MetaTitle dataModel = _metaService.GetHeader(PublishedContent);
            MetaTitleViewModel viewModel = dataModel.Map<MetaTitleViewModel>();
            return viewModel;
        }
    }
}

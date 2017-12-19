using MBran.Components.MetaHeader.Models;
using MBran.Components.MetaHeader.Service;
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

        public override object GetViewModel()
        {
            var dataModel = _metaService.GetHeader(PublishedContent);
            var viewModel = dataModel.Map<MetaTitleViewModel>();
            return viewModel;
        }
    }
}

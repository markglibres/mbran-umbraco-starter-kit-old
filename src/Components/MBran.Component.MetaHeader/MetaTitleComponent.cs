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
        
        public MetaTitleComponent(IContentHelper contentHelper,
            IMetaService metaService) 
            : base(contentHelper)
        {
            _metaService = metaService;
        }

        public override object GetModel()
        {
            var dataModel = _metaService.GetHeader(PublishedContent);
            var viewModel = dataModel.Map<MetaTitleViewModel>();
            return viewModel;
        }
    }
}

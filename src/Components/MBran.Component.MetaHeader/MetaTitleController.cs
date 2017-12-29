using MBran.Components.MetaHeader.Service;
using MBran.Core;
using MBran.Core.Components;
using MBran.Core.Helpers.Interface;

namespace MBran.Components.MetaHeader
{
    public class MetaTitleController : ComponentsController
    {
        private readonly IMetaService _metaService;

        public MetaTitleController(IContentHelper contentHelper, 
            IPublishedContentHelper publishedContentHelper,
            IMetaService metaService) 
            : base(contentHelper, publishedContentHelper)
        {
            _metaService = metaService;
        }

        protected override object GetModel()
        {
            return _metaService.GetHeader(PublishedContent);
        }
    }
}

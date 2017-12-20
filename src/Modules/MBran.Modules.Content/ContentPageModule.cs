using MBran.Core;
using MBran.Core.Modules;
using MBran.Core.Modules.Models;
using MBran.Models;

namespace MBran.Modules.Content
{
    public class ContentPageModule : PageModule
    {
        public ContentPageModule(IContentHelper contentHelper) 
            : base(contentHelper)
        {

        }

        public override IPageModuleModel GetModel()
        {
            var contentModule = PublishedContent.As<ContentModule>();

            return new ContentPageModuleModel
            {
                Components = contentModule.ContentModuleComponents
            };
            
        }
    }
}

using MBran.Core.Modules.Models;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace MBran.Modules.Content
{
    public class ContentPageModuleModel : IPageModuleModel
    {
        public IEnumerable<IPublishedContent> Components { get; set; }
    }
}

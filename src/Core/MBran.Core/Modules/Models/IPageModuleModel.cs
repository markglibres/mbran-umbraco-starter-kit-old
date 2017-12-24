using System.Collections.Generic;
using Umbraco.Core.Models;

namespace MBran.Core.Modules.Models
{
    public interface IPageModuleModel
    {
        IEnumerable<IPublishedContent> Components { get; set; }
    }
}

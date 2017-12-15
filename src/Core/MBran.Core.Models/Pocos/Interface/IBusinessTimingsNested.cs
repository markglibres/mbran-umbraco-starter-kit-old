using System.Collections.Generic;
using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial interface IBusinessTimingsNested
    {
        IEnumerable<IPublishedContent> BusinessTimings { get; set;  }
    }
}

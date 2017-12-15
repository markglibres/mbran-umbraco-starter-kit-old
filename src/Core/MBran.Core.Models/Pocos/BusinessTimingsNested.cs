using System.Collections.Generic;
using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class BusinessTimingsNested : IBusinessTimingsNested
    {
        public IEnumerable<IPublishedContent> BusinessTimings { get; set; }
    }
}

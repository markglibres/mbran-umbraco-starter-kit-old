using System.Collections.Generic;
using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial class BusinessTimingsNested : BasePoco, IBusinessTimingsNested
    {
        public virtual IEnumerable<IPublishedContent> BusinessTimings { get; set; }
    }
}

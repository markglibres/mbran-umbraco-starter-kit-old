using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public partial interface IBasePoco
    {
        int Id { get; set; }
        IPublishedContent PublishedContent { get; set; }
    }
}

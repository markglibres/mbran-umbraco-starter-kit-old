using Umbraco.Core.Models;

namespace MBran.Core.Models
{
    public abstract class BasePoco : IBasePoco
    {
        public int Id { get; set; }
        public IPublishedContent PublishedContent { get; set; }
    }
}

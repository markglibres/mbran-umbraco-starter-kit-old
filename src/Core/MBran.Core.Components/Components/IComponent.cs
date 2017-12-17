using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public interface IComponent
    {
        string Name { get; }
        IPublishedContent PublishedContent { get; }
    }
}

using MBran.Umbraco.Models;

namespace MBran.Umbraco.Core
{
    public interface IPageService
    {
        string Title { get; }
        string Summary { get; }
        Image Image { get; }
    }
}

using MBran.Models;

namespace MBran.Core
{
    public interface IPageService
    {
        string Title { get; }
        string Summary { get; }
        Image Image { get; }
    }
}

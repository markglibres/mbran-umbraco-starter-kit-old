using MBran.Models;

namespace MBran.Components.ErrorPage
{
    public interface IErrorPageService
    {
        Error404 GetErrorPage();
    }
}

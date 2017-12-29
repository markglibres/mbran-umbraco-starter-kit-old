using MBran.Models;

namespace MBran.Components.ErrorPage.Service
{
    public interface IErrorPageService
    {
        Error404 GetErrorPage();
    }
}

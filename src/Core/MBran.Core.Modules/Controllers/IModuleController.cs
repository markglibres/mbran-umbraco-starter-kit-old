using System.Web.Mvc;

namespace MBran.Core.Modules.Controllers
{
    public interface IModuleController
    {
        int PageId { get; }
        PartialViewResult RenderModel(object model);
        PartialViewResult Render(string viewName, object model);
        string GetViewPath();
        string GetViewName();
        PartialViewResult GetMvcView(object model);
        PartialViewResult GetView(object model, string viewPath = "");
    }
}

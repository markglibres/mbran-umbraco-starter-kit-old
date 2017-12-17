using System.Web.Mvc;

namespace MBran.Core.Components
{
    public interface IComponentController
    {
        int PageId { get; }
        PartialViewResult RenderModel(object model);
        PartialViewResult Render(string viewName, object model);
        
    }
}

using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public interface IComponentController
    {
        int PageId { get; }
        PartialViewResult RenderContent(IPublishedContent content);
        PartialViewResult RenderModel(object model);
        PartialViewResult Render(string viewName, object model);
        string GetViewPath();
        string GetComponentName();
       
    }
}
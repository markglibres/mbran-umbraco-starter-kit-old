using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Umbraco.Components
{
    public interface IComponentController
    {
        int PageId { get; }
        PartialViewResult ComponentView();
        PartialViewResult ComponentView(string viewName);
        PartialViewResult ComponentView(object model);
        PartialViewResult ComponentView(string viewName, object model);
        string GetViewName();
        PartialViewResult RenderModel(IPublishedContent model = null);
    }
}

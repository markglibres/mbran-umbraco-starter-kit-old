using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public interface IComponentController
    {
        int PageId { get; }
        PartialViewResult ComponentView();
        PartialViewResult ComponentView(string viewName);
        PartialViewResult ComponentView(object model);
        PartialViewResult ComponentView(string viewName, object model);
        PartialViewResult RenderModel(IPublishedContent model = null);
        
    }
}

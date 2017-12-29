using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public interface IComponentController
    {
        int PageId { get; }
        IPublishedContent PublishedContent { get; }
        PartialViewResult RenderContent(IPublishedContent content);
        PartialViewResult Render();
        PartialViewResult RenderModel(object model);
        PartialViewResult Render(string viewName, object model);
       
    }
}
using MBran.Core.Modules.Models;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Models;

namespace MBran.Core.Modules
{
    public interface IPageModule
    {
        IPageModuleModel GetModel();
        void SetHtmlHelper(HtmlHelper helper);
        void SetPublishedContent(IPublishedContent content);
        void SetRouteOptions(RouteValueDictionary options);
        string Name { get; }
        IPublishedContent PublishedContent { get; }
        RouteValueDictionary Options { get; }
        MvcHtmlString Render(object model, RouteValueDictionary options);
        MvcHtmlString Render(string viewPath, object model, RouteValueDictionary options);
        MvcHtmlString Render();
    }
}

using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public interface IComponent
    {
        string Name { get; }
        IPublishedContent PublishedContent { get; }
        RouteValueDictionary Options { get; }
        MvcHtmlString Render(object model, RouteValueDictionary options);
        MvcHtmlString Render(string viewPath, object model, RouteValueDictionary options);
        MvcHtmlString Render();
        void SetHtmlHelper(HtmlHelper helper);
        void SetPublishedContent(IPublishedContent content);
        void SetRouteOptions(RouteValueDictionary options);
        object GetViewModel();
    }
}

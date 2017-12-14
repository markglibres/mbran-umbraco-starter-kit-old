using System.Web.Mvc;
using System.Web.Routing;

namespace MBran.Core.Components
{
    public interface IComponentRender
    {
        MvcHtmlString Render(object model, RouteValueDictionary options);
        MvcHtmlString Render(string viewPath, object model, RouteValueDictionary options);
        string RenderAction { get; }
    }
}

using System.Web.Mvc;
using System.Web.Routing;

namespace MBran.Core.Components
{
    public interface IComponentRender
    {
        MvcHtmlString Render(object model, RouteValueDictionary options);
        MvcHtmlString Render(string actionName, object model, RouteValueDictionary options);
        string RenderAction { get; }
    }
}

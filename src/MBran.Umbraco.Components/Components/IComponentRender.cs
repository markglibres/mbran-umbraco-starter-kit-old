using System.Web.Mvc;
using System.Web.Routing;

namespace MBran.Umbraco.Components
{
    public interface IComponentRender
    {
        MvcHtmlString Render(object model);
        MvcHtmlString Render(object model, RouteValueDictionary options);
        MvcHtmlString Render(string actionName, object model, RouteValueDictionary options);
    }
}

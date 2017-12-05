using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MBran.Umbraco.Components
{
    public static class HtmlHelperComponentExtensions
    {
        public static MvcHtmlString Component<T>(this HtmlHelper helper,
            object model = null,
            RouteValueDictionary options = null)
            where T : IComponent, IComponentRender
        {
            T component = (T)Activator.CreateInstance(typeof(T), helper);
            return component.Render(model, options);
        }
    }
}

using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MBran.Umbraco.Components
{
    public static class HtmlHelperComponentExtensions
    {
        public static MvcHtmlString Component(this HtmlHelper helper, string componentName,
            object model = null,
            RouteValueDictionary options = null)
        {
            string actionName = componentName;
            if (model != null)
            {
                actionName = "Render" + actionName;
            }
            return helper.RenderComponent(componentName, actionName, model, options);
        }

        public static MvcHtmlString RenderComponent(this HtmlHelper helper, string componentName,
            string actionName,
            object model = null,
            RouteValueDictionary options = null)
        {
            var controllerName = componentName + "Surface";
            var _options = options ?? new RouteValueDictionary();
            _options.Remove("model");
            _options.Add("model", model);
            
            return helper.Action(actionName, controllerName, _options);
        }

    }
}

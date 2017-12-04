using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Umbraco.Web.Mvc;

namespace MBran.Umbraco.Components
{
    public static class HtmlHelperComponentExtensions
    {
        public static MvcHtmlString Component<T>(this HtmlHelper helper,
            object model = null,
            RouteValueDictionary options = null)
            where T : IComponent
        {
            T component = Activator.CreateInstance<T>();
            string componentName = component.Controller.Name;
            componentName = Regex.Replace(componentName, "Controller$", String.Empty);
            return helper.Component(componentName, model, options);
        }

        public static MvcHtmlString Component(this HtmlHelper helper, string componentName,
            object model = null,
            RouteValueDictionary options = null)
        {
            string actionName = componentName;
            actionName = Regex.Replace(actionName, "Surface", String.Empty);
            if (model != null)
            {
                actionName = "RenderModel";
            }
            return helper.RenderComponent(componentName, actionName, model, options);
        }

        public static MvcHtmlString RenderComponent(this HtmlHelper helper, string componentName,
            string actionName,
            object model = null,
            RouteValueDictionary options = null)
        {
            var _options = options ?? new RouteValueDictionary();
            _options.Remove("model");
            _options.Add("model", model);
            
            return helper.Action(actionName, componentName, _options);
        }

    }
}

using MBran.Core.Components.Extensions;
using MBran.Core.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public static class HtmlHelperComponentExtensions
    {
        public static MvcHtmlString Component<T>(this HtmlHelper helper,
            IPublishedContent content = null, 
            RouteValueDictionary options = null)
            where T : IComponent
        {

            IComponent component = DependencyResolver.Current.GetService<T>();
            return helper.Render(component, content, options);
        }

        public static MvcHtmlString Component(this HtmlHelper helper, 
            IPublishedContent content, RouteValueDictionary options = null)
        {
            var componentType = GetComponentType(content);
            if (componentType == null)
            {
                return helper.RenderComponentView(content, options);
            }

            return helper.RenderComponentController(content, options);
        }

        public static MvcHtmlString RenderComponentView(this HtmlHelper helper, 
            IPublishedContent content, RouteValueDictionary options = null)
        {
            var routeOptions = options ?? new RouteValueDictionary();
            routeOptions.Remove(ComponentConstants.ContentKey);
            routeOptions.Add(ComponentConstants.ContentKey, content);

            routeOptions = helper.ParseViewLocations(routeOptions);
            return helper.Action(ComponentConstants.RenderContentAction, ComponentConstants.ControllerName, routeOptions);
        }

        public static MvcHtmlString RenderComponentController(this HtmlHelper helper,
            IPublishedContent content, RouteValueDictionary options = null)
        {
         
            var componentType = GetComponentType(content);
            if ((componentType == null) || !(DependencyResolver.Current.GetService(componentType) is IComponent component))
            {
                return new MvcHtmlString(string.Empty);
            }

            return helper.Render(component, content, options);
            
        }

        private static MvcHtmlString Render(this HtmlHelper helper,
            IComponent component,
            IPublishedContent content = null,
            RouteValueDictionary options = null)
        {
            var routeOptions = helper.ParseViewLocations(options);

            component.SetHtmlHelper(helper);
            if(content != null)
            {
                component.SetPublishedContent(content);
            }
            component.SetRouteOptions(routeOptions);
            return component.Render();
        }

        private static RouteValueDictionary ParseViewLocations(this HtmlHelper helper, RouteValueDictionary options = null)
        {
            var routeOptions = options ?? new RouteValueDictionary();
            string modulePath;
            if (!string.IsNullOrEmpty((modulePath = helper.GetExecutingModulePath())))
            {
                if (routeOptions[ComponentConstants.ViewLocations] is List<string> viewLocations)
                {
                    viewLocations.Add(modulePath);
                }
                else
                {
                    routeOptions.Add(ComponentConstants.ViewLocations, new List<string> { modulePath });
                }

            }
            return routeOptions;
        }

        private static Type GetComponentType(IPublishedContent content)
        {
            var componentType = content.GetDocumentTypeAlias() + "Component";
            return AppDomain.CurrentDomain.FindComponent(componentType);
        }

        public static string GetExecutingModulePath(this HtmlHelper helper)
        {
            string viewPath = ((WebViewPage)helper.ViewDataContainer)?.VirtualPath;
            var match = Regex.Match(viewPath, @"^(.+Views/Modules/.+/)", RegexOptions.IgnoreCase);
            if(!match.Success)
            {
                return string.Empty;
            }

            return match.Groups[1].Value;
        }

    }
}

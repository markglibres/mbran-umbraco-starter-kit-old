using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public static class HtmlHelperComponentExtensions
    {
        public static MvcHtmlString Component<T>(this HtmlHelper helper)
            where T : IComponent
        {

            IComponent component = DependencyResolver.Current.GetService<T>();
            component.SetHtmlHelper(helper);
            return component.Render();
        }

        public static MvcHtmlString Component(this HtmlHelper helper, IPublishedContent content, RouteValueDictionary options = null)
        {
            var componentType = GetComponentType(content);
            if (componentType == null)
            {
                return helper.RenderContent(content, options);
            }

            if (!(DependencyResolver.Current.GetService(componentType) is IComponent component))
            {
                return new MvcHtmlString(string.Empty);
            }

            component.SetHtmlHelper(helper);
            component.SetPublishedContent(content);
            return component.Render();
        }

        private static MvcHtmlString RenderContent(this HtmlHelper helper, 
            IPublishedContent content, RouteValueDictionary options = null)
        {
            var routeOptions = options ?? new RouteValueDictionary();
            routeOptions.Remove(ComponentConstants.ContentKey);
            routeOptions.Add(ComponentConstants.ContentKey, content);
            return helper.Action(ComponentConstants.RenderContentAction, ComponentConstants.ControllerName, routeOptions);
        }

        private static Type GetComponentType(IPublishedContent content)
        {
            var docType = content.DocumentTypeAlias;
            return Type.GetType(docType + "Component");
        }

    }
}

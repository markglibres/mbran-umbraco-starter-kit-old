using System;
using System.Web.Mvc;
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
            var docType = content.DocumentTypeAlias;
            var componentType = Type.GetType(docType + "Component");
            if (componentType == null)
            {
                return new MvcHtmlString(string.Empty);    
            }

            if (!(DependencyResolver.Current.GetService(componentType) is IComponent component))
            {
                return new MvcHtmlString(string.Empty);
            }

            component.SetHtmlHelper(helper);
            component.SetPublishedContent(content);
            return component.Render();
        }

    }
}

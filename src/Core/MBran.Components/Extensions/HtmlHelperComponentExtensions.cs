using MBran.Components.Constants;
using MBran.Components.Controllers;
using MBran.Components.Helpers;
using MBran.Core.Extensions;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Mvc;

namespace MBran.Components.Extensions
{
    public static class HtmlHelperComponentExtensions
    {
        public static MvcHtmlString Component<T>(this HtmlHelper helper,
            RouteValueDictionary routeValues = null)
            where T: PublishedContentModel, IPublishedContent
        {
            var controllerName = typeof(T).Name;
            var componentController = ComponentsHelper.Instance.FindController(controllerName);
            if(componentController == null)
            {
                controllerName = nameof(ComponentsController).Replace("Controller", string.Empty);
            }

            var options = routeValues ?? new RouteValueDictionary();
            options.Add(RouteDataConstants.ComponentTypeKey, typeof(T).Name);

            return helper.Action(nameof(ComponentsController.Render), controllerName, options);

        }

        public static MvcHtmlString Component<T>(this HtmlHelper helper, object model,
            RouteValueDictionary routeValues = null)
            where T : PublishedContentModel, IPublishedContent
        {
            throw new NotImplementedException();
        }

        public static MvcHtmlString Component<T>(this HtmlHelper helper, string viewPath,
            RouteValueDictionary routeValues = null)
            where T : PublishedContentModel, IPublishedContent
        {
            throw new NotImplementedException();
        }

        public static MvcHtmlString Component<T>(this HtmlHelper helper, string viewPath, object model,
            RouteValueDictionary routeValues = null)
            where T : PublishedContentModel, IPublishedContent
        {
            throw new NotImplementedException();
        }

        public static MvcHtmlString Component(this HtmlHelper helper, IPublishedContent model,
            RouteValueDictionary routeValues = null)
        {
            throw new NotImplementedException();
        }

        public static MvcHtmlString Component(this HtmlHelper helper, IPublishedContent model, string viewPath,
            RouteValueDictionary routeValues = null)
        {
            throw new NotImplementedException();
        }

        
    }
}

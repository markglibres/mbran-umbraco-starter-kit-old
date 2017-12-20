using Humanizer;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public abstract class Component : IComponent
    {
        private readonly string _componentName;
        public virtual string Name => _componentName.Humanize();
        private string RenderAction => nameof(IComponentController.RenderModel);
        private string ControllerName => nameof(ComponentsController);
        private HtmlHelper _htmlHelper;
        private IPublishedContent _content;
        private RouteValueDictionary _options;
        public IPublishedContent PublishedContent => _content ??  _contentHelper.CurrentPage();
        public RouteValueDictionary Options => _options ?? new RouteValueDictionary();
        private readonly IContentHelper _contentHelper;

        protected Component(IContentHelper contentHelper)
        {
            _contentHelper = contentHelper;
            _componentName = GetType().UnderlyingSystemType.Name;
        }
        private string GetControllerName()
        {
            return Regex.Replace(ControllerName, "Controller$", string.Empty);
        }
        
        public MvcHtmlString Render(object model, RouteValueDictionary options)
        {
            return Render(string.Empty, model, options);
        }

        public MvcHtmlString Render(string viewPath, object model, RouteValueDictionary options)
        {
            var routeOptions = options ?? Options;
            routeOptions.Remove(ComponentConstants.ModelKey);
            routeOptions.Add(ComponentConstants.ModelKey, model);
            routeOptions.Add(ComponentConstants.ComponentKey, _componentName);
            routeOptions[ComponentConstants.ViewPathKey] = viewPath;
            
            return _htmlHelper.Action(RenderAction, GetControllerName(), routeOptions);
        }

        public virtual MvcHtmlString Render()
        {
            return Render(string.Empty, GetViewModel(), Options);
        }
        
        
        public abstract object GetViewModel();

        public void SetHtmlHelper(HtmlHelper helper)
        {
            _htmlHelper = helper;
        }

        public void SetPublishedContent(IPublishedContent content)
        {
            _content = content;
        }

        public void SetRouteOptions(RouteValueDictionary options)
        {
            _options = options;
        }
    }
}

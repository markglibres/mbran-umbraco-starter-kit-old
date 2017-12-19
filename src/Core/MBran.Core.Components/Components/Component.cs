using Humanizer;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public abstract class Component : IComponent, IComponentRender
    {
        private readonly string _componentName;
        public virtual string Name => _componentName.Humanize();
        private string RenderAction => nameof(IComponentController.RenderModel);
        private string ControllerName => nameof(ComponentsController);
        private HtmlHelper _htmlHelper;
        public IPublishedContent PublishedContent => _pageHelper.CurrentPage();
        
        private readonly IPageHelper _pageHelper;

        protected Component(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
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
            var routeOptions = options ?? new RouteValueDictionary();
            routeOptions.Remove(ComponentConstants.ModelKey);
            routeOptions.Add(ComponentConstants.ModelKey, model);
            routeOptions.Add(ComponentConstants.ComponentKey, _componentName);
            routeOptions[ComponentConstants.ViewPathKey] = viewPath;
            
            return _htmlHelper.Action(RenderAction, GetControllerName(), routeOptions);
        }

        public virtual MvcHtmlString Render()
        {
            return Render(string.Empty, GetViewModel(), GetOptions());
        }

        public virtual RouteValueDictionary GetOptions()
        {
            return new RouteValueDictionary();
        }
        
        public abstract object GetViewModel();

        public void SetHtmlHelper(HtmlHelper helper)
        {
            _htmlHelper = helper;
        }
    }
}

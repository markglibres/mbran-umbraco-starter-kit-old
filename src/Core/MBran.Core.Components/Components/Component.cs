using Humanizer;
using System;
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

        public Component(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
            _componentName = this.GetType().UnderlyingSystemType.Name;
        }
        private string GetControllerName()
        {
            return Regex.Replace(ControllerName, "Controller$", String.Empty);
        }
        
        public MvcHtmlString Render(object model, RouteValueDictionary options)
        {
            return Render(String.Empty, model, options);
        }

        public MvcHtmlString Render(string viewPath, object model, RouteValueDictionary options)
        {
            var _options = options ?? new RouteValueDictionary();
            _options.Remove(ComponentConstants.MODEL_KEY);
            _options.Add(ComponentConstants.MODEL_KEY, model);
            _options.Add(ComponentConstants.COMPONENT_KEY, _componentName);
            _options[ComponentConstants.VIEW_PATH_KEY] = viewPath;
            
            return _htmlHelper.Action(RenderAction, GetControllerName(), _options);
        }

        public virtual MvcHtmlString Render()
        {
            return Render(String.Empty, GetModel(), GetOptions());
        }

        public virtual RouteValueDictionary GetOptions()
        {
            return new RouteValueDictionary();
        }
        
        public abstract object GetModel();

        public void SetHtmlHelper(HtmlHelper helper)
        {
            _htmlHelper = helper;
        }
    }
}

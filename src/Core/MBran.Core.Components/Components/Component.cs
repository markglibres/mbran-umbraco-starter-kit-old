using Humanizer;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MBran.Core.Components
{
    public abstract class Component<T> : IComponent, IComponentRender
        where T: IComponentController
    {
        private readonly string _componentName;
        private readonly HtmlHelper _htmlHelper;
        public virtual string Name => _componentName.Humanize();
        public virtual string RenderAction => nameof(IComponentController.RenderModel);

        public Component(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
            _componentName = this.GetType().UnderlyingSystemType.Name;
        }
        private string GetControllerName()
        {
            string controllerName = typeof(T).Name;
            controllerName = Regex.Replace(controllerName, "Controller$", String.Empty);
            return controllerName;
        }
        
        public virtual MvcHtmlString Render(object model, RouteValueDictionary options)
        {
            return Render(String.Empty, model, options);
        }

        public MvcHtmlString Render(string viewPath, object model, RouteValueDictionary options)
        {
            var _options = options ?? new RouteValueDictionary();
            _options.Remove("model");
            _options.Add("model", model);
            _options[ComponentConstants.VIEW_PATH_KEY] = viewPath;
            
            return _htmlHelper.Action(RenderAction, GetControllerName(), _options);
        }
    }
}

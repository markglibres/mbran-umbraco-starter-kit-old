using Humanizer;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MBran.Umbraco.Components
{
    public abstract class Component<T> : IComponent, IComponentRender
        where T: IComponentController
    {
        private readonly string _componentName;
        private readonly HtmlHelper _htmlHelper;
        public virtual string Name => _componentName.Humanize();
        
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
        private string GetActionName()
        {
            string actionName = GetControllerName();
            actionName = Regex.Replace(actionName, "Surface$", String.Empty);
            return actionName;
        }

        public virtual MvcHtmlString Render(object model, RouteValueDictionary options)
        {
            string actionName = GetActionName();
            if (model != null)
            {
                actionName = nameof(ComponentSurfaceController.RenderModel);
            }
            return Render(actionName, model, options);
        }

        public MvcHtmlString Render(string actionName, object model, RouteValueDictionary options)
        {
            var _options = options ?? new RouteValueDictionary();
            _options.Remove("model");
            _options.Add("model", model);

            return _htmlHelper.Action(actionName, GetControllerName(), _options);
        }
    }
}

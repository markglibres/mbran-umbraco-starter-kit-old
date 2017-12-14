﻿using Humanizer;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Umbraco.Core.Models;

namespace MBran.Core.Components
{
    public abstract class Component<T> : IComponent, IComponentRender
        where T: Controller, IComponentController
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
            return Render(RenderAction, model, options);
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

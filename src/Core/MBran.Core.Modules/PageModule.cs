using Humanizer;
using MBran.Core.Modules.Controllers;
using MBran.Core.Modules.Models;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Umbraco.Core.Models;

namespace MBran.Core.Modules
{
    public abstract class PageModule : IPageModule
    {
        private readonly string _moduleName;
        public string Name => _moduleName.Humanize(); 
        private IPublishedContent _content;
        public IPublishedContent PublishedContent => _content ?? _contentHelper.CurrentPage();
        private RouteValueDictionary _options;
        public RouteValueDictionary Options => _options ?? new RouteValueDictionary();
        public string ControllerName => Regex.Replace(nameof(ModulesController), "Controller$", string.Empty);
        public string RenderAction => nameof(IModuleController.RenderModel);
        private readonly IContentHelper _contentHelper;
        private HtmlHelper _htmlHelper;

        protected PageModule(IContentHelper contentHelper)
        {
            _contentHelper = contentHelper;
            _moduleName = GetType().UnderlyingSystemType.Name;
        }

        public abstract IPageModuleModel GetModel();

        public MvcHtmlString Render(object model, RouteValueDictionary options)
        {
            throw new NotImplementedException();
        }

        public MvcHtmlString Render(string viewPath, object model, RouteValueDictionary options)
        {
            var routeOptions = options ?? Options;
            routeOptions.Remove(ModuleConstants.ModelKey);
            routeOptions.Add(ModuleConstants.ModelKey, model);
            routeOptions.Add(ModuleConstants.ModuleKey, _moduleName);
            routeOptions[ModuleConstants.ViewPathKey] = viewPath;

            return _htmlHelper.Action(RenderAction, ControllerName, routeOptions);
        }
        

        public MvcHtmlString Render()
        {
            return Render(string.Empty, GetModel(), Options);
        }

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
